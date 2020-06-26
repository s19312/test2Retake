using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2Retake.Models
{
    public class FireFighter_Action
    {
        public int IdFireFighter { get; set; }
        public int IdAction { get; set; }


        public virtual FireFighter IdFireFighterNavigation { get; set; }

        public virtual Action IdActionNavigation { get; set; }
    }
}
