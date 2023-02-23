using System;

namespace GymManagementSystemBLL
{
    /// <summary>
    /// Class that compares members person number
    /// </summary>
    public class MemberPersonNumberSorter : IComparer<Member>
    {
        public int Compare(Member x, Member y) => x.PersonNumber.CompareTo(y.PersonNumber);
    }
    /// <summary>
    /// Class that compares members name
    /// </summary>
    public class MemberNameSorter : IComparer<Member>
    {
        public int Compare(Member x, Member y) => x.Name.CompareTo(y.Name);
    }
    /// <summary>
    /// Class that compares members phone number
    /// </summary>
    public class MemberPhoneSorter : IComparer<Member>
    {
        public int Compare(Member x, Member y) => x.Phone.CompareTo(y.Phone);
    }
    /// <summary>
    /// Class that compares members email
    /// </summary>
    public class MemberEmailSorter : IComparer<Member>
    {
        public int Compare(Member x, Member y) => x.Email.CompareTo(y.Email);
    }
}
