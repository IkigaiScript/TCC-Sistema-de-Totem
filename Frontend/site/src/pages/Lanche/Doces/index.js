import React from 'react';
import {PagesDefault, DivButton, DivRelogio, DivLanche} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Buttons from '../../../components/Buttons'
 
export default function Doce (){
    return (
        <PagesDefault>
            <h1>Qual doce deseja?</h1>

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
            </DivLanche>

        </PagesDefault>       
    );
}