using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace GymManagementSystem
{
    public class Common
    {
        /// <summary>
        /// Method that retuens a new ToolTip
        /// </summary>
        /// <param name="x">the text to be showed</param>
        /// <returns></returns>
        public static ToolTip NewToolTip(string x) => new ToolTip()
        {
            Content = x,
            Background = (Brush)new BrushConverter().ConvertFrom("#3ca1e2"),
            Foreground = Brushes.Black
        };
    }
}
