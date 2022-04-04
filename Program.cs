using ConsoleEx01._0._0.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleEx01._0._0
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Database();
            bool cont = true;

            var userDAO = new UserDAO();

            while (cont == true)
            {
                Console.WriteLine("Bonsoir! Escolha a operação que deseja fazer:" +
                                    "\n 1 - Simples verificação de registros" +
                                    "\n 2 - Adicionar pessoinhas" +
                                    "\n 3 - Alterar alguém!!!!" +
                                    "\n 4 - DELETAR ALGUÉM!" +
                                    "\n 5 - Sair" +
                                    "\n──────▄▀▄─────▄▀▄" +
                                    "\n─────▄█░░▀▀▀▀▀░░█▄" +
                                    "\n─▄▄──█░░░░░░░░░░░█──▄▄" +
                                    "\n█▄▄█─█░░▀░░┬░░▀░░█─█▄▄█");
                string selOpt = Console.ReadLine();
                bool needsCheck = true;

                var user = new User();

                switch (selOpt)
                {
                    default:
                        needsCheck = false;
                        cont = true;
                        Console.Clear();
                        break;
                    case "1":
                        var reader = userDAO.List();
                        
                        Console.WriteLine("===================== Dados dos Clientes =====================\n");
                        foreach (var users in reader)
                        {
                            Console.WriteLine("Cliente número {0}:\nNome: {1}, Cargo: {2}, Data: {3}",
                                users.idUsu, users.NomeUsu, users.Cargo, users.DtNasc);
                        }
                        Console.WriteLine("\n");
                        Console.ReadLine();

                        needsCheck = false;
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Digite o nome do usuário (❁´◡`❁)");
                        user.NomeUsu = Console.ReadLine();

                        Console.WriteLine("Digite o cargo do usuário ಠ_ಠ");
                        user.Cargo = Console.ReadLine();

                        Console.WriteLine("Digite a data de nascença do usuário (DD/MM/AAAA) ヾ(⌐■_■)ノ♪");
                        user.DtNasc = DateTime.Parse(Console.ReadLine());

                        new UserDAO().Insert(user);
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine("Apenas lembrando:\n");

                        var checker = userDAO.List();

                        Console.WriteLine("===================== Dados dos Clientes =====================\n");
                        foreach (var users in checker)
                        {
                            Console.WriteLine("Cliente número {0}:\nNome: {1}, Cargo: {2}, Data: {3}",
                                users.idUsu, users.NomeUsu, users.Cargo, users.DtNasc);
                        }
                        Console.WriteLine("\n");

                        Console.WriteLine("Digite o ID do usuário que deseja alterar (❁´◡`❁)");
                        user.idUsu = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o novo nome do usuário que deseja alterar (❁´◡`❁)");
                        user.NomeUsu = Console.ReadLine();

                        Console.WriteLine("Digite o novo cargo do usuário que deseja alterar (❁´◡`❁)");
                        user.Cargo = Console.ReadLine();

                        Console.WriteLine("Digite a nova dt. de nascimento do usuário que deseja alterar (❁´◡`❁)");
                        user.DtNasc = DateTime.Parse(Console.ReadLine());

                        var postChecker = userDAO.ListSameId(user.idUsu);
                        if (postChecker.Count > 0)
                        {
                            new UserDAO().Update(user);
                        }
                        else
                        {
                            new UserDAO().Insert(user);
                        }
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("Apenas lembrando:");

                        var seer = userDAO.List();

                        Console.WriteLine("===================== Dados dos Clientes =====================");
                        foreach (var users in seer)
                        {
                            Console.WriteLine("Cliente número {0}:\nNome: {1}, Cargo: {2}, Data: {3}",
                                users.idUsu, users.NomeUsu, users.Cargo, users.DtNasc);
                        }
                        Console.WriteLine("\nDigite o ID do usuário que deseja deletar (❁´◡`❁)");
                        user.idUsu = Convert.ToInt32(Console.ReadLine());

                        new UserDAO().Delete(user);
                        Console.Clear();
                        break;
                    case "5":
                        cont = false;
                        needsCheck = false;
                        break;
                }
                if (needsCheck == true)
                {
                    var post = userDAO.List();

                    Console.WriteLine("===================== Dados dos Clientes =====================");
                    foreach (var users in post)
                    {
                        Console.WriteLine("Cliente número {0}:\nNome: {1}, Cargo: {2}, Data: {3}",
                        users.idUsu, users.NomeUsu, users.Cargo, users.DtNasc);
                    }
                    Console.WriteLine("\n");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
