using System.Windows;

namespace GymManagementSystem
{
    /// <summary>
    /// enum of buttons options 
    /// </summary>
    public enum MessageBoxOption
    {
        None = 0,
        Ok = 1,
        Cancel = 2,
        OkAndCancel = 3
    }
    /// <summary>
    /// Enum of MsgBoxResult
    /// </summary>
    public enum MsgBoxResult
    {
        No = 0,
        Ok = 1,
        Cancel = 2
    }
    /// <summary>
    /// Interaction logic for Msg.xaml
    /// An own custom Message box class
    /// </summary>
    public partial class Msg : Window
    {
        #region Fields
        /// <summary>
        /// colse the window
        /// </summary>
        bool close = false;

        /// <summary>
        /// result fiels
        /// Sets the instance as NO
        /// </summary>
        MsgBoxResult result = MsgBoxResult.No;

        #endregion Fields
        #region Properties
        /// <summary>
        /// Property ralted to close field
        /// Only read access is provided
        /// </summary>
        public bool CloseWindow => close;
        /// <summary>
        /// Property ralted to result field
        /// Only read access is provided
        /// </summary>
        public MsgBoxResult Reslut => result;

        #endregion Properties
        
        #region Constructors
        /// <summary>
        /// default constructor
        /// </summary>
        public Msg() : this("") { }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="msg"></param>
        public Msg(string msg) : this(msg, MessageBoxOption.Ok) { }

        /// <summary>
        /// Constructor with two parameter
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="mBO"></param>
        public Msg(string msg, MessageBoxOption mBO) : this(msg, mBO, "") { }

        /// <summary>
        /// Constructor with three parameter
        /// Calls ShowMessage method
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="mBO"></param>
        /// <param name="caption"></param>
        public Msg(string msg, MessageBoxOption mBO, string caption)
        {
            InitializeComponent();
            this.SizeToContent = SizeToContent.WidthAndHeight;
            ShowMessage(msg, mBO, caption);
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// Method that shows the message
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="mBO"></param>
        /// <param name="caption"></param>
        public void ShowMessage(string msg, MessageBoxOption mBO, string caption)
        {
            switch (mBO)
            {
                case MessageBoxOption.Ok:
                    DisplayOkButton();
                    Title = caption;
                    lblMsg.Content = msg;

                    break;
                case MessageBoxOption.OkAndCancel:
                    DisplayOkAndCancel();
                    lblMsg.Content = msg;
                    Title = caption;
                    break;
                default:
                    result = MsgBoxResult.No;
                    break;
            }
        }
        /// <summary>
        /// Method that displays ok button.
        /// Calls EnableOkButton and DisenableCancelButton methods;
        /// </summary>
        void DisplayOkButton()
        {
            EnableOkButton();
            DisenableCancelButton();
        }
        /// <summary>
        /// Method that Displays Ok And Cancel buttons.
        /// Calls EnableOkButton and EnableCancelButton methods
        /// </summary>
        void DisplayOkAndCancel()
        {
            EnableOkButton();
            EnableCancelButton();
        }

        /// <summary>
        /// Method that disenables cancel button
        /// </summary>
        void DisenableCancelButton()
        {
            btnCancel.Visibility = Visibility.Hidden;
            btnCancel.IsEnabled = false;
            borderCancel.Visibility = Visibility.Hidden;
            borderCancel.IsEnabled = false;
        }
        /// <summary>
        /// Method that enables cancel button
        /// </summary>
        void EnableCancelButton()
        {
            borderOk.HorizontalAlignment = HorizontalAlignment.Left;
            borderCancel.HorizontalAlignment = HorizontalAlignment.Right;
            btnCancel.Visibility = Visibility.Visible;
            btnCancel.IsEnabled = true;
            borderCancel.Visibility = Visibility.Visible;
            borderCancel.IsEnabled = true;
        }
        /// <summary>
        /// Method that enables Ok button
        /// </summary>
        void EnableOkButton()
        {
            borderOk.HorizontalAlignment = HorizontalAlignment.Center;
            btnOk.Visibility = Visibility.Visible;
            btnOk.IsEnabled = true;
            borderOk.Visibility = Visibility.Visible;
            borderOk.IsEnabled = true;
        }


        /// <summary>
        /// Method that closes the window.
        /// sets the result as No
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            result = MsgBoxResult.Cancel;
            close = false;
            this.Close();
        }

        /// <summary>
        /// Method that closes the window.
        /// sets the result as Ok
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            result = MsgBoxResult.Ok;
            close = true;
            this.Close();
        }

        #endregion Methods
    }
}
