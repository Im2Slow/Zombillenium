using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class Sorcier : Personnel
	{
		List<string> pouvoirs;
		string tatouage;
        public string Tatouage
        {
            get { return tatouage; }
        }
        public List<string> Pouvoirs
        {
            get { return pouvoirs; }
        }
        public Sorcier (int matricule, string nom, string prenom, string sexe, string fonction, string tatouage, List<string> pouvoirs):base(matricule,nom,prenom,sexe,fonction)
		{
			this.tatouage = tatouage;
			this.pouvoirs = pouvoirs;
		}
		public override string ToString()
		{
            string toReturn = base.ToString() + ", pouvoirs : ";
            foreach (string i in pouvoirs)
            {
                toReturn += " - " + i;
            }
            return toReturn;
		}
	}
}

