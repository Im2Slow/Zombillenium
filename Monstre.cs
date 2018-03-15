using System;

namespace Zombillenium
{
	public abstract class Monstre : Personnel
	{
		Attraction affectation;
		int cagnotte;

		 Monstre (int matricule, string nom, string prenom, string sexe, string fonction, Attraction affectation, int cagnotte):base(matricule,nom,prenom,sexe,fonction)
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
	}
}

