using System;

namespace GymManagementSystemDAL.Dtos
{
    public class GroupTrainerDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Trainer id
        /// </summary>
        public int TrainerId { get; set; }

        /// <summary>
        /// Group id
        /// </summary>
        public int GroupId { get; set; }
    }
}
