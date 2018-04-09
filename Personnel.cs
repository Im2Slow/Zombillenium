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
        public int Matricule
        {
            get { return matricule; }
            set { matricule = value; }
        }
        public string Nom
        {
            get { return nom; }
        }
        public string Prenom
        {
            get { return prenom; }
        }
        public string Sexe
        {
            get { return sexe; }
        }
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
		public override string ToString()
		{
            return "matricule : " + matricule + ", nom : " + nom + ", prenom : " + prenom + ", sexe : " + sexe + ", fonction : " + fonction;
		}
	}
}

