using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class Spectacle : Attraction
	{
		List<DateTime> horaire;
		int nbr_places;
		string nom_salle;
		public Spectacle  (int id, bool maintenance, string nature_maintenance, int nbr_min_monstres, string nom, bool ouvert, string type_besoin, bool besoin_spe, TimeSpan duree_maintenance, List<DateTime> horaire, int nbr_places,string nom_salle ):base(id,maintenance,nature_maintenance,nbr_min_monstres,nom,ouvert,type_besoin,besoin_spe,duree_maintenance)
		{
			this.horaire = horaire;
			this.nom_salle = nom_salle;
			this.nbr_places = nbr_places;
		}
	}
}

