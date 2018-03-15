using System;

namespace Zombillenium
{
	public class Vampire : Monstre
	{
		float indice_luminosite;
		public Vampire (int matricule, string nom, string prenom, string sexe, string fonction, Attraction affectation, int cagnotte, float indice_luminosite):base(matricule,nom,prenom,sexe,fonction,affectation,cagnotte)
		{
			this.indice_luminosite = indice_luminosite;
		}
	}
}

