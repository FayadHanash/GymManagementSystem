using System;

namespace GymManagementSystemDAL.Dtos
{
    public class GroupMemberIdDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Member id
        /// </summary>
        public int MemberId { get; set; }

        /// <summary>
        /// GroupMembersDtoId
        /// </summary>
        public int GroupMembersDtoId { get; set; }

        /// <summary>
        /// Instance of GroupMembersDto
        /// </summary>
        public GroupMembersDto GroupMembersDto { get; set; }

    }
}
