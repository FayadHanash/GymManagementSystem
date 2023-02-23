using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Controls;
using GymManagementSystemBLL;

namespace GymManagementSystem
{
    /// <summary>
    /// Class that prints a group information as pdf file
    /// </summary>
    public class Printer
    {
        /// <summary>
        /// creates an instance of Group object
        /// </summary>
        Group group = new Group();

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        /// <param name="group"></param>
        public Printer(Group group)
        {
            this.group = group;
        }
        /// <summary>
        /// Method that prints data to file or to printer 
        /// Creates an instance of PrintDialog and PrintDocument.
        /// Calls the PrintDocument_PrintPage method that takes care about handling of printing and justifing the content.
        /// </summary>
        public void Print()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            bool? print = printDialog.ShowDialog();
            if (print == true)
                printDocument.Print();
        }

        /// <summary>
        /// Method that handles and justifies the content of the document
        /// Sets the postions where the texts should be prints (draws)
        /// Creates an instance of drawing Font and sets fonts and fonts size
        /// Creates an instance of Pen to drawe the lines and an instance of Group
        /// Prints the group to document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            float PostX = 10;
            float PostY = 10;
            float PostX2 = 1000;
            var black = System.Drawing.Brushes.Black;
            System.Drawing.FontFamily fontFamily = new System.Drawing.FontFamily("Times New Roman");
            System.Drawing.Font printFont = new System.Drawing.Font(fontFamily, 12);

            string title = $"Informations about training group: {group.GroupName.Replace("_", " ")}";
            e.Graphics.DrawString(title, new System.Drawing.Font(fontFamily, 20), black, PostX, PostY);
            System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Green, 1);
            System.Drawing.Pen pen1 = new System.Drawing.Pen(System.Drawing.Color.Blue, (float)0.3);
            PostY += 40;
            e.Graphics.DrawLine(pen, PostX, PostY, PostX2, PostY);
            PostY += 30;
            string Name = string.Format("{0,-20} {1,-20}", "Name: ", group.GroupName.Replace("_", " "));
            e.Graphics.DrawString(Name, printFont, black, PostX, PostY);
            PostY += 20;

            string Date = string.Format("{0,-20} {1,-20}", "Date: ", group.Date);
            e.Graphics.DrawString(Date, printFont, black, PostX, PostY);
            PostY += 20;

            string Time = string.Format("{0,-20} {1,-20}", "Time: ", group.Time);
            e.Graphics.DrawString(Time, printFont, black, PostX, PostY);
            PostY += 20;
            string Dur = string.Format("{0,-20} {1,-20}", "Duration: ", group.Duration);
            e.Graphics.DrawString(Dur, printFont, black, PostX, PostY);
            PostY += 20;

            string dec = string.Format("{0,-20} {1,-20}", "Descripation: ", group.Description);
            e.Graphics.DrawString(dec, printFont, black, PostX, PostY);
            PostY += 40;

            string trainer = string.Format("{0,-20} {1,-20}", "Responsible trainer: ", group.Trainer.ToString());
            e.Graphics.DrawString(trainer, printFont, black, PostX, PostY);
            PostY += 25;
            string membe = string.Format("{0,-20} ", "Members joined: ");
            e.Graphics.DrawString(membe, printFont, black, PostX, PostY);
            PostY += 25;
            int i = 0;
            List<Member> members = group.Members;
            members.ForEach(x =>
            {
                i++;
                e.Graphics.DrawString($"({i,0})- {x.ToString()}", printFont, black, PostX, PostY);
                PostY += 20;
            });
            PostY += 40;
            e.Graphics.DrawLine(pen, PostX, PostY, PostX2, PostY);
            PostY += 20;
            string last = $"Last update: {DateTime.Now.ToString("d")}-{DateTime.Now.ToLongTimeString()}";
            e.Graphics.DrawString(last, printFont,black, PostX, PostY);
        }
    }
}
