using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class Spectacle : Attraction
	{
		List<DateTime> horaire;
		int nbr_places;
		string nom_salle;
        public Spectacle  (int id, string nom, int nbr_min_monstres, bool besoin_spe, string type_besoin, string nom_salle, int nbr_places, List<DateTime> horaire):base(id,nom,nbr_min_monstres,besoin_spe,type_besoin)
		{
			this.horaire = horaire;
			this.nom_salle = nom_salle;
			this.nbr_places = nbr_places;
		}
	}
}

