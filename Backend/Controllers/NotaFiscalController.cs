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

namespace Backend.Controllers
{
    [ApiController]
    [Route("Notas")]
    public class NotaFiscalController : ControllerBase
    {
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

        [HttpPost("Email/{pedido}")]  // mandar email 
        public ActionResult EnviarEmail(int pedido)
        {
            // Adicionar anexo com a nota fiscal criada 
            Database.IdBase ConsTBase = new Database.IdBase();

            try
            {
                Models.TbNotaFiscal nota = buss.Consultar(pedido);
                Models.TbPedido ped = ConsTBase.Pedido(pedido);
                StringBuilder file = this.NewFile(nota,ped);

                MailMessage mail = new MailMessage("venanciodacostacarloshenrique@gmail.com",nota.DsEmail);
                mail.Subject = $"PEDIDO: {nota.IdPedido}";
                mail.SubjectEncoding = Encoding.UTF8;
                
                string body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Suspendisse interdum consectetur libero id faucibus nisl tincidunt. In massa tempor nec feugiat nisl pretium fusce id. Tristique senectus et netus et. Nunc sed augue lacus viverra vitae. Quam nulla porttitor massa id neque aliquam vestibulum. Leo vel fringilla est ullamcorper eget nulla. Tortor dignissim convallis aenean et tortor at risus viverra adipiscing. Nibh sit amet commodo nulla facilisi nullam vehicula. Feugiat in fermentum posuere urna nec. Amet mauris commodo quis imperdiet. Vivamus at augue eget arcu dictum. Cras tincidunt lobortis feugiat vivamus at augue eget arcu. Quam adipiscing vitae proin sagittis nisl rhoncus mattis rhoncus. Tellus cras adipiscing enim eu turpis. Vestibulum lectus mauris ultrices eros in. Leo urna molestie at elementum eu. Turpis in eu mi bibendum neque egestas congue quisque egestas. Dictum sit amet justo donec enim. Ullamcorper velit sed ullamcorper morbi tincidunt. Vitae justo eget magna fermentum. Libero id faucibus nisl tincidunt eget nullam. Facilisi cras fermentum odio eu feugiat pretium nibh ipsum consequat. Orci dapibus ultrices in iaculis nunc sed augue. Donec pretium vulputate sapien nec sagittis. Ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget. Dis parturient montes nascetur ridiculus mus mauris vitae ultricies. Blandit aliquam etiam erat velit scelerisque in. Facilisis gravida neque convallis a cras. Egestas sed sed risus pretium quam vulputate dignissim. Placerat orci nulla pellentesque dignissim enim sit amet venenatis urna. Urna nunc id cursus metus.";
                mail.Body = body; 
                mail.BodyEncoding = Encoding.UTF8;

                var attach = new Attachment(file.ToString());                
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

        private StringBuilder NewFile(Models.TbNotaFiscal notaFiscal, Models.TbPedido pedido)
        {
            string text = string.Empty;
            List<Models.TbPedidoCombo> combos = buss.ConsultarCombo(pedido.IdPedido);
            List<Models.TbPedidoSnackBar> snacks = buss.ConsultarSnackBar(pedido.IdPedido);

            for(int i=0; i < combos.Count; i++)
            {
                Models.TbPedidoCombo combo = combos[i];
                text += $"{combo.IdComboNavigation.NmCombo}\t{combo.NrQtdCombo}\t{combo.IdComboNavigation.VlPreco}\n";
            }

            for(int j=0; j < snacks.Count; j++)
            {
                Models.TbPedidoSnackBar snack = snacks[j];
                text += $"{snack.IdSnackBarNavigation.NmProduto}\t{snack.NrQtdSnackBar}\t{snack.IdSnackBarNavigation.VlPreco}\n";
            }

            text += $"\n{pedido.VlTotal}";
            text += $"\n{pedido.NmTitular}";
            text += $"\n{pedido.DsFormaPagamento}";
            text += $"\n{pedido.DsStatus}";
            text += $"\n{notaFiscal.DsCpf}";

            string path = "C:\\Users\\MGonzalez\\Documents\\Grupo do TCC\\TCC-Sistema-de-Totem\\Backend\\Storage\\NotaFiscal.pdf";
            System.IO.File.WriteAllText(path,text, Encoding.UTF8);

            return new StringBuilder(path);
        }
        
        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}