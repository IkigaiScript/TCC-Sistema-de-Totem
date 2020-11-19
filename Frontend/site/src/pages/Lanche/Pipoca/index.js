import React from 'react';
import { Multiselect } from 'multiselect-react-dropdown';
import {PagesDefault, ButtonWrapper, OptionWrapper, Custom} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons'
import { BiReset } from "react-icons/bi";
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { PedidoSnackBar } from '../../../services/PedidoSnackBarApi'
import { SnackBar } from '../../../services/SnackBarApi'
import { GetPhoto } from '../../../services/GetPhotoApi'
const snackbar = new SnackBar();
const getPhoto = new GetPhoto();
const pedidosnackbar = new PedidoSnackBar();
 

export default function Pipoca(){
    const options = {
        select: [{name: "Pipoca", id: "1"},
                 {name: "Combo", id: "2"},
                 {name: "Doce", id: "3"},
                 {name: "Bebida", id: "4"}]
   };

   const style = {
        chips: {
            color: "white"
        },
        searchBox: {
            width: "150px",
            height: "35px"
        },
        multiselectContainer: {
            width: "150px",
            height: "35px"
        }
  };

    return (
        <PagesDefault>
            
        <h1>Qual pipoca deseja?</h1>

        <ButtonWrapper>
            <Button
                to = '/compra/lanche'
                children = 'Voltar'
            />

            <Relogio />

            <Multiselect
                    options={options.select}
                    displayValue="name"
                    style={style}
                    singleSelect
            />

        </ButtonWrapper>

        <OptionWrapper>

            <Custom>

                <SelectionLanche />

                <SelectionLanche />

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