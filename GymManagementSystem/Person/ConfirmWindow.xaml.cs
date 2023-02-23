using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GymManagementSystemBLL;

namespace GymManagementSystem
{
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        #region Fields
        /// <summary>
        /// to controll if all data added successfully
        /// </summary>
        bool closeWindow;
        /// <summary>
        /// declare member of Person class
        /// </summary>
        Person temp;


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
        /// Default constructor
        /// calls InitializeToolTip and initializeGUI method
        /// </summary>
        public ConfirmWindow()
        {
            InitializeComponent();
            InitializeGUI();
            InitializeToolTip();
        }

        /// <summary>
        /// Constructor with one parameter
        /// Sets the parameter as a reference to temp filed
        /// calls InitializeToolTip, UpdateGUIand initializeGUI method
        /// </summary>
        /// <param name="temp"></param>
        public ConfirmWindow(Person temp)
        {
            this.temp = temp;
            InitializeComponent();
            InitializeGUI();
            UpdateGUI();
            InitializeToolTip();
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// Method that initializes the GUI by emptify all labels and list box
        /// </summary>
        private void InitializeGUI()
        {
            lblFullName.Content = String.Empty;
            txtAddress.Text = String.Empty;
            lblBirthDate.Content = String.Empty;
            lblEmail.Content = String.Empty;
            lblGender.Content = String.Empty;
            lblPersonNumber.Content = String.Empty;
            lblTelNumber.Content = String.Empty;
            this.Owner = Application.Current.MainWindow;
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
        /// Method that justifies GUI depending on the object
        /// Fills the text boxes,listbox and labels with date which sended as parameter in constructor
        /// </summary>
        private void UpdateGUI()
        {
            lblFullName.Content = $"{temp.FirstName}  {temp.LastName}";
            lblPersonNumber.Content = temp.PersonNumber.ToString();
            lblGender.Content = temp.Gender;
            lblBirthDate.Content = temp.BirthDate;
            lblTelNumber.Content = temp.Phone;
            lblEmail.Content = temp.Email;
            txtAddress.Text = $"{temp.Address.Street}\n{temp.Address.ZipCode}  {temp.Address.City}\n{temp.Address.Country.ToString().Replace('_', ' ')}\n";

        }

        /// <summary>
        /// Method that closes the window and set closeWindow to true
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
