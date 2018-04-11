using System;
using System.Collections.Generic;
using System.IO;

namespace Zombillenium
{
    public class Administration
    {
        List<Attraction> attractions;
        List<Attraction> attractionsTrie;
        List<Personnel> membres;
        List<Personnel> membresTrie;
        Boutique purgatory;
        /// <summary>
        /// Constructeur de l'administration
        /// </summary>
        public Administration()
        {
            attractions = new List<Attraction>();
            purgatory = new Boutique(573, "Le purgatoire", 1, false, "", "barbe a papa");
            attractions.Add(purgatory);
            membres = new List<Personnel>();
        }
        public List<Attraction> Attractions
        {
            get { return attractions; }
        }
        public List<Attraction> AttractionsTrie
        {
            get { return attractionsTrie; }
        }
        public List<Personnel> Membres
        {
            get { return membres; }
        }
        public List<Personnel> MembresTrie
        {
            get { return membresTrie; }
        }
        /// <summary>
        /// Ajoute une attraction fournie a la liste des attractions du parc
        /// </summary>
        /// <param name="toAdd">Attraction a ajouter a la liste des attractions du parc</param>
        public void AjoutAttraction(Attraction toAdd)
        {
            attractions.Add(toAdd);
        }
        /// <summary>
        /// Ajoute un membre personnel fourni a la liste des membres du personnel du parc
        /// </summary>
        /// <param name="toAdd">Membre du personnel a ajouter a la liste des membres du personnel du parc</param>
        public void AjoutPersonnel(Personnel toAdd)
        {
            membres.Add(toAdd);
        }
        /// <summary>
        /// Affecte un monstre fourni a une attraction fournie
        /// </summary>
        /// <param name="toBeAffected">Monstre a affecter a l'attraction fournie</param>
        /// <param name="toAffectTo">Attraction a laquelle affecter le monstre fournie</param>
        public void Affecter(Monstre toBeAffected, Attraction toAffectTo)
        {
            toBeAffected.Affectation = toAffectTo;
        }
        /// <summary>
        /// Incremente la cagnotte du monstre fourni par un montant fourni. On utilise un montant negatif pour decrementer la cagnotte
        /// </summary>
        /// <param name="sujet">Monstre auquel incrementer la cagnotte</param>
        /// <param name="montant">Montant par lequel incrementer la cagnotte, negatif pour decrementer la cagnotte</param>
        public void GestionCagnotte(Monstre sujet, int montant)
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
        /// <summary>
        /// Genere et retourne la liste des monstres affectes a l'attraction fournie
        /// </summary>
        /// <param name="attr">Attraction a laquelle sont affecter les monstres a retourner</param>
        /// <returns>Liste des montres affectes a l'attraction fournie</returns>
        public List<Monstre> Equipe(Attraction attr)
        {
            List<Monstre> team = new List<Monstre>();
            foreach (Personnel i in membres)
            {
                if (i is Monstre)
                {
                    if ((i as Monstre).Affectation == attr)
                    {
                        team.Add(i as Monstre);
                    }
                }
            }
            return team;
        }
        /// <summary>
        /// Affecte automatiquement a chaque attraction des monstres en fonction des besoin de l'attraction, puis jusqu'a atteindre le nombre de monstre minimal devant etre affecter a chaque attraction, si possible
        /// </summary>
        public void GestionEquipe() // check les types de monstres , mais n'accède pas encore aux caractéristiques propre à un monstre
        {
            foreach (Attraction i in attractions)
            {
                if (i.Ouvert)
                {
                    foreach (Personnel j in membres)
                    {
                        if (i.Besoin_spe && j is Monstre)
                        {
                            if (i.Type_besoin == "demon" && j is Demon && (j as Monstre).Affectation == null)
                            {
                                Affecter(j as Demon, i);
                            }
                            else if (i.Type_besoin == "force" && j is Demon && (j as Monstre).Affectation == null)
                            {
                                if((j as Demon).Force >= i.NiveauRequis)
                                {
                                    Affecter(j as Demon, i);
                                }
                                Affecter(j as Demon, i);
                            }
                            else if (i.Type_besoin == "zombie" && j is Zombie && (j as Monstre).Affectation == null)
                            {
                                Affecter(j as Zombie, i);
                            }
                            else if (i.Type_besoin == "degre_decomposition" && j is Zombie && (j as Monstre).Affectation == null)
                            {
                                if ((j as Zombie).Degre_decomp >= i.NiveauRequis)
                                {
                                    Affecter(j as Zombie, i);
                                }
                            }
                            else if (i.Type_besoin == "vampire" && j is Vampire && (j as Monstre).Affectation == null)
                            {
                                Affecter(j as Vampire, i);
                            }
                            else if (i.Type_besoin == "indice_luminosite" && j is Vampire && (j as Monstre).Affectation == null)
                            {
                                if ((j as Vampire).Indice_luminosite >= i.NiveauRequis)
                                {
                                    Affecter(j as Vampire, i);
                                }
                            }
                            else if (i.Type_besoin == "fantome" && j is Fantome && (j as Monstre).Affectation == null)
                            {
                                Affecter(j as Fantome, i);
                            }
                            else if (i.Type_besoin == "loupgarou" && j is LoupGarou && (j as Monstre).Affectation == null)
                            {
                                Affecter(j as LoupGarou, i);
                            }
                            else if (i.Type_besoin == "indice_cruaute" && j is LoupGarou && (j as Monstre).Affectation == null)
                            {
                                if ((j as LoupGarou).Indice_cruaute >= i.NiveauRequis)
                                {
                                    Affecter(j as LoupGarou, i);
                                }
                            }
                        }
                            if (Equipe(i).Count < i.Nbr_min_monstres && j is Monstre && (j as Monstre).Affectation == null)
                        {
                            Affecter(j as Monstre, i);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Contruit un string representant les membres du personnel d'une liste de membres du personnel fourni en format CSV et l'ecrit dans le fichier decrit par son chemin fourni
        /// </summary>
        /// <param name="chemin">Chemin relatif du fichier</param>
        /// <param name="personnelsToWrite">Liste des membres du personnel a ecrire dans le fichier</param>
        public void WriteCSVPersonnel(string chemin, List<Personnel> personnelsToWrite)
        {
            try
            {
                StreamWriter stream = new StreamWriter(chemin, true);
                foreach (Personnel p in personnelsToWrite)
                {
                    string toWrite = p.Matricule + ";" + p.Nom + ";" + p.Prenom + ";" + p.Sexe + ";" + p.Fonction + ";";
                    if (p is Sorcier)
                    {
                        toWrite = "Sorcier;" + toWrite + (p as Sorcier).Tatouage + ";";
                        foreach (string pouvoir in (p as Sorcier).Pouvoirs)
                        {
                            toWrite += pouvoir + "-";
                        }
                        toWrite = toWrite.TrimEnd('-');
                        toWrite += ";";
                    }
                    else if (p is Monstre)
                    {

                        toWrite += +(p as Monstre).Cagnotte + ";";
                        if ((p as Monstre).Affectation != null)
                        {
                            toWrite += (p as Monstre).Affectation.Id + ";";
                        }
                        else
                        {
                            toWrite += "neant" + ";";
                        }
                        if (p is Demon)
                        {
                            toWrite = "Demon;" + toWrite + (p as Demon).Force + ";";
                        }
                        else if (p is Vampire)
                        {
                            toWrite = "Vampire;" + toWrite + (p as Vampire).Indice_luminosite + ";";
                        }
                        else if (p is Zombie)
                        {
                            toWrite = "Zombie;" + toWrite + (p as Zombie).Couleur + ";" + (p as Zombie).Degre_decomp + ";";
                        }
                        else if (p is Fantome)
                        {
                            toWrite = "Fantome;" + toWrite;
                        }
                        else if (p is LoupGarou)
                        {
                            toWrite = "LoupGarou;" + toWrite + (p as LoupGarou).Indice_cruaute + ";";
                        }
                        else
                        {
                            toWrite = "Monstre;" + toWrite;
                        }
                    }
                    else
                    {
                        toWrite = "Personnel;" + toWrite;
                    }
                    stream.WriteLine(toWrite);
                }
                stream.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("export: erreur lors de l'ecriture dans un fichier");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("export: erreur lors de l'ecriture dans un fichier");
            }

        }
        /// <summary>
        /// Contruit un string representant les attractions d'une liste d'attractions fournie en format CSV et l'ecrit dans le fichier decrit par son chemin fourni
        /// </summary>
        /// <param name="chemin">chemin relatif du fichier</param>
        /// <param name="attractionsToWrite">liste d'attractions a ecrire dans le fichier</param>
        public void WriteCSVAttractions(string chemin, List<Attraction> attractionsToWrite)
        {
            try
            {
                StreamWriter stream = new StreamWriter(chemin, true);
                foreach (Attraction a in attractionsToWrite)
                {
                    string toWrite = a.Id + ";" + a.Nom + ";" + a.Nbr_min_monstres + ";" + a.Besoin_spe + ";" + a.Type_besoin + ";";
                    if (a is Boutique)
                    {
                        toWrite = "Boutique;" + toWrite + (a as Boutique).Type + ";";
                    }
                    else if (a is RollerCoaster)
                    {
                        toWrite = "RollerCoaster;" + toWrite + (a as RollerCoaster).Categorie + ";" + (a as RollerCoaster).AgeMin + ";" + (a as RollerCoaster).TailleMin + ";";
                    }
                    else if (a is DarkRide)
                    {
                        toWrite = "DarkRide;" + toWrite + (a as DarkRide).Duree + ";" + (a as DarkRide).Vehicule + ";";
                    }
                    else if (a is Spectacle)
                    {
                        toWrite = "DarkRide;" + toWrite + (a as Spectacle).Nom_salle + ";" + (a as Spectacle).Nbr_places + ";";
                        foreach (DateTime time in (a as Spectacle).Horaire)
                        {
                            toWrite += time.ToString("HH:mm") + " ";
                        }
                        toWrite += ";";
                    }
                    else
                    {
                        toWrite = "Attraction;" + toWrite;
                    }
                    stream.WriteLine(toWrite);
                }
                stream.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("export: erreur lors de l'ecriture dans un fichier");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("export: erreur lors de l'ecriture dans un fichier");
            }

        }
        /// <summary>
        /// Lis un ficher dont le chemin est fourni et en interprete le contenu en creant les personnels et attractions decrit en format CSV
        /// </summary>
        /// <param name="chemin">chemin relatif du fichier a lire</param>
        public void ReadCSV(string chemin)
        {
            StreamReader monStreamReader = new StreamReader(chemin);
            string ligne;
            while ((ligne = monStreamReader.ReadLine()) != null)
            {
                string[] temp = ligne.Split(';');
                int temp1 = Int32.Parse(temp[1]);
                if (temp[0] == "Sorcier")
                {
                    string[] listeValues = temp[7].Split('-');
                    List<string> powers = new List<string>();
                    foreach (string value in listeValues)
                    {
                        powers.Add(value);
                    }
                    Sorcier so = new Sorcier(temp1, temp[2], temp[3], temp[4], temp[5], temp[6], powers);
                    AjoutPersonnel(so);
                }
                else if (temp[0] == "Boutique" || temp[0] == "RollerCoaster" || temp[0] == "DarkRide" || temp[0] == "Spectacle")
                {
                    int temp3 = Int32.Parse(temp[3]);
                    bool temp4 = Boolean.Parse(temp[4]);
                    switch (temp[0])
                    {
                        case "Boutique":
                            Boutique b;
                            if (temp4)
                            {
                                b = new Boutique(temp1, temp[2], temp3, temp4, temp[5], temp[6]);
                            }
                            else
                            {
                                b = new Boutique(temp1, temp[2], temp3, temp4, "", temp[5]);
                            }
                            AjoutAttraction(b);;
                            break;
                        case "RollerCoaster":
                            int temp7_rc = Int32.Parse(temp[7]);
                            float temp8_rc = float.Parse(temp[8]);
                            RollerCoaster rc = new RollerCoaster(temp1, temp[2], temp3, temp4, temp[5], temp[6], temp7_rc, temp8_rc);
                            AjoutAttraction(rc);
                            break;
                        case "Spectacle":
                            int temp7_s = Int32.Parse(temp[7]);
                            List<DateTime> tempList = new List<DateTime>();
                            string[] listeDate = temp[8].Split(' ');
                            foreach (string value in listeDate)
                            {
                                tempList.Add(DateTime.Parse(value));
                            }
                            Spectacle sp = new Spectacle(temp1, temp[2], temp3, temp4, temp[5], temp[6], temp7_s, tempList);
                            AjoutAttraction(sp);
                            break;
                        case "DarkRide":
                            TimeSpan temp6_d = TimeSpan.Parse(temp[6]);
                            bool temp7_d = Boolean.Parse(temp[7]);
                            DarkRide dr = new DarkRide(temp1, temp[2], temp3, temp4, temp[5], temp6_d, temp7_d);
                            AjoutAttraction(dr);
                            break;
                    }
                }
                else
                {
                    int temp6 = Int32.Parse(temp[6]);
                    int temp7;
                    try
                    {
                        temp7 = Int32.Parse(temp[7]);
                    }
                    catch (FormatException)
                    {
                        temp7 = -1;
                    }
                        switch (temp[0])
                        {
                            case "Monstre":
                                foreach (Attraction i in attractions)
                                {
                                    if (i.Id == temp7)
                                    {
                                        Monstre m = new Monstre(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i);
                                        AjoutPersonnel(m);
                                    }
                                }
                                if (temp7 == -1)
                                {
                                    Monstre m = new Monstre(temp1, temp[2], temp[3], temp[4], temp[5], temp6, null);
                                    AjoutPersonnel(m);
                                }
                                break;
                            case "Demon":
                                int temp8;
                                try
                                {
                                    temp8 = Int32.Parse(temp[8]);
                                }
                                catch (FormatException)
                                {
                                    temp8 = -1;
                                }
                                foreach (Attraction i in attractions)
                                {
                                    if (i.Id == temp7)
                                    {
                                        Demon d = new Demon(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp8);
                                        //Console.WriteLine(d.ToString());
                                     AjoutPersonnel(d);
                                    }
                                }
                                if (temp7 == -1)
                                {
                                    Demon d = new Demon(temp1, temp[2], temp[3], temp[4], temp[5], temp6, null, temp8);
                                    //Console.WriteLine(d.ToString());
                                    AjoutPersonnel(d);
                                }
                                break;
                            case "Fantome":
                                foreach (Attraction i in attractions)
                                {
                                    if (i.Id == temp7)
                                    {
                                        Fantome f = new Fantome(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i);
                                        AjoutPersonnel(f);
                                    }
                                }
                                if (temp7 == -1)
                                {
                                    Fantome f = new Fantome(temp1, temp[2], temp[3], temp[4], temp[5], temp6, null);
                                    AjoutPersonnel(f);
                                }
                                break;
                            case "Zombie":
                                int temp9;
                                try
                                {
                                    temp9 = Int32.Parse(temp[9]);
                                }
                                catch (FormatException)
                                {
                                    temp9 = -1;
                                }
                                foreach (Attraction i in attractions)
                                {
                                    if (i.Id == temp7)
                                    {
                                    Zombie z = new Zombie(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp[8], temp9);
                                    AjoutPersonnel(z);
                                    }
                                }
                                if (temp7 == -1)
                                {
                                    Zombie z = new Zombie(temp1, temp[2], temp[3], temp[4], temp[5], temp6, null, temp[8], temp9);
                                    AjoutPersonnel(z);
                                }
                                break;
                            case "Vampire":
                                float temp8_v;
                                try
                                {
                                    temp8_v = float.Parse(temp[8]);
                                }
                                catch (FormatException)
                                {
                                    temp8_v = -1;
                                }
                                foreach (Attraction i in attractions)
                                {
                                    if (i.Id == temp7)
                                    {
                                        Vampire v = new Vampire(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp8_v);
                                        AjoutPersonnel(v);
                                    }
                                }
                                if (temp7 == -1)
                                {
                                    Vampire v = new Vampire(temp1, temp[2], temp[3], temp[4], temp[5], temp6, null, temp8_v);
                                    AjoutPersonnel(v);
                                }
                                break;
                            case "LoupGarou":
                                float temp8_lg;
                                try
                                {
                                    temp8_lg = float.Parse(temp[8]);
                                }
                                catch (FormatException)
                                {
                                    temp8_lg = -1;
                                }
                                foreach (Attraction i in attractions)
                                {
                                    if (i.Id == temp7)
                                    {
                                        LoupGarou lg = new LoupGarou(temp1, temp[2], temp[3], temp[4], temp[5], temp6, i, temp8_lg);
                                        AjoutPersonnel(lg);
                                    }
                                }
                                if (temp7 == -1)
                                {
                                    LoupGarou lg = new LoupGarou(temp1, temp[2], temp[3], temp[4], temp[5], temp6, null, temp8_lg);
                                    AjoutPersonnel(lg);
                                }
                                break;
                        }
                }

            }
            monStreamReader.Close();
        }
        /// <summary>
        /// Trie les membres du personnel selon un critere de comparaison fourni en utilisant une liste des membres du personnel tries distinct de la liste des membres du personnel du parc
        /// </summary>
        /// <param name="comparisonParameter">critere de comparaison</param>
        public void SortPersonnelList(string comparisonParameter)
        {
            try
            {
                membresTrie = new List<Personnel>();
                foreach(Personnel p in membres)
                {
                    switch (comparisonParameter)
                    {
                        case "nom":
                        case "prenom":
                        case "matricule":
                        case "fonction":
                        case "sexe":
                        case "type":
                            membresTrie.Add(p);
                            break;
                        case "cagnotte":
                            if (p is Monstre)
                            {
                                membresTrie.Add(p);
                            }
                            break;
                        case "force":
                            if(p is Demon)
                            {
                                membresTrie.Add(p);
                            }
                            break;
                        case "indice_luminosite":
                            if (p is Vampire)
                            {
                                membresTrie.Add(p);
                            }
                            break;
                    }
                }
                membresTrie.Sort(delegate (Personnel p1, Personnel p2)
                {
                    int toReturn = 0;
                    switch (comparisonParameter)
                    {
                        case "nom":
                            toReturn = String.Compare(p1.Nom, p2.Nom);
                            break;
                        case "prenom":
                            toReturn = String.Compare(p1.Prenom, p2.Prenom);
                            break;
                        case "matricule":
                            toReturn = p1.Matricule - p2.Matricule;
                            break;
                        case "fonction":
                            toReturn = String.Compare(p1.Fonction, p2.Fonction);
                            break;
                        case "sexe":
                            toReturn = String.Compare(p1.Sexe, p2.Sexe);
                            break;
                        case "cagnotte":
                            if (p1 is Monstre && p2 is Monstre)
                            {
                                toReturn = (p1 as Monstre).Cagnotte - (p2 as Monstre).Cagnotte;
                            }
                            break;
                        case "type":
                            toReturn = TypeToInt(p1) - TypeToInt(p2);
                            break;
                        case "force":
                            if (p1 is Demon && p2 is Demon)
                            {
                                toReturn = (p1 as Demon).Force - (p2 as Demon).Force;
                            }
                            break;
                        case "indice_luminoste":
                            if (p1 is Vampire && p2 is Vampire)
                            {
                                toReturn = Convert.ToInt32(10 * ((p1 as Vampire).Indice_luminosite - (p2 as Vampire).Indice_luminosite));
                            }
                            break;
                    }
                    return toReturn;
                });
            }
            catch (NullReferenceException)
            {
            }
        }
        /// <summary>
        /// Retourne un entier en fonction du type d'un membre du personnel fourni pour comparaison
        /// </summary>
        /// <param name="p">Membre du personnel</param>
        /// <returns>Entier en fonction du type du membre du personnel</returns>
        private int TypeToInt(Personnel p)
        {
            int toReturn = 0;
            if (p is Zombie)
            {
                toReturn = 100;
            }
            else if (p is Demon)
            {
                toReturn = 101;
            }
            else if (p is LoupGarou)
            {
                toReturn = 102;
            }
            else if (p is Fantome)
            {
                toReturn = 103;
            }
            else if (p is Vampire)
            {
                toReturn = 104;
            }
            else if (p is Monstre)
            {
                toReturn = 10;
            }
            else if (p is Sorcier)
            {
                toReturn = 11;
            }
            else if (p is Personnel)
            {
                toReturn = 1;
            }
            return toReturn;
        }
        /// <summary>
        /// Trie les attractions selon un critere de comparaison fourni en utilisant une liste d'attractions triees distinct de la liste d'attractions du parc
        /// </summary>
        /// <param name="comparisonParameter">critere de comparaison</param>
        public void SortAttractionlList(string comparisonParameter)
        {
            try
            {
                attractionsTrie = new List<Attraction>();
                foreach (Attraction a in attractions)
                {
                    switch (comparisonParameter)
                    {
                        case "nom":
                        case "id":
                        case "nbr_min_monstres":
                        case "besoin_spe":
                        case "maintenance":
                        case "type_besoin":
                        case "ouvert":
                        case "nature_maintenance":
                            attractionsTrie.Add(a);
                            break;
                        case "type_boutique":
                            if (a is Boutique)
                            {
                                attractionsTrie.Add(a);
                            }
                            break;
                        case "vehicule":
                            if (a is DarkRide)
                            {
                                attractionsTrie.Add(a);
                            }
                            break;
                        case "ageMin":
                        case "categorie":
                            if (a is RollerCoaster)
                            {
                                attractionsTrie.Add(a);
                            }
                            break;
                        case "nbr_places":
                        case "nom_salle":
                            if (a is Spectacle)
                            {
                                attractionsTrie.Add(a);
                            }
                            break;
                    }
                }
                attractionsTrie.Sort(delegate (Attraction a1, Attraction a2)
                {
                    int toReturn = 0;
                    switch (comparisonParameter)
                    {
                        case "nom":
                            toReturn = String.Compare(a1.Nom, a2.Nom);
                            break;
                        case "id":
                            toReturn = a1.Id - a2.Id;
                            break;
                        case "nbr_min_monstres":
                            toReturn = a1.Nbr_min_monstres - a2.Nbr_min_monstres;
                            break;
                        case "besoin_spe":
                            if (a1.Besoin_spe && !a2.Besoin_spe)
                            {
                                toReturn = -1;
                            }
                            else if (!a1.Besoin_spe && a2.Besoin_spe)
                            {
                                toReturn = 1;
                            }
                            break;
                        case "maintenance":
                            if (a1.Maintenance && !a2.Maintenance)
                            {
                                toReturn = -1;
                            }
                            else if (!a1.Maintenance && a2.Maintenance)
                            {
                                toReturn = 1;
                            }
                            break;
                        case "type_besoin":
                            toReturn = String.Compare(a1.Type_besoin, a2.Type_besoin);
                            break;
                        case "ouvert":
                            if (a1.Ouvert && !a2.Ouvert)
                            {
                                toReturn = -1;
                            }
                            else if (!a1.Ouvert && a2.Ouvert)
                            {
                                toReturn = 1;
                            }
                            break;
                        case "nature_maintenance":
                            toReturn = String.Compare(a1.Nature_maintenance, a2.Nature_maintenance);
                            break;
                        case "type_boutique":
                            if (a1 is Boutique && a2 is Boutique)
                            {
                                toReturn = String.Compare((a1 as Boutique).Type, (a2 as Boutique).Type);
                            }
                            break;
                        case "vehicule":
                            if (a1 is DarkRide && a2 is DarkRide)
                            {
                                if ((a1 as DarkRide).Vehicule && !(a2 as DarkRide).Vehicule)
                                {
                                    toReturn = -1;
                                }
                                else if (!(a1 as DarkRide).Vehicule && (a2 as DarkRide).Vehicule)
                                {
                                    toReturn = 1;
                                }
                            }
                            break;
                        case "ageMin":
                            if (a1 is RollerCoaster && a2 is RollerCoaster)
                            {
                                toReturn = (a1 as RollerCoaster).AgeMin - (a2 as RollerCoaster).AgeMin;
                            }
                            break;
                        case "categorie":
                            if (a1 is RollerCoaster && a2 is RollerCoaster)
                            {
                                toReturn = String.Compare((a1 as RollerCoaster).Categorie, (a2 as RollerCoaster).Categorie);
                            }
                            break;
                        case "nbr_places":
                            if (a1 is Spectacle && a2 is Spectacle)
                            {
                                toReturn = (a1 as Spectacle).Nbr_places - (a2 as Spectacle).Nbr_places;
                            }
                            break;
                        case "nom_salle":
                            if (a1 is Spectacle && a2 is Spectacle)
                            {
                                toReturn = String.Compare((a1 as Spectacle).Nom_salle, (a2 as Spectacle).Nom_salle);
                            }
                            break;
                    }
                    return toReturn;
                });
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}
//implementation interfaces et delegation

