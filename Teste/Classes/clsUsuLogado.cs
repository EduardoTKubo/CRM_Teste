using System;
using System.Data;
using System.Threading.Tasks;

namespace Teste.Classes
{
    class clsUsuLogado
    {
        private static string log_Id = string.Empty;
        public static string Log_Id
        {
            get { return clsUsuLogado.log_Id; }
        }
        
        private static string log_Nome = string.Empty;
        public static string Log_Nome
        {
            get { return clsUsuLogado.log_Nome; }
        }

        private static string log_Cpf = string.Empty;
        public static string Log_Cpf
        {
            get { return clsUsuLogado.log_Cpf; }
        }

        private static string log_Rank = string.Empty;
        public static string Log_Rank
        {
            get { return clsUsuLogado.log_Rank; }
        }
        
        private static string log_Status = string.Empty;
        public static string Log_Status
        {
            get { return clsUsuLogado.log_Status; }
        }

        private static string log_Senha = string.Empty;
        public static string Log_Senha
        {
            get { return clsUsuLogado.log_Senha; }
        }


        private static string log_Equipe = string.Empty;
        public static string Log_Equipe
        {
            get { return clsUsuLogado.log_Equipe; }
        }

        public static string log_Base = string.Empty;
        public static string Log_Base
        {
            get { return log_Base; }
            set { log_Base = value.TrimStart().TrimEnd(); }
        }


        public static string log_NomePC = string.Empty;
        public static string Log_NomePC
        {
            get { return log_NomePC; }
            set { log_NomePC = value.TrimStart().TrimEnd(); }
        }
               
        
        public async static Task<bool> IsLoginOK(string cpf, string senha)
        {
            if (cpf.Length < 6)
            {
                clsVariaveis.StrSQL = ("select * from Usuarios where Ativo = 1 and Matricula = '@cpf' ").Replace("@cpf", cpf);
            }
            else
            {
                if (senha.Length > 0)
                {
                    clsVariaveis.StrSQL = ("select * from Usuarios where Ativo = 1 and Doc ='@cpf' and Senha = '@senha' ").Replace("@cpf", cpf).Replace("@senha", senha);
                }
                else
                {
                    clsVariaveis.StrSQL = ("select * from Usuarios where Ativo = 1 and Doc ='@cpf' ").Replace("@cpf", cpf);
                }

            }

            DataTable dt = await Classes.clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }


        public async static Task<bool> ObterDadosUsuarioLogado(string cpf)
        {
            string Param = "[IdUsu],[Nome],[Doc],[Rank],[Status],[Senha],[Equipe],[Base]";

            DataTable dt = new DataTable();
            if (cpf.Length < 6)
            {
                dt = await Classes.clsConexao.ConsultaAsync(("select " + Param + " from Usuarios where Ativo = 1 and Matricula = '@cpf' ").Replace("@cpf", cpf));
            }
            else
            {
                dt = await Classes.clsConexao.ConsultaAsync(("select " + Param + " from Usuarios where Ativo = 1 and Doc = '@cpf' ").Replace("@cpf", cpf));
            }

            if (dt.Rows.Count > 0)
            {
                CarregarDadosUsuarioLogado(dt);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void CarregarDadosUsuarioLogado(DataTable dt)
        {
            //clsUsuario.usu_cod = Convert.ToInt32(dt.Rows[0][0].ToString());
            log_Id = dt.Rows[0][0].ToString();
            log_Nome = dt.Rows[0][1].ToString();
            log_Cpf = dt.Rows[0][2].ToString();
            log_Rank = dt.Rows[0][3].ToString();
            log_Status = dt.Rows[0][4].ToString();
            log_Senha = dt.Rows[0][5].ToString();
            log_Equipe = dt.Rows[0][6].ToString();
            log_Base = dt.Rows[0][7].ToString();
            log_NomePC = Environment.MachineName;
        }

        public async static void MapOperacional(string _cpf)
        {
            clsVariaveis.StrSQL = "select * from Map_Operacional where Operador = '" + _cpf +
                                   "' and data = '" + DateTime.Now.ToString("yyyy-MM-dd") +
                                   "' and PA = '" + clsUsuLogado.log_NomePC + "' ";
            DataTable dtUsu = new DataTable();
            dtUsu = await Classes.clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if (dtUsu.Rows.Count == 0)
            {
                clsVariaveis.StrSQL = "insert into Map_Operacional ( Operador ,pa ,data ,inicio ) " +
                                       "values ( '" + _cpf + "' ,'" + clsUsuLogado.log_NomePC +
                                       "' ,'" + DateTime.Now.ToString("yyyy-MM-dd") +
                                       "' ,'" + DateTime.Now.ToString("HH:mm:ss") + "' )";
                bool booMap = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);
            }
        }

    }
}
