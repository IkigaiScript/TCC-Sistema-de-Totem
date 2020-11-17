import React, { useState } from 'react';
import Relogio from '../../../components/Relogio';
import Input from '../../../components/Input';
import Button from '../../../components/Buttons';
import {PageDefault, CartaoWrapper, Custom, ButtonWrapper} from './style';
import { Cartao } from '../../../services/CartaoApi';
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
const api = new Cartao();

export default function ValidarCartao (){

    const [cvv,setCvv] = useState();
    const [numero,setNumero] = useState();
    const [pagamento,setPagamento] = useState();
    const [senha,setSenha] = useState();

    async function cadastrarCartao() {
        try {
            const req = {
                Cvv:cvv,
                Numero:numero,
                Pagamento:pagamento,
                Senha:senha
            }

            console.log(req);
            const resp = await api.cadastrar(req)
            return resp;
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

            <CartaoWrapper id = 'cartao'>

                <Custom>

                <Input id = 'cartao' type = 'radio' width = '30px' 
                        value = {pagamento}
                        onChange = {e => setPagamento(e.target.value)}/>
                <span>Debito</span>

                </Custom>

                <Custom>

                <Input id = 'cartao' type = 'radio' width = '30px'
                        value = {pagamento}
                        onChange = {e => setPagamento(e.target.value)}
                    />
                <span>Credito</span>

                </Custom>

            </CartaoWrapper>
            
            <CartaoWrapper>

                <Custom>

                    <span>Numero do cartão</span>
                    <Input type = 'password'
                            value = {numero}
                            onChange = {e => setNumero(e.target.value)}
                        />
                </Custom>

                <Custom>

                    <span>Validade</span>
                    <Input type = 'date'  width = '500'/>

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
                    to = '/PagamentoRealizado'
                    children = 'Concluir'
                />

            </ButtonWrapper>
            <ToastContainer/>
        </PageDefault>
    );
}