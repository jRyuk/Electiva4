using DAL;
using DAL.BAL;
using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Reportes
{
    public partial class ReporteDocumentos : Form
    {
        public ReporteDocumentos()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dataGridView1.DataSource = null;
         
            dataGridView1.DataSource = UsuariosBAL.Instance.ObtenerReporteDocumentos();
        }

        private void copyAlltoClipboard()
        {
           
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("sep=,");
            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            var choofdlog = new FolderBrowserDialog();
         

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                var path = choofdlog.SelectedPath;
                using (var file = File.Open(($"{path}{DateTime.Now.ToString().Replace(" ", "").Replace("\\", "").Replace("/","").Replace(":", "")}.csv"), FileMode.OpenOrCreate))
                {
                    UnicodeEncoding uniencoding = new UnicodeEncoding();
                    byte[] result = uniencoding.GetBytes(sb.ToString());

                    file.Seek(0, SeekOrigin.End);
                     file.Write(result, 0, result.Length);
                }
            }

        }
    }
}
