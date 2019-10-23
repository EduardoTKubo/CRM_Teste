using System;

namespace Teste.Classes
{
    class clsVariaveis
    {
        private static string conexao = @"Data Source=10.0.32.54;Initial Catalog=Teste; User ID=sa; Password=SRV@admin2012;";
        public static string Conexao
        {
            get { return clsVariaveis.conexao; }
        }
        
        private static string strSQL = string.Empty;
        public static string StrSQL
        {
            get { return clsVariaveis.strSQL; }
            set { clsVariaveis.strSQL = value; }
        }


        private static int intContador = 0;
        public static int IntContador
        {
            get { return intContador; }
            set { intContador = value; }
        }

        private static DateTime hrIni = DateTime.Now;
        public static DateTime HrIni
        {
            get { return clsVariaveis.hrIni; }
            set { clsVariaveis.hrIni = value; }
        }

        private static string strDDD = string.Empty;
        public static string StrDDD
        {
            get { return clsVariaveis.strDDD; }
            set { clsVariaveis.strDDD = value; }
        }

        private static string strTel = string.Empty;
        public static string StrTel
        {
            get { return clsVariaveis.strTel; }
            set { clsVariaveis.strTel = value; }
        }

        private static int intQTelLigou = 0;
        public static int IntQTelLigou
        {
            get { return clsVariaveis.intQTelLigou; }
            set { clsVariaveis.intQTelLigou = value; }
        }


        private static string strNegativa = string.Empty;
        public static string StrNegativa
        {
            get { return clsVariaveis.strNegativa; }
            set { clsVariaveis.strNegativa = value; }
        }



    }
}
