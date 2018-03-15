using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class Boutique : Attraction
	{
		string type;
		public Boutique  (int id, bool maintenance, string nature_maintenance, int nbr_min_monstres, string nom, bool ouvert, string type_besoin, bool besoin_spe, TimeSpan duree_maintenance, string type):base(id,maintenance,nature_maintenance,nbr_min_monstres,nom,ouvert,type_besoin,besoin_spe,duree_maintenance)
		{
			this.type = type;
		}
		public string Type
		{
			get { return type; }
			set { type = value; }
		}
	}
}

