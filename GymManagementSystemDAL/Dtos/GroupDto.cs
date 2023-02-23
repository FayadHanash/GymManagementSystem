using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManagementSystemDAL.Dtos
{
    public class GroupDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Resposible trainer
        /// </summary>
        public GroupTrainerDto Trainer { get; set; }

        /// <summary>
        /// Members 
        /// </summary>
        public GroupMembersDto Members { get; set; }

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// Description for a group
        /// </summary>
        public string Description { get; set; } 

        /// <summary>
        /// Duration
        /// </summary>
        public string Duration { get; set; } 

        /// <summary>
        /// Time
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Date for instance training group
        /// </summary>
        public string Date { get; set; } 

    }
}
