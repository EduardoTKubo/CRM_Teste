using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Classes
{
    class clsUsuario
    {
        private int usu_Id;
        public int Usu_Id
        {
            get { return usu_Id; }
            set { usu_Id = value; }
        }

        //private string usu_Matr = string.Empty;
        //public string Usu_Matr
        //{
        //    get { return usu_Matr.TrimStart().TrimEnd(); }
        //    set { usu_Matr = value.TrimStart().TrimEnd(); }
        //}

        private string usu_Nome = string.Empty;
        public string Usu_Nome
        {
            get { return usu_Nome.TrimStart().TrimEnd(); }
            set { usu_Nome = value.TrimStart().TrimEnd(); }
        }

        private string usu_Cpf = string.Empty;
        public string Usu_Cpf
        {
            get { return usu_Cpf.TrimStart().TrimEnd(); }
            set { usu_Cpf = value.TrimStart().TrimEnd(); }
        }


        private string usu_Rank = string.Empty;
        public string Usu_Rank
        {
            get { return usu_Rank.TrimStart().TrimEnd(); }
            set { usu_Rank = value.TrimStart().TrimEnd(); }
        }

        private string usu_Status = string.Empty;
        public string Usu_Status
        {
            get { return usu_Status.TrimStart().TrimEnd(); }
            set { usu_Status = value.TrimStart().TrimEnd(); }
        }
        
        private string usu_Senha = string.Empty;
        public string Usu_Senha
        {
            get { return usu_Senha.TrimStart().TrimEnd(); }
            set { usu_Senha = value.TrimStart().TrimEnd(); }
        }

        private string usu_PedeSenha = string.Empty;
        public string Usu_PedeSenha
        {
            get { return usu_PedeSenha.TrimStart().TrimEnd(); }
            set { usu_PedeSenha = value.TrimStart().TrimEnd(); }
        }

        private string usu_Equipe = string.Empty;
        public string Usu_Equipe
        {
            get { return usu_Equipe.TrimStart().TrimEnd(); }
            set { usu_Equipe = value.TrimStart().TrimEnd(); }
        }



        public clsUsuario()
        {
        }
               
        // construtor
        public clsUsuario(int usu_Id, string usu_Nome, string usu_Cpf, string usu_Rank, string usu_Status, string usu_Senha, string usu_PedeSenha, string usu_Equipe)
        {
            this.usu_Id = usu_Id;
            this.usu_Nome = usu_Nome;
            this.usu_Cpf = usu_Cpf;
            this.usu_Rank = usu_Rank;
            this.usu_Status = usu_Status;
            this.usu_Senha = usu_Senha;
            this.usu_PedeSenha = usu_PedeSenha;
            this.usu_Equipe = usu_Equipe;
        }
        

        public static string ComandoInsertUsuario(clsUsuario Usuario)
        {
            string Comando = "insert into Usuario (Doc ,Nome ,Status ,Rank ,Senha ,SolicitaSenha ,Equipe ) values (";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_Cpf, "TEXT")      + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_Nome, "TEXT")     + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_Status , "TEXT")  + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_Rank, "TEXT")     + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_Senha, "TEXT")    + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_PedeSenha, "BOO") + " ,";
            Comando += clsFuncoes.MontaInsert(Usuario.Usu_Equipe, "TEXT")   + " )";

            //DateTime thisDay = DateTime.Today;
            //Comando += "'" + clsFuncoes.ToDateUSA(thisDay.ToString()) + "' ,";

            return Comando;
        }


        public static string ComandoUpdateUsuario(clsUsuario Usuario)
        {
            string Comando = "update Usuario set " +clsFuncoes.MontaUpdate("nome", Usuario.Usu_Nome, "TEXT").ToString();
            Comando += "," + clsFuncoes.MontaUpdate("status"       , Usuario.Usu_Status   , "TEXT");
            Comando += "," + clsFuncoes.MontaUpdate("rank"         , Usuario.Usu_Rank     , "TEXT");
            Comando += "," + clsFuncoes.MontaUpdate("senha"        , Usuario.Usu_Senha    , "TEXT");
            Comando += "," + clsFuncoes.MontaUpdate("solicitasenha", Usuario.Usu_PedeSenha, "BOO");
            Comando += "," + clsFuncoes.MontaUpdate("equipe"       , Usuario.Usu_Equipe   , "TEXT");
            Comando += " where IdUsu = " + Usuario.Usu_Id.ToString();

            return Comando;
        }
    }
}
