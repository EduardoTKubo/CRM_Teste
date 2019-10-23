using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Classes
{
    class clsUsuario
    {
        private string usu_Id = string.Empty;
        public string Usu_Id
        {
            get { return usu_Id.TrimStart().TrimEnd(); }
            set { usu_Id = value.TrimStart().TrimEnd(); }
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


        private string usu_Equipe = string.Empty;
        public string Usu_Equipe
        {
            get { return usu_Equipe.TrimStart().TrimEnd(); }
            set { usu_Equipe = value.TrimStart().TrimEnd(); }
        }
        
        private string usu_Base = string.Empty;
        public string Usu_Base
        {
            get { return usu_Base.TrimStart().TrimEnd(); }
            set { usu_Base = value.TrimStart().TrimEnd(); }
        }

 
        //private string usu_TrocaDeBase = string.Empty;
        //public string Usu_TrocaDeBase
        //{
        //    get { return usu_TrocaDeBase.TrimStart().TrimEnd(); }
        //    set { usu_TrocaDeBase = value.TrimStart().TrimEnd(); }
        //}

        private bool usu_TrocaDeBase = false;
        public bool Usu_TrocaDeBase
        {
            get { return usu_TrocaDeBase; }
            set { usu_TrocaDeBase = value; }
        }




    }
}
