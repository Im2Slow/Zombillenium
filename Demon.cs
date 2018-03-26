using System;

namespace Zombillenium
{
    public class Demon : Monstre, IVanishable
	{
		int force;
        public Demon (int matricule, string nom, string prenom, string sexe, string fonction, int cagnotte, Attraction affectation,int force):base(matricule,nom,prenom,sexe,fonction,cagnotte,affectation)
		{
			this.force = force;
		}
		public override string ToString()
		{
            return base.ToString() + ", force : " + force;
		}
	}
}

