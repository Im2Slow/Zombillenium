using System;
using System.Collections.Generic;
namespace Zombillenium
{
	public class Administration
	{
		List<Attraction> attractions;
		List<Personnel> membres;
        Boutique purgatory;
		public Administration (string chemin)
		{
			attractions = new List<Attraction> ();
            purgatory = new Boutique (57, false, "", 1, "La barbe à SEGPA", false, "", false,, "barbe a papa");
            attractions.Add(purgatory);
			membres = new List<Personnel> ();
		}
		public void AjoutAttraction(Attraction toAdd)
		{
			attractions.Add(toAdd);
		}
		public void AjoutPersonnel(Personnel toAdd)
		{
			membres.Add (toAdd);
		}
		public void Affecter(Monstre toBeAffected, Attraction toAffectTo)
		{
			toBeAffected.Affectation = toAffectTo;
		}
		public void GestionCagnotte(Monstre sujet, int montant)
		{
			sujet.Cagnotte += montant;
			if (sujet.Cagnotte < 50) {
				foreach (Boutique i in attractions) {
					if (i.Type == "barbe a papa") {
						purgatory = i;
					}
				}
				Affecter (sujet, purgatory);
			} 
			else if (sujet.Cagnotte > 500) 
			{
                if (sujet is Demon)
                {
                    (sujet as Demon).Vanishable = true;
                }

                else if (sujet is Zombie)
                {
                    (sujet as Zombie).Vanishable = true;
                }
				sujet.Affectation = null;
			}
		}
		public List<Monstre> Equipe(Attraction attr)
		{
			List<Monstre> team = new List<Monstre> ();
			foreach (Monstre i in membres)
			{
				if (i.Affectation == attr)
				{
					team.Add (i);
				}
			}
			return team;
		}
		public void GestionEquipe()
		{
			foreach (Attraction i in attractions)
			{
				if(i.
			}
		}
	}
}

