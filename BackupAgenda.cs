namespace AgendaConsole
{
    internal class BackupAgenda
    {
        public static string nomeArquivo = "dados.txt";
        public static void SalvarDados(ref string[] nome, ref string[] email, ref int tl)
        {
            StreamWriter sw = new StreamWriter(nomeArquivo);
            for (int i = 0; i < tl; i++)
            {
                sw.WriteLine(nome[i]+" - "+ email[i]);
            }
            sw.Close();
        }

        public static void RestaurarDados(ref string[] nome, ref string[] email, ref int tl)
        {
            tl = 0;
            StreamReader sr =  new StreamReader(nomeArquivo);
            string line = sr.ReadLine();

            while(line != null)
            {
                nome[tl] = line.Split(" - ")[0];
                email[tl] = line.Split(" - ")[1]; 
                tl++;
                line = sr.ReadLine();
            }

            sr.Close();
        }
    }
}