import React, { useState, useEffect } from 'react';
import Relogio from '../../../components/Relogio';
import Input from '../../../components/Input';
import Button from '../../../components/Buttons';
import {Link} from 'react-router-dom';
import {PageDefault, CartaoWrapper, Custom, ButtonWrapper} from './style';
import { Cartao } from '../../../services/CartaoApi';
import { Pedido } from '../../../services/PedidoApi'
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
const cartao = new Cartao();
const pedido = new Pedido();

export default function ValidarCartao (){

    const [ped] = useState(window.localStorage.getItem('pedido'));
    const [cvv,setCvv] = useState();
    const [numero,setNumero] = useState();
    const [pagamento,setPagamento] = useState();
    const [senha,setSenha] = useState();

    async function cancelar(){
        try{
            const response = await pedido.deleteOrder(ped);
            localStorage.clear();
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

    async function cadastrarCartao() {
        try {
            const req = {
                Pedido:Number(ped),
                Cvv:Number(cvv),
                Numero:numero,
                Pagamento:pagamento,
                Senha:Number(senha)
            }

            console.log(req);
            const response = await cartao.cadastrar(req);
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
            <h1>Pagamento com Cartão</h1>

            <CartaoWrapper id = 'cartaowrapper'>

                <Custom>

                    <Input  id = 'cartao' 
                            name = 'tipo' 
                            type = 'radio' 
                            width = '30px' 
                            value = {pagamento}
                            onChange = {e => setPagamento('debito')}
                    />  
                    <span>Debito</span>

                </Custom>

                <Custom>

                    <Input  id = 'cartao' 
                            name = 'tipo' 
                            type = 'radio' 
                            width = '30px'
                            value = {pagamento}
                            onChange = {e => setPagamento('credito')}
                    />
                    <span>Credito</span>

                </Custom>

            </CartaoWrapper>
            
            <CartaoWrapper>

                <Custom>

                    <label>Numero do cartão</label>
                    <Input  type = 'password'
                            name = 'tipo'
                            value = {numero}
                            onChange = {e => setNumero(e.target.value)}
                    />

                </Custom>

            </CartaoWrapper>

            <CartaoWrapper>

                <Custom>

                    <span>CVV</span>
                    <Input type = 'password'  
                        width = '350px'
                        maxLength = '3'
                        value = {cvv} 
                        onChange = {e => setCvv(e.target.value)} 
                    />

                </Custom>

                <Custom>

                    <span>Senha</span>
                    <Input type = 'password'  
                            width = '300px'
                            value = {senha}
                            onChange = {e => setSenha(e.target.value)}
                    />

                </Custom>

            </CartaoWrapper>

            <ButtonWrapper>

                <Relogio />

                <Button 
                    to = '/'
                    children = 'Cancelar Pedido'
                    onClick = {cancelar} 
                />
    
                <Button 
                    as = {Link}
                    to = '/PagamentoRealizado'
                    children = 'Concluir'
                    onClick = {() => {
                        cadastrarCartao();  
                        // window.localStorage.clear();
                    }}
                />

            </ButtonWrapper>
            <ToastContainer/>
        </PageDefault>
    );
}