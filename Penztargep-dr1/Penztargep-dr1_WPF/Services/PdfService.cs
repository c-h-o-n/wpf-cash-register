using iText.IO.Font;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Colorspace;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.Win32;
using Penztargep_dr1_Domain.Models;
using Penztargep_dr1_Domain.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace Penztargep_dr1_WPF.Services {
    public class PdfService : IPdfService {
        private readonly IDataService<Receipt> _receiptService;
        private readonly IDataService<ReceiptItem> _receiptItemService;
        public ICommand CreatePDFCommand => throw new NotImplementedException();

        public void CreatePdfReceipt(Receipt receipt, IEnumerable<ReceiptItem> receiptItems) {

            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var exportFile = System.IO.Path.Combine(exportFolder, "Test.pdf");

            using (var writer = new PdfWriter(exportFile)) {
                using (var pdf = new PdfDocument(writer)) {
                    Rectangle rectangle = new Rectangle(PageSize.A4);
                    var doc = new Document(pdf);

                    Table table = new Table(2);
                    //Table table = new Table(UnitValue.CreatePercentArray(1)).UseAllAvailableWidth();
                    table.SetMaxWidth(780f);
                    table.UseAllAvailableWidth();
                    table.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    table.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    table.SetBorder(Border.NO_BORDER);

                    Cell headerCell = new Cell(1, 2);
                    headerCell.SetBorder(Border.NO_BORDER);
                    headerCell.SetTextAlignment(TextAlignment.CENTER);
                    headerCell.Add(new Paragraph("Teszt cég neve\nTeszt cég székhelye\nBolt Neve\nBolt Címe\nEladó cég adószáma"));
                    table.AddCell(headerCell);

                    Cell subHeaderCell = new Cell(1, 2);
                    subHeaderCell.SetBorder(Border.NO_BORDER);
                    subHeaderCell.SetTextAlignment(TextAlignment.CENTER);
                    subHeaderCell.Add(new Paragraph("-----\tNyugta\t-----"));
                    table.AddCell(subHeaderCell);

                    foreach (var item in receiptItems) {
                        Cell nameCell = new Cell();
                        nameCell.SetBorder(Border.NO_BORDER);
                        nameCell.Add(new Paragraph(item.Product.Name));
                        table.AddCell(nameCell);

                        Cell priceCell = new Cell();
                        priceCell.SetBorder(Border.NO_BORDER);
                        priceCell.SetTextAlignment(TextAlignment.RIGHT);
                        priceCell.Add(new Paragraph(item.Total.ToString()));
                        table.AddCell(priceCell);
                    }

                    Cell separatorCell = new Cell(1, 2);
                    separatorCell.SetBorder(Border.NO_BORDER);
                    separatorCell.SetTextAlignment(TextAlignment.CENTER);
                    separatorCell.Add(new Paragraph("--------------------------------------------------"));
                    table.AddCell(separatorCell);

                    Cell totalStringCell = new Cell();
                    totalStringCell.SetBorder(Border.NO_BORDER);
                    totalStringCell.Add(new Paragraph("Összesen"));
                    table.AddCell(totalStringCell);

                    Cell totalValueCell = new Cell();
                    totalValueCell.SetBorder(Border.NO_BORDER);
                    totalValueCell.SetTextAlignment(TextAlignment.RIGHT);
                    totalValueCell.Add(new Paragraph(receipt.Total.ToString()));
                    table.AddCell(totalValueCell);

                    Cell messageCell = new Cell(1, 2);
                    messageCell.SetBorder(Border.NO_BORDER);
                    messageCell.SetTextAlignment(TextAlignment.CENTER);
                    messageCell.Add(new Paragraph("Köszònjük, hogy nálunk vásárolt!"));
                    table.AddCell(messageCell);

                    Cell dateCell = new Cell();
                    dateCell.SetBorder(Border.NO_BORDER);
                    dateCell.Add(new Paragraph(receipt.Date));
                    table.AddCell(dateCell);

                    doc.Add(table);
                }
            }
        }
    }
}
