using System;

namespace Zombillenium
{
	public class Demon : Monstre
	{
		int force;
		bool vanishable;
		public bool Vanishable
		{
			get{ return vanishable; }
			set{ vanishable = value; }
		}
		public Demon (int matricule, string nom, string prenom, string sexe, string fonction, Attraction affectation, int cagnotte, int force):base(matricule,nom,prenom,sexe,fonction,affectation,cagnotte)
		{
			this.force = force;
		}
	}
}

