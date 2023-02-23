using System;

namespace GymManagementSystemBLL
{
    /// <summary>
    /// Class that compares trainers person number
    /// </summary>
    public class TrainerPersonNumberSorter : IComparer<Trainer>
    {
        public int Compare(Trainer x, Trainer y) => x.PersonNumber.CompareTo(y.PersonNumber);
    }
    /// <summary>
    /// Class that compares trainers name
    /// </summary>
    public class TrainerNameSorter : IComparer<Trainer>
    {
        public int Compare(Trainer x, Trainer y) => x.Name.CompareTo(y.Name);
    }
    /// <summary>
    /// Class that compares trainers phone number
    /// </summary>
    public class TrainerPhoneSorter : IComparer<Trainer>
    {
        public int Compare(Trainer x, Trainer y) => x.Phone.CompareTo(y.Phone);
    }
    /// <summary>
    /// Class that compares trainers email
    /// </summary>
    public class TrainerEmailSorter : IComparer<Trainer>
    {
        public int Compare(Trainer x, Trainer y) => x.Email.CompareTo(y.Email);
    }
}
