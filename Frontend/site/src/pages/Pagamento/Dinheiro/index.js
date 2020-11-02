import React from 'react';
import Button from '../../../components/Buttons';
import Relogio from '../../../components/Relogio/';
import { PageDefault, TextWrapper, ButtonWrapper } from './style';

export default function Dinheiro (){
    return (
        <PageDefault>
            <h1>Pagamento com Dinheiro</h1>
            
            <TextWrapper>

                <p>
                    Não deseja pagar no cartão ou por QRCode? Tudo bem, pague no dinheiro 
                    no momento que for retirar seu pedido,
                </p>  

                <p> 
                    Lembre-se que ao comprar o ingresso de meia-entrada deverá mostrar um documento
                    comprovando que você tem direito a meia-entrada caso contrario deverá pagar o 
                    restante do valor no caixa no momento da retirada.
                </p>

            </TextWrapper>

        
            <h1>N° Pedido:</h1>
            

            <ButtonWrapper>

                <Button 
                    to= '/' 
                    children= 'Cancelar Pedido' 
                />

                <Relogio />

                <Button 
                    to='/'  
                    children='Finalizar' 
                />

            </ButtonWrapper>

        </PageDefault>

    );
}
