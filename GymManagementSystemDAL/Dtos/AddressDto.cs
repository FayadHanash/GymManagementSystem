using System;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystemDAL.Dtos
{
    public class AddressDto
    {
        /// <summary>
        /// id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Street 
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// City 
        /// </summary>
        public string City { get; set; } 
        /// <summary>
        /// Zip code
        /// </summary>
        public string ZipCode { get; set; } 

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; } 
    }
}
