using System.Net.Security;

namespace AgendaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //armazena os dados da agenda
            string[] nome = new string[200];
            string[] email = new string[200];
            string emailContato = "";
            string op = "";

            //tamanho logico
            int tl = 0;
            int pos = 0;

            BackupAgenda.nomeArquivo = "dados.txt";
            BackupAgenda.RestaurarDados(ref nome, ref email, ref tl); 


            while (op != "6")
            {
                op = ExibirMenu();
                switch (op)
                {
                    case "1":
                        ExibirContatos(nome, email, tl);
                        break;
                    case "2":
                        InserirContatos(ref nome, ref email, ref tl);
                        break;
                    case "3":
                        AlterarContatos(ref nome, ref email, ref tl);
                        break;
                    case "4":
                        Console.WriteLine("Excluir um contato");
                        Console.Write("E-mail: ");
                        emailContato = Console.ReadLine();
                        if (ExcluirContato(ref nome, ref email, ref tl, emailContato))
                        {
                            Console.WriteLine("Contato excluido");
                        }
                        else
                        {
                            Console.WriteLine("Console não encontrado");
                        }
                        Console.ReadKey();                        
                        
                        break;
                    case "5":
                        Console.WriteLine("Localizar um contato");
                        Console.Write("E-mail: ");
                        emailContato = Console.ReadLine();
                        
                        pos = LocalizarContatos(email, tl, emailContato);

                        if (pos != -1)
                        {
                            Console.WriteLine("Nome: {0} - E-mail: {1}", nome[pos], email[pos]);                            
                        }
                        else
                        {
                            Console.WriteLine("Contato não encontrado");
                        }
                        Console.ReadKey();

                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("Opção desconhecida, por favor escolha a opção desejada");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                        Console.ReadKey();
                        break;
                }
            }             

            BackupAgenda.SalvarDados(ref nome, ref email, ref tl);
        }

        static string ExibirMenu()
        {            
            Console.Clear();
            Console.WriteLine("Agenda Modo Console");
            Console.WriteLine("Exibir dados - 1");
            Console.WriteLine("Inserir contato - 2");
            Console.WriteLine("Alterar contato - 3");
            Console.WriteLine("Excluir contato - 4");
            Console.WriteLine("Localizar contato - 5");
            Console.WriteLine("Sair - 6");
            Console.Write("Opção: ");
            string op = Console.ReadLine();
            Console.Clear();
            return op;
        }

        static void ExibirContatos(string[] nome, string[] email, int tl)
        {
            for (int i = 0; i < tl; i++)
            {
                Console.WriteLine("Nome: {0} - E-mail: {1}", nome[i], email[i]);
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar");
            Console.ReadKey();
        }

        static void InserirContatos(ref string[] nome, ref string[] email, ref int tl)
        {
            try
            {
                Console.WriteLine("Alterar contato");
                Console.Write("Nome: ");
                nome[tl] = Console.ReadLine();
                Console.Write("E-mail: ");
                email[tl] = Console.ReadLine();
                int pos = LocalizarContatos(email, tl, email[tl]);
                
                if (pos == -1 )
                {
                    tl++;
                    Console.WriteLine("Contato inserido");                    
                }
                else
                {
                    Console.WriteLine("Contato já cadastrado");
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey();
            }            
        }

        static int LocalizarContatos(string[] email, int tl, string emailContato)
        {            
            int pos = -1;
            int i = 0;

            while (i < tl && email[i] != emailContato)
            {
                i++;
            }
            
            if (i < tl) pos = i;
            return pos;
        }

        static void AlterarContatos(ref string[] nome, ref string[] email, ref int tl)
        {
            try
            {
                if (tl >= 200)
                {
                    Console.WriteLine("Número maximo de contatos atingido");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Alterar contato");
                    Console.Write("E-mail: ");
                    string emailContato = Console.ReadLine();
                    int pos = LocalizarContatos(email, tl, emailContato);

                    if (pos != -1)
                    {
                        Console.WriteLine("Novos dados do contato");
                        Console.Write("Nome: ");
                        string novoNome = Console.ReadLine();
                        Console.Write("email: ");
                        string novoEmail = Console.ReadLine();

                        if (LocalizarContatos(email, tl, novoEmail) == -1 || novoEmail == emailContato)
                        {
                            nome[pos] = novoNome;
                            email[pos] = novoEmail;
                            Console.WriteLine("Contato alterado");
                        }
                        else
                        {
                            Console.WriteLine("Já existe um contato com este e-mail");
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Contato não encontrado");
                        Console.ReadKey();
                    }
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadKey();
            }
        }

        static bool ExcluirContato(ref string[] nome, ref string[] email, ref int tl, string emailContato)
        {
            bool excluiu = false;
            int pos = -1;
            pos = LocalizarContatos(email, tl, emailContato);

            if (pos != -1)
            {
                for (int i = pos; i < tl-1; i++)
                {
                    nome[i] = nome[i+1];
                    email[i] = email[i + 1];
                }
                excluiu = true;
                tl--;
            }
            return excluiu;

        }
    }    
}