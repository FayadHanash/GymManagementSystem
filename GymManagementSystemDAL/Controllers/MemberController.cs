using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using GymManagementSystemDAL.Data;
using GymManagementSystemDAL.Dtos;

namespace GymManagementSystemDAL.Controllers
{
    /// <summary>
    /// Class that handles Member data in the database
    /// </summary>
    public class MemberController
    {
        #region Methods
        /// <summary>
        /// Method that adds a new member to database
        /// </summary>
        /// <param name="member"></param>
        /// <returns>True if the member added, otherwise false</returns>
        public static bool CreateMember(MemberDto member)
        {
            using (GymMSContext db = new GymMSContext())
            {
                try
                {
                    db.Members.Add(member);
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
        /// Method that gets all members from database
        /// </summary>
        /// <returns></returns>
        public List<MemberDto> GetMembers()
        {
            List<MemberDto> temp = new List<MemberDto>();
            using (GymMSContext db = new GymMSContext())
            {
                var memberDtos = (from m in db.Members
                                  select new
                                  {
                                      m.Id,
                                      m.FirstName,
                                      m.LastName,
                                      m.PersonNumber,
                                      m.Email,
                                      m.Phone,
                                      m.Birthdate,
                                      m.DateRegistered,
                                      m.Gender,
                                      Address = new AddressDto()
                                      {
                                          Street = m.Address.Street,
                                          City = m.Address.City,
                                          Country = m.Address.Country,
                                          ZipCode = m.Address.ZipCode
                                      }


                                  }).ToList();


                foreach (var member in memberDtos)
                    temp.Add(new MemberDto()
                    {
                        Id = member.Id,
                        FirstName = member.FirstName,
                        LastName = member.LastName,
                        PersonNumber = member.PersonNumber,
                        Email = member.Email,
                        Phone = member.Phone,
                        Birthdate = member.Birthdate,
                        DateRegistered = member.DateRegistered,
                        Gender = member.Gender,
                        Address = new AddressDto()
                        {
                            Street = member.Address.Street,
                            City = member.Address.City,
                            Country = member.Address.Country,
                            ZipCode = member.Address.ZipCode
                        }

                    });
            }
            return temp;
        }

        /// <summary>
        /// Method that updates a member in the database
        /// </summary>
        /// <param name="member"></param>
        /// <returns>True if the member updated, otherwise false</returns>
        public static bool UpdateMember(MemberDto member)
        {
            using (GymMSContext db = new GymMSContext())
            {
                try
                {
                    var memberToUpdate = db.Members.FirstOrDefault(m => m.Id == member.Id);
                    memberToUpdate.FirstName = member.FirstName;
                    memberToUpdate.LastName = member.LastName;
                    memberToUpdate.PersonNumber = member.PersonNumber;
                    memberToUpdate.Email = member.Email;
                    memberToUpdate.Phone = member.Phone;
                    memberToUpdate.Birthdate = member.Birthdate;
                    memberToUpdate.DateRegistered = member.DateRegistered;
                    memberToUpdate.Gender = member.Gender;
                    memberToUpdate.Address = new AddressDto()
                    {
                        Street = member.Address.Street,
                        City = member.Address.City,
                        Country = member.Address.Country,
                        ZipCode = member.Address.ZipCode
                    };

                    db.Update(memberToUpdate);
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
        /// Method that deletes a member from database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if the member deleted, otherwise false</returns>
        public static bool DeleteMember(int id)
        {
            using (GymMSContext db = new GymMSContext())
            {
                try
                {
                    MemberDto member = db.Members.Where(x => x.Id == id).FirstOrDefault<MemberDto>();
                    db.Members.Remove(member);
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
        /// Method that returns a member from the database by a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MemberDto GetMemberById(int id)
        {
            using (GymMSContext db = new GymMSContext())
            {
                var member = (from m in db.Members
                              where m.Id == id
                              select new
                              {
                                  m.Id,
                                  m.FirstName,
                                  m.LastName,
                                  m.PersonNumber,
                                  m.Email,
                                  m.Phone,
                                  m.Birthdate,
                                  m.DateRegistered,
                                  m.Gender,
                                  Address = new AddressDto()
                                  {
                                      Street = m.Address.Street,
                                      City = m.Address.City,
                                      Country = m.Address.Country,
                                      ZipCode = m.Address.ZipCode
                                  }
                              }).FirstOrDefault();
                if (member != null)
                {

                    MemberDto memberDto = new MemberDto()
                    {
                        Id = member.Id,
                        FirstName = member.FirstName,
                        LastName = member.LastName,
                        PersonNumber = member.PersonNumber,
                        Email = member.Email,
                        Phone = member.Phone,
                        Birthdate = member.Birthdate,
                        DateRegistered = member.DateRegistered,
                        Gender = member.Gender,
                        Address = member.Address
                    };
                    return memberDto;
                }
            }
            return null;
        }

        #endregion Methods
    }
}
