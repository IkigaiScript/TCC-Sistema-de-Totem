import React from 'react';
import {PagesDefault, Titulo, Img, SubTitulo, Body,} from './style'
import ImgPagamentoRealizado from '../../assets/Img/PagamentoRealizado.png'

export default function PagamentoRealizado() {
    return(
        <PagesDefault>
            <Titulo>PAGAMENTO REALIZADO</Titulo>
            <Img src={ImgPagamentoRealizado} alt="Pagamento Realizado" width="270px;" height="310;"/> 
            <SubTitulo>SEU PAGAMENTO FOI REALIZADO COM SUCESSO,<br></br> SEU PEDIDO ESTÁ SENDO FEITO.</SubTitulo>
        </PagesDefault>
    );
}