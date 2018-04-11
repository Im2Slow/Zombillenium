using System;

namespace Zombillenium
{
	public class Monstre : Personnel
	{
		Attraction affectation;
		int cagnotte;

        public Monstre (int matricule, string nom, string prenom, string sexe, string fonction, int cagnotte, Attraction affectation):base(matricule,nom,prenom,sexe,fonction)
		{
			this.affectation = affectation;
			this.cagnotte = cagnotte;
		}

		public int Cagnotte
		{
			get{ return cagnotte; }
			set{ cagnotte = value; }
		}

        public Attraction Affectation
		{
			get {return this.affectation;}
			set { affectation = value; }
		}
        /// <summary>
        /// Supprime l'affectation d'un monstre a une attraction
        /// </summary>
        public void Vanish()
        {
            affectation = null;
        }
		public override string ToString()
		{
            string toReturn = base.ToString() + ", cagnotte : " + cagnotte + ", affectation : ";
            if (affectation != null)
            {
                toReturn += affectation.Id;
            }
            else
            {
                toReturn += "neant";
            }
            return toReturn;
		}
	}
}

