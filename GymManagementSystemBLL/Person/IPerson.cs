using System;

namespace GymManagementSystemBLL
{
    public interface IPerson
    {
        #region Fields
        /// <summary>
        /// First name field.
        /// Both read and write access
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Last name field.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Person number field.
        /// Both read and write access
        /// </summary>
        string PersonNumber { get; set; }

        /// <summary>
        /// Gender field.
        /// Both read and write access
        /// </summary>
        Gender Gender { get; set; }

        /// <summary>
        /// Birthday field.
        /// Both read and write access
        /// </summary>
        string BirthDate { get; set; }

        /// <summary>
        /// Address field.
        /// Both read and write access
        /// </summary>
        Address Address { get; set; }

        /// <summary>
        /// Phone number field.
        /// Both read and write access
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Email field.
        /// Both read and write access
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// DateTime field.
        /// Both read and write access
        /// </summary>
        DateTime DateRegistered { get; set; }

        #endregion Fields
        
        #region Methods

        /// <summary>
        /// Method prepares a string format.
        /// Returns the person information.
        /// </summary>
        /// <returns>A formatted string.</returns>
        string GetInfo();
        #endregion Methods
    }
}
