import React from 'react'
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import {PageDefault, ClassificarWrapper, TopWrapper} from './style'

export default function ConsulTop (){
    return(
        <PageDefault>
            
            <h1>Classificação dos Top 10</h1>
            
            <ClassificarWrapper>

                <TopWrapper>

                    <Button 
                        children = 'Top 10 mais Vendidas'
                    />

                </TopWrapper>

                <TopWrapper>

                    <Button 
                        children = 'Top 10 mais Vendidas'
                    />

                </TopWrapper>

            </ClassificarWrapper>



            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>


        </PageDefault>
    );
}