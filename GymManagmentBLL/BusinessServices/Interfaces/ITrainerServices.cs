using GymManagmentBLL.ViewModels.TrainerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.BusinessServices.Interfaces
{
    internal interface ITrainerServices
    {
        IEnumerable<TrainerViewModel> getaAlltrainers();

        bool CreateTrainer(CreateTrainerViewModel CreateTrainer);

        TrainerViewModel? GetTrainerDetails(int trainerId);

        TrainerToUpdateViewModel GetTrainerToUpdate(int trainerId);

        bool updateTrainer(int id, TrainerToUpdateViewModel trainerToUpdate);

        bool deleteTrainer(int trainerId);

    }
}
