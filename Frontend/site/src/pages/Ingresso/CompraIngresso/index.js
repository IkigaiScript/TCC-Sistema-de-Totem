import React, { useState } from 'react'
import {PageDefault, Custom, ButtonWrapper,AssentoInfo} from './style';
import Relogio from '../../../components/Relogio/';
import Input from '../../../components/Input';
import Button from '../../../components/Buttons';
import SelectFilme from '../../../components/SelectionFilme'
import { BiReset } from "react-icons/bi";
import Ingresso from '../../../services/IngressoApi'
const api = new Ingresso();

export default function CompraIngresso (){

    const [sessao,setSessao] = useState(0);
    const [fileira,setFileira] = useState('');
    const [poltrona,setPoltrona] = useState(0);
    const [pedido,setPedido] = useState(0);
    const [meiaEntrada,setMeiaEntrada] = useState(false);
    const [assentos,setAssentos] = useState([]);

    async function register(){
        try{
            const req = {
                Sessao:sessao,
                Fileira:fileira,
                Poltrona:poltrona,
                Pedido:pedido,
                MeiaEntrada:meiaEntrada
            };

            const response = await api.RegisterTicket(req);
            return response;
        }
        catch(e){
            console.log(e);
        }
    }

    async function assentos(){
        try{
            const response = await api.ConsultPlaces(sessao);
            setAssentos([...response]);
            return response;
        }
        catch(e){
            console.log(e);
        }
    }

    return (
        <PageDefault>
            <h1>Ingresso</h1>

            <SelectFilme />

            <AssentoInfo>
                <span>Assentos</span>
                
            </AssentoInfo>

            <Custom>

                <div>

                    <span>Sala</span>
                    <Input type = 'text' border = '0' 
                        width = '400px'
                    />

                </div>

                <div>

                    <span>Sessão</span>
                    <Input type = 'text' 
                        border = '0' width = '400px'
                    />

                </div>

            </Custom>

            <Custom>

                <div>

                    <span>Inteira R$ 00,00</span>
                    <Input type = 'number'  width = '300'
                        min = '0' max = '50'
                    />

                </div>

                <div>

                    <span>Meia-entrada R$ 00,00</span>
                    <Input  type = 'number' width = '300'
                        min = '0' max = '50'
                    />
                    
                </div>

            </Custom>

            <div>

                <span>Qual seu nome?</span>
                <Input type = 'text' width = '80vw'/>

            </div>

            <ButtonWrapper>

                <Button 
                    to = '/compra/lanche'
                    children = 'Comprar Lanche'
                />
                
                <Relogio  />

                <Button 
                    to = '/escolha-pagamento'
                    children = 'Pagamento'
                />

            </ButtonWrapper>

            
        </PageDefault>
    );
}