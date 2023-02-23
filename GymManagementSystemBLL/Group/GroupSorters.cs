using System;

namespace GymManagementSystemBLL
{
    /// <summary>
    /// Class that compares groups name
    /// </summary>
    public class GroupSorter : IComparer<Group>
    {
        public int Compare(Group x, Group y) => x.GroupName.CompareTo(y.GroupName);
    }
    /// <summary>
    /// Class that compares groups DateTime
    /// </summary>
    public class DateSorter : IComparer<Group>
    {
        public int Compare(Group x, Group y) => x.DateTime.CompareTo(y.DateTime);
    }
    /// <summary>
    /// Class that compares groups Day
    /// </summary>
    public class DaySorter : IComparer<Group>
    {
        public int Compare(Group x, Group y) => x.Day.CompareTo(y.Day);
    }
    
    /// <summary>
    /// Class that compares groups Time
    /// </summary>
    public class TimeSorter : IComparer<Group>
    {   
        public int Compare(Group x, Group y) => x.Time.CompareTo(y.Time);
    }
    /// <summary>
    /// Class that compares groups Duration
    /// </summary>
    public class DurationSorter : IComparer<Group>
    {
        public int Compare(Group x, Group y) => x.Duration.CompareTo(y.Duration);
    }
}
