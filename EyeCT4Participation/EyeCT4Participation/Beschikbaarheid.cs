using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeCT4Participation
{
    class Beschikbaarheid
    {
        public int Dag { get; private set; }

        public int Dagdeel { get; private set; }

        public int id { get; private set; }
        public int gebruikerID { get; private set; }

        public Beschikbaarheid(int id, int dag, int dagdeel, int gebruikerid)
        {
            this.id = id;
            this.Dag = dag;
            this.Dagdeel = dagdeel;
            this.gebruikerID = gebruikerid;
        }

        public override string ToString()
        {
            return Dag + " " + Dagdeel;
        }
    }
}
