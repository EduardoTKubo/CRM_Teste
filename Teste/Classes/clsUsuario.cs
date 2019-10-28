
namespace Teste.Classes
{
    class clsUsuario
    {
        public int Usu_Id { get; set; }
        public string Usu_Nome { get; set; }
        public string Usu_Cpf { get; set; }
        public string Usu_Rank { get; set; }
        public string Usu_Status { get; set; }
        public string Usu_Senha { get; set; }
        public string Usu_PedeSenha { get; set; }
        public string Usu_Equipe { get; set; }

        public clsUsuario()
        {
        }

        public clsUsuario(int usu_Id, string usu_Nome, string usu_Cpf, string usu_Rank, string usu_Status, string usu_Senha, string usu_PedeSenha, string usu_Equipe)
        {
            Usu_Id = usu_Id;
            Usu_Nome = usu_Nome;
            Usu_Cpf = usu_Cpf;
            Usu_Rank = usu_Rank;
            Usu_Status = usu_Status;
            Usu_Senha = usu_Senha;
            Usu_PedeSenha = usu_PedeSenha;
            Usu_Equipe = usu_Equipe;
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
