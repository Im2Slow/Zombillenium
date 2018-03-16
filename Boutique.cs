using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public class Boutique : Attraction
	{
		string type;
        public Boutique  (int id,string nom, int nbr_min_monstres,bool besoin_spe, string type_besoin , string type):base(id,nom,nbr_min_monstres,besoin_spe,type_besoin)
		{
			this.type = type;
		}
		public string Type
		{
			get { return type; }
			set { type = value; }
		}
	}
}

