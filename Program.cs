using System;
using System.IO;
using System.Collections.Generic;

namespace Zombillenium
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            Menu();
		}
        /// <summary>
        /// Affiche un menu dans la console avec lequel interagir par le biais du clavier
        /// </summary>
        static void Menu()
        {
            bool stopAccueil = false;
            Administration parc = new Administration();
            const int CAGNOTTE_DEPART = 50;
            while (stopAccueil == false)
            {
                Console.WriteLine("Bienvenue sur le logiciel de gestion de Zombilenium, choissisez une action à effectuer en entrant le chiffre correspondant : \n 1) Gerer personnel \n 2) Gerer attractions \n 3) Importer via CSV \n 4) Exporter \n 0) Quitter");
                int reponseAccueil = 0;
                try { reponseAccueil= int.Parse(Console.ReadLine()); }
                catch (FormatException) { Console.WriteLine("Veuillez respecter le format"); }
                switch (reponseAccueil)
                {
                    case 1:
                        Console.Clear();
                        bool stopPersonnel = false;
                        while (stopPersonnel == false)
                        {
                            Console.WriteLine("Gestion du personnel : \n 1) Afficher la liste des membres du personnel \n 2) Ajouter un nouveau membre \n 3) Modifier un membre spécifique via matricule (Ce processus est irréversible, merci de prendre connaissance d'un matricule existant) \n 4) Trier liste \n 0) Précédent");
                            int reponsePersonnel = 0;
                            try { reponsePersonnel = int.Parse(Console.ReadLine()); }
                            catch (FormatException) { Console.WriteLine("Veuillez respecter le format"); }
                            switch (reponsePersonnel)
                            {
                                case 1:
                                    Console.Clear();
                                    AfficheListePersonnel(parc.Membres);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.Clear();
                                    bool stopType = false;
                                    bool stopMat = false;
                                    Console.WriteLine("Veuillez fournir un matricule (nombre entier à 5 chiffres) : ");
                                    int reponseMat = 0;
                                    while (stopMat == false)
                                    {
                                        
                                        string stringMat = Console.ReadLine();
                                        if (stringMat.Length == 5)
                                        {
                                            try
                                            {
                                                reponseMat = int.Parse(stringMat);
                                                int compteur = 0;
                                                foreach (Personnel i in parc.Membres)
                                                {
                                                    if (i.Matricule == reponseMat)
                                                    {
                                                        compteur++;
                                                    }
                                                }
                                                Console.WriteLine(compteur);
                                                if (compteur == 0)
                                                {
                                                    stopMat = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Matricule déja utilisé, veuillez en choisir un autre :");
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Veuillez entrer un nombre entier : ");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Veuillez vous assurer qu'il s'agit bien d'un matricule à 5 chiffres");
                                        }
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Veuillez choisir un nom :");
                                    string reponseNom = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Veuillez choisir un prenom :");
                                    string reponsePrenom = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Veuillez indiquer le sexe :");
                                    string reponseSexe = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Veuillez indiquer sa fonction (ou neant s'il y en a pas)");
                                    string reponseFonction = Console.ReadLine();
                                    Console.Clear();

                                    while (stopType == false)
                                    {
                                        Console.WriteLine("Type du membre : \n 1) Demon \n 2) Fantome \n 3) Loup-garou \n 4) Zombie \n 5) Sorcier \n 6) Vampire \n 7) Autre (Monstre) \n 8) Annuler");
                                        int reponseType = 0;
                                        try { reponseType = int.Parse(Console.ReadLine()); }
                                        catch (FormatException) { Console.WriteLine("Veuillez respecter le format"); }
                                        switch (reponseType)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("Force du demon (entre 1 et 10) :");
                                                int reponseForce = int.Parse(Console.ReadLine());
                                                Demon d = new Demon(reponseMat, reponseNom, reponsePrenom, reponseSexe, reponseFonction, CAGNOTTE_DEPART, null, reponseForce);
                                                parc.AjoutPersonnel(d);
                                                stopType = true;
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Fantome f = new Fantome(reponseMat, reponseNom, reponsePrenom, reponseSexe, reponseFonction, CAGNOTTE_DEPART, null);
                                                parc.AjoutPersonnel(f);
                                                stopType = true;
                                                break;
                                            case 3:
                                                Console.Clear();
                                                Console.WriteLine("Cruauté du loup-garou (entre 1 et 10) :");
                                                int reponseCruaute = int.Parse(Console.ReadLine());
                                                LoupGarou lg = new LoupGarou(reponseMat, reponseNom, reponsePrenom, reponseSexe, reponseFonction, CAGNOTTE_DEPART, null, reponseCruaute);
                                                parc.AjoutPersonnel(lg);
                                                stopType= true;
                                                break;
                                            case 4:
                                                Console.Clear();
                                                Console.WriteLine("Couleur du Zombie (bleuâtre ou grisâtre)");
                                                string reponseCouleur = Console.ReadLine();
                                                Console.WriteLine("Degré de décomposition du zombie (entre 1 et 10) :");
                                                int reponseDecomp = int.Parse(Console.ReadLine());
                                                Zombie z = new Zombie(reponseMat, reponseNom, reponsePrenom, reponseSexe, reponseFonction, CAGNOTTE_DEPART, null, reponseCouleur, reponseDecomp);
                                                parc.AjoutPersonnel(z);
                                                stopType = true;
                                                break;
                                            case 5:
                                                Console.Clear();
                                                Console.WriteLine("Grade du sorcier : (novice,mega,giga,strata)");
                                                string reponseTatoo = Console.ReadLine();
                                                List<string> listePouvoirs = new List<string>();
                                                bool stopPouvoirs = false;
                                                while (stopPouvoirs == false)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Ajouter pouvoirs ? \n 1) Oui \n 2) Non");
                                                    int reponsePouvoir = int.Parse(Console.ReadLine());
                                                    switch (reponsePouvoir)
                                                    {
                                                        case 1:
                                                            Console.Clear();
                                                            Console.WriteLine("Veuillez donner le type de pouvoir");
                                                            string pouvoirToAdd= Console.ReadLine();
                                                            listePouvoirs.Add(pouvoirToAdd);
                                                            break;
                                                        case 2:
                                                            Console.Clear();
                                                            stopPouvoirs = true;
                                                            break;
                                                    }
                                                }
                                                Sorcier s = new Sorcier(reponseMat, reponseNom, reponsePrenom, reponseSexe, reponseFonction, reponseTatoo,listePouvoirs);
                                                parc.AjoutPersonnel(s);
                                                stopType = true;
                                                break;
                                            case 6:
                                                Console.Clear();
                                                Console.WriteLine("Indice de luminosité du vampire (entre 1 et 10) :");
                                                int reponseLum = int.Parse(Console.ReadLine());
                                                Vampire v = new Vampire(reponseMat, reponseNom, reponsePrenom, reponseSexe, reponseFonction, CAGNOTTE_DEPART, null, reponseLum);
                                                parc.AjoutPersonnel(v);
                                                stopType = true;
                                                break;
                                            case 7:
                                                Console.Clear();
                                                Monstre m = new Monstre(reponseMat, reponseNom, reponsePrenom, reponseSexe, reponseFonction, CAGNOTTE_DEPART, null);
                                                parc.AjoutPersonnel(m);
                                                stopType = true;
                                                break;
                                            case 8:
                                                Console.Clear();
                                                stopType = true;
                                                break;
                                            default:
                                                Console.Clear();
                                                break;
                                        }
                                    }
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Veuillez indiquer le matricule du monstre à modifier (si vous ne le connaissez pas, nous vous invitons à consulter notre liste du personnel) :");
                                    int reponseMatr = 0;
                                    bool stopMatr = false;
                                    while (stopMatr == false)
                                    {

                                        string stringMatr = Console.ReadLine();
                                        if (stringMatr.Length == 5)
                                        {
                                            try
                                            {
                                                reponseMatr = int.Parse(stringMatr);

                                                stopMatr = true;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Veuillez entrer un nombre entier : ");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Veuillez vous assurer qu'il s'agit bien d'un matricule à 5 chiffres");
                                        }
                                    }
                                    bool stopModif = false;
                                    while (stopModif == false)
                                    {
			                    		Console.WriteLine("Quelle modification souhaitez vous effectuer ? \n 1) Modifier Cagnotte \n 2) Modifier Affectation \n 3) Modifier Fonction \n 4) Précedent");
                                        int reponseModif = int.Parse(Console.ReadLine());
                                        switch (reponseModif)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("Veuillez choisir un montant à ajouter (positif, exemple : 5) ou à retirer (négatif, exemple : -2)");
                                                int reponseCagnotte = int.Parse(Console.ReadLine());
                                                int count1 = 0;
                                                Console.WriteLine("dans case 1");
                                                foreach (Personnel i in parc.Membres)
                                                {
                                                    Console.WriteLine("dans foreach");
                                                    if (i.Matricule == reponseMatr)
                                                    {
                                                        Console.WriteLine("dans if matricule");
                                                        count1++;
                                                        if (i is Monstre)
                                                        {
                                                            Console.WriteLine("dans if monstre");
                                                            parc.GestionCagnotte(i as Monstre, reponseCagnotte);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Seul les monstres possèdent une cagnotte, vous avez probablement sélectionné un sorcier");
                                                        }
                                                    }
                                                }
                                                if (count1 == 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Le matricule que vous avez fourni n'existe pas");
                                                }
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("Veuillez indiquer l'id d'une attraction à affecter (si vous ne le connaissez pas, nous vous invitons à consulter notre liste des attractions) :");
                                                int reponseID = int.Parse(Console.ReadLine());
                                                int count2 = 0;
                                                int count3 = 0;
                                                foreach (Personnel i in parc.Membres)
                                                {
                                                    if (i.Matricule == reponseMatr)
                                                    {
                                                        count2++;
                                                        if (i is Monstre)
                                                        {
                                                            foreach (Attraction j in parc.Attractions)
                                                            {
                                                                if (j.Id == reponseID)
                                                                {
                                                                    count3++;
                                                                    parc.Affecter(i as Monstre, j);
                                                                }
                                                            }                                                    
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Seul les monstres possèdent une affectation, vous avez probablement sélectionné un sorcier");
                                                        }
                                                    }                                                  
                                                }
                                                if (count2 == 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("le matricule que vous avez fourni n'existe pas");
                                                }
                                                if (count3 == 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("l'id que vous avez fourni n'existe pas");
                                                }
                                                break;
                                            case 3:
                                                Console.Clear();
                                                Console.WriteLine("Veuillez choisir une nouvelle fonction :");
                                                string reponseFonc = Console.ReadLine();
                                                int count4 = 0;
                                                foreach (Personnel i in parc.Membres)
                                                {
                                                    if (i.Matricule == reponseMatr)
                                                    {
                                                        count4++;
                                                        i.Fonction = reponseFonc;
                                                    }
                                                }
                                                if (count4 == 0)
                                                {
                                                    Console.WriteLine("Le matricule que vous avez entré n'existe pas");
                                                }
                                                break;
                                            case 4:
                                                Console.Clear();
                                                stopModif = true;
                                                break;
                                        }
                                    }
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Les parametres valides sont : nom, prenom, matricule, fonction, sexe, type, cagnotte, force, indice_luminosite\nParametre de comparaison : ");
                                    parc.SortPersonnelList(Console.ReadLine());
                                    AfficheListePersonnel(parc.MembresTrie);
                                    break;
                                case 0:
                                    Console.Clear();
                                    stopPersonnel = true;
                                    break;
                                default :
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.Clear();
                        bool stopAttraction = false;
                        while (stopAttraction == false)
                        {
                            Console.WriteLine("Gestion des attractions : \n 1) Afficher la liste des attractions \n 2) Ajouter une nouvelle attraction \n 3) Accéder à une attraction spécifique via id (Ce processus est irréversible, merci de prendre connaissance d'un identifiant existant)\n 4) Trier Liste \n 5) Affectation automatique \n 0) Précédent");
                            int reponseAttraction = 0;
                            try { reponseAttraction = int.Parse(Console.ReadLine()); }
                            catch (FormatException) { Console.WriteLine("Veuillez respecter le format"); }
                            switch (reponseAttraction)
                            {
                                case 1:
                                    Console.Clear();
                                    AfficheListeAttraction(parc.Attractions);
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.Clear();
                                    bool stopType = false;
                                    bool stopId = false;
                                    Console.WriteLine("Veuillez fournir un id (nombre entier à 3 chiffres) : ");
                                    int reponseId = 0;
                                    while (stopId == false)
                                    {

                                        string stringId = Console.ReadLine();
                                        if (stringId.Length == 3)
                                        {
                                            try
                                            {
                                                reponseId = int.Parse(stringId);
                                                int compteur = 0;
                                                foreach (Attraction i in parc.Attractions)
                                                {
                                                    if (i.Id == reponseId)
                                                    {
                                                        compteur++;
                                                    }
                                                }
                                                if (compteur == 0)
                                                {
                                                    stopId = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Id déja utilisé, veuillez en choisir un autre :");
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Veuillez entrer un nombre entier : ");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Veuillez vous assurer qu'il s'agit bien d'un matricule à 3 chiffres");
                                        }
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Veuillez choisir un nom :");
                                    string reponseNom = Console.ReadLine();
                                    Console.Clear();
                                    bool stopNbrMin = false;
                                    int reponseNbrMinMonstre = 0;
                                    while (stopNbrMin == false)
                                    {
                                        Console.WriteLine("Veuillez choisir un nombre minimum de monstre pour cette attraction :");
                                        try
                                        {
                                            reponseNbrMinMonstre = int.Parse(Console.ReadLine());
                                            stopNbrMin = true;
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Veuillez entrer un nombre entier");
                                        }
                                        Console.Clear();
                                    }
                                    bool stopBesoinSpe = false;
                                    bool reponseBesoinSpe = false;
                                    while (stopBesoinSpe == false)
                                    {
                                        Console.WriteLine("Veuillez indiquer si un besoin spécifique est nécessaire (true pour oui, false pour non) :");
                                        try
                                        {
                                            reponseBesoinSpe = bool.Parse(Console.ReadLine());
                                            stopBesoinSpe = true;
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Erreur d'entrée utilisateur, veuillez respecter le modèle");
                                        }
                                        Console.Clear();
                                    }
                                    Console.WriteLine("Veuillez indiquer le type de besoin (ou neant s'il y en a pas)");
                                    string reponseTypeBesoin = Console.ReadLine();
                                    Console.Clear();

                                    while (stopType == false)
                                    {
                                        Console.WriteLine("Type d'attraction : \n 1) Boutique \n 2) RollerCoaster \n 3) Spectacle \n 4) DarkRide \n 5) Annuler");

                                        int reponseType = 0;
                                        try { reponseType = int.Parse(Console.ReadLine()); }
                                        catch (FormatException) { Console.WriteLine("Veuillez respecter le format"); }

                                        switch (reponseType)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("Veuillez preciser le type de boutique :");
                                                string reponseTypeBoutique = Console.ReadLine();
                                                Boutique b = new Boutique(reponseId, reponseNom, reponseNbrMinMonstre, reponseBesoinSpe, reponseTypeBesoin, reponseTypeBoutique);
                                                parc.AjoutAttraction(b);
                                                stopType = true;
                                                break;
                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("Veuillez preciser la categorie (assise, inversée, bobsleigh) :");
                                                string reponseCategorie = Console.ReadLine();
                                                Console.Clear();
                                                Console.WriteLine("Veuillez preciser l'age minimum (entier) :");
                                                int reponseAgeMin = 0;
                                                bool stopAgeMin = false;
                                                while (stopAgeMin == false)
                                                {
                                                    try
                                                    {
                                                        reponseAgeMin = int.Parse(Console.ReadLine());
                                                        stopAgeMin = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Veuillez entrer un nombre entier");
                                                    }
                                                }
                                                Console.Clear();
                                                float reponseTailleMin = 0;
                                                Console.WriteLine("Veuillez entrer la taille minimum (nombre réel) :");
                                                bool stopTaille = false;
                                                while (stopTaille == false)
                                                {
                                                    try
                                                    {
                                                        reponseTailleMin = float.Parse(Console.ReadLine());
                                                        stopTaille = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Veuillez entrer un nombre réel");
                                                    }
                                                }
                                                RollerCoaster rc = new RollerCoaster(reponseId, reponseNom, reponseNbrMinMonstre, reponseBesoinSpe, reponseTypeBesoin, reponseCategorie, reponseAgeMin, reponseTailleMin);
                                                parc.AjoutAttraction(rc);
                                                stopType = true;
                                                break;
                                            case 3:
                                                Console.Clear();
                                                Console.WriteLine("Veuillez preciser le nom de la salle :");
                                                string reponseNomSalle = Console.ReadLine();
                                                Console.Clear();
                                                Console.WriteLine("Veuillez preciser le nombre de places (nombre entier) :");
                                                int reponseNbrPlaces = 0;
                                                bool stopNbrPlaces = false;
                                                while (stopNbrPlaces == false)
                                                {
                                                    try
                                                    {
                                                        reponseNbrPlaces = int.Parse(Console.ReadLine());
                                                        stopNbrPlaces = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Veuillez entrer un nombre entier");
                                                    }
                                                }
                                                Console.Clear();
                                                List<DateTime> horaires = new List<DateTime>();
                                                bool stopHoraires = false;
                                                while (stopHoraires == false)
                                                {
                                                    Console.WriteLine("Ajouter horaires ? \n 1) Oui \n 2) Non");
                                                    int reponseHoraire = 0;
                                                    try { reponseHoraire = int.Parse(Console.ReadLine()); }
                                                    catch (FormatException) { Console.WriteLine("Veuillez respecter le format"); }
                                                    switch (reponseHoraire)
                                                    {
                                                        case 1:
                                                            Console.Clear();
                                                            bool stopHoraire = false;
                                                            while (stopHoraire == false)
                                                            {
                                                                Console.WriteLine("Veuillez donner l'horaire (sous la forme hh:mm");
                                                                try
                                                                {
                                                                    DateTime horaireToAdd = DateTime.Parse(Console.ReadLine());
                                                                    horaires.Add(horaireToAdd);
                                                                }
                                                                catch (FormatException)
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Erreur d'entrée utilisateur, veuillez respecter le modèle");
                                                                }
                                                            }
                                                            break;
                                                        case 2:
                                                            Console.Clear();
                                                            stopHoraires = true;
                                                            break;
                                                    }
                                                }
                                                Console.Clear();
                                                Spectacle s = new Spectacle(reponseId, reponseNom, reponseNbrMinMonstre, reponseBesoinSpe, reponseTypeBesoin, reponseNomSalle, reponseNbrPlaces, horaires);
                                                parc.AjoutAttraction(s);
                                                stopType = true;
                                                break;
                                            case 4:
                                                Console.Clear();
                                                Console.WriteLine("Veuillez preciser la durée en minutes");
                                                TimeSpan reponseDuree = TimeSpan.Parse(Console.ReadLine());
                                                Console.Clear();
                                                bool stopVehicule = false;
                                                bool reponseVehicule = false;
                                                while (stopVehicule == false)
                                                {
                                                    Console.WriteLine("Veuillez indiquer la présence d'un vehicule (true pour oui, false pour non) :");
                                                    try
                                                    {
                                                        reponseVehicule = bool.Parse(Console.ReadLine());
                                                        stopVehicule = true;
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Erreur d'entrée utilisateur, veuillez respecter le modèle");
                                                    }
                                                    Console.Clear();
                                                }
                                                DarkRide dr = new DarkRide(reponseId, reponseNom, reponseNbrMinMonstre, reponseBesoinSpe, reponseTypeBesoin, reponseDuree, reponseVehicule);
                                                parc.AjoutAttraction(dr);
                                                stopType = true;
                                                break;

                                            case 0:
                                                Console.Clear();
                                                stopType = true;
                                                break;
                                            default:
                                                Console.Clear();
                                                break;
                                        }
                                    }
                                    Console.Clear();
                                    break;
                                case 3:
                                    Console.Clear();
                                    bool stopiD = false;
                                    Console.WriteLine("Veuillez indiquer l'id d'une attraction à laquelle vous souhaitez accéder (si vous n'en connaissez pas, nous vous invitons à consulter notre liste des attractions) :");
                                    int reponseiD = 0;
                                    while (stopiD == false)
                                    {  
                                        string stringId = Console.ReadLine();
                                        if (stringId.Length == 3)
                                        {
                                            try
                                            {
                                                reponseiD = int.Parse(stringId);
                                                stopiD = true;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Veuillez entrer un nombre entier : ");
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Veuillez vous assurer qu'il s'agit bien d'un matricule à 3 chiffres");
                                        }
                                    }
                                    bool stopChoix = false;
                                    Console.Clear();
                                    while (stopChoix == false)
                                    {
                                        Console.WriteLine("L'attraction a été trouvée, que souhaitez-vous faire : \n 1) Afficher l'équipe composant l'attraction \n 2) Modifier l'attraction \n 0) Précédent");
                                        int choix = 0;
                                        choix = int.Parse(Console.ReadLine());
                                        switch (choix)
                                        {
                                            case 1:
                                                Console.Clear();
                                                int count25 = 0;
                                                foreach (Attraction i in parc.Attractions)
                                                {
                                                    if (i.Id == reponseiD)
                                                    {
                                                        count25++;
                                                        AfficheListeMonstre((parc.Equipe(i)));
                                                    }
                                                }
                                                if (count25 == 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                }
                                                break;
                                            case 2:
                                                bool stopMod = false;
                                                Console.Clear();
                                                while (stopMod == false)
                                                {
                                                    Console.WriteLine("Quelle modification souhaitez-vous effectuer ? \n 1) Besoin Spécifique \n 2) Type de besoin \n 3) Niveau requis pour le besoin \n 4) Envoyer en maintenance \n 5) Remettre en activité \n BOUTIQUE \n 6) Type de boutique \n ROLLERCOASTER \n 7) Age Minimum \n 8) Taille Minimum \n 9) Catégorie \n SPECTACLE \n 10) Nombre places \n 11) Horaires \n 12) Nom de la salle \n DARK RIDE \n 13) Durée \n 14) Vehicule \n 0) Précédent");
                                                    int reponseMod = int.Parse(Console.ReadLine());
                                                    switch (reponseMod)
                                                    {
                                                        case 1:
                                                            Console.Clear();
                                                            int count5 = 0;
                                                            Console.WriteLine("L'attraction a-t-elle des besoin spécifiques ? (true or false)");
                                                            bool reponseBeSpe = bool.Parse(Console.ReadLine());
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count5++;
                                                                    i.Besoin_spe = reponseBeSpe;
                                                                }
                                                            }
                                                            if (count5 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 2:
                                                            Console.Clear();
                                                            int count6 = 0;
                                                            Console.WriteLine("Quel est le type de besoin ?");
                                                            string reponseTypeBe = Console.ReadLine();
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count6++;
                                                                    i.Type_besoin = reponseTypeBe;
                                                                }
                                                            }
                                                            if (count6 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 3:
                                                            Console.Clear();
                                                            int count7 = 0;
                                                            Console.WriteLine("Quel est le niveau requis du besoin ? (exemple : 6 en force chez un demon)");
                                                            int reponseNiveauRequis = int.Parse(Console.ReadLine());
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count7++;
                                                                    i.NiveauRequis = reponseNiveauRequis;
                                                                }
                                                            }
                                                            if (count7 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 4:
                                                            Console.Clear();
                                                            int count8 = 0;
                                                            Console.WriteLine("Quelle est la nature de la maintenance ?");
                                                            string reponseNatM = Console.ReadLine();
                                                            Console.WriteLine("Quelle est la durée de la maintenance ?");
                                                            TimeSpan reponseDureeM = TimeSpan.Parse(Console.ReadLine());
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count8++;
                                                                    i.EnvoyerEnMaintenance(reponseDureeM, reponseNatM);
                                                                }
                                                            }
                                                            if (count8 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 5:
                                                            Console.Clear();
                                                            int count9 = 0;
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count9++;
                                                                    i.RemettreEnActivite();
                                                                }
                                                            }
                                                            if (count9 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 6:
                                                            Console.Clear();
                                                            int count11 = 0;
                                                            Console.WriteLine("Quel est le type de la boutique ?");
                                                            string reponseTypeB = Console.ReadLine();
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count11++;
                                                                    if (i is Boutique)
                                                                    {
                                                                        ((Boutique)i).Type = reponseTypeB;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Cette attraction n'est pas une boutique");
                                                                    }
                                                                }
                                                            }
                                                            if (count11 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 7:
                                                            Console.Clear();
                                                            int count12 = 0;
                                                            Console.WriteLine("Quel est l'âge minimum pour utiliser le RollerCoaster ?");
                                                            int reponseAgeMin = int.Parse(Console.ReadLine());
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count12++;
                                                                    if (i is RollerCoaster)
                                                                    {
                                                                        ((RollerCoaster)i).AgeMin = reponseAgeMin;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Cette attraction n'est pas un rollercoaster");
                                                                    }
                                                                }
                                                            }
                                                            if (count12 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 8:
                                                            Console.Clear();
                                                            int count13 = 0;
                                                            Console.WriteLine("Quelle est la taille minimale pour utiliser le RollerCoaster ?");
                                                            float reponseTailleMin = float.Parse(Console.ReadLine());
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count13++;
                                                                    if (i is RollerCoaster)
                                                                    {
                                                                        ((RollerCoaster)i).TailleMin = reponseTailleMin;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Cette attraction n'est pas un rollercoaster");
                                                                    }
                                                                }
                                                            }
                                                            if (count13 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 9:
                                                            Console.Clear();
                                                            int count14 = 0;
                                                            Console.WriteLine("A quelle catégorie appartient ce rollercoaster ?");
                                                            string reponseCategorie = Console.ReadLine();
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count14++;
                                                                    if (i is RollerCoaster)
                                                                    {
                                                                        ((RollerCoaster)i).Categorie = reponseCategorie;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Cette attraction n'est pas un rollercoaster");
                                                                    }
                                                                }
                                                            }
                                                            if (count14 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 10:
                                                            Console.Clear();
                                                            int count15 = 0;
                                                            Console.WriteLine("Quel est le nombre de place pour ce spectacle ?");
                                                            int reponseNbrPlaces = int.Parse(Console.ReadLine());
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count15++;
                                                                    if (i is Spectacle)
                                                                    {
                                                                        ((Spectacle)i).Nbr_places = reponseNbrPlaces;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Cette attraction n'est pas un spectacle");
                                                                    }
                                                                }
                                                            }
                                                            if (count15 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 11:
                                                            Console.Clear();
                                                            int count16 = 0;
                                                            Console.WriteLine("Quelles sont les horaires de ce spectacle ?");
                                                            List<DateTime> reponseHoraires = new List<DateTime>();
                                                            bool stopHoraires = false;
                                                            while (stopHoraires == false)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("Ajouter horaires ? \n 1) Oui \n 2) Non");
                                                                int reponseHoraire = 0;
                                                                try { reponseHoraire = int.Parse(Console.ReadLine()); }
                                                                catch (FormatException)
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("Veuillez respecter le format");
                                                                }
                                                                switch (reponseHoraire)
                                                                {
                                                                    case 1:
                                                                        Console.Clear();
                                                                        bool stopHoraire = false;
                                                                        while (stopHoraire == false)
                                                                        {
                                                                            Console.WriteLine("Veuillez donner l'horaire (sous la forme hh:mm");
                                                                            try
                                                                            {
                                                                                DateTime horaireToAdd = DateTime.Parse(Console.ReadLine());
                                                                                reponseHoraires.Add(horaireToAdd);
                                                                            }
                                                                            catch (FormatException)
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine("Erreur d'entrée utilisateur, veuillez respecter le modèle");
                                                                            }
                                                                        }
                                                                        break;
                                                                    case 2:
                                                                        Console.Clear();
                                                                        stopHoraires = true;
                                                                        break;
                                                                }
                                                            }
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count16++;
                                                                    if (i is Spectacle)
                                                                    {
                                                                        ((Spectacle)i).Horaire = reponseHoraires;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Cette attraction n'est pas un spectacle");
                                                                    }
                                                                }
                                                            }
                                                            if (count16 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 12:
                                                            Console.Clear();
                                                            int count17 = 0;
                                                            Console.WriteLine("Quel est le nom de la salle où se déroulera le spectacle ?");
                                                            string reponseNomSalle = Console.ReadLine();
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count17++;
                                                                    if (i is Spectacle)
                                                                    {
                                                                        ((Spectacle)i).Nom_salle = reponseNomSalle;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Cette attraction n'est pas un spectacle");
                                                                    }
                                                                }
                                                            }
                                                            if (count17 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 13:
                                                            Console.Clear();
                                                            int count18 = 0;
                                                            Console.WriteLine("Quel est la durée du Dark Ride ?");
                                                            TimeSpan reponseDuree = TimeSpan.Parse(Console.ReadLine());
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count18++;
                                                                    if (i is DarkRide)
                                                                    {
                                                                        ((DarkRide)i).Duree = reponseDuree;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Cette attraction n'est pas un Dark Ride");
                                                                    }
                                                                }
                                                            }
                                                            if (count18 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 14:
                                                            Console.Clear();
                                                            int count19 = 0;
                                                            Console.WriteLine("Le DarkRide comporte-t-il des vehicules (true ou false) ?");
                                                            bool reponseVehicule = bool.Parse(Console.ReadLine());
                                                            foreach (Attraction i in parc.Attractions)
                                                            {
                                                                if (i.Id == reponseiD)
                                                                {
                                                                    count19++;
                                                                    if (i is DarkRide)
                                                                    {
                                                                        ((DarkRide)i).Vehicule = reponseVehicule;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("Cette attraction n'est pas un Dark Ride");
                                                                    }
                                                                }
                                                            }
                                                            if (count19 == 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("L'identifiant que vous avez entré n'existe pas");
                                                            }
                                                            break;
                                                        case 0:
                                                            stopMod = true;
                                                            break;

                                                    }
                                                }
                                                break;
                                            case 0:
                                                Console.Clear();
                                                stopChoix = true;
                                                break;
                                            default:
                                                Console.Clear();
                                                break;
                                        }
                                    }                                
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Les parametres valides sont : nom, id, nbr_min_monstres, besoin_spe, maintenance, type_besoin, ouvert, nature_maintenance, type_boutique, vehicule, ageMin, categorie, nbr_places, nom_salle\nParametre de comparaison : ");
                                    parc.SortAttractionlList(Console.ReadLine());
                                    AfficheListeAttraction(parc.AttractionsTrie);
                                    break;
                                case 5:
                                    parc.GestionEquipe();
                                    Console.WriteLine("Affectations réussies");
                                    break;
                                case 0:
                                    Console.Clear();
                                    stopAttraction = true;
                                    break;
                                default:
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                    case 3:
                        Console.Clear();
                        try
                        {
                            parc.ReadCSV("Listing.csv");
                            Console.WriteLine("Importation réussie");
                        }
                        catch (IOException)
                        {
                            Console.WriteLine("Erreur : Fichier corrompu");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        bool stopExport = false;
                        while (stopExport == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Exportation dans un fichier CSV :\n 1) Exporter dernier tri du personnel\n 2) Exporter dernier tri des attractions\n 3) Exporter tout\n 4) Effacer le contenu de export.csv\n 0) Précédent");
                            int reponseExport = 0;
                            try { reponseExport = int.Parse(Console.ReadLine()); }
                            catch (FormatException) { Console.WriteLine("Veuillez respecter le format"); }
                            switch (reponseExport)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Exportation...");
                                    parc.WriteCSVPersonnel("export.csv", parc.MembresTrie);
                                    Console.WriteLine("done");
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Exportation...");
                                    parc.WriteCSVAttractions("export.csv", parc.AttractionsTrie);
                                    Console.WriteLine("done");
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Exportation...");
                                    parc.WriteCSVAttractions("export.csv", parc.Attractions);
                                    parc.WriteCSVPersonnel("export.csv", parc.Membres);
                                    Console.WriteLine("done");
                                    break;
                                case 4:
                                    try
                                    {
                                        File.WriteAllText("export.csv", String.Empty);
                                        Console.WriteLine("Le contenu du fichier a été effacé avec succès");
                                    }
                                    catch (IOException)
                                    {
                                        Console.WriteLine("Le fichier n'a pas été encore crée, veuillez faire un premier export avant de tenter d'effacer son contenu");
                                    }
                                    break;
                                case 0:
                                    Console.Clear();
                                    stopExport = true;
                                    break;
                                default:
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                    case 0:
                        Console.Clear();
                        stopAccueil = true;
                        break;
                    default :
                        Console.Clear();
                        break;
                }
                
            }
        }
        /// <summary>
        /// Affiche dans la console la liste du personnel fournie
        /// </summary>
        /// <param name="liste">Liste du personnel a afficher</param>
        static void AfficheListePersonnel(List<Personnel> liste)
        {
            foreach (Personnel i in liste)
            {
                Console.WriteLine("\n" + i.ToString());
            }
        }
        /// <summary>
        /// Affiche dans la console la liste des monstres fournie
        /// </summary>
        /// <param name="liste">Liste des monstres a afficher</param>
        static void AfficheListeMonstre(List<Monstre> liste)
        {
            foreach (Monstre i in liste)
            {
                Console.WriteLine("\n" + i.ToString());
            }
        }
        /// <summary>
        /// Affiche dans la console la liste des attractions fournie
        /// </summary>
        /// <param name="liste">Liste des attractions a afficher</param>
        static void AfficheListeAttraction(List<Attraction> liste)
        {
            if (liste != null)
            {
                foreach (Attraction i in liste)
                {
                    Console.WriteLine("\n" + i.ToString());
                }
            }
        }
	}
}
