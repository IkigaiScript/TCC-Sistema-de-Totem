import React from 'react';
import {PagesDefault, Img, SubTitle} from './style';
import ImgPagamentoErro from '../../../assets/Img/PagamentoErro.png';
import Relogio from '../../../components/Relogio'

export default function ErroNoPagamento() {
    return (
        <PagesDefault>

        <h1>ERRO NO PAGAMENTO</h1>

            <Img src= {ImgPagamentoErro} alt="Erro no Pagamento" width="290" height="310"/>

            <SubTitle>
                OPS! PARECE QUE OCORREU UM ERRO NO<br></br> MOMENTO DO SEU PAGAMENTO.
            </SubTitle>

            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>

        </PagesDefault>

    );
}