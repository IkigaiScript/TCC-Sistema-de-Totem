import React from 'react';
import Input from '../../../components/Input'
import Relogio from '../../../components/Relogio';
import {PageDefault, SearchWrappper} from './style';


export default function ConsultGerente() {

    return(

        <PageDefault>

            <h1>Realizar  consulta por dia/mes</h1>

            <SearchWrappper>

                <Input 
                    type = 'month'
                    placeholder = 'Escolhau um mês'
                    
                    width = '20vw'
                />

                <Input 
                    type = 'date'
                    placeholder = 'Escolhau um dia'
                    
                    width = '20vw'
                />    

            </SearchWrappper>


            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>

        </PageDefault>
    )

}