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
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Media;

namespace Penztargep_dr1_WPF.Services {
    public class PdfService : IPdfService {
        private readonly IDataService<Receipt> _receiptService;
        private readonly IDataService<ReceiptItem> _receiptItemService;
        private readonly IProductService _productService;
        private readonly IDataService<Category> _categoryService;

        public PdfService(IDataService<Receipt> receiptService, IDataService<ReceiptItem> receiptItemService, IProductService productService, IDataService<Category> categoryService) {
            _receiptService = receiptService;
            _receiptItemService = receiptItemService;
            _productService = productService;
            _categoryService = categoryService;
        }

        public ICommand CreatePDFCommand => throw new NotImplementedException();

        private string FormatDate(string date) {
            Regex pattern = new Regex("[:. ]");
            return pattern.Replace(date, "");

        }

        public void CreatePdfReceipt(Receipt receipt, IEnumerable<ReceiptItem> receiptItems) {
            Directory.CreateDirectory("./receipts");

            using (var writer = new PdfWriter(String.Format("./receipts/{0}.pdf", FormatDate(receipt.Date)))) {
                using (var pdf = new PdfDocument(writer)) {
                    Rectangle rectangle = new Rectangle(PageSize.A4);
                    var doc = new Document(pdf);

                    Table table = new Table(2);
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


        public void CreatePdfSummary(IEnumerable<Receipt> receipts) {

            var exportFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var exportFile = System.IO.Path.Combine(exportFolder, "Test-Summary.pdf");

            Directory.CreateDirectory("./summaries");

            IEnumerable<ReceiptItem> receiptItems = _receiptItemService.GetAll().Result;

            using (var writer = new PdfWriter(String.Format("./summaries/{0}.pdf", FormatDate(DateTime.Now.ToString())))) {
                using (var pdf = new PdfDocument(writer)) {
                    int totalValue = 0;

                    Rectangle rectangle = new Rectangle(PageSize.A4);
                    var doc = new Document(pdf);


                    Table table = new Table(5);
                    table.SetMaxWidth(780f);
                    table.UseAllAvailableWidth();
                    table.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    table.SetVerticalAlignment(VerticalAlignment.MIDDLE);
                    table.SetBorder(Border.NO_BORDER);


                    Cell titleCell = new Cell(1, 5);
                    titleCell.SetBorder(Border.NO_BORDER);
                    titleCell.SetTextAlignment(TextAlignment.CENTER);
                    titleCell.Add(new Paragraph("Eladás összegzés"));
                    table.AddCell(titleCell);

                    Cell headerCell1 = new Cell();
                    headerCell1.SetBorder(Border.NO_BORDER);
                    headerCell1.SetTextAlignment(TextAlignment.CENTER);
                    headerCell1.Add(new Paragraph("Kód"));
                    table.AddCell(headerCell1);

                    Cell headerCell2 = new Cell();
                    headerCell2.SetBorder(Border.NO_BORDER);
                    headerCell2.SetTextAlignment(TextAlignment.CENTER);
                    headerCell2.Add(new Paragraph("Név"));
                    table.AddCell(headerCell2);

                    Cell headerCell3 = new Cell();
                    headerCell3.SetBorder(Border.NO_BORDER);
                    headerCell3.SetTextAlignment(TextAlignment.CENTER);
                    headerCell3.Add(new Paragraph("Kategória"));
                    table.AddCell(headerCell3);

                    Cell headerCell4 = new Cell();
                    headerCell4.SetBorder(Border.NO_BORDER);
                    headerCell4.SetTextAlignment(TextAlignment.CENTER);
                    headerCell4.Add(new Paragraph("Eladott Mennyiség"));
                    table.AddCell(headerCell4);

                    Cell headerCell5 = new Cell();
                    headerCell5.SetBorder(Border.NO_BORDER);
                    headerCell5.SetTextAlignment(TextAlignment.CENTER);
                    headerCell5.Add(new Paragraph("Árbevétel"));
                    table.AddCell(headerCell5);


                    foreach (var receipt in receipts) {
                        foreach (var item in receiptItems) {
                            if (receipt.Id == item.ReceiptId) {
                                Product product = _productService.Get(item.ProductId).Result;
                                Category category = _categoryService.Get(product.CategoryId).Result;

                                Cell productCodeCell = new Cell();
                                productCodeCell.SetBorder(Border.NO_BORDER);
                                productCodeCell.SetTextAlignment(TextAlignment.CENTER);
                                productCodeCell.Add(new Paragraph(String.Format("{0:000}", product.Code)));
                                table.AddCell(productCodeCell);

                                Cell productNameCell = new Cell();
                                productNameCell.SetBorder(Border.NO_BORDER);
                                productNameCell.SetTextAlignment(TextAlignment.CENTER);
                                productNameCell.Add(new Paragraph(product.Name));
                                table.AddCell(productNameCell);

                                Cell categoryNameCell = new Cell();
                                categoryNameCell.SetBorder(Border.NO_BORDER);
                                categoryNameCell.SetTextAlignment(TextAlignment.CENTER);
                                categoryNameCell.Add(new Paragraph(category.Name));
                                table.AddCell(categoryNameCell);

                                Cell quantityCell = new Cell();
                                quantityCell.SetBorder(Border.NO_BORDER);
                                quantityCell.SetTextAlignment(TextAlignment.CENTER);
                                quantityCell.Add(new Paragraph(String.Format("{0} db", item.Quantity)));
                                table.AddCell(quantityCell);

                                Cell priceCell = new Cell();
                                priceCell.SetBorder(Border.NO_BORDER);
                                priceCell.SetTextAlignment(TextAlignment.CENTER);
                                priceCell.Add(new Paragraph(String.Format("{0:# ### ### ### ##0 Ft}", item.Total)));
                                table.AddCell(priceCell);

                                totalValue += item.Total;
                            }

                        }
                    }

                    Cell totalTextCell = new Cell();
                    totalTextCell.SetBorder(Border.NO_BORDER);
                    totalTextCell.SetTextAlignment(TextAlignment.CENTER);
                    totalTextCell.Add(new Paragraph("Összesen:"));
                    table.AddCell(totalTextCell);

                    Cell totalValueCell = new Cell();
                    totalValueCell.SetBorder(Border.NO_BORDER);
                    totalValueCell.SetTextAlignment(TextAlignment.CENTER);
                    totalValueCell.Add(new Paragraph(String.Format("{0:# ### ### ### ##0 Ft}", totalValue)));
                    table.AddCell(totalValueCell);

                    doc.Add(table);
                }
            }
        }
    }      
}
