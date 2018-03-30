using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class RollerCoaster : Attraction
	{
		int ageMin;
		string categorie;
		float tailleMin;
        public RollerCoaster (int id, string nom, int nbr_min_monstres,bool besoin_spe, string type_besoin, string categorie, int ageMin,float tailleMin):base(id,nom,nbr_min_monstres,besoin_spe,type_besoin)
		{
			this.ageMin = ageMin;
			this.categorie = categorie;
			this.tailleMin = tailleMin;
		}
        public int AgeMin
        {
            get { return ageMin; }
            set { ageMin = value; }
        }
        public float TailleMin
        {
            get { return tailleMin; }
            set { tailleMin = value; }
        }
        public string Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }
		public override string ToString()
		{
            return base.ToString() + " , age min : " + ageMin + " , categorie : " + categorie + " , taille min : " + tailleMin;
		}
	}
}

