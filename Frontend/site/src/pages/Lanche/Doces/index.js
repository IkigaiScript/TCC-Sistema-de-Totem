import React from 'react';
import {PagesDefault, DivButton, DivRelogio, DivLanche,DivTitulo, UltDiv} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Buttons from '../../../components/Buttons';
import { BiReset } from "react-icons/bi";


 
export default function Doce (){
    return (
        <PagesDefault>
            <DivTitulo>
                <h1>Qual doce deseja?</h1>
            </DivTitulo>

            <DivButton>
            <Buttons
                 to = '/'
                children = 'Voltar'
            />
            </DivButton>

            <DivRelogio>
                 <Relogio/>
            </DivRelogio>

            <DivLanche>
                 <SelectionLanche/>
                 <SelectionLanche/>
                 <SelectionLanche/>
                 <SelectionLanche/>
            </DivLanche>

            <UltDiv>
                <Buttons
                    to = '/'
                    children = "Comprar ingresso"
                />
                <a href="" alt="Desfazer"><BiReset/>  Desfazer </a>
                <Buttons
                    to = '/'
                    children = "Pagamento"
                />
            </UltDiv>

        </PagesDefault>       
    );
}