import React from 'react';
import {PagesDefault, ButtonWrapper, OptionWrapper, Custom} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons'
import { BiReset } from "react-icons/bi";



 
export default function Bebida (){
    return (
        <PagesDefault>
            
            <h1>Qual Bebida deseja tomar?</h1>

            <ButtonWrapper>
                <Button
                    to = '/compra/lanche'
                    children = 'Voltar'
                />

                <Relogio />

                <Button 
                    children = 'DropDown'
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