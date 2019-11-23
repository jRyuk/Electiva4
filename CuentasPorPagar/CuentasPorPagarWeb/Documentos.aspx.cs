using DAL;
using DAL.BAL;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CuentasPorPagarWeb
{
    public partial class Documentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbContext.Instance.Init("default");
            GridView1.DataSource = UsuariosBAL.Instance.ObtenerReporteDocumentos();
            GridView1.DataBind();
        }

        protected void btnEportarCsv_Click(object sender, EventArgs e)
        {
            try
            {
                string txt = string.Empty;

                for (int i = 0; i < GridView1.HeaderRow.Cells.Count; i++)
                {
                    txt += GridView1.HeaderRow.Cells[i].Text.ToString() + ",";
                }
                txt += "\r\n";
                foreach (GridViewRow row in GridView1.Rows)
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
                String g =  dateTime + ".csv";

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

        protected void btnExportarPdf_Click(object sender, EventArgs e)
        {
            Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
            try
            {
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
                var dt = UsuariosBAL.Instance.ObtenerReporteDocumentos();
                if (dt != null)
                {
                    //Craete instance of the pdf table and set the number of column in that table  
                    PdfPTable PdfTable = new PdfPTable(dt.Columns.Count);
                    PdfPCell PdfPCell = null;
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

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}