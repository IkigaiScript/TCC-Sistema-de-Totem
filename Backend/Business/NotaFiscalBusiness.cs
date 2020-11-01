using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Backend.Models;
using Backend.Database;
namespace Backend.Business
{
    public class NotaFiscalBusiness : Cryptography
    {
        NotaFiscalDatabase db = new NotaFiscalDatabase();
        IdBase ConsTBase = new IdBase();
        public int Cadastrar(TbNotaFiscal tb)
        {
            if(!string.IsNullOrEmpty(tb.DsCpf))
            {
                string cpf = tb.DsCpf.Replace(".","").Replace("-","");
                if(cpf.Length != 11) throw new ArgumentException("Cpf inválido");
    
                foreach(char let in cpf)
                {
                    int num = (int) let;
                    if(num < 48 || num > 57) throw new ArgumentException("Cpf só pode conter numero");
                }

                // usar api para validar cpf
            }

            if(db.ExitsPedido(tb.IdPedido.Value)) throw new ArgumentException("Só pode existir uma nota por pedido");

            if(ConsTBase.Pedido(tb.IdPedido.Value) == null) throw new ArgumentException("Pedido não existe");

            if(string.IsNullOrEmpty(tb.DsEmail)) throw new ArgumentException("Email está vazio");

            string com =  tb.DsEmail.Substring(tb.DsEmail.LastIndexOf("."));
            if(com != ".com") throw new ArgumentException("Email inválido");

            string[] dominio = new string[4]{"@gmail","@outlook","@hotmail","@yahoo"};
            if(!dominio.Any(x => tb.DsEmail.Contains(x))) throw new ArgumentException("Dominio do email não aceito");
            
            // usar api para validar email
            
            tb.DsCpf = CriarHash(tb.DsCpf);
            return db.Cadastrar(tb);
        }

        public TbNotaFiscal Consultar(int pedido)
        {
            if(!db.ExitsPedido(pedido)) throw new ArgumentException("Nenhuma nota fiscal encontrada");

            if(ConsTBase.Pedido(pedido) == null) throw new ArgumentException("Pedido não existe");

            return db.Consultar(pedido);
        }

        public void ValidarPedido(int pedido)
        {
            if(ConsTBase.Pedido(pedido) == null) throw new ArgumentException("Pedido não existe");
        }
        public List<TbPedidoSnackBar> ConsultarSnackBar(int pedido)
        {
            this.ValidarPedido(pedido);
        
            return db.ConsultarSnackBar(pedido);
        }

        public List<TbPedidoCombo> ConsultarCombo(int pedido)
        {
            this.ValidarPedido(pedido);

            return db.ConsultarCombo(pedido);
        }

        public List<TbIngresso> ConsultarIngresso(int pedido)
        {
            this.ValidarPedido(pedido);

            return db.ConsultarIngresso(pedido);
        }
    }
}