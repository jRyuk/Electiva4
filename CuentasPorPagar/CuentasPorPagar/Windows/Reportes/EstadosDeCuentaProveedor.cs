using DAL.BAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CuentasPorPagar.Windows.Reportes
{
    public partial class EstadosDeCuentaProveedor : Form
    {
        public EstadosDeCuentaProveedor()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ncr = txtNCR.Text;

            if (string.IsNullOrEmpty(ncr)) return;

            var inicio = dInicio.Value.ToString("yyyy-MM-dd");
            var fin = dFin.Value.ToString("yyyy-MM-dd");

            var result = UsuariosBAL.Instance.ObtenerEstadoProveedor($"'{inicio}', '{fin}', '{ncr}'");

            dataGridView1.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
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
                using (var file = File.Open(($"{path}\\{DateTime.Now.ToString().Replace(" ", "").Replace("\\", "").Replace("/", "").Replace(":", "")}.csv"), FileMode.OpenOrCreate))
                {
                    UnicodeEncoding uniencoding = new UnicodeEncoding();
                    byte[] result = uniencoding.GetBytes(sb.ToString());

                    file.Seek(0, SeekOrigin.End);
                    file.Write(result, 0, result.Length);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var choofdlog = new FolderBrowserDialog();


            if (!(choofdlog.ShowDialog() == DialogResult.OK))
            {
                return;
            }
            var folderPath = choofdlog.SelectedPath;

            iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 32);
            iTextSharp.text.Font regularFont = FontFactory.GetFont("Arial", 36);
            Paragraph title;
            Paragraph text;
            title = new Paragraph("Reporte de documentos", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 20;

            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 90;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));

                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value == null ? "" : cell.Value.ToString());
                }
            }

            //Exporting to PDF

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "\\report.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(title);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }
    }
}
