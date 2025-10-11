using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    internal class Member:GymUser
    {
        //join date hya hya created at

        public string photo { get; set; }


        #region RelationShips
        public HealthRecord HealthRecord { get; set; }

        public ICollection<MemberShip> Memberships { get; set; }

        public ICollection<MemberSession> MemberSessions { get; set; }

        #endregion

    }
}
