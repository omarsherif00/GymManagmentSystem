using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    public class session:BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Description { get; set; }
        public int Capacity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        public ICollection<MemberSession> Membersessions { get; set; }
    }
}
