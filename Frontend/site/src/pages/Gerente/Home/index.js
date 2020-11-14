import React, { useState } from 'react';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import {PageDefault, OpcaoWrapper} from './style';
import { ToastContainer,toast } from 'react-toastify';
import { Gerente } from '../../../services/GerenteApi';
const api = new Gerente();

export default function HomeGerente() {

    const [totem,setTotem] = useState(0);
    const [login,setLogin] = useState(0);

    async function TotemLogins(){
        try{
            const response = await api.TotemLogins();
            setTotem(response.Totem);
            setLogin(response.Login);
            return response;
        }
        catch(e){
            toast.error(e.response.data);
        }
    }
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