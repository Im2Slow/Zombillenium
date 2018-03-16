using System;

namespace Zombillenium
{
	public class Zombie : Monstre
	{
		int degre_decomp;
		string couleur;
		bool vanishable;
		public bool Vanishable
		{
			get{ return vanishable; }
			set{ vanishable = value; }
		}
        public Zombie (int matricule, string nom, string prenom, string sexe, string fonction, int cagnotte, Attraction affectation,string couleur,int degre_decomp):base(matricule,nom,prenom,sexe,fonction,cagnotte, affectation)
		{
			this.degre_decomp = degre_decomp;
			this.couleur = couleur;
		}
	}
}

