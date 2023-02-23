using System;
using Microsoft.Win32;

namespace GymManagementSystem
{
    /// <summary>
    /// Class to handle with files
    /// </summary>
    public class FileUtility
    {
        /// <summary>
        /// Method that prompts dialog to give a name (perhaps the path where the file will be saved) for a file
        /// </summary>
        /// <param name="filterExtension">the file extension to be filtered</param>
        /// <param name="title">a title</param>
        /// <returns>returns the file with name, and extension and path</returns>

        public static string SaveFileDialog(string filterExtension, string title)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = title;
            saveFileDialog.Filter = filterExtension;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.AddExtension = true;
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Nullable<bool> result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                return saveFileDialog.FileName;
            }
            return string.Empty;
        }

        /// <summary>
        /// Method that prompts dialog to open a file
        /// </summary>
        /// <param name="filterExtension">the file extension to be filtered</param>
        /// <param name="title">a title</param>
        /// <returns>returns the file with name, and extension and path</returns>
        public static string OpenFileDialog(string filterExtension, string title)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = title;
            openFileDialog.Filter = filterExtension;
            openFileDialog.FilterIndex = 1;
            openFileDialog.AddExtension = true;
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }

        /// <summary>
        /// Method that changes the file extension
        /// </summary>
        /// <param name="Name">the file name to be changed</param>
        /// <param name="ext">the extension to be added</param>
        /// <returns>file name with a new extension</returns>
        public static string changeFileExtension(string Name, string ext) => String.Concat(Name.Substring(0,Name.LastIndexOf('.')),ext);
    }
}
