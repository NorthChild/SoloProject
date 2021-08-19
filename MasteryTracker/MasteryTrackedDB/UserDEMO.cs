using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteryTrackedDB
{
    public partial class UserDEMO
    {

        public int UserID { get; set; }
        public virtual Users Users { get; set; }


    }
}
