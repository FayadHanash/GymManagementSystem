using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GymManagementSystemBLL;

namespace GymManagementSystem
{
    /// <summary>
    /// Interaction logic for GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        #region Fields
        /// <summary>
        /// array of IManger interface that contains objects of the trainer manager and the member manager
        /// </summary>
        IManager[] manager;
        /// <summary>
        /// to controll if all data added successfully
        /// </summary>
        bool closeWindow = false;

        /// <summary>
        /// declare group of Group class
        /// </summary>
        Group group;

        /// <summary>
        /// A predicate that shows error messages to the user and always returns false
        /// </summary>
        Predicate<string> Errors = ShowErrors;
        
        #endregion Fields
        
        #region Properties
        /// <summary>
        ///Propertie related to close window
        /// just read access
        /// </summary>
        public bool CloseWindow => closeWindow;

        /// <summary>
        /// Property related to group field
        /// just read access
        /// </summary>
        public Group Groupdata => group;

        #endregion Properties

        #region Constructors
        /// <summary>
        /// Constructor with one parameter 
        /// Creates an instance of Group object and sets the parameter as a referance to the manager field  
        /// Calls InitializeGUI and InitializeToolTip methods
        /// </summary>
        /// <param name="manager"></param>
        public GroupWindow(ref IManager[] manager)
        {
            InitializeComponent();
            group = new Group();
            this.manager = manager;
            InitializeGUI();
            InitializeToolTip();
        }

        /// <summary>
        /// Constructor with two parameters 
        /// Sets the first parameter as a reference to group object and sets the second parameter as a referance to the manager field  
        /// Calls InitializeGUI and InitializeToolTip methods
        /// </summary>
        /// <param name="group"></param>
        /// <param name="manager"></param>
        public GroupWindow(Group group, ref IManager[] manager)
        {
            this.group = group;
            this.manager = manager;
            InitializeComponent();
            InitializeGUIForEdit();
            InitializeToolTip();
        }

        #endregion Constructors
        
        #region Methods
        /// <summary>
        /// Method that justifies GUI depending on the object
        /// Fills the text boxes and comboboxes with date which sended as parameter in the constructor
        /// this method is used when a group data needs to change / edit
        /// </summary>
        private void InitializeGUIForEdit()
        {
            cmbSelectGroup.ItemsSource = Enum.GetNames(typeof(GroupTrainingTypes));
            cmbDuration.ItemsSource = Helper.SetDuration();
            cmbDate.ItemsSource = Helper.SetDaysAndDate();
            cmbTime.ItemsSource = Helper.SetTime();
            InitializeSelectTrainerCombobox();
            cmbSelectGroup.SelectedIndex = cmbSelectGroup.Items.IndexOf(group.GroupName);
            cmbDuration.SelectedIndex = cmbDuration.Items.IndexOf(group.Duration);
            cmbTime.SelectedIndex = cmbTime.Items.IndexOf(group.Time);
            cmbDate.SelectedIndex = cmbDate.Items.IndexOf(group.Date);
            foreach (var item in cmbSelectTrainer.Items)
            {
                Trainer trainer = (Trainer)item;
                if (group.Trainer.Id == trainer.Id)
                {
                    cmbSelectTrainer.SelectedIndex = cmbSelectTrainer.Items.IndexOf(item);
                    break;
                }
            }
            txtDescription.Text = group.Description;
            lstSelectedMembers.Items.Clear();
            for (int i = 0; i < group.Members.Count; i++)
            {
                lstSelectedMembers.Items.Add(group.Members[i]);
            }
            InitializeSelectMembersComboboxForEdit();
            MangeButtons();
        }

        /// <summary>
        /// Method that displays a help text when the mouse over- combobox and buttons ok and Cancel buttons
        /// </summary>

        private void InitializeToolTip()
        {
            btnCreateGroup.ToolTip = Common.NewToolTip("click this button to create a group.");
            btnCancel.ToolTip = Common.NewToolTip("click this button to cancel");
            btnRemoveMemberFromlst.ToolTip = Common.NewToolTip("click an item in the list to remove an item");
            txtDescription.ToolTip = Common.NewToolTip("here you can descripe the group");
            cmbTime.ToolTip = Common.NewToolTip("Select a time");
            cmbDate.ToolTip = Common.NewToolTip("select a date and day");
            cmbDuration.ToolTip = Common.NewToolTip("select a duration");
            cmbSelectGroup.ToolTip = Common.NewToolTip("Select a group");
            cmbSelectTrainer.ToolTip = Common.NewToolTip("select a trainer");
            cmbSelectMember.ToolTip = Common.NewToolTip("Select mambers to add in the list");
        }
        
        /// <summary>
        /// Method that initializes the GUI by:
        /// Calling MangeButtons,SetDuration,SetDaysAndDate,
        ///  SetTime, InitializeSelectMembersCombobox and InitializeSelectTrainerCombobox methods
        /// </summary>
        void InitializeGUI()
        {
            this.Owner = Application.Current.MainWindow;
            MangeButtons();
            cmbSelectGroup.ItemsSource = Enum.GetNames(typeof(GroupTrainingTypes));
            cmbDuration.ItemsSource = Helper.SetDuration();
            cmbDate.ItemsSource = Helper.SetDaysAndDate();
            cmbTime.ItemsSource = Helper.SetTime();
            InitializeSelectMembersCombobox();
            InitializeSelectTrainerCombobox();
        }

        /// <summary>
        /// Method that displays error messages to the user and returns false
        /// </summary>
        /// <param name="msg">the message</param>
        /// <returns>false</returns>
        private static bool ShowErrors(string msg)
        {
            MsgBox.Show(msg, "Error");
            return false;
        }

        /// <summary>
        /// Method that manages the removeItem button
        /// </summary>
        private void MangeButtons() 
        {
            if (lstSelectedMembers.Items.Count <= 0)
                btnRemoveMemberFromlst.IsEnabled = false;
            else
                btnRemoveMemberFromlst.IsEnabled = true;
        }

        /// <summary>
        /// Method initializes select members's combo box 
        /// creates a list of all members that are registerd in combobox
        /// </summary>
        public void InitializeSelectMembersCombobox()
        {
            MemberManager memberMgr = (MemberManager)manager[0];
            List<Member> members = new List<Member>();
            memberMgr.List.ForEach(m => members.Add(m));
            members.ForEach(m => cmbSelectMember.Items.Add(m));
        }

        /// <summary>
        /// Method that initializes select members combo box when a group needs to be changd
        /// compares between two lists and adds the diffrence between them to comboboxes
        /// the first list is members that registered 
        /// the second list is the members that is already the client has selected and added to list box 
        /// then compares and adds the members that is not alreedy selected to combobox
        /// </summary>
        public void InitializeSelectMembersComboboxForEdit()
        {
            MemberManager memberMgr = (MemberManager)manager[0];
            List<Member> membersList = new List<Member>();
            memberMgr.List.ForEach(x => membersList.Add(x));
            List<Member> membersJoindList = new List<Member>();
            group.Members.ForEach(x => membersJoindList.Add(x));
            List<Member> result = membersList.Where(x=> !membersJoindList.Any(y => y.Id == x.Id)).ToList();
            cmbSelectMember.Items.Clear();
            result.ForEach(x => cmbSelectMember.Items.Add(x));
        }

        /// <summary>
        /// Method that initializes select trainer's combo box 
        /// creates a array of all trainers that are registerd in combobox
        /// </summary>
        public void InitializeSelectTrainerCombobox()
        {
            TrainerManager trainerMgr = (TrainerManager)manager[1];
            List<Trainer> trainers = new List<Trainer>();
            trainerMgr.List.ForEach(x => trainers.Add(x));
            cmbSelectTrainer.Items.Clear();
            trainers.ForEach(x => { cmbSelectTrainer.Items.Add(x); });
        }

        /// <summary>
        /// Method that removes the member from selected list box
        /// then adds the removed item to combobox again
        /// calls MangeButtons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveMemberFromlst_Click(object sender, RoutedEventArgs e)
        {
            int index = lstSelectedMembers.SelectedIndex;
            if (index >= 0)
            {
                var selectedItem = lstSelectedMembers.SelectedItem;
                lstSelectedMembers.Items.RemoveAt(index);
                cmbSelectMember.Items.Add(selectedItem);
                MangeButtons();
            }
            else
                MsgBox.Show("You have to select a member", "ERROR");
        }

        /// <summary>
        /// Method that gets all inputs 
        /// makes sure if all inputs are correct and not empty by calling other validate methods 
        /// </summary>
        /// <returns>true if all inputs is given, otherwise false </returns>
        private bool GetInputs() => !ValidateComboBoxes(cmbSelectGroup.SelectedIndex, "The group name should be selected") ? false 
            : !ValidateComboBoxes(cmbSelectTrainer.SelectedIndex, "The group trainer should be selected") ? false 
            : !ValidateAddedMembers() ? false 
            : !ValidateComboBoxes(cmbDuration.SelectedIndex, "The group duration should be selected") ? false 
            : !ValidateComboBoxes(cmbTime.SelectedIndex, "The time should be selected") ? false 
            : !ValidateComboBoxes(cmbDate.SelectedIndex, "The date should be selected") ? false 
            : !ValidateText(txtDescription.Text, "The description should be angiven") ? false 
            : true;


        /// <summary>
        /// Method that ensures if a members is added (selected/joined) to a group
        /// </summary>
        /// <returns>true if added, otherwise false</returns>
        private bool ValidateAddedMembers() => lstSelectedMembers.Items.Count > 0 ? true : Errors("You have to add members");

        /// <summary>
        /// Method that validates if a combo box is selected or not
        /// </summary>
        /// <param name="index"> index og combobox to control</param>
        /// <param name="err">error message</param>
        /// <returns>true or false</returns>
        private bool ValidateComboBoxes(int index, string err) => index == -1 ? Errors(err) : true;

        /// <summary>
        /// Method that controls text boxes 
        /// </summary>
        /// <param name="text">text input to be controlled </param>
        /// <param name="errMessage">errer meeage</param>
        /// <returns>true or false</returns>
        private bool ValidateText(string text, string errMessage) => String.IsNullOrEmpty(text.Trim()) ? Errors(errMessage) : true;

        /// <summary>
        /// Method that creates the group if getInputs return true which is all inputs are specified
        /// </summary>
        /// <returns>true if the group created</returns>
        private bool CheckInputs()
        {
            if (GetInputs())
            {
                group.GroupName = cmbSelectGroup.Text;
                group.Trainer = (Trainer)cmbSelectTrainer.SelectedItem;
                group.Members = new List<Member>();
                group.Members = GetAddedMembersFromListBox();
                group.Duration = cmbDuration.Text;
                group.Time = cmbTime.Text;
                group.Date = cmbDate.Text;
                group.Description = txtDescription.Text;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method that gets members that have been added to list box
        /// </summary>
        /// <returns> en array of members</returns>
        private List<Member> GetAddedMembersFromListBox()
        {
            List<Member> lst = new List<Member>();
            foreach (var item in lstSelectedMembers.Items)
            {
                lst.Add((Member)item);
            }
            return lst;
        }

        /// <summary>
        /// Method that creates a group 
        /// then CheckInput method is called to create a group
        /// if CheckInput method returend true then creates an instance of ConfirmInputsGroupWindow 
        /// ConfirmInputsGroupWindow shows a dialog(new window) with all given inpust, 
        /// it is just for double check for the client to ensure that all selecteed values is correct.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateGroup_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputs())
            {
                ConfirmGroupWindow confirmGroup = new ConfirmGroupWindow(group);
                confirmGroup.ShowDialog();
                confirmGroup.Title = "Double check your data";
                if (confirmGroup.CloseWindow == true)
                {
                    closeWindow = true;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Method that closes the window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// An event handle method that calls, every time a member is selected
        /// gets the index from selected value and removes from combobox and adds it to list box
        /// calls MangeButtons method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSelectMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMembers = cmbSelectMember.SelectedItem;
            int selectedI = -1;
            selectedI = cmbSelectMember.Items.IndexOf(selectedMembers);
            if (selectedI >= 0)
            {
                cmbSelectMember.Items.RemoveAt(selectedI);
                lstSelectedMembers.Items.Add(selectedMembers);
                MangeButtons();
            }
        }

        #endregion Methods
    }
}
