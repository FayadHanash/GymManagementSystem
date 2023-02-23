using GymManagementSystemDAL.Dtos;
using System;


namespace GymManagementSystemBLL
{
    public class Helper
    {
        /// <summary>
        /// Method that initializes duration for a group 
        /// creates a array of some values
        /// </summary>
        public static string[] SetDuration() => new string[] { "15 - minutes", "30-minutes", "45-minutes", "60-minutes", "90-minutes" };

        /// <summary>
        /// Method that initializes date for group date
        /// calls CalculateOffset method to calculate the far from the desired day
        /// then gets the next day and date of an specific day
        /// creates and returns a array of some dayes.
        /// </summary>
        public static string[] SetDaysAndDate()
        {
            DateTime date = DateTime.Now.Date;
            DateTime nextMonday, nextWednesday, nextThursday, nextFriday, nextSunday;
            nextMonday = date.AddDays(CalculateOffset(date.DayOfWeek, DayOfWeek.Monday));
            nextWednesday = date.AddDays(CalculateOffset(date.DayOfWeek, DayOfWeek.Wednesday));
            nextThursday = date.AddDays(CalculateOffset(date.DayOfWeek, DayOfWeek.Thursday));
            nextFriday = date.AddDays(CalculateOffset(date.DayOfWeek, DayOfWeek.Friday));
            nextSunday = date.AddDays(CalculateOffset(date.DayOfWeek, DayOfWeek.Sunday));

            string[] dateList = new string[]
            {
                $"{nextMonday.ToString("yyyy-MM-dd")}  {nextMonday.DayOfWeek.ToString()}",
                $"{nextWednesday.ToString("yyyy-MM-dd")}  {nextWednesday.DayOfWeek.ToString()}",
                $"{nextThursday.ToString("yyyy-MM-dd")}  {nextThursday.DayOfWeek.ToString()}",
                $"{nextFriday.ToString("yyyy-MM-dd")}  {nextFriday.DayOfWeek.ToString()}",
                $"{nextSunday.ToString("yyyy-MM-dd")}  {nextSunday.DayOfWeek.ToString()}"
            };
            return dateList;
        }

        /// <summary>
        /// Method that calculates the far between current day and the desired 
        /// </summary>
        /// <param name="current"> current day</param>
        /// <param name="desired"> next coming day</param>
        /// <returns>offset</returns>
        private static int CalculateOffset(DayOfWeek current, DayOfWeek desired)
        {
            int offset = (7 - (int)current + (int)desired) % 7;
            return offset == 0 ? 7 : offset;
        }

        /// <summary>
        /// Method that initializes times for a group 
        /// creates and returns a array of some values
        /// </summary>
        public static string[] SetTime() => new string[]
            {
                "06:00 AM",
                "07:30 AM",
                "09:00 AM",
                "09:30 AM",
                "10:00 AM",
                "11:00 AM",
                "01:00 PM",
                "03:00 PM",
                "04:30 PM",
                "06:00 PM"
            };
        
        /// <summary>
        ///  Method that returns a new MemberDto object
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static MemberDto NewMemberDto(Member x) => new MemberDto()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Gender = x.Gender.ToString(),
            PersonNumber = x.PersonNumber,
            Birthdate = x.BirthDate,
            Email = x.Email,
            Phone = x.Phone,
            DateRegistered = x.DateRegistered,
            Address = new AddressDto()
            {
                Street = x.Address.Street,
                City = x.Address.City,
                Country = x.Address.Country.ToString(),
                ZipCode = x.Address.ZipCode
            },
        };

        /// <summary>
        /// Method that returns a new TrainerDto object
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static TrainerDto NewTrainerDto(Trainer x) => new TrainerDto()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PersonNumber = x.PersonNumber,
            Email = x.Email,
            Phone = x.Phone,
            Birthdate = x.BirthDate,
            DateRegistered = x.DateRegistered,
            Gender = x.Gender.ToString(),
            Address = new AddressDto()
            {
                Street = x.Address.Street,
                City = x.Address.City,
                Country = x.Address.Country.ToString(),
                ZipCode = x.Address.ZipCode
            }

        };

        /// <summary>
        /// Method that returns a new  GroupDto object
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static GroupDto NewGroupDto(Group x)
        {
            GroupDto groupDto = new GroupDto()
            {
                Name = x.GroupName,
                Description = x.Description,
                Duration = x.Duration,
                Time = x.Time,
                Date = x.Date,
                Trainer = new GroupTrainerDto()
                {
                    TrainerId = x.Trainer.Id
                },
            };
            GroupMembersDto groupMembersDto = new GroupMembersDto();
            ICollection<GroupMemberIdDto> members = new List<GroupMemberIdDto>();
            foreach (var member in x.Members)
            {
                members.Add(new GroupMemberIdDto()
                {
                    MemberId = member.Id
                });
            }
            groupMembersDto.MembersCollection = members;
            groupDto.Members = groupMembersDto;
            return groupDto;
        }

        /// <summary>
        /// Method that returns a new Member object
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Member NewMember(MemberDto x)
        {
            Member member = new Member()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PersonNumber = x.PersonNumber,
                Email = x.Email,
                Phone = x.Phone,
                BirthDate = x.Birthdate,
                DateRegistered = x.DateRegistered,
                Gender = (Gender)Enum.Parse(typeof(Gender), x.Gender),
                Address = new Address()
                {
                    Street = x.Address.Street,
                    City = x.Address.City,
                    ZipCode = x.Address.ZipCode,
                    Country = (Countries)Enum.Parse(typeof(Countries), x.Address.Country)
                }

            };
            return member;
        }

        /// <summary>
        /// Method that returns a new Trainer object
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Trainer NewTrainer(TrainerDto x)
        {
            Trainer trainer = new Trainer()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PersonNumber = x.PersonNumber,
                Email = x.Email,
                Phone = x.Phone,
                BirthDate = x.Birthdate,
                DateRegistered = x.DateRegistered,
                Gender = (Gender)Enum.Parse(typeof(Gender), x.Gender),
                Address = new Address()
                {
                    Street = x.Address.Street,
                    City = x.Address.City,
                    ZipCode = x.Address.ZipCode,
                    Country = (Countries)Enum.Parse(typeof(Countries), x.Address.Country)
                }

            };
            return trainer;
        }
    }
}
