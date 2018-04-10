using System;

namespace Zombillenium
{
    public class LoupGarou : Monstre
	{
		float indice_cruaute;
    
        public float Indice_cruaute
        {
            get { return indice_cruaute; }
        }

        public LoupGarou (int matricule, string nom, string prenom, string sexe, string fonction, int cagnotte, Attraction affectation, float indice_cruaute):base(matricule,nom,prenom,sexe,fonction,cagnotte, affectation)
		{
			this.indice_cruaute = indice_cruaute;
		}

        public override string ToString( )
        {
            return base.ToString() + ", cruauté = " + indice_cruaute;
        }
    }
}

