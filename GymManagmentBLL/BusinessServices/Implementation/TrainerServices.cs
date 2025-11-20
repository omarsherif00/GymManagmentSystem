using GymManagmentBLL.BusinessServices.Interfaces;
using GymManagmentBLL.ViewModels.TrainerViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.UnitOfWorkPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Implementation
{
    internal class TrainerServices:ITrainerServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainerServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CreateTrainer(CreateTrainerViewModel CreateTrainer)
        {
            if(CreateTrainer is null|| isEmailExist(CreateTrainer.Email)|| isPhoneExist(CreateTrainer.Phone))
                return false;

            var trainer=new Trainer
            {
                Name = CreateTrainer.Name,
                Email = CreateTrainer.Email,
                Phone = CreateTrainer.Phone,
                DateOfBirth = CreateTrainer.DateOfBirth,
                Gender = CreateTrainer.Gender,
                Address=new Address
                {
                    BuildingNumber=CreateTrainer.BuildingNumber,
                    City=CreateTrainer.City,
                    Street=CreateTrainer.Street,
                },
                Speciality=CreateTrainer.Speciality,
            };

            try
            {
                _unitOfWork.GetRepositry<Trainer>().Add(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IEnumerable<TrainerViewModel> getaAlltrainers()
        {
            var Trainers = _unitOfWork.GetRepositry<Trainer>().GetAll();

            if (Trainers is null || !Trainers.Any())
                return [];
            return Trainers.Select(t => new TrainerViewModel
            {
                Id=t.id,
                Name=t.Name,
                Email=t.Email,
                Phone=t.Phone,
                specialties=t.Speciality.ToString(),
            });
        }
        public TrainerViewModel? GetTrainerDetails(int trainerId)
        {
            var trainer=_unitOfWork.GetRepositry<Trainer>().GetById(trainerId);

            if(trainer is null) return null;
            
            return new TrainerViewModel
            {
                Name=trainer.Name,
                Email=trainer.Email,
                Phone=trainer.Phone,
                DateOfBirth=trainer.DateOfBirth.ToShortDateString(),
                Gender=trainer.Gender.ToString(),
                Address=$"{trainer.Address.BuildingNumber}-{trainer.Address.Street}-{trainer.Address.City}",
                specialties=trainer.Speciality.ToString(), 


            };

        }
        public TrainerToUpdateViewModel GetTrainerToUpdate(int trainerId)
        {
            var trainer = _unitOfWork.GetRepositry<Trainer>().GetById(trainerId);
            if (trainer is null) return null;

            return new TrainerToUpdateViewModel
            {
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Speciality = trainer.Speciality,
                BuildingNumber = trainer.Address.BuildingNumber,
                City = trainer.Address.City,
                Street = trainer.Address.Street,

            };
        }

        public bool deleteTrainer(int trainerId)
        {
            var trainerRepo = _unitOfWork.GetRepositry<Trainer>();

            var trainer=trainerRepo.GetById(trainerId);
            if (trainer is null || HasFutureSession(trainerId)) return false;

            try
            {
                trainerRepo.Delete(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }




        public bool updateTrainer(int id, TrainerToUpdateViewModel trainerToUpdate)
        {
            var trainerRepo = _unitOfWork.GetRepositry<Trainer>();
            var EmailExistForAnotherOldTrainer=trainerRepo
                .GetAll(X=>X.Email==trainerToUpdate.Email && X.id!=id).Any();
            var PhoneExistForAnotherOldTrainer=trainerRepo
                .GetAll(X=>X.Phone==trainerToUpdate.Phone && X.id!=id).Any();
        
            if(EmailExistForAnotherOldTrainer||PhoneExistForAnotherOldTrainer||trainerToUpdate is null)
                return false;

            var trainer = trainerRepo.GetById(id);

            if(trainer is null) return false;

           
            trainer.Phone = trainerToUpdate.Phone;
            trainer.Email=trainerToUpdate.Email;
            trainer.Address.BuildingNumber = trainerToUpdate.BuildingNumber;
            trainer.Address.Street = trainerToUpdate.Street;
            trainer.Address.City = trainerToUpdate.City;
            trainer.Speciality = trainerToUpdate.Speciality;

            trainer.UpdatedAt=DateTime.Now;

            try
            {
                trainerRepo.Update(trainer);
                return _unitOfWork.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }

        }


        #region Helper Method
        private bool isEmailExist(string Email)
        {
            return _unitOfWork.GetRepositry<Trainer>().GetAll(X => X.Email == Email).Any();

        }
        private bool isPhoneExist(string phone)
        {
            return _unitOfWork.GetRepositry<Trainer>().GetAll(X => X.Phone == phone).Any();

        }

        private bool HasFutureSession(int trainerId)
        {
            return _unitOfWork.GetRepositry<session>()
                .GetAll(S=>S.TrainerId==trainerId&&S.StartDate>DateTime.Now)
                .Any();
        }

        #endregion
    }
}
