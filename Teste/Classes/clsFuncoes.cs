using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Teste.Classes;

namespace Teste.Classes
{
    class clsFuncoes
    {
        public static string Duracao()
        {
            var dt1 = DateTime.Now;
            var dt2 = clsVariaveis.HrIni;

            TimeSpan dif = dt1 - dt2;

            string duracao = Convert.ToInt32(dif.TotalHours).ToString("D2") + ":" + Convert.ToInt32(dif.TotalMinutes).ToString("D2") + ":" + Convert.ToInt32(dif.TotalSeconds).ToString("D2");
            return duracao;
        }

        public static bool IsNumeric(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }


        public static void LimpaCampos(Form _f, Control _Control)
        {
            foreach (Control item in _Control.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Text = "";
                }
                else if (item is Label)
                {
                    if (item.AllowDrop)
                    {
                        (item as Label).Text = "";
                    }
                }
                else if (item is CheckBox)
                {
                    (item as CheckBox).Checked = false;
                }
                else if (item is ComboBox)
                {
                    (item as ComboBox).Text = "";
                    (item as ComboBox).SelectedIndex = -1;
                }
                else if (item is MaskedTextBox)
                {
                    (item as MaskedTextBox).Clear();
                }
                else if (item is RadioButton)
                {
                    (item as RadioButton).Checked = false;
                }
                else if (item is TabControl)
                {
                    (item as TabControl).SelectedIndex = 0;
                }
            }
        }


        public static string MontaInsert(string _strDado, string _strTipo)
        {
            if (_strDado == "")
            {
                return " NULL ";
            }
            else
            {
                if (_strTipo == "TEXT")
                {
                    if (_strDado == "  /")
                    {
                        return " NULL ";
                    }
                    else
                    {
                        return " '" + _strDado.Trim() + "' ";
                    }
                }
                else if (_strTipo == "EMAIL")
                {
                    return " '" + _strDado.Trim().ToLower() + "' ";
                }
                else if (_strTipo == "INT")
                {
                    return " " + _strDado + " ";
                }
                else if (_strTipo == "REAL")
                {
                    _strDado = _strDado.Replace(".", "");
                    _strDado = _strDado.Replace(",", ".");
                    return " " + _strDado + " ";
                }
                else if (_strTipo == "DATE")
                {
                    if (_strDado == "  /  /")
                    {
                        return " NULL ";
                    }
                    else
                    {
                        return " '" + Convert.ToDateTime(_strDado).ToString("yyyy-MM-dd") + "' ";
                    }
                }
                else if (_strTipo == "BOO")
                {
                    if (_strDado == "True")
                    {
                        return " 1 ";
                    }
                    else
                    {
                        return " 0 ";
                    }
                }
                else
                {
                    return " NULL ";
                }
            }
        }


        public static string MontaUpdate(string _strcampo, string _strDado, string _strTipo)
        {
            if (_strDado == "")
            {
                return _strcampo + " = NULL ";
            }
            else
            {
                if (_strTipo == "TEXT")
                {
                    if (_strDado == "  /  /")
                    {
                        return _strcampo + " = NULL ";
                    }
                    else if (_strDado == "  /")
                    {
                        return _strcampo + " = NULL ";
                    }
                    else
                    {
                        return _strcampo + " = '" + _strDado.Trim() + "' ";
                    }
                }
                else if (_strTipo == "INT")
                {
                    return _strcampo + " = " + _strDado + " ";
                }
                else if (_strTipo == "REAL")
                {
                    _strDado = _strDado.Replace(".", "");
                    _strDado = _strDado.Replace(",", ".");
                    return _strcampo + " = " + _strDado + " ";
                }
                else if (_strTipo == "EMAIL")
                {
                    return _strcampo + " = '" + _strDado.Trim().ToLower() + "' ";
                }
                else if (_strTipo == "BOO")
                {
                    if (_strDado == "True")
                    {
                        return _strcampo + " = 1 ";
                    }
                    else
                    {
                        return _strcampo + " = 0 ";
                    }
                }
                else if (_strTipo == "DATE")
                {
                    if (_strDado == "  /  /")
                    {
                        return _strcampo + " = NULL ";
                    }
                    else
                    {
                        return _strcampo + " = '" + Convert.ToDateTime(_strDado).ToString("yyyy-MM-dd") + "' ";
                    }
                }
                else
                {
                    return _strcampo + " = NULL ";
                }
            }
        }

        public static void OpenForm(Form f, Form Container, string tpShow)
        {
            try
            {
                foreach (Form childForm in Container.MdiChildren)
                {
                    if (childForm.Name == f.Name)
                        return;
                }

                f.StartPosition = FormStartPosition.CenterScreen;
                //f.MdiParent = Container;
                if (tpShow == "0")
                {
                    f.Show();
                }
                else
                {
                    f.ShowDialog();
                }

            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar abrir o Formulario", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void OpenFormModal(Form f)
        {
            try
            {
                f.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar abrir o Formulario", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string PrimeiroDiadoMes(string _destino)
        {
            string resp = "";

            switch (_destino)
            {
                case "SQL":
                    resp = DateTime.Today.Subtract(TimeSpan.FromDays(DateTime.Today.Day - 1)).ToString("yyyy-MM-dd");
                    break;
                case "DATE":
                    resp = DateTime.Today.Subtract(TimeSpan.FromDays(DateTime.Today.Day - 1)).ToString("dd/MM/yyyy");
                    break;
                default:
                    break;
            }
            return resp;
        }

        public static string PrimeiroDiadoMesAnterior(string _destino)
        {
            string resp = "";
            DateTime dtBase = DateTime.Now;
            dtBase = dtBase.AddMonths(-1);

            switch (_destino)
            {
                case "SQL":
                    resp = dtBase.Subtract(TimeSpan.FromDays(dtBase.Day - 1)).ToString("yyyy-MM-dd"); ;
                    break;
                case "DATE":
                    resp = dtBase.Subtract(TimeSpan.FromDays(dtBase.Day - 1)).ToString("dd/MM/yyyy"); ;
                    break;
                default:
                    break;
            }
            return resp;
        }

        public static string TextNoFormatting(Form form, MaskedTextBox mask)
        {
            mask.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            String retString = mask.Text;
            mask.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            return retString;
        }

        public static string ToDateUSA(string _data)
        {
            DateTime data = Convert.ToDateTime(_data);
            return data.Year.ToString() + "-" + data.Month.ToString() + "-" + data.Day.ToString();
        }


        public static string ValidarData(Form form, MaskedTextBox msk)
        {
            string dtOK = "";

            string semMask = clsFuncoes.TextNoFormatting(form, msk);
            if (semMask.Length != 0)
            {
                DateTime resultado = DateTime.MinValue;
                if (!DateTime.TryParse(msk.Text, out resultado))
                {
                    dtOK = "Data Inválida";
                }
            }
            return dtOK;
        }


        public static string ValidarDoc(Form _f, TextBox _t)
        {
            string docvalido = "";

            string strInf = _t.Text.Trim();
            if (strInf != "")
            {
                int tamanho = strInf.Length;
                if (tamanho < 12)
                {
                    strInf = Convert.ToUInt64(strInf).ToString(@"00000000000");
                    _t.Text = strInf;
                    if (!Classes.clsFuncoes.IsCpf(strInf))
                    {
                        docvalido = "CPF inválido!";
                    }
                }
                else
                {
                    strInf = Convert.ToUInt64(strInf).ToString(@"00000000000000");
                    _t.Text = strInf;
                    if (!Classes.clsFuncoes.IsCnpj(strInf))
                    {
                        docvalido = "CNPJ inválido!";
                    }
                }
            }
            return docvalido;
        }


        public static bool ValidarEmail(Form _f, TextBox _t)
        {
            bool emailValido = false;

            string strInf = _t.Text.Trim();
            if (strInf != "")
            {
                string email = _t.Text;
                email = email.ToLower();
                _t.Text = email.ToLower();

                //Expressão regular retirada de
                //https://msdn.microsoft.com/pt-br/library/01escwtf(v=vs.110).aspx
                string emailRegex = string.Format("{0}{1}",
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

                try
                {
                    emailValido = Regex.IsMatch(email, emailRegex);
                }
                catch (RegexMatchTimeoutException)
                {
                    emailValido = false;
                }
            }
            return emailValido;
        }

    }
}
