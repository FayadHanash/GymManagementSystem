using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GymManagementSystemBLL;

namespace GymManagementSystem
{
    /// <summary>
    /// Declare a delegate that takes one boolean parameter for indicating whether the window is closed and the changes has done
    /// </summary>
    /// <param name="x"></param>
    public delegate void CloseRegisterWindow(bool x);

    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        #region Fields
        /// <summary>
        /// array of managers
        /// </summary>
        IManager[] manager;

        /// <summary>
        /// person object
        /// </summary>
        Person person;

        /// <summary>
        /// boolean to check if the window is called to add a new person or to edit an existing one
        /// </summary>
        bool isAdd = false;

        /// <summary>
        /// boolean to check if the window is called to edit an existing person
        /// </summary>
        bool isEdit = false;

        /// <summary>
        /// A predicate that shows error messages to the user and always returns false
        /// </summary>
        Predicate<string> Error = ShowErrors;
        
        #endregion Fields

        #region Properties
        /// <summary>
        /// Declare an event handler for CloseRegisterWindow
        /// </summary>
        public event CloseRegisterWindow CloseRegisterWindow = delegate { };

        /// <summary>
        /// property raleted to person object
        /// Only read access is provided
        /// </summary>
        public Person Person { get => person; }



        #endregion Properties

        #region Constructors
        /// <summary>
        /// Constructor with one parameter
        /// calls InitializeGUI method
        /// Sets the coming parameter as reference to the manager object
        /// Marks this constructor as it is to be adding new persons contructor
        /// </summary>
        /// <param name="manager"></param>
        public RegisterWindow(ref IManager[] manager)
        {
            InitializeComponent();
            InitializeGUI();
            this.manager = manager;
            isAdd = true;
            isEdit = false;
        }

        /// <summary>
        /// Constructor with two parameters
        /// calls InitializeGUI,ManageRadioButton and InitializeGUIForEdit methods
        /// Sets the coming parameter as reference to the person object
        /// Marks this constructor as it is to be editing an existing person contructor
        /// </summary>
        /// <param name="person"></param>
        /// <param name="isMember"></param>
        public RegisterWindow(Person person, bool isMember)
        {
            InitializeComponent();
            InitializeGUI();
            this.person = person;
            isAdd = false;
            isEdit = true;
            ManageRadioButton(isMember);
            InitializeGUIForEdit();
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// Method that manage the radio buttons 
        /// Checks if it is a mamber or a trainer
        /// </summary>
        /// <param name="rdButton"></param>
        void ManageRadioButton(bool rdButton)
        {
            if (rdButton)
            {
                rbMember.IsChecked = true;
                rbTrainer.IsChecked = false;
                rbMember.IsEnabled = false;
                rbTrainer.IsEnabled = false;
            }
            else
            {
                rbMember.IsChecked = false;
                rbTrainer.IsChecked = true;
                rbMember.IsEnabled = false;
                rbTrainer.IsEnabled = false;
            }
        }

        /// <summary>
        /// Method that initializes the GUI.
        /// Call EmptyTextBoxes, SetGenderComboBox and InitializeToolTip methods
        /// Justifies country combobox as setting a default country
        /// </summary>
        public void InitializeGUI()
        {
            this.Owner = Application.Current.MainWindow;
            EmptyTextBoxes();
            SetGenderComboBox();
            cmbCountry.ItemsSource = Enum.GetNames(typeof(Countries));
            cmbCountry.SelectedIndex = (int)Countries.Sverige;
            InitializeToolTip();
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
        /// Method that raises the CloseBugWindowEvent
        /// </summary>
        /// <param name="x"></param>
        void OnCloseWindow(bool x) => CloseRegisterWindow(x);
        

        /// <summary>
        /// Method that displays a help text when the mouse over- combobox, description text box, task list box and
        /// ok and Cancel buttons
        /// </summary>
        private void InitializeToolTip()
        {
            btnOK.ToolTip = Common.NewToolTip("click this button to register the data");
            btnCancel.ToolTip = Common.NewToolTip("click this button to cancel");
            txtFirstName.ToolTip = Common.NewToolTip("Input the first name");
            txtLastName.ToolTip = Common.NewToolTip("Input the last name");
            txtEmail.ToolTip = Common.NewToolTip("Input the email and email should contains . and @");
            dtpBirthday.ToolTip = Common.NewToolTip("click to open calender");
            cmbGender.ToolTip = Common.NewToolTip("click to select your gender");
            txtTelNumber.ToolTip = Common.NewToolTip("Input the phone number");
            txtStreet.ToolTip = Common.NewToolTip("Input the street");
            txtZipCode.ToolTip = Common.NewToolTip("Input the zip code");
            txtCity.ToolTip = Common.NewToolTip("Input the city");
            cmbCountry.ToolTip = Common.NewToolTip("click to select the country");
            txtPersonNummer.ToolTip = Common.NewToolTip("Input the Person number");
        }

        /// <summary>
        /// Method justifies gender combobbox
        /// </summary>
        public void SetGenderComboBox()
        {
            cmbGender.Items.Clear();
            cmbGender.ItemsSource = Enum.GetNames(typeof(Gender));
        }

        /// <summary>
        /// Method that justifies GUI depending on the object
        /// Fills the text boxes and comboboxes with date which coming as parameter in constructor
        /// Method calls InitializeToolTip method
        /// </summary>
        public void InitializeGUIForEdit()
        {

            txtFirstName.Text = person.FirstName;
            txtLastName.Text = person.LastName;
            txtPersonNummer.Text = person.PersonNumber;
            dtpBirthday.Text = person.BirthDate;
            txtTelNumber.Text = person.Phone;
            txtEmail.Text = person.Email;
            txtStreet.Text = person.Address.Street;
            txtCity.Text = person.Address.City;
            txtZipCode.Text = person.Address.ZipCode;
            cmbGender.SelectedIndex = (int)person.Gender;
            cmbCountry.SelectedIndex = (int)person.Address.Country;
            InitializeToolTip();

        }
        /// <summary>
        /// Method that Empties text boxes
        /// </summary>
        void EmptyTextBoxes()
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtPersonNummer.Text = String.Empty;
            txtTelNumber.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtStreet.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtZipCode.Text = String.Empty;
        }


        /// <summary>
        /// Method that gets all inputs 
        /// Makes sure if all inputs are correct and not empty by calling other validate methods 
        /// </summary>
        /// <returns>true if all inputs is given, otherwise false </returns>
        private bool GetInputs() => !ValidateText(txtFirstName.Text, "The first name should be given") ? false
            : !ValidateText(txtLastName.Text, "The last name should be given") ? false
            : !ValidateText(txtPersonNummer.Text, "The person number should be given") ? false
            : !ValidateText(dtpBirthday.Text, "The birthday should be given") ? false
            : !ValidateGender() ? false
            : !ValidateText(txtTelNumber.Text, "The phone number should be given") ? false
            : !ValidateEmail() ? false
            : !ValidateText(txtStreet.Text, "The street should be given") ? false
            : !ValidateText(txtZipCode.Text, "The zip code should be given") ? false
            : !ValidateText(txtCity.Text, "The city should be given") ? false
            : !ValidateCountry() ? false
            : true;

        /// <summary>
        /// Method that controls text boxes 
        /// </summary>
        /// <param name="text">text input to be controlled </param>
        /// <param name="errMessage">errer message</param>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        private bool ValidateText(string text, string errMessage) => String.IsNullOrEmpty(text.Trim()) ? Error(errMessage) : true;

        /// <summary>
        /// Method that controls the gender combobox
        /// </summary>
        /// <returns>true if gender selected, otherwise false</returns>
        private bool ValidateGender() => cmbGender.SelectedIndex == -1 ? Error("The gender must be select") : true;

        /// <summary>
        /// Method that controls the country combobox
        /// </summary>
        /// <returns>true if country selected, otherwise false. is always true because defualt country is setted</returns>
        private bool ValidateCountry() => cmbCountry.SelectedIndex == -1 ? Error("The country must be select") : true;


        /// <summary>
        /// Method that controls the email
        /// Calls the ValideText to ensures the text box isn't empty and trims it
        /// Creats an instance of Regex(Regular Expression language) to match in email text
        /// </summary>
        /// <returns>true if email is correct, otherwise false</returns>
        private bool ValidateEmail()
        {
            if (ValidateText(txtEmail.Text, "The email must be given"))
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
                if (regex.IsMatch(txtEmail.Text))
                    return true;
                else
                    Error("The email is not correct");
            }
            return false;
        }

        /// <summary>
        /// Method that adds the person if getInputs return true which is all inputs specified
        /// Creates an instance of Address and sending the address data as parameters
        /// </summary>
        /// <returns>true if tme member added</returns>
        private bool CheckInputs(Person temp)
        {
            if (GetInputs())
            {
                temp.FirstName = txtFirstName.Text;
                temp.LastName = txtLastName.Text;
                temp.PersonNumber = txtPersonNummer.Text;
                temp.BirthDate = dtpBirthday.Text;
                temp.Gender = (Gender)cmbGender.SelectedIndex;
                temp.Phone = txtTelNumber.Text;
                temp.Email = txtEmail.Text;
                Address address = new Address(txtStreet.Text, txtZipCode.Text, txtCity.Text, (Countries)cmbCountry.SelectedIndex);
                temp.Address = address;
                DateTime dateRegister = DateTime.Now;
                temp.DateRegistered = dateRegister;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method that adds a new person if the isAdd boolean true, otherwise closes the window due to IsEdit boolean is true
        /// Calls CheckInputs and GetConfirm methods
        /// Creates instances of Member and Trainer, Sets instances of MemberManager and TrainerManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (isAdd == true && isEdit == false)
            {
                if (rbMember.IsChecked == true) // if it is a member
                {
                    Member member = new Member();
                    if (CheckInputs(member))
                    {
                        if (GetConfirm(member))
                        {
                            MemberManager mMgr = (MemberManager)manager[0];
                            mMgr.Add(member);
                            manager[0] = mMgr;
                            OnCloseWindow(true);
                            this.Close();
                        }
                    }

                }
                else if (rbTrainer.IsChecked == true) //if it is a trainer
                {
                    Trainer trainer = new Trainer();
                    if (CheckInputs(trainer))
                    {
                        if (GetConfirm(trainer))
                        {
                            TrainerManager tMgr = (TrainerManager)manager[1];
                            tMgr.Add(trainer);
                            manager[1] = tMgr;
                            OnCloseWindow(true);
                            this.Close();
                        }
                    }
                }
                else MsgBox.Show("You must select a member or trainer");
            }
            else if (isAdd == false && isEdit == true)
            {
                if (CheckInputs(person))
                {
                    if (GetConfirm(person))
                    {
                        OnCloseWindow(true);
                        this.Close();
                    }
                }
            }
            else MsgBox.Show("No item added");
        }

        /// <summary>
        /// Method that Confirms the inputs.
        /// Creates an instance of ConfirmWindow and shows the ConfirmWindow dialog.
        /// </summary>
        /// <param name="pe"></param>
        /// <returns></returns>
        bool GetConfirm(Person p)
        {
            ConfirmWindow confirmWindow = new ConfirmWindow(p);
            confirmWindow.Title = "Double check your data";
            confirmWindow.ShowDialog();
            if (confirmWindow.CloseWindow == true)
                return true;
            return false;
            
        }

        /// <summary>
        /// Method closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OnCloseWindow(false);
            this.Close();
        }

        #endregion Methods
    }
}
