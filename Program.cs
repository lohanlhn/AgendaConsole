namespace AgendaConsole
{
    internal class Program
    {
        static int ExibirMenu()
        {
            int op = 0;
            Console.Clear();
            Console.WriteLine("Agenda Modo Console");
            Console.WriteLine("Exibir dados - 1");
            Console.WriteLine("Inserir contato - 2");
            Console.WriteLine("Alterar contato - 3");
            Console.WriteLine("Excluir contato - 4");
            Console.WriteLine("Localizar contato - 5");
            Console.WriteLine("Sair - 6");
            Console.WriteLine("Opção: ");
            op = Convert.ToInt32(Console.ReadLine());
            return op;
        }
        static void Main(string[] args)
        {
            //armazena os dados da agenda
            string[] nome = new string[200];
            string[] email = new string[200];

            //tamanho logico
            int tl = 0;
            int op = 0;

            while (op != 6)
            {
                op = ExibirMenu();
                switch (op)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                }
            }            

        }
    }    
}