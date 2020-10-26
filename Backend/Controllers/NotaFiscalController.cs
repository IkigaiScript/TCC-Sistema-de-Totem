using System;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Notas")]
    public class NotaFiscalController : ControllerBase
    {
        Database.IdBase ConsTBase = new Database.IdBase();
        Utils.NotaFiscalConversor conv = new Utils.NotaFiscalConversor();
        Business.NotaFiscalBusiness buss = new Business.NotaFiscalBusiness();

        [HttpPost] // inserir 
        public ActionResult<Models.Response.NotaFiscalResponse> Cadastrar(Models.Request.NotaFiscalRequest req)
        {
            try
            {
                Models.TbNotaFiscal nota = conv.ParaTabela(req);
                return conv.ParaResponse(buss.Cadastrar(nota));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                  new Models.Response.ErrorResponse(400,ex.Message)  
                );
            }
        }

        [HttpPost("Email/{pedido}")]  // mandar email - testar 
        public ActionResult EnviarEmail(int pedido)
        {
            // Adicionar anexo com a nota fiscal criada 
            Database.IdBase ConsTBase = new Database.IdBase();

            try
            {
                Models.TbNotaFiscal nota = buss.Consultar(pedido);
                Models.TbPedido ped = ConsTBase.Pedido(pedido);
                string file = this.NewFile(nota,ped);

                MailMessage mail = new MailMessage("venanciodacostacarloshenrique@gmail.com",nota.DsEmail);
                mail.Subject = $"{ped.NmTitular}";
                mail.SubjectEncoding = Encoding.UTF8;
                
                string body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Suspendisse interdum consectetur libero id faucibus nisl tincidunt. In massa tempor nec feugiat nisl pretium fusce id. Tristique senectus et netus et. Nunc sed augue lacus viverra vitae. Quam nulla porttitor massa id neque aliquam vestibulum. Leo vel fringilla est ullamcorper eget nulla. Tortor dignissim convallis aenean et tortor at risus viverra adipiscing. Nibh sit amet commodo nulla facilisi nullam vehicula. Feugiat in fermentum posuere urna nec. Amet mauris commodo quis imperdiet. Vivamus at augue eget arcu dictum. Cras tincidunt lobortis feugiat vivamus at augue eget arcu. Quam adipiscing vitae proin sagittis nisl rhoncus mattis rhoncus. Tellus cras adipiscing enim eu turpis. Vestibulum lectus mauris ultrices eros in. Leo urna molestie at elementum eu. Turpis in eu mi bibendum neque egestas congue quisque egestas. Dictum sit amet justo donec enim. Ullamcorper velit sed ullamcorper morbi tincidunt. Vitae justo eget magna fermentum. Libero id faucibus nisl tincidunt eget nullam. Facilisi cras fermentum odio eu feugiat pretium nibh ipsum consequat. Orci dapibus ultrices in iaculis nunc sed augue. Donec pretium vulputate sapien nec sagittis. Ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget. Dis parturient montes nascetur ridiculus mus mauris vitae ultricies. Blandit aliquam etiam erat velit scelerisque in. Facilisis gravida neque convallis a cras. Egestas sed sed risus pretium quam vulputate dignissim. Placerat orci nulla pellentesque dignissim enim sit amet venenatis urna. Urna nunc id cursus metus.";
                mail.Body = body; 
                mail.BodyEncoding = Encoding.UTF8;

                var attach = new Attachment(file);                
                mail.Attachments.Add(attach);  
                
                SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("venanciodacostcarloshenrique@gmail.com","Blizard2020");
                smtp.EnableSsl = true;
                smtp.Timeout = 100; 

                try
                {
                    smtp.Send(mail);
                }
                catch(Exception) 
                {
                    return new BadRequestObjectResult(
                        new Models.Response.ErrorResponse(500,"Erro ao mandar email")
                    );
                }
                
                return new OkResult();
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(400,ex.Message)
                );
            }
        }

        private string NewFile(Models.TbNotaFiscal notaFiscal, Models.TbPedido pedido)
        {
            string text = string.Empty;

            List<Models.TbPedidoCombo> combos = buss.ConsultarCombo(pedido.IdPedido);
            List<Models.TbPedidoSnackBar> snacks = buss.ConsultarSnackBar(pedido.IdPedido);
            
            string path = $"C:\\Users\\MGonzalez\\Documents\\Grupo do TCC\\TCC-Sistema-de-Totem\\Backend\\Storage\\";
            string arq = $"{path}Arquivos\\{pedido.IdPedido}.pdf";

            FileStream pdf = new FileStream(arq,FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escrito = PdfWriter.GetInstance(doc,pdf);

            doc.Open();

            Image logo = Image.GetInstance($"{path}Fotos\\logo.png");
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
            paragrafo.Add($"Numero do Pedido {pedido.IdPedido}");
            paragrafo.Add($"Extrato no. {notaFiscal.IdNotaFisical}\n".ToUpper());
            paragrafo.Add("Cumpom fiscal eletronico - sat\n".ToUpper());
            doc.Add(paragrafo);
            doc.Add(risco);

            Paragraph client = new Paragraph(text, new iTextSharp.text.Font(Font.NORMAL,13,Font.BOLD,BaseColor.DARK_GRAY));
            client.Alignment = Element.ALIGN_LEFT;
            client.SpacingAfter = 10;
            client.SpacingBefore = 10;
            client.Add($"CPF/CNPJ do consumidor {notaFiscal.DsCpf ?? "Não informado"}\n".ToUpper());
            client.Add($"nome: {pedido.NmTitular}\n".ToUpper()); 
            doc.Add(client);

            int total = 0;

            if(snacks.Count > 0)
            {
                PdfPTable tabela = new PdfPTable(5); // 4 colunas - nm,qtd,peso,valor
                tabela.DefaultCell.FixedHeight = 20;
                tabela.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tabela.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                tabela.DefaultCell.BorderColor = BaseColor.LIGHT_GRAY;
                tabela.SpacingBefore = 10;
                tabela.SpacingAfter = 10;
                // tabela.GetRowHeight(120);
                tabela.WidthPercentage = 100;

                string[] title = new string[] { "Produto", "QTD", "Peso", "Preço UNI", "Total" };
                
                foreach(string str in title)
                {
                    tabela.AddCell(new Phrase(str,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                }

                foreach(Models.TbPedidoSnackBar snack in snacks)
                {
                    tabela.AddCell(new Phrase(snack.IdSnackBarNavigation.NmProduto,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    tabela.AddCell(new Phrase(snack.NrQtdSnackBar.ToString(),new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    tabela.AddCell(new Phrase(snack.IdSnackBarNavigation.DsPeso,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    tabela.AddCell(new Phrase($"R$ {snack.IdSnackBarNavigation.VlPreco}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    tabela.AddCell(new Phrase($"R$ {snack.IdSnackBarNavigation.VlPreco * snack.NrQtdSnackBar}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                    total += 1;
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
                        tabela1.AddCell(new Phrase(combo.IdComboNavigation.NmCombo,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase(combo.NrQtdCombo.ToString(),new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase(combo.IdComboNavigation.DsFirstItem,new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase(combo.IdComboNavigation.DsSecondaryItem ?? "",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase(combo.IdComboNavigation.DsThirdItem ?? "",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase($"R$ {combo.IdComboNavigation.VlPreco}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));
                        tabela1.AddCell(new Phrase($"R$ {combo.IdComboNavigation.VlPreco * combo.NrQtdCombo}",new iTextSharp.text.Font(Font.NORMAL,11,Font.BOLD,BaseColor.DARK_GRAY)));                
                        total += 1;
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
            paragrafo1.Add($"Desconto R$ {ConsTBase.Desconto(pedido.IdCupomDesconto.Value).VlDesconto}\n".ToUpper());
            paragrafo1.Add($"Troco R$ {pedido.VlTroco}");

            doc.Add(paragrafo1);
            
            doc.Close();            

            Console.WriteLine("Concluido");
            return arq;
        }
        
        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}