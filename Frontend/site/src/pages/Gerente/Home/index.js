import React from 'react';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import {PageDefault, OpcaoWrapper} from './style';
import { ToastContainer,toast } from 'react-toastify'
import { Gerente } from '../../../services/GerenteApi'
const api = new Gerente();

export default function HomeGerente() {

    return(

        <PageDefault>

            <h1>Gerenciamento do Totem</h1>

            <OpcaoWrapper>
               
                <Button 
                    children = 'Consultar por dia/mês'
               
                />

                <Button 
                    children = 'Consultar os top 10'
               
                />


                <Button 
                    children = 'Consultar'
            
                />

            </OpcaoWrapper>
            
            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>

        </PageDefault>
    )

}