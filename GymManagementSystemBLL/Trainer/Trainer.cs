using System;

namespace GymManagementSystemBLL
{
    [Serializable]
    public class Trainer : Person
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Trainer()
        {
        }
        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        public Trainer(string FullName)
        {
            string temp = FullName.Substring(FullName.IndexOf(' ')+1);
            this.FirstName = (temp.Substring(0, temp.IndexOf(' '))).Replace('_', ' ');
            this.LastName = (temp.Substring(temp.IndexOf(' ') + 1)).Replace('_', ' ');
        }

        /// <summary>
        /// Constructor with 10 parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstNam"></param>
        /// <param name="lastName"></param>
        /// <param name="personNumber"></param>
        /// <param name="gender"></param>
        /// <param name="birthdate"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="dateRegistered"></param>
        public Trainer(int id, 
            string firstNam, 
            string lastName, 
            string personNumber, 
            Gender gender, 
            string birthdate, 
            Address address, 
            string email, 
            string phone, 
            DateTime dateRegistered)
        {
            FirstName = firstNam;
            this.LastName = lastName;
            this.PersonNumber = personNumber;
            this.Gender = gender;
            this.BirthDate = birthdate;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.DateRegistered = dateRegistered;
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Method prepares a string format. It will be used in the ViewTrainerWindow,
        /// Shows the trainer information in the label.
        /// </summary>
        /// <returns>A formatted string.</returns>
        public override string GetInfo()
        {
            string trainerInfoText = "Personal info:\n";
            trainerInfoText += $"{FirstName}  {LastName}\n";
            trainerInfoText += $"{PersonNumber}\n";
            trainerInfoText += $"{Gender}\n";
            trainerInfoText += $"{BirthDate}\n\n";
            trainerInfoText += "Contact info:\n";
            trainerInfoText += $"{Phone}\n";
            trainerInfoText += $"{Email}\n\n";
            trainerInfoText += "Address info:\n";
            trainerInfoText += $"{Address.Street}\n";
            trainerInfoText += $"{Address.ZipCode}  {Address.City}\n";
            trainerInfoText += $"{Address.Country.ToString().Replace('_', ' ')}\n\n";
            trainerInfoText += $"{FirstName} is registered since:\n {DateRegistered}";
            return trainerInfoText;
        }

        /// <summary>
        /// This method prepares a format string that is in sync with the ToString method.  
        /// It will be used in the GroupWindow.
        /// </summary>
        public override string ToString() => String.Format("{0,0} ", $"{FirstName}  {LastName}");

        /// <summary>
        /// Method that formats a string for writing to a test file, it will facilitate the reading
        /// </summary>
        /// <returns></returns>
        public string ToStringForTextFile() => $"ID:{Id} {FirstName.Replace(' ', '_')} {LastName.Replace(' ', '_')}";

        #endregion Methods
    }
}
