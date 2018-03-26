using System;
using System.Collections.Generic;

namespace Zombillenium
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            Administration parc = new Administration();
            parc.ReadCSV("Listing.csv");
            AfficheListePersonnel(parc.Membres);
            AfficheListeAttraction(parc.Attractions);

			
		}
        static void AfficheListePersonnel(List<Personnel> liste)
        {
            foreach (Personnel i in liste)
            {
                Console.WriteLine(i.ToString());
            }
        }
        static void AfficheListeAttraction(List<Attraction> liste)
        {
            foreach (Attraction i in liste)
            {
                Console.WriteLine(i.ToString());
            }
        }
	}
}
