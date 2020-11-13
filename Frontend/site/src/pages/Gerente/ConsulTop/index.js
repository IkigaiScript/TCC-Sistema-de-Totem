import React,{ useState, useEffect } from 'react'
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import {PageDefault, ClassificarWrapper, TopWrapper} from './style'
import { ToastContainer,toast } from 'react-toastify'
import { Gerente } from '../../../services/GerenteApi'
const api = new Gerente();

"use strict"

export default function ConsulTop (){
    
    async function consultTopFilmes(){
        try{
            const response = await api.TopFilmes();
            return response;
        }
        catch(e){
            toast.error(e.response.data)
        }
    }

    async function consultTopProdutos(){
        try{
            const response = api.TopProdutos();
            return response;
        }
        catch(e){
            toast.error(e.response.data);
        }
    }

    useEffect(() => {
        consultTopFilmes();
        consultTopProdutos();
    },[]);
    
    return(
        <PageDefault>
            <ToastContainer/>
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