using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEx01._0._0.Classes
{
    class UserDAO
    {
        private Database db;

        public void Insert(User user)
        {
            var strQuery = "";
            strQuery += string.Format("insert into tb_liaUsuario values(default, '{0}', '{1}', STR_TO_DATE('{2}', '%d/%m/%Y %T'))",
                        user.NomeUsu, user.Cargo, user.DtNasc);

            using (db = new Database())
            {
                db.ExcCommand(strQuery);
            }
        }

        public void Update(User user)
        {
            db = new Database();

            string strQuery = "";
                strQuery += "update tb_liaUsuario set ";
                strQuery += string.Format("NomeUsu =  '{0}', ", user.NomeUsu);
                strQuery += string.Format("Cargo = '{0}', ", user.Cargo);
                strQuery += string.Format("DtNasc = str_to_date('{0}', '%d/%m/%Y %T') ", user.DtNasc);
                strQuery += string.Format("where IdUsu = {0}", user.idUsu);
            using (db = new Database())
            {
                db.ExcCommand(strQuery);
            }
        }

        public void Delete(User user)
        {
            using (db = new Database())
            {
                var strQuery = string.Format("delete from tb_liaUsuario where IdUsu = {0}", user.idUsu);
                db.ExcCommand(strQuery);
            }
        }

        public List<User> List()
        {
            using(db = new Database())
            {
                var strQuery = "select * from tb_liaUsuario;";
                var results = db.Return(strQuery);
                return ListUsers(results);
            }
        }
        public List<User> ListSameId(int IdUsu)
        {
            using (db = new Database())
            {
                var strQuery = String.Format("select * from tb_liaUsuario where IdUsu = {0};",IdUsu);
                var results = db.Return(strQuery);
                return ListUsers(results);
            }
        }

        public List<User> ListUsers(MySqlDataReader results)
        {
            var users = new List<User>();
            while(results.Read())
            {
                var TempUsers = new User()
                {
                    idUsu = int.Parse(results["IdUsu"].ToString()),
                    NomeUsu = results["NomeUsu"].ToString(),
                    Cargo = results["Cargo"].ToString(),
                    DtNasc = DateTime.Parse(results["DtNasc"].ToString())
                };
                users.Add(TempUsers);
            }
            results.Close();
            return users;
        }
    }
}
