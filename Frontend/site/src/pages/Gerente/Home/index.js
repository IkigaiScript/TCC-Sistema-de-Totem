import React from 'react';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import {PageDefault, OpcaoWrapper} from './style';

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