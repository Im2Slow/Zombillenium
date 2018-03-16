using System;
using System.Collections.Generic;
using System.IO;

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
            purgatory = new Boutique (57,"La barbe à SEGPA",1,false, "","barbe a papa");
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
		public void GestionCagnotte(Monstre sujet, int montant) //nombre negatif pour retirer des points
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
                if (i.Ouvert)
                {
                    foreach (Monstre j in membres)
                    {
                        if (i.Besoin_spe)
                        {
                            if (i.Type_besoin == "Demon" && j is IDemonable)
                            {
                                Equipe(i).Add(j);
                            }
                            else if (i.Type_besoin == "Zombie" && j is IZombiable)
                            {
                                Equipe(i).Add(j);
                            }
                            else if (i.Type_besoin == "Vampire" && j is IVampirable)
                            {
                                Equipe(i).Add(j);
                            }

                        }
                        if(Equipe(i).Count < i.Nbr_min_monstres && j.Affectation == null)
                        {
                            Equipe(i).Add(j);
                        }
                    }
                }
			}
		}
        public void ReadCSV(string chemin)
        {
            StreamReader monStreamReader = new StreamReader(chemin);
            string ligne = monStreamReader.ReadLine();

            while (ligne != null)
            {
                string[] temp = ligne.Split(';');
                if (temp[0] == "Sorcier")
                {
                    foreach (string val in temp)
                    {
                        int temp1 = Int32.Parse(temp[1]);
                        string[] listeValues = temp[7].Split('-');
                        List<string> powers = new List<string>();
                        foreach (string value in listeValues)
                        {
                            powers.Add(value);
                        }
                        Sorcier s = new Sorcier(temp1, temp[2], temp[3], temp[4], temp[5], temp[6], powers);
                        membres.Add(s);
                    }
                }
                else if (temp[0] == "Boutique" || temp[0] == "RollerCoaster" || temp[0] == "DarkRide" || temp[0] == "Spectacle")
                {
                    foreach (string val in temp)
                    {
                        int temp1 = Int32.Parse(temp[1]);
                        int temp3 = Int32.Parse(temp[3]);
                        bool temp4 = Boolean.Parse(temp[4]);
                        switch (temp[0])
                        {
                            case "Boutique":
                                Boutique b = new Boutique(temp1, temp[2], temp3, temp4, temp[5], temp[6]);
                                attractions.Add(b);
                                break;
                            case "RollerCoaster":
                                int temp7_rc = Int32.Parse(temp[7]);
                                float temp8_rc = float.Parse(temp[8]);
                                RollerCoaster r = new RollerCoaster(temp1, temp[2], temp3, temp4, temp[5], temp[6], temp7_rc,temp8_rc);
                                attractions.Add(r);
                                break;
                            case "Spectacle":
                                int temp7_s = Int32.Parse(temp[7]);
                                List<DateTime> tempList = new List<DateTime>();
                                string[] listeDate = temp[8].Split(':');
                                foreach (string value in listeDate)
                                {
                                    tempList.Add(DateTime.Parse(value));
                                }
                                Spectacle s = new Spectacle(temp1, temp[2], temp3, temp4, temp[5], temp[6], temp7_s,tempList);
                                attractions.Add(s);
                                break;
                            case "DarkRide":
                                TimeSpan temp6_d = TimeSpan.Parse(temp[6]);
                                bool temp7_d = Boolean.Parse(temp[7]);
                                DarkRide d = new DarkRide(temp1,temp[2],temp3,temp4,temp[5],temp6_d,temp7_d);
                                attractions.Add(d);
                                break;
                        }
                    }
                }
                else
                {
                    foreach (string val in temp)
                    {
                        int temp1 = Int32.Parse(temp[1]);
                        int temp6 = Int32.Parse(temp[6]);
                        int temp7 = Int32.Parse(temp[7]);
                        foreach (Attraction i in attractions)
                        {
                            if (i.Id == temp7)
                            {
                                switch (temp[0])
                                {
                                    case "Monstre":
                                        Monstre m = new Monstre(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i);
                                        membres.Add(m);
                                        break;
                                    case "Demon":
                                        int temp8 = Int32.Parse(temp[8]);
                                        Demon d= new Demon(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp8);
                                        membres.Add(d);
                                        break;
                                    case "Fantome":
                                        Fantome f = new Fantome(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i);
                                        membres.Add(f);
                                        break;
                                    case "Zombie":
                                        int temp9 = Int32.Parse(temp[9]);
                                        Zombie z = new Zombie(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i,temp[8],temp9);
                                        membres.Add(z);
                                        break;
                                    case "Vampire":
                                        float temp8_v = Int32.Parse(temp[8]);
                                        Vampire v = new Vampire(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp8_v);
                                        membres.Add(v);
                                        break;
                                    case "LoupGarou":
                                        int temp8_lg = Int32.Parse(temp[8]);
                                        LoupGarou lg = new LoupGarou(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp8_lg);
                                        membres.Add(lg);
                                        break;
                                        
                                } 
                            }
                        }
                    }
                }
                ligne = monStreamReader.ReadLine();
            }
            monStreamReader.Close();
        }
	}
}

//implementation interfaces et delegation

