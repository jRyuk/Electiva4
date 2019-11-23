using DAL;
using DAL.BAL;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuentasPorPagarWeb
{
    public partial class Proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbContext.Instance.Init("default");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
           

            var ncr = txtNRC.Text;

            if (string.IsNullOrEmpty(ncr)) return;

            var inicio = DateTime.Parse(txtInicio.Text).ToString("yyyy-MM-dd");
            var fin = DateTime.Parse(txtFin.Text).ToString("yyyy-MM-dd");

            var result = UsuariosBAL.Instance.ObtenerEstadoProveedor($"'{inicio}', '{fin}', '{ncr}'");
            dataGridView.DataSource =result;
            dataGridView.DataBind();
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {
                string txt = string.Empty;

                for (int i = 0; i < dataGridView.HeaderRow.Cells.Count; i++)
                {
                    txt += dataGridView.HeaderRow.Cells[i].Text.ToString() + ",";
                }
                txt += "\r\n";
                foreach (GridViewRow row in dataGridView.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        txt += cell.Text + ","; //Add the Data rows.
                    }
                    txt += "\r\n"; //Add new line.
                }

                Response.Clear(); //Download the Text file.
                HttpContext.Current.Response.Buffer = true;
                String dateTime = System.DateTime.Now.ToString("ddMMyyyyhhmmss");
                String g = dateTime + ".csv";

                Response.AddHeader("content-disposition", "attachment;filename=" + g + "");
                Response.Charset = "";
                Response.ContentType = "application/text";
                Response.Output.Write(txt.Replace("&#225;", "a"));
                Response.Flush();
                Response.End();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (System.Threading.ThreadAbortException ex)
            {

            }
            catch (Exception ex)
            {

            }

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            try
            {

                var ncr = txtNRC.Text;

                if (string.IsNullOrEmpty(ncr)) return;

                var inicio = DateTime.Parse(txtInicio.Text).ToString("yyyy-MM-dd");
                var fin = DateTime.Parse(txtFin.Text).ToString("yyyy-MM-dd");

                var result = UsuariosBAL.Instance.ObtenerEstadoProveedor($"'{inicio}', '{fin}', '{ncr}'");

                PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();
                Chunk c = new Chunk("Lista de documentos", FontFactory.GetFont("Verdana", 16));
                Paragraph p = new Paragraph();
                p.Alignment = Element.ALIGN_CENTER;
                p.Add(c);
                p.SpacingAfter = 20;
                pdfDoc.Add(p);

                //Resize image depend upon your need   

                Font font8 = FontFactory.GetFont("ARIAL", 7);
                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 7);
                var dt = result;
                if (dt != null)
                {
                    //Craete instance of the pdf table and set the number of column in that table  
                    PdfPTable PdfTable = new PdfPTable(dt.Columns.Count);
                    PdfPCell PdfPCell = null;

                    foreach (DataColumn column in dt.Columns)
                    {

                        PdfPCell = new PdfPCell(new Phrase(new Chunk(column.ColumnName, boldFont)));
                        PdfTable.AddCell(PdfPCell);

                    }

                    for (int rows = 0; rows < dt.Rows.Count; rows++)
                    {
                        for (int column = 0; column < dt.Columns.Count; column++)
                        {
                            PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font8)));
                            PdfTable.AddCell(PdfPCell);
                        }
                    }
                    //PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table            
                    pdfDoc.Add(PdfTable); // add pdf table to the document   
                }
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename= reporte.pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();  
            }
            catch (DocumentException de)
            {
                System.Web.HttpContext.Current.Response.Write(de.Message);
            }
            catch (IOException ioEx)
            {
                System.Web.HttpContext.Current.Response.Write(ioEx.Message);
            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Response.Write(ex.Message);
            }
        }
    }
}