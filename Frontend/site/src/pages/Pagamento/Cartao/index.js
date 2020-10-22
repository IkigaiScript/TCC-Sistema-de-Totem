import React from 'react';
import Relogio from '../../../components/Relogio';
import {PageDefault,CartaoWrapper,Custom,Input} from './style';

export default function Cartao (){
    return (
        <div>
            <h1>Pagamento com Cartão</h1>

            <CartaoWrapper>

                <Custom>

                    <Input id = 'cartao' type = 'radio' width = '30px' />
                    <span>Debito</span>

                </Custom>

                <Custom>

                    <Input id = 'cartao' type = 'radio' width = '30px' />
                    <span>Credito</span>

                </Custom>

            </CartaoWrapper>

            <Custom>
                <span>Numero do cartão</span>
                <Input type = 'number'/>
            </Custom>

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

            <div>

            </div>

            <Relogio />

        </div>
    );
}