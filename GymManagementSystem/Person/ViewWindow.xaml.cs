using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GymManagementSystemBLL;
namespace GymManagementSystem
{
    /// <summary>
    /// Interaction logic for ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {

        #region Fields
        /// <summary>
        /// array of managers
        /// </summary>

        IManager[] manager;

        /// <summary>
        /// member manager
        /// </summary>
        
        MemberManager memberMgr;

        /// <summary>
        /// trainer manager
        /// </summary>
        
        TrainerManager trainerMgr;


        #endregion Fields

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// Calls InitializeGUI and InitializeToolTip
        /// </summary>
        public ViewWindow()
        {
            InitializeComponent();
            InitializeGUI();
            InitializeToolTip();
        }

        /// <summary>
        /// Constructor with one parameter
        /// calls InitializeGUI method
        /// Sets the coming parameter as reference to the manager object
        /// </summary>
        /// <param name="manager"></param>
        public ViewWindow(ref IManager[] manager)
        {
            InitializeComponent();
            InitializeGUI();
            this.manager = manager;
            memberMgr = (MemberManager)manager[0];
            trainerMgr = (TrainerManager)manager[1];
            UpdatMembersList();
            UpdatTrainersList();
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// Method that initializes the GUI
        /// calls UpdatMembersList, UpdatTrainersList and InitializeToolTip methods
        /// </summary>
        void InitializeGUI()
        {
            this.Owner = Application.Current.MainWindow;
            InitializeToolTip();
        }

        /// <summary>
        /// Method that displays a help text when the mouse over- Edit,Delete and CloseWindow buttons
        /// </summary>
        private void InitializeToolTip()
        {
            btnEditMember.ToolTip = Common.NewToolTip("Select a mamber, then click this button to edit.");
            btnDeleteMember.ToolTip = Common.NewToolTip("Select a mamber, then click this button to delete.");
            btnCloseMember.ToolTip = Common.NewToolTip("click this button to close this window.");
            btnEditTrainer.ToolTip = Common.NewToolTip("Select a trainer, then click this button to edit.");
            btnDeleteTrainer.ToolTip = Common.NewToolTip("Select a trainer, then click this button to delete.");
            btnCloseTrainer.ToolTip = Common.NewToolTip("click this button to close this window.");
        }

        /// <summary>
        /// Method updates the member list
        /// empty the label and list box
        /// calls MangeButtons method
        /// </summary>
        private void UpdatMembersList()
        {
            lblMemberDetails.Text = String.Empty;
            lstMembers.ItemsSource = null;
            lstMembers.Items.Clear();
            memberMgr.List.ForEach(x=> 
            {
                lstMembers.Items.Add(x);
            });
            MangeButtons();
        }

        /// <summary>
        /// Method updates the trainer list
        /// empty the label and list box
        /// calls mangeButtons method
        /// </summary>
        private void UpdatTrainersList()
        {
            lblTrainerDetails.Text = String.Empty;
            lstTrainers.ItemsSource = null;
            lstTrainers.Items.Clear();
            lstTrainers.ItemsSource = trainerMgr.List;
            MangeButtons();
        }

        /// <summary>
        /// Method that manages the buttons
        /// </summary>
        private void MangeButtons()
        {
            if (memberMgr.Count <= 0)
            {
                btnEditMember.IsEnabled = false;
                btnDeleteMember.IsEnabled = false;
            }
            else
            {
                btnEditMember.IsEnabled = true;
                btnDeleteMember.IsEnabled = true;

            }
            if (trainerMgr.Count <= 0)
            {
                btnEditTrainer.IsEnabled = false;
                btnDeleteTrainer.IsEnabled = false;
            }
            else
            {
                btnEditTrainer.IsEnabled = true;
                btnDeleteTrainer.IsEnabled = true;

            }
        }

        /// <summary>
        /// Method that edits a member data 
        /// Creates an instance of RegisterWindow by sending the selected item (object) to edit
        /// Shows the dialogto change data
        /// if ok button is clicked in the RegisterWindow then changes the data, then updates the member list,otherwise displays error message
        /// </summary>
        private void btnEditMember_Click(object sender, RoutedEventArgs e)
        {
            int index = lstMembers.SelectedIndex;
            if (index >= 0)
            {
                RegisterWindow memberWindow = new RegisterWindow(memberMgr.GetAt(index), true);
                memberWindow.Title = "Edit member";
                memberWindow.Show();
                memberWindow.CloseRegisterWindow += (x) =>
                {
                    if (x)
                    {
                        memberMgr.Update((Member)memberWindow.Person);
                        UpdatMembersList();
                    }
                };
            }
            else
                MsgBox.Show("You have to select a member", "Error");
        }

        /// <summary>
        /// Method that closes the window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseMember_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method that edits a trainer data 
        /// Creates an instance of RegisterWindow by sending the selected item (object) to edit
        /// Shows the dialogto change data
        /// if ok button is clicked in the RegisterWindow then changes the data, then updates the trainer list,otherwise displays error message
        /// </summary>

        private void btnEditTrainer_Click(object sender, RoutedEventArgs e)
        {
            int index = lstTrainers.SelectedIndex;
            if (index >= 0)
            {
                RegisterWindow trainerWindow = new RegisterWindow(trainerMgr.GetAt(index), false);
                trainerWindow.Title = "Edit trainer";
                trainerWindow.Show();
                trainerWindow.CloseRegisterWindow += (x) =>
                {
                    if (x)
                    {
                        trainerMgr.Update((Trainer)trainerWindow.Person);
                        UpdatTrainersList();
                    }
                };
            }
            else
                MsgBox.Show("You have to select a trainer", "Error");
        }

        /// <summary>
        /// Method that closes the window 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseTrainer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method that deletes a member in the members list 
        /// If the data has been deleted then calls method that updates UpdateMembersList, otherwise displays error message
        /// </summary>
        private void btnDeleteMember_Click(object sender, RoutedEventArgs e)
        {
            int index = lstMembers.SelectedIndex;
            if (index >= 0)
            {
                Member member = memberMgr.GetAt(index);
                memberMgr.Delete(member,member.Id);
                UpdatMembersList();
            }
            else
            {
                MsgBox.Show("You have to select a member", "ERROR");
            }
        }

        /// <summary>
        /// Method that deletes a trainer in the trainers list 
        /// If the data has been deleted then calls method that updates UpdateTrainersList, otherwise displays error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteTrainer_Click(object sender, RoutedEventArgs e)
        {
            int index = lstTrainers.SelectedIndex;
            if (index >= 0)
            {
                Trainer trainer = trainerMgr.GetAt(index);
                trainerMgr.Delete(trainer,trainer.Id);
                UpdatTrainersList();
            }
            else
            {
                MsgBox.Show("You have to select a trainer", "ERROR");
            }
        }

        /// <summary>
        /// Methods that shows more information about the selected trainer when an item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstTrainers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstTrainers.SelectedIndex;
            if (index >= 0)
            {
                lblTrainerDetails.Text = trainerMgr.GetAt(index).GetInfo();
            }
        }

        /// <summary>
        /// Methods that shows more information about the selected member when an item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstMembers.SelectedIndex;
            if (index >= 0)
            {
                lblMemberDetails.Text = memberMgr.GetAt(index).GetInfo();
            }
        }

        /// <summary>
        /// Method that sorts the list view according to selected columnHeader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstMembersGridViewCloumnHeader_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedColumn = (e.OriginalSource as GridViewColumnHeader).Column.Header.ToString();
                switch (selectedColumn)
                {
                    case "Person Number":
                        memberMgr.Sort(new MemberPersonNumberSorter());
                        UpdatMembersList();
                        break;
                    case "Name":
                        memberMgr.Sort(new MemberNameSorter());
                        UpdatMembersList();
                        break;
                    case "Phone":
                        memberMgr.Sort(new MemberPhoneSorter());
                        UpdatMembersList();
                        break;
                    case "Email":
                        memberMgr.Sort(new MemberEmailSorter());
                        UpdatMembersList();
                        break;
                    default:
                        UpdatMembersList();
                        break;
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Method that sorts the list view according to selected columnHeader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstTrainersGridColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedColumn = (e.OriginalSource as GridViewColumnHeader).Column.Header.ToString();
                switch (selectedColumn)
                {
                    case "Person Number":
                        trainerMgr.Sort(new TrainerPersonNumberSorter());
                        UpdatTrainersList();
                        break;
                    case "Name":
                        trainerMgr.Sort(new TrainerNameSorter());
                        UpdatTrainersList();
                        break;
                    case "Phone":
                        trainerMgr.Sort(new TrainerPhoneSorter());
                        UpdatTrainersList();
                        break;
                    case "Email":
                        trainerMgr.Sort(new TrainerEmailSorter());
                        UpdatTrainersList();
                        break;
                    default:
                        UpdatTrainersList();
                        break;
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion Methods
    }
}
