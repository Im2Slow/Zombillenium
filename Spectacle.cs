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
        public int Nbr_places
        {
            get { return nbr_places; }
            set { nbr_places = value; }
        }
        public string Nom_salle
        {
            get { return nom_salle; }
            set { nom_salle = value; }
        }
        public List<DateTime> Horaire
        {
            get { return horaire; }
            set { horaire = value; }
        }
		public override string ToString()
		{
            string toReturn = "";
            toReturn = base.ToString() + ", nom salle : " + nom_salle + " , nombre places : " + nbr_places + " , horaires : ";
            foreach (DateTime i in horaire)
            {
                toReturn += i.Hour + ":" + i.Minute + " ";
            }
            return toReturn;
		}
	}
}

