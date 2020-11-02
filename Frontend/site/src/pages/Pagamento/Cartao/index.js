import React from 'react';
import Relogio from '../../../components/Relogio';
import Input from '../../../components/Input';
import Button from '../../../components/Buttons'
import {PageDefault, CartaoWrapper, Custom, ButtonWrapper} from './style';

export default function Cartao (){
    return (
        <PageDefault>
            <h1>Pagamento com Cartão</h1>

            <CartaoWrapper id = 'cartao'>

                <Custom>

                    <Input id = 'cartao' type = 'radio' width = '30px' />
                    <span>Debito</span>

                </Custom>

                <Custom>

                    <Input id = 'cartao' type = 'radio' width = '30px' />
                    <span>Credito</span>

                </Custom>

            </CartaoWrapper>
            
            <CartaoWrapper>

                <Custom>

                    <span>Numero do cartão</span>
                    <Input type = 'number'/>

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
                    />

                </Custom>

                <Custom>

                    <span>Senha</span>
                    <Input type = 'password'  width = '300px'/>

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