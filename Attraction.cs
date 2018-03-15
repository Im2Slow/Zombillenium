using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public abstract class Attraction
	{
		bool besoin_spe;
		TimeSpan duree_maintenance;
		int id;
		bool maintenance;
		string nature_maintenance;
		int nbr_min_monstres;
		string nom;
		bool ouvert;
		string type_besoin;

		 Attraction (int id, bool maintenance, string nature_maintenance, int nbr_min_monstres, string nom, bool ouvert, string type_besoin, bool besoin_spe, TimeSpan duree_maintenance)
		{
            this.id = id;
			this.maintenance = maintenance;
			this.nature_maintenance = nature_maintenance;
			this.nbr_min_monstres = nbr_min_monstres;
			this.nom = nom;
			this.ouvert = ouvert;
			this.type_besoin = type_besoin;
			this.besoin_spe = besoin_spe;
			this.duree_maintenance = duree_maintenance;
		}
		public bool Maintenance
		{
			get{ return maintenance; }
			set{ maintenance = value; }
		}
	}
}

