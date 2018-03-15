using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class RollerCoaster : Attraction
	{
		int ageMin;
		string categorie;
		float tailleMin;
		public RollerCoaster (int id, bool maintenance, string nature_maintenance, int nbr_min_monstres, string nom, bool ouvert, string type_besoin, bool besoin_spe, TimeSpan duree_maintenance,int ageMin, string categorie, float tailleMin):base(id,maintenance,nature_maintenance,nbr_min_monstres,nom,ouvert,type_besoin,besoin_spe,duree_maintenance)
		{
			this.ageMin = ageMin;
			this.categorie = categorie;
			this.tailleMin = tailleMin;
		}
	}
}

