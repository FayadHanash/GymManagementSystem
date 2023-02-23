using System;
using GymManagementSystemDAL.Controllers;
using GymManagementSystemDAL.Dtos;

namespace GymManagementSystemBLL
{
    public class TextUtility<T>
    {
        /// <summary>
        /// Method to save the data to a text file
        /// </summary>
        /// <param name="fileName">text file path and name</param>
        /// <param name="list">list object to be writen to a text file</param>
        public static void SaveToFile(string fileName, List<T> list)
        {
            List<Group> groups = new List<Group>();
            groups = list as List<Group>;
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(File.Open(fileName, FileMode.Create));
                writer.WriteLine(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    writer.WriteLine(groups[i].GroupName);
                    writer.WriteLine(groups[i].Description);
                    writer.WriteLine(groups[i].Duration);
                    writer.WriteLine(groups[i].Time);
                    writer.WriteLine(groups[i].Date);
                    writer.WriteLine(groups[i].Trainer.ToStringForTextFile());

                    writer.WriteLine(groups[i].MembersCount());
                    for (int j = 0; j < groups[i].MembersCount(); j++)
                    {
                        writer.WriteLine(groups[i].Members[j].ToStringForTextFile());
                    }

                }
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// Method to read the data from a text file
        /// </summary>
        /// <param name="fileName">text file path and name</param>
        /// <param name="list">list of objects to be loaded from a text file</param>
        public static void LoadFromFile(string fileName, ref List<Group> list)
        {
            list = new List<Group>();
            StreamReader reader = null;
            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException("File not found", fileName);
                }
                reader = new StreamReader(File.Open(fileName, FileMode.Open));
                int count = Convert.ToInt32(reader.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    Group group = new Group();
                    group.GroupName = reader.ReadLine();
                    group.Description = reader.ReadLine();
                    group.Duration = reader.ReadLine();
                    group.Time = reader.ReadLine();
                    group.Date = reader.ReadLine();
                    string trainer = reader.ReadLine();
                    try
                    {
                        string x = trainer.Substring(0, trainer.IndexOf(" "));
                        int getGetTrainerId = Int16.Parse(x.Substring(x.IndexOf("ID:") + 3));
                        TrainerDto trainerDto = TrainerController.GetTrainerById(getGetTrainerId);
                        if (trainerDto != null)
                        {
                            group.Trainer = Helper.NewTrainer(trainerDto);
                        }
                    }
                    catch
                    {
                        group.Trainer = new Trainer(trainer);
                    }
                    int mrmberCont = Convert.ToInt32(reader.ReadLine());
                    group.Members = new List<Member>();
                    for (int j = 0; j < mrmberCont; j++)
                    {
                        string member = reader.ReadLine();
                        try
                        {
                            string y = member.Substring(0, member.IndexOf(" "));
                            int getGetMemberId = Int16.Parse(y.Substring(y.IndexOf("ID:") + 3));
                            MemberDto memberDto = MemberController.GetMemberById(getGetMemberId);
                            if (memberDto != null)
                            {
                                group.Members.Add(Helper.NewMember(memberDto));
                            }
                        }
                        catch
                        {
                            group.Members.Add(new Member(member));
                        }
                    }
                    list.Add(group);
                }
            }
            finally
            {

                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
