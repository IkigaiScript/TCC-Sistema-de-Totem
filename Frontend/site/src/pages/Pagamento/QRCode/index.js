import React from 'react';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import QRSucesso from '../../../assets/Img/QRSucesso.png'
import { PageDefault, ButtonWrappper, QRCodeWrapper } from './style'


export default function QRCode (){
    return (
        <PageDefault>
            <h1>Pagamento com QRCode</h1>
           
            <p>
                Pague de forma rapida e facil use agora o nosso pagamento por QRCODE basta ler o 
                codigo QRCode, com a tela do seu celular
            </p>

            <QRCodeWrapper>
                <img src = {QRSucesso} alt = '' />
            </QRCodeWrapper>

            <ButtonWrappper>

                <Button 
                    to = '/'
                    children = 'Cancelar Pedido' 
                />

                <Relogio />

            </ButtonWrappper>

        </PageDefault>
    );
}