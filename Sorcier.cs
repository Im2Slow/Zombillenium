using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class Sorcier : Personnel
	{
		List<string> pouvoirs;
		string tatouage;
		public Sorcier (int matricule, string nom, string prenom, string sexe, string fonction, List<string> pouvoirs, string tatouage):base(matricule,nom,prenom,sexe,fonction)
		{
			this.tatouage = tatouage;
			this.pouvoirs = pouvoirs;
		}
	}
}

