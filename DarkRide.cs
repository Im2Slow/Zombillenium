using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class DarkRide : Attraction
	{
		TimeSpan duree;
		bool vehicule;
		public DarkRide (int id, bool maintenance, string nature_maintenance, int nbr_min_monstres, string nom, bool ouvert, string type_besoin, bool besoin_spe, TimeSpan duree_maintenance, TimeSpan duree,  bool vehicule):base(id,maintenance,nature_maintenance,nbr_min_monstres,nom,ouvert,type_besoin,besoin_spe,duree_maintenance)
		{
			this.duree = duree;
			this.vehicule = vehicule;
		}
	}
}

