import React from 'react';
import Relogio from '../../../components/Relogio'
import {PagesDefault, Img, SubTitle} from './style';
import ImgPagamentoRealizado from '../../../assets/Img/PagamentoRealizado.png';

export default function PagamentoRealizado() {
    
    return(

        <PagesDefault>

            <h1>PAGAMENTO REALIZADO</h1>

            <Img src={ImgPagamentoRealizado} alt="Pagamento Realizado" width="270px" height="310"/> 

            <SubTitle>
                SEU PAGAMENTO FOI REALIZADO COM SUCESSO,<br></br> SEU PEDIDO ESTÁ SENDO FEITO.
            </SubTitle>

            <div style = {{visibility: 'hidden'}}>
             <Relogio />
            </div>

        </PagesDefault>

    );
}