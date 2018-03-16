using System;

namespace Zombillenium
{
    public class Demon : Monstre, IDemonable
	{
		int force;
		bool vanishable;
		public bool Vanishable
		{
			get{ return vanishable; }
			set{ vanishable = value; }
		}
        public Demon (int matricule, string nom, string prenom, string sexe, string fonction, int cagnotte, Attraction affectation,int force):base(matricule,nom,prenom,sexe,fonction,cagnotte,affectation)
		{
			this.force = force;
		}
	}
}

