using System;
using System.Reflection;

namespace GymManagementSystemBLL
{
    [Serializable]
    public class Member : Person
    {
        #region constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Member()
        { }

        /// <summary>
        /// Constructor with one parameter
        /// </summary>
        public Member(string FullName)
        {
            string temp = FullName.Substring(FullName.IndexOf(' ') + 1);
            this.FirstName = (temp.Substring(0, temp.IndexOf(' '))).Replace('_', ' ');
            this.LastName = (temp.Substring(temp.IndexOf(' ') + 1)).Replace('_', ' ');
        }
        /// <summary>
        /// Constructor with ten parameters
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
        public Member
            (
            int id,
            string firstNam, 
            string lastName, 
            string personNumber, 
            Gender gender, 
            string birthdate, 
            Address address, 
            string email, 
            string phone, 
            DateTime dateRegistered
            )
        {
            this.Id = id;
            this.FirstName = firstNam;
            this.LastName = lastName;
            this.PersonNumber = personNumber;
            this.Gender = gender;
            this.BirthDate = birthdate;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.DateRegistered = dateRegistered;
        }
        #endregion constructor

        #region Methods
        /// <summary>
        /// Method prepares a string format. It will be used in the ViewMemberWindow,
        /// Shows the member information in the label.
        /// </summary>
        /// <returns>A formatted string.</returns>
        public override string GetInfo()
        {
            string memberInfoText = "Personal info:\n";
            memberInfoText += $"{FirstName}  {LastName}\n";
            memberInfoText += $"{PersonNumber}\n";
            memberInfoText += $"{Gender}\n";
            memberInfoText += $"{BirthDate}\n\n";
            memberInfoText += "Contact info:\n";
            memberInfoText += $"{Phone}\n";
            memberInfoText += $"{Email}\n\n";
            memberInfoText += "Address info:\n";
            memberInfoText += $"{Address.Street}\n";
            memberInfoText += $"{Address.ZipCode}  {Address.City}\n";
            memberInfoText += $"{Address.Country.ToString().Replace('_', ' ')}\n\n";
            memberInfoText += $"{FirstName} is registered since:\n {DateRegistered}";
            return memberInfoText;
        }
        

        /// <summary>
        /// This method prepares a format string that is in sync with the ToString method.  
        /// It will be used in the GroupWindow.
        /// </summary>
        /// <returns>A formatted string as heading for the values formatted in the ToString
        /// method below.</returns>
        public override string ToString() => String.Format("{0,0} ", $"{FirstName}  {LastName}");

        /// <summary>
        /// Method that formats a string for writing to a test file, it will facilitate the reading
        /// </summary>
        /// <returns></returns>
        public string ToStringForTextFile() => $"ID:{Id} {FirstName.Replace(' ', '_')} {LastName.Replace(' ', '_')}";

        #endregion Methods
    }
}
