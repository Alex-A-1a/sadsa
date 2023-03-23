using LibrarieModele;
using System.IO;

namespace NivelStocareDate
{
    public class AdministrareAlimente_FisierText
    {
        private const int NR_MAX_ALIMENTE = 100;
        private string numeFisier;
        public AdministrareAlimente_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddAliment(Aliment aliment)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(aliment.ConversieLaSir_PentruFisier());
            }
        }
        public Aliment[] GetAlimente(out int nrAlimente)
        {
            Aliment[] alimente = new Aliment[NR_MAX_ALIMENTE];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrAlimente = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    alimente[nrAlimente++] = new Aliment(linieFisier);
                }
            }
            return alimente;
        }
    }
}