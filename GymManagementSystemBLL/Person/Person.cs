using System;

namespace GymManagementSystemBLL
{
    [Serializable]
    public abstract class Person : IPerson
    {
        #region Fields
        /// <summary>
        /// id field.
        /// </summary>
        private int id;
        /// <summary>
        /// First name field.
        /// </summary>
        private string firstName;
        /// <summary>
        /// Last name field
        /// </summary>
        private string lastName; 
        /// <summary>
        /// Person number field
        /// </summary>
        private string personNumber; 
        /// <summary>
        /// gender field
        /// </summary>
        private Gender gender;
        /// <summary>
        /// birthdate field
        /// </summary>
        private string birthdate; 
        /// <summary>
        /// address field
        /// </summary>
        private Address address; 
        /// <summary>
        /// email field
        /// </summary>
        private string email; 
        /// <summary>
        /// phone field
        /// </summary>
        private string phone;
        /// <summary>
        /// date registered
        /// </summary>
        DateTime dateRegistered;

        #endregion Fields

        #region Constructors
        /// <summary>
        /// default constructor.
        /// Creates an insance of Address Object
        /// </summary>
        public Person()
        {
            address = new Address();
        }

        /// <summary>
        ///  Copy Constructor - clone the other person
        ///  this person is created with the same values from another person object
        /// </summary>
        public Person(Person theOther)
        {
            this.firstName = theOther.FirstName;
            this.lastName = theOther.LastName;
            this.personNumber = theOther.personNumber;
            this.phone = theOther.phone;
            this.email = theOther.email;
            this.address = new Address(theOther.address);
            this.dateRegistered = theOther.dateRegistered;
            this.gender = theOther.gender;
            this.birthdate = theOther.birthdate;

        }



        /// <summary>
        /// constructor with 10 parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="personNumber"></param>
        /// <param name="gender"></param>
        /// <param name="birthdate"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="dateRegistered"></param>
        public Person(int id, 
            string firstName, 
            string lastName, 
            string personNumber, 
            Gender gender, 
            string birthdate, 
            Address address, 
            string email, 
            string phone, 
            DateTime dateRegistered)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.personNumber = personNumber;
            this.gender = gender;
            this.birthdate = birthdate;
            this.address = address;
            this.email = email;
            this.phone = phone;
            this.dateRegistered = dateRegistered;
        }
        #endregion Constructors

        #region Properties
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Property related to first name field
        /// Both read and write access
        /// </summary>
        public string FirstName { get => firstName; set => firstName = value; }

        /// <summary>
        /// Property related to last name field
        /// Both read and write access
        /// </summary>
        public string LastName { get => lastName; set => lastName = value; }

        /// <summary>
        /// Property returns full name.
        /// </summary>
        public string Name { get => $"{lastName.ToUpper()} {firstName}"; }

        /// <summary>
        /// Property related to person number field
        /// Both read and write access
        /// </summary>
        public string PersonNumber { get => personNumber; set => personNumber = value; }

        /// <summary>
        /// Property related to gender field
        /// Both read and write access
        /// </summary>
        public Gender Gender { get => gender; set => gender = value; }

        /// <summary>
        /// Property related to birthday field
        /// Both read and write access
        /// </summary>
        public string BirthDate { get => birthdate; set => birthdate = value; }

        /// <summary>
        /// Property related to address field
        /// Both read and write access
        /// </summary>
        public Address Address { get => address; set => address = value; }

        /// <summary>
        /// Property related to phone field
        /// Both read and write access
        /// </summary>
        public string Phone { get => phone; set => phone = value; }

        /// <summary>
        /// Property related to email field
        /// Both read and write access
        /// </summary>
        public string Email { get => email; set => email = value; }

        /// <summary>
        /// Property related to dateRegistered field
        /// Both read and write access
        /// </summary>
        public DateTime DateRegistered { get => dateRegistered; set => dateRegistered = value; }

        #endregion Properties

        #region Methods
        /// <summary>
        /// Method prepares a string format.,
        /// Returns the person information.
        /// </summary>
        /// <returns>A formatted string.</returns>
        public abstract string GetInfo();
        #endregion Methods
    }


    /// <summary>
    /// Gender Enum
    /// </summary>
    public enum Gender
    {
        Man,
        Famale,
        Other
    }
}
