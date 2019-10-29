using System;
using System.Data;
using System.Threading.Tasks;

namespace Teste.Classes
{
    class clsUsuLogado
    {

        public static string Log_Id { get; set; }
        public static string Log_Nome { get; set; }
        public static string Log_Cpf { get; set; }
        public static string Log_Rank { get; set; }
        public static string Log_Status { get; set; }
        public static string Log_Senha { get; set; }
        public static string Log_Equipe { get; set; }
        public static string Log_Base { get; set; }
        public static string Log_SeqBase { get; set; }
        public static string Log_NomePC { get; set; }


        // construtores
        public clsUsuLogado()
        {
        }

        public clsUsuLogado(string log_Id, string log_Nome, string log_Cpf, string log_Rank, string log_Status, string log_Senha, string log_Equipe, string log_Base, string log_SeqBase, string log_NomePC)
        {
            Log_Id = log_Id;
            Log_Nome = log_Nome;
            Log_Cpf = log_Cpf;
            Log_Rank = log_Rank;
            Log_Status = log_Status;
            Log_Senha = log_Senha;
            Log_Equipe = log_Equipe;
            Log_Base = log_Base;
            Log_SeqBase = log_SeqBase;
            Log_NomePC = log_NomePC;
        }



        public async static Task<bool> IsLoginOK(string cpf, string senha)
        {
            int intI = 0;

            if (cpf.Length < 6)
            {
                clsVariaveis.StrSQL = ("select * from Usuario where Ativo = 1 and Matricula = '" + cpf + "' ");
                intI = 1;
            }
            else
            {
                if (senha.Length > 0)
                {
                    clsVariaveis.StrSQL = ("select * from Usuario where Ativo = 1 and Doc ='" + cpf + "' and Senha = '" + senha + "' and SolicitaSenha = 1 ");
                    intI = 2;
                }
                else
                {
                    clsVariaveis.StrSQL = ("select * from Usuario where Ativo = 1 and Doc ='" + cpf + "' and SolicitaSenha = 0");
                    intI = 3;
                }

            }

            DataTable dt = new DataTable();
            dt = await Classes.clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                switch (intI)
                {
                    case 1:
                        clsVariaveis.StrErro = "Matricula não encontrada";
                        break;
                    case 2:
                        clsVariaveis.StrErro = "Documento ou Senha Inválida";
                        break;
                    case 3:
                        clsVariaveis.StrErro = "Matricula não encontrada";
                        break;
                }                

                return false;
            }    
            
        }


        public async static Task<bool> ObterDadosUsuarioLogado(string cpf)
        {
            string Param = "[IdUsu],[Nome],[Doc],[Rank],[Status],[Senha],[Equipe],[BaseDeTrab],[SeqDaBase]";

            DataTable dt = new DataTable();
            if (cpf.Length < 6)
            {
                dt = await Classes.clsConexao.ConsultaAsync(("select " + Param + " from Usuario where Ativo = 1 and Matricula = '@cpf' ").Replace("@cpf", cpf));
            }
            else
            {
                dt = await Classes.clsConexao.ConsultaAsync(("select " + Param + " from Usuario where Ativo = 1 and Doc = '@cpf' ").Replace("@cpf", cpf));
            }

            if (dt.Rows.Count > 0)
            {
                CarregarClasseUsuarioLogado(dt);
                return true;
            }
            else
            {
                return false;
            }

        }


        public static void CarregarClasseUsuarioLogado(DataTable dt)
        {
            //clsUsuario.usu_cod = Convert.ToInt32(dt.Rows[0][0].ToString());
            clsUsuLogado.Log_Id = dt.Rows[0][0].ToString();
            clsUsuLogado.Log_Nome = dt.Rows[0][1].ToString();
            clsUsuLogado.Log_Cpf = dt.Rows[0][2].ToString();
            clsUsuLogado.Log_Rank = dt.Rows[0][3].ToString();
            clsUsuLogado.Log_Status = dt.Rows[0][4].ToString();
            clsUsuLogado.Log_Senha = dt.Rows[0][5].ToString();
            clsUsuLogado.Log_Equipe = dt.Rows[0][6].ToString();
            clsUsuLogado.Log_Base = dt.Rows[0][7].ToString();
            clsUsuLogado.Log_SeqBase = dt.Rows[0][8].ToString();
            clsUsuLogado.Log_NomePC = Environment.MachineName;
        }


        public static void InicializaConfigOperador()
        {
            clsUsuLogado.Log_Base = "";

            clsVariaveis.StrSQL = "select BaseDeTrab ,SeqDaBase from Usuario where Doc = '" + clsUsuLogado.Log_Cpf + "' and Ativo = 1";
            DataTable dtOpe = clsConexao.Consulta(clsVariaveis.StrSQL);
            if (dtOpe.Rows.Count > 0)
            {
                clsUsuLogado.Log_Base = dtOpe.Rows[0]["BaseDeTrab"].ToString();
                clsUsuLogado.Log_SeqBase = dtOpe.Rows[0]["SeqDaBase"].ToString();
            }
        }


        public async static void MapOperacional(string _cpf)
        {
            clsVariaveis.StrSQL = "select * from Map_Operacional where Operador = '" + _cpf +
                                   "' and data = '" + DateTime.Now.ToString("yyyy-MM-dd") +
                                   "' and PA = '" + clsUsuLogado.Log_NomePC + "' ";
            DataTable dtUsu = new DataTable();
            dtUsu = await Classes.clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if (dtUsu.Rows.Count == 0)
            {
                clsVariaveis.StrSQL = "insert into Map_Operacional ( Operador ,pa ,data ,inicio ) " +
                                       "values ( '" + _cpf + "' ,'" + clsUsuLogado.Log_NomePC +
                                       "' ,'" + DateTime.Now.ToString("yyyy-MM-dd") +
                                       "' ,'" + DateTime.Now.ToString("HH:mm:ss") + "' )";
                bool booMap = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);
            }
        }

    }
}
