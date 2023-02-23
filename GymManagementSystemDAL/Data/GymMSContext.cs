using System;
using GymManagementSystemDAL.Dtos;
using Microsoft.EntityFrameworkCore;


namespace GymManagementSystemDAL.Data
{
    public class GymMSContext : DbContext
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public GymMSContext()
        {
        }

        /// <summary>
        /// List of members
        /// </summary>
        public DbSet<MemberDto> Members { get; set; }
        
        /// <summary>
        /// List of groups
        /// </summary>
        public DbSet<GroupDto> Groups { get; set; }

        /// <summary>
        /// List of trainers
        /// </summary>
        public DbSet<TrainerDto> Trainers { get; set; }


        /// <summary>
        /// Configuring inlogging
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GymManagementSystemDb");
        }
    }
}
