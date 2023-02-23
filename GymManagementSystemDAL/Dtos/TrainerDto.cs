using System;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystemDAL.Dtos
{
    public class TrainerDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; } 
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; } 
        /// <summary>
        /// Person number
        /// </summary>
        public string PersonNumber { get; set; } 
        /// <summary>
        /// Gender
        /// </summary>
        public string Gender { get; set; } 
        /// <summary>
        /// Birthdate
        /// </summary>
        public string Birthdate { get; set; } 
        /// <summary>
        /// Address
        /// </summary>
        public AddressDto Address { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } 
        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; } 
        /// <summary>
        /// Date registered
        /// </summary>
        public DateTime DateRegistered { get; set; }
    }
}
