import React, { useEffect, useState } from 'react';
import { Multiselect } from 'multiselect-react-dropdown';
import {PagesDefault, ButtonWrapper, OptionWrapper, Custom} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons'
import { BiReset } from "react-icons/bi";
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Combo } from '../../../services/ComboApi'
import { GetPhoto } from '../../../services/GetPhotoApi'
import { PedidoCombo } from '../../../services/PedidoComboApi'
const combo = new Combo();
const getPhoto = new GetPhoto();
const pedidocombo = new PedidoCombo();

export default function Combos(){
    
    const [combos,setCombos] = useState([]);
    const [ped,setPed] = useState(localStorage.getItem('pedido'));
    const [itens,setItens] = useState([]);

    async function consultCombos(){
        try{
            const response = await combo.consultCombo();
            setCombos([...response]);
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

    async function cadastrarCombo(){
        try{
            const req = {
                Pedido:ped,
                Itens:itens
            };

            const response = await pedidocombo.registerComboOrden(req);
            console.log(response);
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
        consultCombos();
    },[]); 

    const options = {
        select: [
            {name: 'Pipoca', id: "1"},
            {name: "Combo", id: "2"},
            {name: "Doce", id: "3"},    
            {name: "Bebida", id: "4"}
        ]
    };

   const style = {
        chips: {
            color: 'white',
            fontsize:'18px',
            paddingleft: '10px'
        },
        searchBox: {
            minwidth: '200px',
            height: '35px',
            background : 'lightgray',
            color: 'white'
           
        },
        multiselectContainer: {
            width: '200px',
            height: '35px',
            color: 'darkorange'
        }
    };

    return (
        <PagesDefault>
            
            <h1>Qual combo deseja?</h1>

            <ButtonWrapper>
                
                <Button
                    to = '/compra/lanche'
                    children = 'Voltar'
                />

                <Relogio />

                <Multiselect
                    placeholder = 'adicionar items'
                    options={options.select}
                    displayValue="name"
                    style={style}
                    singleSelect
                />

            </ButtonWrapper>

            <OptionWrapper>

                <Custom>

                    {combo.map(x => 
                            <>
                                
                            </>
                        )};

                </Custom>

            </OptionWrapper>

            <ButtonWrapper>

                <Button 
                    to = '/sessaofilme'
                    children = 'Compra Ingreeso'
                />

                <button>Desfazer</button>

                <Button 
                    to = '/escolha-pagamento'
                    children = 'Pagamento'
                />

            </ButtonWrapper>
            <ToastContainer/>
        </PagesDefault>       
    );
}