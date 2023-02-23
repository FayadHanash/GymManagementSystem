using System;

namespace GymManagementSystemBLL
{
    [Serializable]
    public class Address
    {
        #region Fields
        /// <summary>
        /// street name
        /// </summary>
        private string street;
        /// <summary>
        /// city 
        /// </summary>
        private string city;
        /// <summary>
        /// zip code
        /// </summary>
        private string zip;
        /// <summary>
        /// country
        /// </summary>
        private Countries country;
        #endregion Fields

        #region Properties
        /// <summary>
        /// Property related to street field
        /// Both read and write access
        /// </summary>
        public string Street { get => street; set => street = value; }

        /// <summary>
        /// Property related to city field
        /// Both read and write access
        /// </summary>
        public string City { get => city; set => city = value; }

        /// <summary>
        /// Property related to zip code field
        /// Both read and write access
        /// </summary>
        public string ZipCode { get => zip; set => zip = value; }

        /// <summary>
        /// Property related to country field
        /// Both read and write access
        /// </summary>

        public Countries Country { get => country; set => country = value; }

        #endregion Properties

        #region Constructors
        /// <summary>
        /// Constructor with 4 parameters
        /// </summary>
        /// <param name="street">input coming from the client object</param>
        /// <param name="zip">input coming from the client object</param>
        /// <param name="city">input coming from the client object</param>
        /// <param name="countries">input coming from the client object</param>

        public Address(string street, string zip, string city, Countries countries)
        {
            this.street = street;
            this.zip = zip;
            this.city = city;
            this.country = countries;
        }

        /// <summary>
        /// Constructor with 3 parameters
        /// </summary>
        /// <param name="street">input coming from the client object</param>
        /// <param name="zip">input coming from the client object</param>
        /// <param name="city">input coming from the client object</param>
        public Address(string street, string zip, string city) : this(street, zip, city, Countries.Sverige)
        {
        }
        
        /// <summary>
        /// Default constructor - calls another constructor in this class
        /// </summary>
        public Address() : this(string.Empty, string.Empty, string.Empty)
        {

        }

        /// <summary>
        /// Copy Constructor - clone the other Address
        /// this adress is created with the same values from another address object
        /// </summary>
        public Address(Address address)
        {
            this.street = address.street;
            this.zip = address.zip;
            this.city = address.city;
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// This method prepares a format string that is in sync with the ToString method. 
        /// replace the '_' char in countries
        /// </summary>
        public override string ToString() => $"{street}\n{zip} {city}\n{country.ToString().Replace('_', ' ')}";
        #endregion Methods
    }
}
