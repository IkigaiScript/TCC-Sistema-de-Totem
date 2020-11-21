import React,{ useState } from 'react';
import Button from '../../../components/Buttons';
import Relogio from '../../../components/Relogio/';
import { Link } from 'react-router-dom';
import { PageDefault, TextWrapper, ButtonWrapper } from './style';
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Pedido } from '../../../services/PedidoApi'
const pedido = new Pedido();

export default function Dinheiro (){

    const [ped] = useState(localStorage.getItem('pedido'));
    
    async function cancelar(){
        try{
            const response = await pedido.deleteOrder(ped);
            console.log(response);
            localStorage.removeItem('pedido');
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

            <h1> Pedido:{ped}</h1>

            <ButtonWrapper>

                <Button 
                    as= { Link }
                    to= '/' 
                    children= 'Cancelar Pedido' 
                    onClick = {cancelar}
                />

                <Relogio />

                <Button 
                    as= { Link }
                    to='/'  
                    children='Finalizar'
                    onClick = {() => sessionStorage.removeItem('pedido')} 
                />

            </ButtonWrapper>
            <ToastContainer/>
        </PageDefault>
    );
}
