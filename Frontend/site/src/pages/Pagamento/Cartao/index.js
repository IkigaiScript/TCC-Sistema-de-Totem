import React,{useState} from 'react';
import Relogio from '../../../components/Relogio';
import Input from '../../../components/Input';
import Button from '../../../components/Buttons';
import {PageDefault, CartaoWrapper, Custom, ButtonWrapper} from './style';
import Cartao from '../../../services/CartaoApi';

const api = new Cartao();

export default function ValidarCartao (){
    
    const [cvv,setCvv] = useState();
    const [numero,setNumero] = useState();
    const [pagamento,setPagamento] = useState();
    const [senha,setSenha] = useState();

    const SalvarCartao = async () => {
        try {
            const info = {
                Cvv:cvv,
                Numero:numero,
                Pagamento:pagamento,
                Senha:senha
            }
            const resp = await api.post(info)
            return resp;

        } catch (e) {
            
        }
    }

    return (
        <PageDefault>
            <h1>Pagamento com Cartão</h1>

            <CartaoWrapper id = 'cartao'>

                <Custom>

                    <Input id = 'cartao' type = 'radio' width = '30px' 
                        value = {pagamento}
                        onChange = {e => setPagamento(e.target.value)}
                    />
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

            </CartaoWrapper>

            <CartaoWrapper>

                <Custom>

                    <span>CVV</span>
                    <Input type = 'password'   width = '350px' maxLength = '3'  
                        value = {cvv}
                        onChange = {e => setCvv(e.target.value)}
                    />

                </Custom>

                <Custom>

                    <span>Senha</span>
                    <Input type = 'password'  width = '300px'
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

        </PageDefault>
    );
}