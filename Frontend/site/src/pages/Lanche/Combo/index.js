import React from 'react';
import { Multiselect } from 'multiselect-react-dropdown';
import {PagesDefault, ButtonWrapper, OptionWrapper, Custom} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons'
import { BiReset } from "react-icons/bi";


 
export default function Combo (){
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
            
            
        </PagesDefault>       
    );
}