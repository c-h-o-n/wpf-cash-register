using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace Penztargep_dr1_WPF.Services {
    public class PdfService : IPdfService {
        private readonly IDataService<Receipt> _receiptService;
        private readonly IDataService<ReceiptItem> _receiptItemService;
        public ICommand CreatePDFCommand => throw new NotImplementedException();

        public void CreatePdfReceipt(Receipt receipt, IEnumerable<ReceiptItem> receiptItems) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.pdf)|*.pdf";
            saveFileDialog.ShowDialog();
           
            try {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create)) {
                    Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);

                    PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();
                    PdfPTable table = new PdfPTable(2);
                    table.DefaultCell.Border = Rectangle.NO_BORDER;
                    PdfPCell cell = new PdfPCell(new Phrase("Nyugta"));
                    cell.Colspan = 2;
                    cell.HorizontalAlignment = 1;
                    cell.Border = Rectangle.NO_BORDER;
                    table.AddCell(cell);
                    foreach (var item in receiptItems) {
                        table.AddCell(item.Product.Name);
                        table.AddCell(item.Total.ToString());
                    }
                    table.AddCell("Összesen:");
                    table.AddCell(receipt.Total.ToString());

                    String date = receipt.Date.Substring(0, receipt.Date.LastIndexOf(".")+1);
                    String hour = receipt.Date.Substring(receipt.Date.LastIndexOf(".")+2);
                    table.AddCell(date);
                    table.AddCell(hour);

                    pdfDoc.Add(table);
                    pdfDoc.Close();
                    stream.Close();
                }
            } catch (Exception) {

            }
        }
    }
}
