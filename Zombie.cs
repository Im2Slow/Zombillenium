using System;

namespace Zombillenium
{
    public class Zombie : Monstre, IVanishable
	{
		int degre_decomp;
		string couleur;

        public int Degre_decomp
        {
            get { return degre_decomp; }
        }
        public string Couleur
        {
            get { return couleur; }
        }
        public Zombie (int matricule, string nom, string prenom, string sexe, string fonction, int cagnotte, Attraction affectation,string couleur,int degre_decomp):base(matricule,nom,prenom,sexe,fonction,cagnotte, affectation)
		{
			this.degre_decomp = degre_decomp;
			this.couleur = couleur;
		}
	}
}

