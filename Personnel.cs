using System;

namespace Zombillenium
{
	public abstract class Personnel
	{
		string fonction;
		int matricule;
		string nom;
		string prenom;
		string sexe;
		public string Fonction
		{
			get{ return fonction; }
			set{ fonction = value; }
		}
		public Personnel (int matricule, string nom, string prenom, string sexe, string fonction)
		{
			this.matricule = matricule;
			this.nom = nom;
			this.prenom = prenom;
			this.sexe = sexe;
			this.fonction = fonction;
		}
        public int Matricule
        {
            get { return Matricule; }
            set { matricule = value; }
        }
	}
}

