using System;
using System.Windows;

namespace GymManagementSystem
{
    // A custom About box (Wpf does not has About box)
    /// <summary>
    /// Interaction logic for WpfAboutBox.xaml
    /// </summary>
    public partial class WpfAboutBox : Window
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public WpfAboutBox()
        {
            InitializeComponent();
            InitializeGUI();
        }
        /// <summary>
        /// Method that Initializes the GUI
        /// </summary>
        void InitializeGUI()
        {
            this.Owner = Application.Current.MainWindow;
            this.Title = "";
            lblProductName.Content = $" Product Name: Gym Management System";
            lblVersion.Content = $" Version: 1.0.0.0";
            lblCopyright.Content = $" Copyright: Copyright ©  2023 By Fayad Al Hanash";
            lblCompanyName.Content = $" Company Name: Gym";
            txtDescription.Text = "The application that allows to register members and trainers.It also allows to create a training group.";
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
