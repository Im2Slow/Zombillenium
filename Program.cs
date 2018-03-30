using System;
using System.Collections.Generic;

namespace Zombillenium
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            Menu();
		}
        static void Menu()
        {
            bool stopAccueil = false;
            Administration parc = new Administration();
            const int CAGNOTTE_DEPART = 50;
            while (stopAccueil == false)
            {
                Console.WriteLine("Bienvenue sur le logiciel de gestion de Zombilenium, choissisez une action à effectuer en entrant le chiffre correspondant : \n 1) Gerer personnel \n 2) Gerer attractions \n 3) Importer via CSV \n 4) Exporter \n 5) Quitter");
                int reponseAccueil = 0;
                try { reponseAccueil= int.Parse(Console.ReadLine()); }
                catch (Exception) { Console.WriteLine("Veuillez respecter le format"); }
                switch (reponseAccueil)
                {
                    case 1:
                        Console.Clear();
                        bool stopPersonnel = false;
                        while (stopPersonnel == false)
                        {
                            Console.WriteLine("Gestion du personnel : \n 1) Afficher la liste des membres du personnel \n 2) Ajouter un nouveau membre \n 3) Modifier membre \n 4) Trier liste \n 5) Précédent");
                            int reponsePersonnel = 0;
                            try { reponsePersonnel = int.Parse(Console.ReadLine()); }
                            catch (Exception) { Console.WriteLine("Veuillez respecter le format"); }
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
                                                Console.WriteLine("hit");
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
                                            catch (Exception)
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
                                        catch (Exception) { Console.WriteLine("Veuillez respecter le format"); }
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
                                    break;
                                case 4:
                                    Console.Clear();
                                    break;
                                case 5:
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
                            Console.WriteLine("Gestion des attractions : \n 1) Afficher la liste des attractions \n 2) Ajouter une nouvelle attraction \n 3) Modifier une attraction \n 4) Trier Liste \n 5) Affectation automatique \n 6) Précédent");
                            int reponseAttraction = 0;
                            try { reponseAttraction = int.Parse(Console.ReadLine()); }
                            catch (Exception) { Console.WriteLine("Veuillez respecter le format"); }
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
                                            catch (Exception)
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
                                        catch (Exception)
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
                                        catch (Exception)
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
                                        catch (Exception) { Console.WriteLine("Veuillez respecter le format"); }

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
                                                    catch (Exception)
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
                                                    catch (Exception)
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
                                                    catch (Exception)
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
                                                    try { reponseHoraire= int.Parse(Console.ReadLine()); }
                                                    catch (Exception) { Console.WriteLine("Veuillez respecter le format"); }
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
                                                                catch (Exception)
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
                                                    catch (Exception)
                                                    {
                                                        Console.WriteLine("Erreur d'entrée utilisateur, veuillez respecter le modèle");
                                                    }
                                                    Console.Clear();
                                                }
                                                DarkRide dr = new DarkRide(reponseId, reponseNom, reponseNbrMinMonstre, reponseBesoinSpe, reponseTypeBesoin, reponseDuree, reponseVehicule);
                                                parc.AjoutAttraction(dr);
                                                stopType = true;
                                                break;

                                            case 5:
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
                                    break;
                                case 4:
                                    Console.Clear();
                                    break;
                                case 5:
                                    parc.GestionEquipe();
                                    Console.WriteLine("Affectations réussies");
                                    break;
                                case 6:
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
                        catch (Exception)
                        {
                            Console.WriteLine("Erreur : Fichier corrompu");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        stopAccueil = true;
                        break;
                    default :
                        Console.Clear();
                        break;
                }
                
            }
        }
        static void AfficheListePersonnel(List<Personnel> liste)
        {
            foreach (Personnel i in liste)
            {
                Console.WriteLine("\n" + i.ToString());
            }
        }
        static void AfficheListeAttraction(List<Attraction> liste)
        {
            foreach (Attraction i in liste)
            {
                Console.WriteLine("\n" + i.ToString());
            }
        }
	}
}
