using System;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Linq;
using System.IO;
using System.Collections.Generic;

using Backend.Services.Documents;
using Backend.Models;
using Backend.Database;
using Backend.Business;
namespace Backend.Services.Documents
{
    public class DocumentPDF
    {
        QrCode qrcode = new QrCode();
        tcdbContext ctx = new tcdbContext();
        IdBase ConsTBase = new IdBase();
        NotaFiscalBusiness buss = new NotaFiscalBusiness();
        public string NewFile(Models.TbNotaFiscal notaFiscal, Models.TbPedido pedido)
        {
            string text = string.Empty;

            List<Models.TbPedidoCombo> combos = buss.ConsultarCombo(pedido.IdPedido);
            List<Models.TbPedidoSnackBar> snacks = buss.ConsultarSnackBar(pedido.IdPedido);
            List<Models.TbIngresso> ingressos = buss.ConsultarIngresso(pedido.IdPedido);

            string path = Path.Combine(AppContext.BaseDirectory,"Storage");
            string arq = Path.Combine(path,"Arquivos",$"{pedido.IdPedido}.pdf");

            FileStream pdf = new FileStream(arq,FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escrito = PdfWriter.GetInstance(doc,pdf);

            doc.Open();

            Image logo = Image.GetInstance(Path.Combine(path,"Fotos","logo.PNG"));
            logo.ScaleToFit(100f, 80f);
            logo.SetAbsolutePosition(80,700);
            doc.Add(logo);

            Paragraph empresa = new Paragraph(text, new iTextSharp.text.Font(Font.NORMAL,13,Font.BOLDITALIC,BaseColor.DARK_GRAY));
            empresa.Alignment = Element.ALIGN_JUSTIFIED;
            empresa.SpacingAfter = 15;
            empresa.SpacingBefore = 36;
            empresa.Add("CineTotem\n");
            empresa.Add("Rua Santo Antônio Marinho\n");
            empresa.Add("São paulo\v\v");
            empresa.Add(DateTime.Now.ToLongDateString());
            empresa.IndentationLeft = 170;
            
            doc.Add(empresa);

            Paragraph risco = new Paragraph(text, new iTextSharp.text.Font(Font.NORMAL,13,Font.BOLDITALIC,BaseColor.DARK_GRAY));
            risco.Alignment = Element.ALIGN_JUSTIFIED_ALL;
            risco.Add("----------------------------------------------------");
            doc.Add(risco);

            Paragraph paragrafo = new Paragraph(text, new iTextSharp.text.Font(Font.NORMAL,13,Font.BOLD,BaseColor.DARK_GRAY));
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.SpacingAfter = 10;
            paragrafo.ExtraParagraphSpace = 40;
            paragrafo.SpacingBefore = 10;
            paragrafo.Add($"Numero do Pedido {pedido.IdPedido}\n");
            paragrafo.Add($"Extrato no. {notaFiscal.IdNotaFisical}\n".ToUpper());
            paragrafo.Add("Cumpom fiscal eletronico - sat\n".ToUpper());
            doc.Add(paragrafo);
            doc.Add(risco);

            Paragraph client = new Paragraph(text, new iTextSharp.text.Font(Font.NORMAL,13,Font.BOLD,BaseColor.DARK_GRAY));
            client.Alignment = Element.ALIGN_LEFT;
            client.SpacingAfter = 10;
            client.SpacingBefore = 10;
            
            string consumidor = pedido.NmTitular == string.Empty 
                                        ? "Não informado"
                                        : pedido.NmTitular;

            string cpf = notaFiscal.DsCpf == string.Empty 
                                        ? "Não informado"
                                        : notaFiscal.DsCpf;

            client.Add($"CPF/CNPJ do consumidor {cpf}\n".ToUpper());
            client.Add($"consumidor: {consumidor}\n".ToUpper()); 
            doc.Add(client);

            int total = 0;
 
            PdfPTable table = new PdfPTable(6);
            table.DefaultCell.FixedHeight = 20;
            table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;
            table.SpacingBefore = 10;
            table.SpacingAfter = 10;
            table.WidthPercentage = 100;

            string[] campos = new string[] { "Poltrona", "Fileira", "Sala", "Horario", "Meia-Entrada", "Valor" };

            foreach(string camp in campos)
            {
                table.AddCell(new Phrase(camp,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
            }

            foreach(Models.TbIngresso ingresso in ingressos)
            {
                total += 1;
                table.AddCell(new Phrase($"{total}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                table.AddCell(new Phrase(ingresso.NrPoltrona.ToString(),new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                table.AddCell(new Phrase(ingresso.DsFileira,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                table.AddCell(new Phrase(ingresso.IdSessaoNavigation.NrSala.ToString(),new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                table.AddCell(new Phrase(ingresso.IdSessaoNavigation.DtHorario.ToLongTimeString(),new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                table.AddCell(new Phrase(ingresso.BtMeiaEntrada ? "sim" : "não",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                table.AddCell(new Phrase($"R$ {ingresso.IdSessaoNavigation.VlIngresso}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
            }

            doc.Add(table); 

            if(snacks.Count > 0)
            {
                PdfPTable tabela = new PdfPTable(5); // 4 colunas - nm,qtd,peso,valor
                tabela.DefaultCell.FixedHeight = 20;
                tabela.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tabela.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabela.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;
                tabela.SpacingBefore = 10;
                tabela.SpacingAfter = 10;
                tabela.WidthPercentage = 100;

                string[] title = new string[] { "Produto", "QTD", "Peso", "Preço UNI", "Total" };
                
                foreach(string str in title)
                {
                    tabela.AddCell(new Phrase(str,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                }

                foreach(Models.TbPedidoSnackBar snack in snacks)
                {
                    total += 1;
                    table.AddCell(new Phrase($"{total}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    tabela.AddCell(new Phrase(snack.IdSnackBarNavigation.NmProduto,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    tabela.AddCell(new Phrase(snack.NrQtdSnackBar.ToString(),new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    tabela.AddCell(new Phrase(snack.IdSnackBarNavigation.DsPeso,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    tabela.AddCell(new Phrase($"R$ {snack.IdSnackBarNavigation.VlPreco}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    tabela.AddCell(new Phrase($"R$ {snack.IdSnackBarNavigation.VlPreco * snack.NrQtdSnackBar}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                }

                doc.Add(tabela);
            }            

            if(combos.Count > 0 )
            {
                    PdfPTable tabela1 = new PdfPTable(7); 
                    tabela1.DefaultCell.FixedHeight = 20;
                    tabela1.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;
                    tabela1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela1.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    tabela1.SpacingBefore = 10;
                    tabela1.SpacingAfter = 10;
                    tabela1.WidthPercentage = 100;

                    string[] title1 = new string[] { "Produto", "QTD", "Item 1", "Item 2", "Item 3", "Preço UNI", "Total" };

                    foreach(string str in title1)
                    {
                        tabela1.AddCell(new Phrase(str,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    }

                    foreach(Models.TbPedidoCombo combo in combos)
                    {
                        total += 1;
                        table.AddCell(new Phrase($"{total}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase(combo.IdComboNavigation.NmCombo,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase(combo.NrQtdCombo.ToString(),new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase(combo.IdComboNavigation.DsFirstItem,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase(combo.IdComboNavigation.DsSecondaryItem ?? "",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase(combo.IdComboNavigation.DsThirdItem ?? "",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase($"R$ {combo.IdComboNavigation.VlPreco}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase($"R$ {combo.IdComboNavigation.VlPreco * combo.NrQtdCombo}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));                
                    }
                    
                    doc.Add(tabela1);
            }

            doc.Add(risco);

            Paragraph paragrafo1 = new Paragraph(text, new iTextSharp.text.Font(Font.NORMAL,13,Font.BOLD,BaseColor.DARK_GRAY));
            paragrafo1.Alignment = Element.ALIGN_LEFT;
            paragrafo1.SpacingAfter = 10;
            paragrafo1.Add($"qtde. total de itens {total}\n".ToUpper());
            paragrafo1.Add($"valor total R$ {pedido.VlTotal}\n".ToUpper());
            paragrafo1.Add($"forma de pagamento\n{pedido.DsFormaPagamento}\n".ToUpper());

            float desconto = 0f;
            if(ctx.TbCupomDesconto.Any(x => x.IdCupomDesconto == pedido.IdCupomDesconto)) // validar desconto 
            {
                desconto = (float) ConsTBase.Desconto(pedido.IdCupomDesconto.Value).VlDesconto;
            }

            paragrafo1.Add($"Desconto R$ {ConsTBase.Desconto(pedido.IdCupomDesconto.Value).VlDesconto}\n".ToUpper());
            
            doc.Add(paragrafo1);
            
            byte[] qrcoder = qrcode.CreateQrCode(pedido.IdPedido);
            Image qrcoding = Image.GetInstance(qrcoder);
            qrcoding.ScaleToFit(380f,230f);
            qrcoding.SetAbsolutePosition(300,10);
            doc.Add(qrcoding);

            doc.Close();            

            Console.WriteLine("Concluido");
            return arq;
        }   
    }
}