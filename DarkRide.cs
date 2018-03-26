using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class DarkRide : Attraction
	{
		TimeSpan duree;
		bool vehicule;
        public DarkRide(int id, string nom, int nbr_min_monstres, bool besoin_spe, string type_besoin, TimeSpan duree, bool vehicule) : base(id, nom, nbr_min_monstres, besoin_spe, type_besoin)
		{
			this.duree = duree;
			this.vehicule = vehicule;
		}
		public override string ToString()
		{
            return base.ToString() + " , duree : " + duree;
		}
	}
}

