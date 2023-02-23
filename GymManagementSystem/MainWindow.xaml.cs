using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using GymManagementSystemBLL;

// ©  2023 By Fayad Al Hanash
namespace GymManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        /// <summary>
        /// Creates an array of IManager.
        /// </summary>
        IManager[] manager = new IManager[2];
        /// <summary>
        /// declare groupMgr
        /// </summary>
        GroupManager groupMgr;
        /// <summary>
        /// declare memberMgr
        /// </summary>
        MemberManager memberMgr;
        /// <summary>
        /// declare trainerMgr
        /// </summary>
        TrainerManager trainerMgr;
        /// <summary>
        /// number that used to print to document // x refers to selected item in listbox
        /// </summary>
        int x = -1;
        /// <summary>
        /// file name
        /// </summary>
        private string fileName = String.Empty;
        /// <summary>
        /// string will be used to filter text files (extension)
        /// </summary>
        const string textExtension = "Text Files (*.txt)|*.txt";
        /// <summary>
        /// string will be used to filter binary files (extension)
        /// </summary>
        const string binaryExtension = "Binary Files (*.bin)|*.bin";
        /// <summary>
        /// string will be used to filter xml files (extension)
        /// </summary>
        const string xmlExtension = "XML Files (*.xml)|*.xml";
        /// <summary>
        /// string will be used to filter text,binary and xml files (extension)
        /// </summary>
        const string AllExtension = "Binary Files (*.bin)|*.bin|XML Files (*.xml)|*.xml|Text Files (*.txt)|*.txt";

        #endregion Fields

        #region Constructor
        /// <summary>
        /// Default constructor
        /// calls initializeGUI method
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();

        }
        #endregion Constructor
        
        #region Methods
        /// <summary>
        /// Method that initializes the GUI.
        /// Creates instances of Member,Trainer and Group manger
        /// Fills the manager array with the instances 
        /// Empties listboxes, labels
        /// Calls TimerDispatcher to set time dispatcher
        /// Calls UpdateGUI and InitializeToolTip methods
        /// </summary>
        void InitializeGUI()
        {
            TimerDispatcher();
            memberMgr = new MemberManager();
            trainerMgr = new TrainerManager();
            groupMgr = new GroupManager();
            manager[0] = memberMgr;
            manager[1] = trainerMgr;
            //TestMember();
            //TestTrainer();
            lstGroups.Items.Clear();
            lstJoinedMembers.Items.Clear();
            lblResponsibleTrainer.Content = String.Empty;
            lblNumOfJoinedMembers.Content = String.Empty;
            lblGroupCount.Content = String.Empty;
            lblMembersCount.Content = String.Empty;
            lblTrainerCount.Content = String.Empty;
            lblDoubleClick.Content = "Click on an item for see members and trainer, or double click for group description";
            UpdateGUI();
            InitializeToolTip();
        }

        /// <summary>
        /// Method that creates a timer
        /// </summary>
        void TimerDispatcher()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        /// <summary>
        /// Method that displays time in ShowTime label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e) =>
            lblShowtime.Content = $"{DateTime.Now.ToLongDateString()}\n{DateTime.Now.ToLongTimeString()}";

        /// <summary>
        /// Method that adds members, used to testing
        /// </summary>
        public void TestMember()
        {
            DateTime dateTime = DateTime.Now;

            for (int i = 1; i < 20; i++)
            {
                
                memberMgr.Add(new Member()
                {
                    FirstName = $"Member {i}",
                    LastName = $"Member {i}",
                    PersonNumber = $"123456789{i}",
                    Gender = Gender.Man,
                    BirthDate = "10/6/2022",
                    Email = $"member{i}@gmail.com",
                    Phone = $"07699999{i}",
                    Address = new Address()
                    {
                        Street = $"address {i}",
                        ZipCode = $"1234{i}",
                        City = $"city {i}",
                        Country = Countries.Sverige
                    },
                    DateRegistered = dateTime
                });
            }

        }
        /// <summary>
        /// method that adds trainer, used to testing
        /// </summary>
        public void TestTrainer()
        {
            DateTime dateTime = DateTime.Now;

            for (int i = 1; i < 10; i++)
            {
                trainerMgr.Add(new Trainer()
                {
                    FirstName = $"Trainer {i}",
                    LastName = $"Trainer {i}",
                    PersonNumber = $"123456789{i}",
                    Gender = Gender.Man,
                    BirthDate = "10/6/2022",
                    Email = $"Trainer{i}@gmail.com",
                    Phone = $"07699999{i}",
                    Address = new Address()
                    {
                        Street = $"address {i}",
                        ZipCode = $"1234{i}",
                        City = $"city {i}",
                        Country = Countries.Sverige
                    },
                    DateRegistered = dateTime
                });
            }

        }


        /// <summary>
        /// Method that manages the buttons
        /// </summary>
        public void MangeButtons()
        {
            int memberListCount = memberMgr.Count;
            int trainerListCount = trainerMgr.Count;
            int groupListCount = groupMgr.Count;
            if (memberListCount <= 0 && trainerListCount <= 0)
                btnEdit.IsEnabled = false;
            else
                btnEdit.IsEnabled = true;

            if (groupListCount <= 0)
            {
                btnEditGroup.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnClear.IsEnabled = false;
                lblDoubleClick.Visibility = Visibility.Hidden;
            }
            else
            {
                btnEditGroup.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnClear.IsEnabled = true;
                lblDoubleClick.Visibility = Visibility.Visible;
            }

            if (memberListCount <= 0 && trainerListCount <= 0)
                btnCreate.IsEnabled = false;
            else if (memberListCount <= 0 && trainerListCount > 0)
                btnCreate.IsEnabled = false;
            else if (trainerListCount <= 0 && memberListCount > 0)
                btnCreate.IsEnabled = false;
            else
                btnCreate.IsEnabled = true;

            if(groupMgr.IsGroupLoadedFromDB)
            {
                menuSaveToDB.IsEnabled = false;
                menuOpenDB.IsEnabled = false;
            }
            else
            {
                menuSaveToDB.IsEnabled = true;
                menuOpenDB.IsEnabled = true;
            }
        }

        /// <summary>
        /// Method that displays a help text when the mouse over- comboboxs,buttons and labels
        /// </summary>
        private void InitializeToolTip()
        {
            btnAdd.ToolTip = Common.NewToolTip("Add a new member or trainer");
            btnEdit.ToolTip = Common.NewToolTip
                (
                  "click this button to see or edit the current registered members/trainers.\n"+
                  "The button will navigates you to another window"
                ) ;
            btnCreate.ToolTip = Common.NewToolTip("click this button to create a new group.\nThe button will navigates you to another window");
            btnEditGroup.ToolTip = Common.NewToolTip("First select an item and then click this buttom to edit a group.\nThe button will navigates you to another window");
            btnDelete.ToolTip = Common.NewToolTip("Select an item in the list and then click this button to delete a group");
            btnClear.ToolTip = Common.NewToolTip("click this button to remove highlight on selected item in group list");
            lstGroups.ToolTip = Common.NewToolTip
                (
                  "Select a item to show more information obout joind members \nand responsible trainer for the group\n" +
                  "Double click an item to show description obout selected item"
                );
            lblMembersCount.ToolTip = Common.NewToolTip("Number of registered members");
            lblTrainerCount.ToolTip = Common.NewToolTip("Number of registered trainer");
            lblGroupCount.ToolTip = Common.NewToolTip("Number of created group");
            lblNumOfJoinedMembers.ToolTip = Common.NewToolTip("Number of joined members in the group");
        }

        /// <summary>
        /// Method that updates the GUI
        /// Calls MangeButtons 
        /// disenble group box and Updates count labels 
        /// </summary>
        public void UpdateGUI()
        {
            grpJoinedTrainerAndMembers.IsEnabled = false;
            grpJoinedTrainerAndMembers.Visibility = Visibility.Hidden;
            lblGroupCount.Content = groupMgr.Count;
            lblMembersCount.Content = memberMgr.Count;
            lblTrainerCount.Content = trainerMgr.Count;
            MangeButtons();
            UpdateCreatedListGroup();
        }

        /// <summary>
        /// Method that updates the list box in main window
        /// </summary>
        private void UpdateCreatedListGroup()
        {
            lstGroups.Items.Clear();
            for (int i = 0; i < groupMgr.Count; i++)
                lstGroups.Items.Add(groupMgr.GetAt(i));
            lblResponsibleTrainer.Content = String.Empty;
            lstJoinedMembers.Items.Clear();
            lblNumOfJoinedMembers.Content = groupMgr.Count.ToString();
        }

        /// <summary>
        /// Method that uses to save data to right file according to file extension
        /// methods matches the comming file's extension then saves data to right file format(type), otherwise will cast throw Invalid File Extension exception
        /// if the data saves successfully then prompts a massege to confirm it
        /// </summary>
        /// <param name="fileNameStr"></param>
        void SaveData(string fileNameStr)
        {
            try
            {
                int lastDotPos = fileNameStr.LastIndexOf('.');
                if (lastDotPos > 0)
                {
                    string extension = fileNameStr.Substring(lastDotPos);
                    switch (extension)
                    {
                        case ".txt":
                            {
                                groupMgr.SaveToFile(fileNameStr);
                                MsgBox.Show(" Text File Saved");
                                break;
                            }
                        case ".bin":
                            {
                                groupMgr.BinarySerialize(fileNameStr);
                                MsgBox.Show("Binary File Saved");
                                break;
                            }
                        case ".xml":
                            {
                                groupMgr.XMLSerialize(fileNameStr);
                                MsgBox.Show("XML File Saved");
                                break;
                            }
                        default:
                            {
                                throw new Exception("Invalid File Extension");
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion Methods

        #region Events
        /// <summary>
        /// Method that adds a member or a trainer 
        /// Creates an instance of RegisterWindow and passes manager array as parameter
        /// Updates GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow regWindow = new RegisterWindow(ref manager);
            regWindow.Show();
            regWindow.CloseRegisterWindow += (x) =>
            {
                if (x)
                {
                    UpdateGUI();
                }
            };
        }
        /// <summary>
        /// Method that navigates to ViewWindow 
        /// Creates an instance of ViewWindow, then shows View window.
        /// Updates the GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ViewWindow editWindow = new ViewWindow(ref manager);
            editWindow.ShowDialog();
            UpdateGUI();
        }
        /// <summary>
        /// Method that creates a group
        /// Creates an instance of GroupWindow, then oppens GroupWindow to get inpus, if close window returns a true, 
        /// then the group will be created.
        /// Updates GUI and group list box, otherwise displayes error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            GroupWindow groupWindow = new GroupWindow(ref manager);
            groupWindow.Title = "Create a new training group";
            groupWindow.ShowDialog();
            if (groupWindow.CloseWindow == true)
            {
                groupWindow.Close();
                groupMgr.Add(groupWindow.Groupdata);
                UpdateCreatedListGroup();
                UpdateGUI();
            }
            else
                MsgBox.Show("No group added", "Error");
        }

        /// <summary>
        /// Method that Edits a group 
        /// Method creates a instance of GroupWindow and passes the selected object to be chenged
        /// if close window returns a true, then the group will be edited.
        /// Updates GUI and group list box, otherwise displayes error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (lstGroups.SelectedIndex >= 0)
            {
                GroupWindow groupWindow = new GroupWindow(groupMgr.GetAt(lstGroups.SelectedIndex), ref manager);
                groupWindow.Title = "Edit group";
                groupWindow.ShowDialog();
                if (groupWindow.CloseWindow == true)
                {
                    groupMgr.Update(groupWindow.Groupdata, lstGroups.SelectedIndex);
                    UpdateCreatedListGroup();
                    UpdateGUI();
                }
            }
            else
                MsgBox.Show("You need to select a item");
        }
        /// <summary>
        /// Method that deletes a selected group in the group list
        /// If the data has been deleted then updates GUI and groups list, otherwise displayes error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstGroups.SelectedIndex >= 0)
            {
                Group group = groupMgr.GetAt(lstGroups.SelectedIndex);
                groupMgr.Delete(group, lstGroups.SelectedIndex);
                UpdateCreatedListGroup();
                UpdateGUI();
            }
            else
                MsgBox.Show("You need to select a item");
        }

        /// <summary>
        /// Method that clears a selected item
        /// calls Updates GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (lstGroups.SelectedIndex >= 0)
            {
                lstGroups.SelectedIndex = -1;
                UpdateGUI();
            }
            else
                MsgBox.Show("You need to select a item");
        }

        /// <summary>
        /// Method that shows more information about the selected group like members that have been joind to the group and responsible trainer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstGroups.SelectedIndex >= 0)
            {
                x = lstGroups.SelectedIndex;
                grpJoinedTrainerAndMembers.IsEnabled = true;
                grpJoinedTrainerAndMembers.Visibility = Visibility.Visible;
                Group group = groupMgr.GetAt(lstGroups.SelectedIndex);
                lblResponsibleTrainer.Content = String.Empty;
                lstJoinedMembers.Items.Clear();
                lblResponsibleTrainer.Content = group.Trainer;
                for (int i = 0; i < group.Members.Count; i++)
                {
                    lstJoinedMembers.Items.Add(group.Members[i]);
                }
                lblNumOfJoinedMembers.Content = group.MembersCount().ToString();
            }
        }

        /// <summary>
        /// Method that shows description about the selected group.
        /// Doubleclick on the item, the description will be showed
        /// sets the selected index to x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstGroups_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstGroups.SelectedIndex >= 0)
            {
                (string des, string desName) = groupMgr.GetAt(lstGroups.SelectedIndex).ShowDescription();
                if (des != null)
                {
                    MsgBox.Show(des, desName);
                }
                x = lstGroups.SelectedIndex;
            }
        }

        /// <summary>
        /// Method that sorts the list view according to selected columnHeader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstGroups_GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedColumn = (e.OriginalSource as GridViewColumnHeader).Column.Header.ToString();
                switch (selectedColumn)
                {
                    case "Group":
                        groupMgr.Sort(new GroupSorter());
                        UpdateCreatedListGroup();
                        UpdateGUI();
                        break;
                    case "Day":
                        groupMgr.Sort(new DaySorter());
                        UpdateCreatedListGroup();
                        UpdateGUI();
                        break;
                    case "Time":
                        groupMgr.Sort(new TimeSorter());
                        UpdateCreatedListGroup();
                        UpdateGUI();
                        break;
                    case "Date":
                        groupMgr.Sort(new DateSorter());
                        UpdateCreatedListGroup();
                        UpdateGUI();
                        break;
                    case "Duration":
                        groupMgr.Sort(new DurationSorter());
                        UpdateCreatedListGroup();
                        UpdateGUI();
                        break;
                    default:
                        UpdateCreatedListGroup();
                        UpdateGUI();
                        break;
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion Events

        #region MenuEvents
        /// <summary>
        /// Method that reinitializes GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuNew_Click(object sender, RoutedEventArgs e)
        {
            if (MsgBox.Show("New program?", MessageBoxOption.OkAndCancel, "Warning"))
                InitializeGUI();
        }

        /// <summary>
        ///  Method that saves data to file, saves to the last opened file if the file name isn't empty otherwise calls 
        ///  SaveDialogAs method to select a file extension and calls SaveData method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(fileName))
                {
                    SaveData(fileName);
                }
                else
                {
                    fileName = FileUtility.SaveFileDialog(AllExtension, "Select a file type to save");
                    SaveData(fileName);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Method that prints data to file or to printer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPrint_Click(object sender, RoutedEventArgs e)
        {
            if (lstGroups.SelectedIndex >= 0 && x >= 0)
            {
                try
                {
                    Printer printer = new Printer(groupMgr.GetAt(x));
                    printer.Print();
                }
                catch (Exception ex)
                {
                    MsgBox.Show(ex.Message);
                }
            }
            else
                MsgBox.Show("Select the group that you need to print", "ERROR");
        }

        /// <summary>
        /// Method that exits the application and prompts a dialog to ensure exiting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            if (MsgBox.Show("Exit program?", MessageBoxOption.OkAndCancel, "Warning"))
                Application.Current.Shutdown();
        }

        /// <summary>
        /// Method that reads data from text file
        /// Method that prompts a dialog to select a text file to be opened
        /// if data have been read from file successfully then updates the gui 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenTextFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tempNmae = FileUtility.OpenFileDialog(textExtension, "Open Text File");
                if (!String.IsNullOrEmpty(tempNmae))
                {
                    fileName = tempNmae;
                    groupMgr.LoadFromFile(fileName);
                    UpdateCreatedListGroup();
                    UpdateGUI();
                    MsgBox.Show("Text File Loaded");
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Method that reads data from binary file
        /// Method that prompts a dialog to select a binary file to be opened
        /// if data have been read from file successfully then updates the gui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenBinaryFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tempName = FileUtility.OpenFileDialog(binaryExtension, "Open Binary File");
                if (!String.IsNullOrEmpty(tempName))
                {
                    fileName = tempName;
                    groupMgr.BinaryDeserialize(fileName);
                    UpdateCreatedListGroup();
                    UpdateGUI();
                    MsgBox.Show("Binary File Loaded");
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());

            }
        }

        /// <summary>
        /// Method that reads data from xml file 
        /// Method that prompts a dialog to select a xml file to be opened
        /// if data have been read from file successfully then updates the gui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenXmlFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string tempName = FileUtility.OpenFileDialog(xmlExtension, "Open XML File");
                if (!String.IsNullOrEmpty(tempName))
                {
                    fileName = tempName;
                    groupMgr.XMLDeserialize(fileName);
                    UpdateCreatedListGroup();
                    UpdateGUI();
                    MsgBox.Show("XML File Loaded");

                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Method that gets groups from local database
        /// Updates the group list and GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuOpenDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                groupMgr.IsGroupLoadedFromDB = true;
                groupMgr.UpdateList();
                UpdateCreatedListGroup();
                UpdateGUI();
                MsgBox.Show("Data loaded from Database");
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Method that saves data to a text file
        /// calls the SaveDialogAs method to give a name (perhaps path) for a file, then if name isn't empty
        /// calls changeFileExtension method to add .txt extension to the file name, then calls SaveData method to save data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSaveAsTextFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fileName = FileUtility.SaveFileDialog(textExtension, "Save as Text File");
                if (!String.IsNullOrEmpty(fileName))
                {
                    fileName = FileUtility.changeFileExtension(fileName, ".txt");
                    SaveData(fileName);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Method that saves data to a binary file 
        /// calls the SaveDialogAs method to give a name (perhaps phas) for a file, then if name isn't empty
        /// calls changeFileExtension method to add .bin extension to the file name, then calls SaveData method to save data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSaveAsBinaryFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fileName = FileUtility.SaveFileDialog(binaryExtension, "Save as Binary File");
                if (!String.IsNullOrEmpty(fileName))
                {
                    fileName = FileUtility.changeFileExtension(fileName, ".bin");
                    SaveData(fileName);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Method that saves data to a xml file 
        /// calls the SaveDialogAs method to give a name (perhaps location) for a file, then if name isn't empty
        /// calls changeFileExtension method to add .xml extension to the file name, then calls SaveData method to save data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSaveAsXmlFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fileName = FileUtility.SaveFileDialog(xmlExtension, "Save as xml File");
                if (!String.IsNullOrEmpty(fileName))
                {
                    fileName = FileUtility.changeFileExtension(fileName, ".xml");
                    SaveData(fileName);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Method that saves a selected group to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSaveToDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (groupMgr.IsGroupLoadedFromDB == false)
                {
                    if (lstGroups.SelectedIndex >= 0)
                    {
                        try
                        {
                            Group group = groupMgr.GetAt(lstGroups.SelectedIndex);
                            groupMgr.IsGroupLoadedFromDB = true;
                            if (groupMgr.Add(group))
                                MsgBox.Show("Group saved to DataBase");
                        }
                        finally
                        {
                            groupMgr.IsGroupLoadedFromDB = false;
                        }
                    }
                    else
                        MsgBox.Show("You need to select an item");
                }
                else
                {
                    MsgBox.Show("You can't save to DB if you have loaded groups from DB");
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }

        }

        /// <summary>
        /// Method that shows description about the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAboutBox_Click(object sender, RoutedEventArgs e)
        {
            WpfAboutBox wpfAboutBox = new WpfAboutBox();
            wpfAboutBox.ShowDialog();
        }
        #endregion MenuEvents

    }
}
