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
        public Administration(string chemin)
        {
            attractions = new List<Attraction>();
            purgatory = new Boutique(57, "La barbe à SEGPA", 1, false, "", "barbe a papa");
            attractions.Add(purgatory);
            membres = new List<Personnel>();
        }
        public void AjoutAttraction(Attraction toAdd)
        {
            attractions.Add(toAdd);
        }
        public void AjoutPersonnel(Personnel toAdd)
        {
            membres.Add(toAdd);
        }
        public void Affecter(Monstre toBeAffected, Attraction toAffectTo)
        {
            toBeAffected.Affectation = toAffectTo;
        }
        public void GestionCagnotte(Monstre sujet, int montant) //nombre negatif pour retirer des points
        {
            sujet.Cagnotte += montant;
            if (sujet.Cagnotte < 50)
            {
                Affecter(sujet, purgatory);
            }
            else if (sujet.Cagnotte > 500)
            {
                if (sujet is IVanishable)
                {
                    (sujet as IVanishable).Vanish();
                }
            }
        }
        public List<Monstre> Equipe(Attraction attr)
        {
            List<Monstre> team = new List<Monstre>();
            foreach (Monstre i in membres)
            {
                if (i.Affectation == attr)
                {
                    team.Add(i);
                }
            }
            return team;
        }
        public void GestionEquipe() // check les types de monstres via des interfaces, mais n'accède pas encore aux caractéristiques propre à un monstre
        {
            foreach (Attraction i in attractions)
            {
                if (i.Ouvert)
                {
                    foreach (Monstre j in membres)
                    {
                        if (i.Besoin_spe)
                        {
                            if (i.Type_besoin == "Demon" && j is Demon && j.Affectation == null)
                            {
                                Affecter(j as Demon, i);
                            }
                            else if (i.Type_besoin == "Zombie" && j is Zombie && j.Affectation == null)
                            {
                                Affecter(j as Zombie, i);
                            }
                            else if (i.Type_besoin == "Vampire" && j is Vampire && j.Affectation == null)
                            {
                                Affecter(j as Vampire, i);;
                            }
                            else if (i.Type_besoin == "Fantome" && j is Fantome && j.Affectation == null)
                            {
                                Affecter(j as Fantome, i);
                            }
                            else if (i.Type_besoin == "LoupGarou" && j is LoupGarou && j.Affectation == null)
                            {
                                Affecter(j as LoupGarou, i);
                            }
                        }
                        if (Equipe(i).Count < i.Nbr_min_monstres && j.Affectation == null)
                        {
                            Affecter(j, i);
                        }
                    }
                }
            }
        }
        public void ReadCSV(string chemin) // ne check pas si les attractions sont ouvertes ou en maintenance
        {
            //si l'attraction affectée à un monstre à instancier n'existe pas, ne crée pas l'instance du monstre
            StreamReader monStreamReader = new StreamReader(chemin);
            string ligne = monStreamReader.ReadLine();

            while (ligne != null)
            {
                string[] temp = ligne.Split(';');
                if (temp[0] == "Sorcier")
                {
                    int temp1 = Int32.Parse(temp[1]);
                    foreach (Personnel i in membres)
                    {
                        if (i.Matricule == temp1)
                        {
                            Console.Write("Erreur : l'individu existe deja dans le logiciel"); //message d'erreur temporaire
                            System.Environment.Exit(1);
                        }
                    }
                    string[] listeValues = temp[7].Split('-');
                    List<string> powers = new List<string>();
                    foreach (string value in listeValues)
                    {
                        powers.Add(value);
                    }
                    Sorcier s = new Sorcier(temp1, temp[2], temp[3], temp[4], temp[5], temp[6], powers);
                    AjoutPersonnel(s);
                }
                else if (temp[0] == "Boutique" || temp[0] == "RollerCoaster" || temp[0] == "DarkRide" || temp[0] == "Spectacle")
                {
                    int temp1 = Int32.Parse(temp[1]);
                    foreach (Attraction i in attractions)
                    {
                        if (i.Id == temp1)
                        {
                            Console.Write("Erreur : l'individu existe deja dans le logiciel"); //message d'erreur temporaire
                            System.Environment.Exit(1);
                        }
                    }
                    int temp3 = Int32.Parse(temp[3]);
                    bool temp4 = Boolean.Parse(temp[4]);
                    switch (temp[0])
                    {
                        case "Boutique":
                            Boutique b = new Boutique(temp1, temp[2], temp3, temp4, temp[5], temp[6]); //est-ce qu'ajouter des instances du même nom à la liste pose probleme ? 
                            AjoutAttraction(b);                                                        
                            break;
                        case "RollerCoaster":
                            int temp7_rc = Int32.Parse(temp[7]);
                            float temp8_rc = float.Parse(temp[8]);
                            RollerCoaster r = new RollerCoaster(temp1, temp[2], temp3, temp4, temp[5], temp[6], temp7_rc, temp8_rc);
                            AjoutAttraction(r);
                            break;
                        case "Spectacle":
                            int temp7_s = Int32.Parse(temp[7]);
                            List<DateTime> tempList = new List<DateTime>();
                            string[] listeDate = temp[8].Split(':');
                            foreach (string value in listeDate)
                            {
                                tempList.Add(DateTime.Parse(value));
                            }
                            Spectacle s = new Spectacle(temp1, temp[2], temp3, temp4, temp[5], temp[6], temp7_s, tempList);
                            AjoutAttraction(s);
                            break;
                        case "DarkRide":
                            TimeSpan temp6_d = TimeSpan.Parse(temp[6]);
                            bool temp7_d = Boolean.Parse(temp[7]);
                            DarkRide d = new DarkRide(temp1, temp[2], temp3, temp4, temp[5], temp6_d, temp7_d);
                            AjoutAttraction(d);
                            break;
                    }
                }
                else
                {
                    int temp1 = Int32.Parse(temp[1]);
                    foreach (Monstre i in membres)
                    {
                        if (i.Matricule == temp1)
                        {
                            Console.Write("Erreur : l'individu existe deja dans le logiciel"); //message d'erreur temporaire
                            System.Environment.Exit(1);
                        }
                    }
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
                                    AjoutPersonnel(m);
                                    break;
                                case "Demon":
                                    int temp8 = Int32.Parse(temp[8]);
                                    Demon d = new Demon(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp8);
                                    AjoutPersonnel(d);
                                    break;
                                case "Fantome":
                                    Fantome f = new Fantome(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i);
                                    AjoutPersonnel(f);
                                    break;
                                case "Zombie":
                                    int temp9 = Int32.Parse(temp[9]);
                                    Zombie z = new Zombie(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp[8], temp9);
                                    AjoutPersonnel(z);
                                    break;
                                case "Vampire":
                                    float temp8_v = Int32.Parse(temp[8]);
                                    Vampire v = new Vampire(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp8_v);
                                    AjoutPersonnel(v);
                                    break;
                                case "LoupGarou":
                                    int temp8_lg = Int32.Parse(temp[8]);
                                    LoupGarou lg = new LoupGarou(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp8_lg);
                                    AjoutPersonnel(lg);
                                    break;

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

