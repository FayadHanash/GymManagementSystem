using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GymManagementSystemBLL;

namespace GymManagementSystem
{
    /// <summary>
    /// Interaction logic for ConfirmGroupWindow.xaml
    /// </summary>
    public partial class ConfirmGroupWindow : Window
    {
        #region Fields
        /// <summary>
        /// to controll if all data added successfully
        /// </summary>
        bool closeWindow;
        /// <summary>
        /// declare group of Group class
        /// </summary>
        Group group;
        #endregion Fields
        
        #region Properties

        /// <summary>
        ///Propertie related to close window
        /// just read access
        /// </summary>
        public bool CloseWindow => closeWindow;
        #endregion Properties
        
        #region Constructors
        /// <summary>
        /// default constructor
        /// </summary>
        public ConfirmGroupWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor one parameter
        /// creates an instance of Group (setes the same object as parameter )
        /// calls InitializeToolTip(), initializeGUI() and UpdateGUI() methods
        /// </summary>
        public ConfirmGroupWindow(Group group)
        {
            this.group = group;
            InitializeComponent();
            InitializeGUI();
            UpdateGUI();
            InitializeToolTip();

        }
        #endregion Constructors
        
        #region Methods
        /// <summary>
        /// Method that initializes the GUI by emptyfy all labels and list box
        /// </summary>
        private void InitializeGUI()
        {
            this.Owner = Application.Current.MainWindow;
            lblGroupName.Content = String.Empty;
            lblDuration.Content = String.Empty;
            lblTime.Content = String.Empty;
            lblDate.Content = String.Empty;
            txtDescription.Text = String.Empty;
            lblResponsibleTrainer.Content = String.Empty;
            lstMembers.ItemsSource = null;
            lstMembers.Items.Clear();
        }
        /// <summary>
        /// Method that displays a help text when the mouse over- confirm and Edit buttons
        /// </summary>
        private void InitializeToolTip()
        {
            btnConfirm.ToolTip = Common.NewToolTip("click this button to confirm the input");
            btnEdit.ToolTip = Common.NewToolTip("click this button to change inputs");
        }
        /// <summary>
        /// Method that justify GUI depending on the objects
        /// fills the text boxes,listbox and labels with data which sended as parameter in constructor
        /// </summary>
        private void UpdateGUI()
        {
            lblGroupName.Content = group.GroupName.ToString().Replace('_', ' ');
            lblDuration.Content = group.Duration;
            lblTime.Content = group.Time;
            lblDate.Content = group.Date;
            txtDescription.Text = group.Description;
            lblResponsibleTrainer.Content = group.Trainer.ToString();
            lstMembers.ItemsSource = group.Members;
        }
        /// <summary>
        /// Method that closes the window when confirm button clicked and sets closewindow to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            closeWindow = true;
            this.Close();
        }
        /// <summary>
        /// Method that closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion Methods
    }
}
