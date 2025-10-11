using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    public class MemberSession:BaseEntity
    {

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int SessionId { get; set; }
        public session Session { get; set; }

        public bool IsAttended { get; set; }
    }
}
