import React from 'react';
import Button from '../../../components/Buttons/';
import Relogio from '../../../components/Relogio/';
import { TextWrapper, Wrapper } from './style';

export default function Dinheiro (){
    return (
        <Wrapper>
            <h1>Pagamento com Dinheiro</h1>
            <Relogio />
            <TextWrapper>
                <p>
                    Não deseja pagar no cartão ou por qrcode? Tudo bem, pague com dinheiro no momento que for retirar seu pedido,
                    no momento da retirar seu lanche pague tudo de uma so vez.
                </p>  

                <p> 
                    Lembre-se que ao comprar o ingresso de meia-entrada deverá mostrar um documento
                    de que você tem direito a esse ingresso caso contrario deverá pagar o restante no caixa.
                </p>
            </TextWrapper>
            <div>
                <h2>N° Pedido:</h2>
            </div>

            <div>
                <Button to="" onClick="" children="Cancelar Pedido"/>
                <Button to="" onClick="" children="Finalizar"/>
            </div>
        </Wrapper>

    );
}