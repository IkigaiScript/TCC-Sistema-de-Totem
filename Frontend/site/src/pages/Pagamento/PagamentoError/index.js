import React from 'react';
import {PagesDefault, Titulo, Img, SubTitulo} from './style';
import ImgPagamentoErro from '../../../assets/Img/PagamentoErro.png';

export default function ErroNoPagamento() {
    return (
       <PagesDefault>
           <Titulo>ERRO NO PAGAMENTO</Titulo>
           <Img src= {ImgPagamentoErro} alt="Erro no Pagamento" width="290px;" height="310"/>
           <SubTitulo>OPS! PARECE QUE OCORREU UM ERRO NO<br></br> MOMENTO DO SEU PAGAMENTO.</SubTitulo>
       </PagesDefault>
    );
}