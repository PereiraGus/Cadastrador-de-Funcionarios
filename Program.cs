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
            bool aswered = false;

            try
            {
                //conecc.Open();
                Console.WriteLine("Conectado!");
                Console.WriteLine(" ");
            }
            catch(Exception e)
            {
                Console.WriteLine("Não foi possível se conectar ao banco de dados");
                cont = false;
                Console.ReadLine();
            }

            while (cont == true)
            {
                Console.WriteLine("Bonsoir! Escolha a operação que deseja fazer:");
                Console.WriteLine("1 - Simples verificação de registros (●'◡'●)");
                Console.WriteLine("2 - Adicionar pessoinhas ＼(((￣(￣(￣▽￣)￣)￣)))／");
                Console.WriteLine("3 - Alterar alguém!!!! φ(゜▽゜*)♪");
                Console.WriteLine("4 - DELETAR ALGUÉM! ┌( ಠ_ಠ)┘");
                Console.WriteLine("5 - Sair ＞︿＜");
                string selOpt = Console.ReadLine();
                bool needsCheck = true;

                var user = new User();

                switch (selOpt)
                {
                    default:
                        needsCheck = false;
                        aswered = true;
                        cont = false;
                        break;
                    case "1":
                        string seeUser = "Select * from tb_liaUsuario";
                        MySqlDataReader read = database.Return(seeUser);
                        Console.WriteLine("===================== Dados dos Clientes =====================");
                        Console.WriteLine(" ");
                        while (read.Read())
                        {
                            Console.WriteLine("Cliente número {0}:", read["IdUsu"]);
                            Console.WriteLine("Nome: {0}, Cargo: {1}, Data: {2}",
                                read["NomeUsu"], read["Cargo"], read["DtNasc"]);
                        }
                        Console.ReadLine();
                        read.Close();
                        needsCheck = false;
                        break;
                    case "2":
                        Console.WriteLine("Digite o nome do usuário (❁´◡`❁)");
                        user.NomeUsu = Console.ReadLine();

                        Console.WriteLine("Digite o cargo do usuário ಠ_ಠ");
                        user.Cargo = Console.ReadLine();

                        Console.WriteLine("Digite a data de nascença do usuário (DD/MM/AAAA) ヾ(⌐■_■)ノ♪");
                        user.DtNasc = DateTime.Parse(Console.ReadLine());

                        new UserDAO().Insert(user);
                        break;
                    case "3":
                        Console.WriteLine("Apenas lembrando:");

                        string checkUser = "Select * from tb_liaUsuario";
                        MySqlDataReader reader = database.Return(checkUser);
                        Console.WriteLine("===================== Dados dos Clientes =====================");
                        Console.WriteLine(" ");
                        while (reader.Read())
                        {
                            Console.WriteLine("Cliente número {0}:", reader["IdUsu"]);
                            Console.WriteLine("Nome: {0}, Cargo: {1}, Data: {2}",
                                reader["NomeUsu"], reader["Cargo"], reader["DtNasc"]);
                        }
                        reader.Close();

                        Console.WriteLine("Digite o ID do usuário que deseja alterar (❁´◡`❁)");
                        user.idUsu = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o novo nome do usuário que deseja alterar (❁´◡`❁)");
                        user.NomeUsu = Console.ReadLine();

                        Console.WriteLine("Digite o novo cargo do usuário que deseja alterar (❁´◡`❁)");
                        user.Cargo = Console.ReadLine();

                        Console.WriteLine("Digite a nova dt. de nascimento do usuário que deseja alterar (❁´◡`❁)");
                        user.DtNasc = DateTime.Parse(Console.ReadLine());

                        new UserDAO().Update(user);
                        break;
                    case "4":
                        Console.WriteLine("Apenas lembrando:");

                        string checkUs = "Select * from tb_liaUsuario";
                        MySqlDataReader checker = database.Return(checkUs);
                        Console.WriteLine("===================== Dados dos Clientes =====================");
                        Console.WriteLine(" ");
                        while (checker.Read())
                        {
                            Console.WriteLine("Cliente número {0}:", checker["IdUsu"]);
                            Console.WriteLine("Nome: {0}, Cargo: {1}, Data: {2}",
                                checker["NomeUsu"], checker["Cargo"], checker["DtNasc"]);
                        }
                        checker.Close();
                        Console.WriteLine("Digite o ID do usuário que deseja deletar (❁´◡`❁)");
                        string idCheckUsu = Console.ReadLine();

                        string delUser = string.Format("delete from tb_liaUsuario where IdUsu = {0}",
                        idCheckUsu);
                        break;
                }
                if (needsCheck == true)
                {
                    string postCheck = "Select * from tb_liaUsuario";
                    MySqlDataReader postChecker = database.Return(postCheck);
                    Console.WriteLine("===================== Dados atualizados dos Clientes =====================");
                    Console.WriteLine(" ");
                    while (postChecker.Read())
                    {
                        Console.WriteLine("Cliente número {0}:", postChecker["IdUsu"]);
                        Console.WriteLine("Nome: {0}, Cargo: {1}, Data: {2}",
                            postChecker["NomeUsu"], postChecker["Cargo"], postChecker["DtNasc"]);
                    }
                    postChecker.Close();
                }
                while (aswered == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Deseja continuar? (S para sim, N para não)");
                    string yesOrNo = Convert.ToString(Console.ReadLine());
                    if (yesOrNo == "S")
                    {
                        cont = true;
                        aswered = true;
                    }
                    else if(yesOrNo == "N")
                     {
                        cont = false;
                        aswered = true;
                    }
                    else
                    {
                       aswered = false;
                    }
                }
            }
        }

    }

}
