using Microsoft.EntityFrameworkCore;
using GymManagementSystemDAL.Data;
using GymManagementSystemDAL.Dtos;

namespace GymManagementSystemDAL.Controllers
{
    /// <summary>
    /// Class that handles Group data in the database
    /// </summary>
    public class GroupController
    {
        #region Methods
        /// <summary>
        /// Method that adds a new group to database
        /// </summary>
        /// <param name="group"></param>
        /// <returns>True if the group added, otherwise false</returns>
        public static bool CreateGroup(GroupDto group)
        {
            using (GymMSContext db = new GymMSContext())
            {
                try
                {
                    group.Id = 0;
                    db.Groups.Add(group);
                    db.SaveChanges();
                    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Method that gets all groups from database
        /// </summary>
        /// <returns></returns>
        public List<GroupDto> GetGroups()
        {
            List<GroupDto> temp = new List<GroupDto>();
            using (GymMSContext db = new GymMSContext())
            {
                var groupDtos = (from g in db.Groups
                                 select new
                                 {
                                     g.Id,
                                     g.Name,
                                     g.Description,
                                     g.Duration,
                                     g.Time,
                                     g.Date,
                                     Trainer = new GroupTrainerDto()
                                     {
                                         Id = g.Id,
                                         TrainerId = g.Trainer.TrainerId
                                     },
                                     Members = new GroupMembersDto()
                                     {
                                         Id = g.Id,
                                         MembersCollection = (from m in g.Members.MembersCollection
                                                              select new GroupMemberIdDto()
                                                              {
                                                                  Id = m.Id,
                                                                  MemberId = m.MemberId
                                                              }).ToList()
                                     }

                                 }).ToList();
                
                foreach (var group in groupDtos)
                {
                    temp.Add(new GroupDto()
                    {
                        Id = group.Id,
                        Name = group.Name,
                        Description = group.Description,
                        Duration = group.Duration,
                        Time = group.Time,
                        Date = group.Date,
                        Trainer = new GroupTrainerDto()
                        {
                            Id = group.Trainer.Id,
                            TrainerId = group.Trainer.TrainerId
                        },
                        Members = new GroupMembersDto()
                        {
                            Id = group.Members.Id,
                            MembersCollection = group.Members.MembersCollection
                        }
                    });
                }

            }
            return temp;
        }

        /// <summary>
        /// Method that updates a group in the database
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="group"></param>
        /// <returns>True if the group updated, otherwise false</returns>
        public static bool UpdateGroup(int groupId, GroupDto group)
        {
            using (GymMSContext db = new GymMSContext())
            {
                try
                {
                    if (DeleteGroup(groupId))
                    {
                        CreateGroup(group);
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Method that deletes a group from database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if the group deleted, otherwise false</returns>
        public static bool DeleteGroup(int id)
        {
            using (GymMSContext db = new GymMSContext())
            {
                try
                {
                    GroupDto group = db.Groups.Where(x => x.Id == id).FirstOrDefault<GroupDto>();
                    db.Groups.Remove(group);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        #endregion Methods
    }
}
