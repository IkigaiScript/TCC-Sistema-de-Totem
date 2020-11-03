using System;
using System.Net;
using System.Text;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

using Backend.Business;
using Backend.Utils;
using Backend.Database;
using Backend.Services.Documents;
using Backend.Models;
using Backend.Models.Request;
using Backend.Models.Response;
namespace Backend.Controllers
{
    [ApiController]
    [Route("Notas")]
    public class NotaFiscalController : ControllerBase 
    {
        DocumentPDF pdf = new Services.Documents.DocumentPDF();
        NotaFiscalConversor conv = new NotaFiscalConversor();
        NotaFiscalBusiness buss = new NotaFiscalBusiness();

        [HttpPost] // inserir 
        public ActionResult<NotaFiscalResponse> Cadastrar(NotaFiscalRequest req)
        {
            try
            {
                TbNotaFiscal nota = conv.ParaTabela(req);
                return conv.ParaResponse(buss.Cadastrar(nota));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                  new ErrorResponse(400,ex.Message)  
                );
            }
        }

        [HttpPost("Email/{pedido}")]  // mandar email -  Terminando
        public ActionResult EnviarEmail(int pedido)
        { 
            IdBase ConsTBase = new IdBase();

            try
            { 
                TbNotaFiscal nota = buss.Consultar(pedido);
                TbPedido ped = ConsTBase.Pedido(pedido);
                string file = pdf.NewFile(nota,ped);

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
                smtp.Credentials = new NetworkCredential("venanciodacostacarloshenrique@gmail.com","Blizard2020");
                smtp.EnableSsl = true;
                
                try
                {
                    smtp.Send(mail);
                }
                catch(Exception) 
                {
                    return new BadRequestObjectResult(
                        new ErrorResponse(500,"Erro ao enviar email")
                    );
                }
                finally
                {
                    System.IO.File.Delete(file);
                }
                
                return new OkResult();
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
                );
            }
        }
        
        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}