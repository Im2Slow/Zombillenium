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
		public Zombie (int matricule, string nom, string prenom, string sexe, string fonction, Attraction affectation, int cagnotte, int degre_decomp, string couleur):base(matricule,nom,prenom,sexe,fonction,affectation,cagnotte)
		{
			this.degre_decomp = degre_decomp;
			this.couleur = couleur;
		}
	}
}

