import React, { useEffect, useState } from 'react';
import Relogio from '../../../components/Relogio';
import Input from '../../../components/Input';
import Cartao from '../../../assets/Img/Cartao.png';
import QRCode from '../../../assets/Img/QRCode.png';
import Dinheiro from '../../../assets/Img/Dinheiro.png';
import { PageDefault, OpcaoWrapper, Opcao, Img, Span, ValorWrapper } from './style';
import { Link } from 'react-router-dom';
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Pedido } from '../../../services/PedidoApi'
const pedido = new Pedido();

export default function HomePagamento (){

    const [ped] = useState(localStorage.getItem('pedido'));
    const [total,setTotal] = useState(0);

    async function calcularTotal(){
        try{
            const response = await pedido.changeOrderAmount(ped);
            console.log(response);
            setTotal(response);
            return response;
        }
        catch(e){
            if(e.response.data.error){
                console.log(e.response.data);
                toast.error(e.response.data.error);
              }
              else {
                console.log(e.response.data);
                toast.error("Algo deu errado!");
              }
        }
    }

    useEffect(() => {
        calcularTotal()
    },[]);

    return (
        <PageDefault>
            <h1>Formas de Pagamento</h1>

            <ValorWrapper>
                <span>R$</span>
                <Input value={total} type = 'number' width = '300' min = '0' disabled />
            </ValorWrapper>


            <OpcaoWrapper>

                <Opcao>
                    <Link to = '/NF-e' onClick={() => window.localStorage.setItem('pagamento','cartao')}>
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
                    <Link to = '/NF-e' onClick={() => window.localStorage.setItem('pagamento','qrcode')}>
                        <Img src = {QRCode} alt = '' height = '200px' width = '200px' />
                        <Span>QRCode</Span>
                    </Link>
                </Opcao>

            </OpcaoWrapper>

            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>   

            <ToastContainer/>
        </PageDefault>
    );
}