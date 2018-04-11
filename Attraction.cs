using System;
using System.Collections.Generic;

namespace Zombillenium
{
	public abstract class Attraction
	{
		bool besoin_spe;
		TimeSpan duree_maintenance;
		int id;
		bool maintenance;
		string nature_maintenance;
		int nbr_min_monstres;
		string nom;
		bool ouvert;
		string type_besoin;
        int niveauRequis;

        public Attraction (int id, string nom,  int nbr_min_monstres, bool besoin_spe, string type_besoin)
		{
            this.id = id;
			this.nbr_min_monstres = nbr_min_monstres;
			this.nom = nom;
			this.type_besoin = type_besoin;
			this.besoin_spe = besoin_spe;
            ouvert = true;
            niveauRequis = 0;
		}
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int NiveauRequis
        {
            get { return niveauRequis; }
            set { niveauRequis = value; }
        }
        public int Nbr_min_monstres
        {
            get { return nbr_min_monstres; }
            set { nbr_min_monstres = value; }
        }
		public bool Maintenance
		{
			get{ return maintenance; }
			set{ maintenance = value; }
		}
        public bool Ouvert
        {
            get { return ouvert; }
            set { ouvert = value; }
        }
        public bool Besoin_spe
        {
            get { return besoin_spe; }
            set { besoin_spe = value; }
        }
        public string Type_besoin
        {
            get { return type_besoin; }
            set { type_besoin = value; }
        }
        public string Nature_maintenance
        {
            get { return nature_maintenance; }
            set { nature_maintenance = value; }
        }
        public TimeSpan Duree_maintenance
        {
            get { return duree_maintenance; }
            set { duree_maintenance = value; }
        }
		public override string ToString()
		{
            return nom + " , id : " + id + " , nombre min monstres : " + nbr_min_monstres + ", besoin spécifique : " + besoin_spe + " , type besoins : " + type_besoin + ", état de maintenance : " + maintenance + ", durée maintenance : " + duree_maintenance + ", nature maintenance : " + nature_maintenance + ", ouvert : " + ouvert;
		}
        /// <summary>
        /// Modifie l'attraction pour la representer "en maintenance" selon les descriptions fournies
        /// </summary>
        /// <param name="duree">Duree de la maintenance</param>
        /// <param name="nature">Nature de la maintenance</param>
        public void EnvoyerEnMaintenance(TimeSpan duree, string nature)
        {
            maintenance = true;
            duree_maintenance = duree;
            nature_maintenance = nature;
            ouvert = false;
        }
        /// <summary>
        /// Modifie l'attraction pour representer la fin de sa maintenance
        /// </summary>
        public void RemettreEnActivite()
        {
            maintenance = false;
            duree_maintenance = TimeSpan.Zero;
            nature_maintenance = "";
            ouvert = true;
        }

    }
}

