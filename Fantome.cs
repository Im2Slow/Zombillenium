using System;

namespace Zombillenium
{
    public class Fantome : Monstre, IFantomable
	{
        public Fantome (int matricule, string nom, string prenom, string sexe, string fonction, int cagnotte, Attraction affectation):base(matricule,nom,prenom,sexe,fonction,cagnotte, affectation)
		{
		}
	}
}

