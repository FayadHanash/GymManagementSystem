using GymManagementSystemDAL.Data;
using GymManagementSystemDAL.Dtos;

namespace GymManagementSystemDAL.Controllers
{
    /// <summary>
    /// Class that handles Trainer data in the database
    /// </summary>
    public class TrainerController
    {
        #region Methods
        /// <summary>
        /// Method that adds a new trainer to database
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns>True if the trainer added, otherwise false</returns>
        public static bool CreateTrainer(TrainerDto trainer)
        {
            using (GymMSContext db = new GymMSContext())
            {
                try
                {
                    db.Trainers.Add(trainer);
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
        /// Method that gets all trainers from database
        /// </summary>
        /// <returns></returns>
        public List<TrainerDto> GetTrainers()
        {
            List<TrainerDto> temp = new List<TrainerDto>();
            using (GymMSContext db = new GymMSContext())
            {
                var trainerDtos = (from m in db.Trainers
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


                foreach (var trainer in trainerDtos)
                    temp.Add(new TrainerDto()
                    {
                        Id = trainer.Id,
                        FirstName = trainer.FirstName,
                        LastName = trainer.LastName,
                        PersonNumber = trainer.PersonNumber,
                        Email = trainer.Email,
                        Phone = trainer.Phone,
                        Birthdate = trainer.Birthdate,
                        DateRegistered = trainer.DateRegistered,
                        Gender = trainer.Gender,
                        Address = new AddressDto()
                        {
                            Street = trainer.Address.Street,
                            City = trainer.Address.City,
                            Country = trainer.Address.Country,
                            ZipCode = trainer.Address.ZipCode
                        }

                    });
            }
            return temp;
        }

        /// <summary>
        /// Method that updates a trainer in the database
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns>True if the trainer updated, otherwise false</returns>
        public static bool UpdateTrainer(TrainerDto trainer)
        {
            using (GymMSContext db = new GymMSContext())
            {
                try
                {
                    var trainerToUpdate = db.Trainers.FirstOrDefault(m => m.Id == trainer.Id);
                    trainerToUpdate.FirstName = trainer.FirstName;
                    trainerToUpdate.LastName = trainer.LastName;
                    trainerToUpdate.PersonNumber = trainer.PersonNumber;
                    trainerToUpdate.Email = trainer.Email;
                    trainerToUpdate.Phone = trainer.Phone;
                    trainerToUpdate.Birthdate = trainer.Birthdate;
                    trainerToUpdate.DateRegistered = trainer.DateRegistered;
                    trainerToUpdate.Gender = trainer.Gender;
                    trainerToUpdate.Address = new AddressDto()
                    {
                        Street = trainer.Address.Street,
                        City = trainer.Address.City,
                        Country = trainer.Address.Country,
                        ZipCode = trainer.Address.ZipCode
                    };

                    db.Update(trainerToUpdate);
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
        /// Method that deletes a trainer from database 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if the trainer deleted, otherwise false</returns>
        public static bool DeleteTrainer(int id)
        {
            using (GymMSContext db = new GymMSContext())
            {
                try
                {
                    TrainerDto trainer = db.Trainers.Where(x => x.Id == id).FirstOrDefault();
                    db.Trainers.Remove(trainer);
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
        /// Method that returns a trainer from the database by a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TrainerDto GetTrainerById(int id)
        {
            using (GymMSContext db = new GymMSContext())
            {
                var trainer = (from m in db.Trainers
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

                if (trainer != null)
                {
                    TrainerDto trainerDto = new TrainerDto()
                    {
                        Id = trainer.Id,
                        FirstName = trainer.FirstName,
                        LastName = trainer.LastName,
                        PersonNumber = trainer.PersonNumber,
                        Email = trainer.Email,
                        Phone = trainer.Phone,
                        Birthdate = trainer.Birthdate,
                        DateRegistered = trainer.DateRegistered,
                        Gender = trainer.Gender,
                        Address = trainer.Address
                        
                    };
                    return trainerDto;
                }
            }
            return null;
        }

        #endregion Methods
    }

}
