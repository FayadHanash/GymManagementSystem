using System;


namespace GymManagementSystemBLL
{
    [Serializable]
    public class Group
    {
        #region Fields
        /// <summary>
        /// Group id
        /// </summary>
        private int id;
        /// <summary>
        /// resposible trainer
        /// </summary>
        private Trainer trainer; 
        /// <summary>
        /// list of members
        /// </summary>
        private List<Member> member;
        /// <summary>
        /// group name
        /// </summary>
        private string name;
        /// <summary>
        /// description for a group
        /// </summary>
        private string description;
        /// <summary>
        /// duration
        /// </summary>
        private string duration;
        /// <summary>
        /// time
        /// </summary>
        private string time;
        /// <summary>
        /// date for instance training group
        /// </summary>
        private string date;

        #endregion Fields

        #region Properties
        /// <summary>
        /// Property related to id field
        /// Both read and write access
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Property related to name field
        /// Both read and write access
        /// </summary>
        public string GroupName { get => name; set => name = value; }

        /// <summary>
        /// Property related to description field
        /// Both read and write access
        /// </summary>
        public string Description { get => description; set => description = value; }

        /// <summary>
        /// Property related to date field
        /// Both read and write access
        /// </summary>
        public string Date { get => date; set => date = value; }

        /// <summary>
        /// Property related to duration field
        /// Both read and write access
        /// </summary>
        public string Duration { get => duration; set => duration = value; }

        /// <summary>
        /// Property related to time field
        /// Both read and write access
        /// </summary>
        public string Time { get => time; set => time = value; }

        /// <summary>
        /// Property related to members field
        /// Both read and write access
        /// </summary>
        public List<Member> Members { get => member; set => member = value; }

        /// <summary>
        /// Property related to trainer field
        /// Both read and write access
        /// </summary>

        public Trainer Trainer { get => trainer; set => trainer = value; }

        /// <summary>
        /// Property which returns the day by slicing the date field
        /// </summary>
        public string Day => date.Substring(date.IndexOf(" "));
        /// <summary>
        /// Property which returns the date without the day by slicing the date field
        /// </summary>
        public string DateTime => date.Substring(0, date.IndexOf(" "));
        #endregion Properties

        #region Constructor
        /// <summary>
        /// defualt constractor
        /// </summary>
        public Group()
        {
        }

        /// <summary>
        /// Constructor with 7 parameters
        /// </summary>
        /// <param name="gId"></param>
        /// <param name="grNmae"></param>
        /// <param name="trainer"></param>
        /// <param name="member"></param>
        /// <param name="duration"></param>
        /// <param name="time"></param>
        /// <param name="date"></param>
        public Group(int gId, string grNmae, Trainer trainer, List<Member> member, string duration, string time, string date)
        {
            this.Id = gId;
            this.name = grNmae;
            this.member = member;
            this.trainer = trainer;
            this.duration = duration;
            this.time = time;
            this.date = date;
        }

        /// <summary>
        /// Copy Constructor - clone the other group
        /// this group is created with the same values from another group object
        /// </summary>
        public Group(Group other)
        {
            this.id = other.id;
            this.name = other.name;
            this.trainer = other.trainer;
            this.member = other.member;
            this.duration = other.duration;
            this.time = other.time;
            this.date = other.date;
        }
        #endregion Constructor

        #region Methods
        /// <summary>
        /// Method returns number of members in mambers list
        /// </summary>
        /// <returns>number of members</returns>
        public int MembersCount() => member.Count;

        /// <summary>
        /// Method that prepares a dialog result that shows a description of an specific group
        /// this method calls when the client double click on item in groups list 
        /// replace the '_' char in name
        /// </summary>
        public (string, string) ShowDescription() => (description, $"Description about  {name.Replace("_", " ")}");
        #endregion Methods
    }
}
