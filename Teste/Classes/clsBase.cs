

using System.Threading.Tasks;

namespace Teste.Classes
{
    class clsBase
    {

        public string Bs_Dt_Arquivo { get; set; }
        public string Bs_Dt_Limite { get; set; }
        public string Bs_Acao { get; set; }
        public string Bs_Arquivo { get; set; }
        public string Bs_Ordem { get; set; }
        public string Bs_Nr_Ciclo_Atual { get; set; }
        public string Bs_Nr_Item_Ordem { get; set; }
        public string Bs_Cd_Prod_Midia { get; set; }
        public string Bs_Nome { get; set; }
        public string Bs_Doc { get; set; }
        public string Bs_Operador { get; set; }
        public string Bs_Tipo_Tab { get; set; }
        public string Bs_Tabulacao { get; set; }
        public string Bs_Data { get; set; }
        public string Bs_Hora { get; set; }
        public string Bs_Obs { get; set; }
        public string Bs_Uso { get; set; }
        public string Bs_Repasses { get; set; }
        public string Bs_Em_Uso { get; set; }
        public string Bs_Em_UsoHora { get; set; }

        public string Bs_ObsDDD { get; set; }
        public string Bs_ObsTel { get; set; }
        public string Bs_ObsAg { get; set; }

        public int Bs_TotTel { get; set; }
        public int Bs_LinhaGrid { get; set; }


        // construtores
        public clsBase()
        {
        }

        public clsBase(string bs_Dt_Arquivo, string bs_Dt_Limite, string bs_Acao, string bs_Arquivo, string bs_Ordem, string bs_Nr_Ciclo_Atual, string bs_Nr_Item_Ordem, string bs_Cd_Prod_Midia, string bs_Nome, string bs_Doc, string bs_Operador, string bs_Tipo_Tab, string bs_Tabulacao, string bs_Data, string bs_Hora, string bs_Obs, string bs_Uso, string bs_Repasses, string bs_Em_Uso, string bs_Em_UsoHora)
        {
            Bs_Dt_Arquivo = bs_Dt_Arquivo;
            Bs_Dt_Limite = bs_Dt_Limite;
            Bs_Acao = bs_Acao;
            Bs_Arquivo = bs_Arquivo;
            Bs_Ordem = bs_Ordem;
            Bs_Nr_Ciclo_Atual = bs_Nr_Ciclo_Atual;
            Bs_Nr_Item_Ordem = bs_Nr_Item_Ordem;
            Bs_Cd_Prod_Midia = bs_Cd_Prod_Midia;
            Bs_Nome = bs_Nome;
            Bs_Doc = bs_Doc;
            Bs_Operador = bs_Operador;
            Bs_Tipo_Tab = bs_Tipo_Tab;
            Bs_Tabulacao = bs_Tabulacao;
            Bs_Data = bs_Data;
            Bs_Hora = bs_Hora;
            Bs_Obs = bs_Obs;
            Bs_Uso = bs_Uso;
            Bs_Repasses = bs_Repasses;
            Bs_Em_Uso = bs_Em_Uso;
            Bs_Em_UsoHora = bs_Em_UsoHora;
        }


        //public async Task<bool> TabularTel( string _ddd ,string _tel , string _tab ,string _ordem ,string _arquivo ,string _acao )
        //{
        //    clsVariaveis.StrSQL = "Update Base_Tel";



        //}





    }
}
