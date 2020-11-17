import React, { useState } from 'react'
import Relogio from '../../../components/Relogio'
import Button from '../../../components/Buttons'
import Input from '../../../components/Input'
import {PageDefault, Custom, ButtonWrapper} from './style'
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Nota } from '../../../services/NotaApi'
import { Cupom } from '../../../services/CupomApi'
import { Pedido } from '../../../services/PedidoApi'
const nota = new Nota();
const pedido = new Pedido();
const cupom = new Cupom();

export default function NFe (){

    const [ped,setPed] = useState(localStorage.getItem('pedido'));
    const [email,setEmail] = useState('');
    const [cpf,setCpf] = useState('');
    const [codigo,setCodigo] = useState('');

    async function cancelar(){
        try{
            const response = await pedido.deleteOrder(ped);
            console.log(response);
            return response;
        } 
        catch(e){
            if(e.response.data.error){
                console.log(e.response.data);
                toast.error(e.response.data.error);
              }
              else {
                console.log(e.response.data);
                toast.error("Algo deu errado!");
              }
        }
    }

    async function cadastrarNota(){
        try{
            const req = {
                Pedido:ped,
                Email:email,
                Cpf:cpf
            };

            const response = await nota.cadastrar(req);
            console.log(response);
            return response;
        }
        catch(e){
            if(e.response.data.error){
                console.log(e.response.data);
                toast.error(e.response.data.error);
              }
              else {
                console.log(e.response.data);
                toast.error("Algo deu errado!");
              }
        }
    }

    return (
        <PageDefault>

            <Custom>

                <p>
                    Estamos quase finalizando o seu pedido, por favor digite seu e-mail para que possamos enviar sua 
                    nota fiscal, caso deseje CPF na nota basta adicionar, lembramos que essa opção não e obrigatoria.
                </p>

            </Custom>

            <Custom ClassName= 'inputone'>

                <Input  type = 'text'  
                        placeholder = 'Digite seu e-mail para receber a nota fiscal' 
                        width = '1000'
                        value = {email}
                        onChange = {e => setEmail(e.target.value)} 
                    />

                <Input  type = 'text'  
                        placeholder = 'Digite seu CPF' 
                        width = '1000' 
                        value = {cpf}                        
                        onChange = {e => setCpf(e.target.value)}
                    />

            </Custom>

            <Custom>

                <p>
                    Caso você tenha alguns de nossos cupom de desconto, basta digitar o seu código, caso não tenha 
                    abaixe agora nosso App CineTotem ou entre em nosso site para  poder  ficar por dentro do que rola
                    em nossos sistemas e ter descontos imperdiveis
                </p>

            </Custom>           

            <Custom className= 'inputwo'>

                <Input  type = 'text' 
                        maxLength ='4' 
                        placeholder = 'Digite o codigo do seu cupom de desconto' 
                        width = '1000'
                        value = {codigo}
                        onChange = {e => setCodigo(e.target.value)}
                    />

            </Custom> 

            <ButtonWrapper> 
                
                <Button 
                    to = '/'
                    children = 'Cancelar Pedido'
                    onClick = {cancelar} 
                />

                <Relogio />

                <Button 
                    to = '/pagamento/cartao'
                    children = 'Confirmar'
                    onClick = {() => {
                        cadastrarNota();
                    }} 
                />
            </ButtonWrapper>
            <ToastContainer/>
        </PageDefault>
    );
}