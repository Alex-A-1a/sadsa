using System;

namespace LibrarieModele
{
    public class Aliment
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int DENUMIRE = 0;
        private const int PRODUCATOR = 1;
        private const int TIP = 2;
        private const int COD = 3;
        private const int PRET = 4;
        private const int STOC = 5;
        private const int COS_DE_CUMPARATURI = 6;
        private const int DATA_ACTUALIZARE = 7;
        public static int idAliment { get; set; } = 0;
        public string Denumire { get; set; }
        public string Producator { get; set; }
        public string Tip { get; set; }
        public int Cod { get; set; }
        public int Pret { get; set; }
        public int Stoc { get; set; }
        public int Cos_De_Cumparaturi { get; set; }
        public string Produs { get { return Denumire + " - " + Producator; } }
        public DateTime dataActualizare { get; set; }
        public int Disponibilitate { get { return Stoc - Cos_De_Cumparaturi; } }
        public Aliment(string _denumire = "", string _producator = "", string _tip = "", int _pret = 0, int _stoc = 1)
        {
            Denumire = _denumire;
            Producator = _producator;
            Tip = _tip;
            Cod = ++idAliment;
            Pret = _pret;
            Stoc = _stoc;
            dataActualizare = DateTime.Now;
        }
        public Aliment(string date)
        {
            string[] infoAliment = date.Split(SEPARATOR_PRINCIPAL_FISIER);
            Denumire = infoAliment[DENUMIRE];
            Producator = infoAliment[PRODUCATOR];
            Tip = infoAliment[TIP];
            Cod = Convert.ToInt32(infoAliment[COD]);
            idAliment = Cod;
            Pret = Convert.ToInt32(infoAliment[PRET]);
            Stoc = Convert.ToInt32(infoAliment[STOC]);
            Cos_De_Cumparaturi = Convert.ToInt32(infoAliment[COS_DE_CUMPARATURI]);
            dataActualizare = DateTime.Parse(infoAliment[DATA_ACTUALIZARE]);
        }
        public string Info()
        {
            string info = string.Format("Cod:{0} Denumire:{1} Producator: {2} Tip: {3} Pret: {4} Stoc: {5}",
                Cod.ToString(),
                (Denumire ?? " NECUNOSCUT "),
                (Producator ?? " NECUNOSCUT "),
                (Tip ?? " NECUNOSCUT "),
                Pret.ToString(),
                Stoc.ToString());
            return info;
        }
        public string ConversieLaSir()
        {
            return "#" + Cod.ToString() + " - " + Denumire + " - " + Producator + " - " + Tip + "\nPret: " + Pret.ToString() + "\nStoc: " + Stoc.ToString() + "\n";
        }
        public string ConversieLaSir_PentruFisier()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Denumire ?? "NECUNOSCUT"),
                (Producator ?? " NECUNOSCUT "),
                (Tip ?? " NECUNOSCUT "),
                Cod.ToString(),
                Pret.ToString(),
                Stoc.ToString(),
                Cos_De_Cumparaturi.ToString(),
                dataActualizare.ToString());
            return s;
        }
        public int GetCod()
        {
            return Cod;
        }
        public int GetPret()
        {
            return Pret;
        }
        public int GetStoc()
        {
            return Stoc;
        }
        public string GetDenumire()
        {
            return Denumire;
        }
        public string GetProducator()
        {
            return Producator;
        }
        public string GetTip()
        {
            return Tip;
        }
        public void SetCod(int Cod)
        {
            this.Cod = Cod;
        }
    }
}