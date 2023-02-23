using GymManagementSystemDAL.Controllers;
using GymManagementSystemDAL.Dtos;
using System;

namespace GymManagementSystemBLL
{
    public class Common<T>
    {
        /// <summary>
        /// Method that adds a new object to the database and the object is of type (Member, Trainer and Group)
        /// </summary>
        /// <param name="t"> type of (Member, Trainer and Group)</param>
        /// <returns>true if the object is added, otherwise false</returns>
        public bool Add(T t)
        {
            switch (t)
            {
                case Member:
                    return MemberController.CreateMember(Helper.NewMemberDto(t as Member));
                case Trainer:
                    return TrainerController.CreateTrainer(Helper.NewTrainerDto(t as Trainer));
                case Group:
                    return GroupController.CreateGroup(Helper.NewGroupDto(t as Group));
                default:
                    return false;
            }
        }
        /// <summary>
        /// Method that deletes an object from the database and the object is of type (Member, Trainer and Group)
        /// </summary>
        /// <param name="t">type of (Member, Trainer and Group)</param>
        /// <param name="id">object id</param>
        /// <returns>true if the object is deleted, otherwise false</returns>
        public bool Delete(T t, int id)
        {
            switch(t)
            {
                case Member:
                    return MemberController.DeleteMember(id);
                case Trainer:
                    return TrainerController.DeleteTrainer(id);
                case Group:
                    return GroupController.DeleteGroup(id);
                default:
                    return false;
            }

        }

        /// <summary>
        /// Method that updates an object in the database and the object is of type (Member, Trainer and Group)
        /// </summary>
        /// <param name="t">type of (Member, Trainer and Group)</param>
        /// <returns>true if the object is updated, otherwise false</returns>
        public bool Update(T t)
        {
            switch (t)
            {
                case Member:
                    return MemberController.UpdateMember(Helper.NewMemberDto(t as Member));
                case Trainer:
                    return TrainerController.UpdateTrainer(Helper.NewTrainerDto(t as Trainer));
                case Group:
                    Group x = t as Group;
                    return GroupController.UpdateGroup(x.Id,Helper.NewGroupDto(x));
                default:
                    return false;
            }
        }
        /// <summary>
        /// Method that gets all objects from the database and the object is of type (Member, Trainer and Group)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<T> DBList(List<T> t)
        {
            switch (t)
            {
                case List<Member>:
                    List<Member> tempMembers = new List<Member>();
                    MemberController memberEditor = new MemberController();
                    memberEditor.GetMembers().ForEach(x => { tempMembers.Add(Helper.NewMember(x)); });
                    return tempMembers as List<T>;
                    
                case List<Trainer>:
                    List<Trainer> tempTrainers = new List<Trainer>();
                    TrainerController trainerEditor = new TrainerController();
                    TrainerController trainerController = new TrainerController();
                    trainerController.GetTrainers().ForEach(x => { tempTrainers.Add(Helper.NewTrainer(x)); });
                    return tempTrainers as List<T>;
                    
                case List<Group>:
                    List<Group> groups = new List<Group>();
                    GroupController groupEditor = new GroupController();
                    foreach (var i in groupEditor.GetGroups())
                    {
                        Group group = new Group()
                        {
                            Id = i.Id,
                            GroupName = i.Name,
                            Description = i.Description,
                            Duration = i.Duration,
                            Time = i.Time,
                            Date = i.Date,

                        };
                        TrainerDto trainerDto = TrainerController.GetTrainerById(i.Trainer.TrainerId);
                        if (trainerDto != null)
                        {
                            group.Trainer = Helper.NewTrainer(trainerDto);
                        }
                        List<Member> members = new List<Member>();
                        foreach (var m in i.Members.MembersCollection)
                        {
                            MemberDto memberDto = MemberController.GetMemberById(m.MemberId);
                            if (memberDto != null)
                            {
                                members.Add(Helper.NewMember(memberDto));
                            }
                        }
                        group.Members = members;
                        groups.Add(group);
                    }
                    return groups as List<T>;
                default:
                    return new List<T>();
            }
        }
    }
}
