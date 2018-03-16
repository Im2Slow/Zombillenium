using System;

namespace Zombillenium
{
    public class LoupGarou : Monstre
	{
		int indice_cruaute;

        public LoupGarou (int matricule, string nom, string prenom, string sexe, string fonction, int cagnotte, Attraction affectation, int indice_cruaute):base(matricule,nom,prenom,sexe,fonction,cagnotte, affectation)
		{
			this.indice_cruaute = indice_cruaute;
		}
	}
}

