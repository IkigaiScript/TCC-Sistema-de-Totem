import React from 'react'
import Relogio from '../../../components/Relogio'
import Input from '../../../components/Input'
import Cartao from '../../../assets/Img/Cartao.png'
import QRCode from '../../../assets/Img/QRCode.png'
import Dinheiro from '../../../assets/Img/Dinheiro.png'
import {PageDefault, OpcaoWrapper, Opcao, Img, Span, ValorWrapper} from './style'
import {Link} from 'react-router-dom'


export default function HomePagamento (){
    return (
        <PageDefault>
            <h1>Formas de Pagamento</h1>

            <ValorWrapper>
                <span>R$</span>
                <Input type = 'number' width = '300' min = '0'/>
            </ValorWrapper>


            <OpcaoWrapper>

                <Opcao>
                    <Link to = '/NF-e'>
                        <Img src = {Cartao} alt = '' height = '200px' width = '200px' />
                        <Span>Cartão</Span>
                    </Link>
                </Opcao>

                <Opcao>
                    <Link to = '/pagamento/dinheiro'>
                        <Img src = {Dinheiro} alt = '' height = '200px' width = '200px' />
                        <Span>Dinheiro</Span>
                    </Link>
                </Opcao>

                <Opcao>

                    <Link to = '/NF-e'>

                        <Img src = {QRCode} alt = '' height = '200px' width = '200px' />
                        <Span>QRCode</Span>

                    </Link>

                </Opcao>

            </OpcaoWrapper>

            <div style = {{visibility: 'hidden'}}>
             <Relogio />
            </div>
    
        </PageDefault>
    );
}