using System;

namespace GymManagementSystemDAL.Dtos
{
    public class GroupMembersDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// collection of members
        /// </summary>
        public ICollection<GroupMemberIdDto> MembersCollection { get; set; }

        /// <summary>
        /// group id
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// instance of GroupDto
        /// </summary>
        public GroupDto Group { get; set; }


    }
}
