using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Teste.Classes
{
    class clsExcel
    {

        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);

        public static void ExportarXLS(DataGridView dgv)
        {
            if (dgv.RowCount == 0)
            {
                MessageBox.Show("Não tem registros para exportar", "Relatórios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(Type.Missing);

            wb.Sheets.Add();
            Microsoft.Office.Interop.Excel.Worksheet ws1 = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            ws1.Name = "Relatorio";

            try
            {
                for (int i = 1; i < dgv.Columns.Count + 1; i++)
                {
                    ws1.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }
                //
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        //if (j != 2)
                        //{
                        ws1.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                        //}
                        //else
                        //{
                        //    ws1.Cells[i + 2, j + 1] = "'" + dgv.Rows[i].Cells[j].Value.ToString(); //+ "'";
                        //}
                    }
                }
                ws1.Columns.AutoFit();

                MessageBox.Show("Exportação finalizada", "Relatório", MessageBoxButtons.OK, MessageBoxIcon.Information);
                app.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlNormal;
                app.Visible = true;
            }
            catch (Exception ex)
            {
                if (!ex.Message.Equals("Exceção de HRESULT: 0x800A03EC"))
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }
                else
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }
            }
            finally
            {
                //GetExcelProcessAndKill(app);
                app = null;
                wb = null;
                ws1 = null;
            }
        }


        public static void GetExcelProcessAndKill(Microsoft.Office.Interop.Excel.Application excelApp)
        {
            int id = 0;
            GetWindowThreadProcessId(excelApp.Hwnd, out id);
            Process.GetProcessById(id).Kill();
        }

    }
}
