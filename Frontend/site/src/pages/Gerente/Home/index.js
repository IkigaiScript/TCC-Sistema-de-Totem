import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import {PageDefault, OpcaoWrapper,  GrafiWrapper} from './style';
import { ToastContainer,toast } from 'react-toastify';
import { Gerente } from '../../../services/GerenteApi';
import Chart from 'react-google-charts';

const gerente = new Gerente();

export default function HomeGerente() {

    const [totem,setTotem] = useState(0);
    const [login,setLogin] = useState(0);

    async function totemLogins(){

        try{
            const response = await gerente.totemLogins();
            setTotem(response.totem);
            setLogin(response.login);
            return response;
        }
        catch(e){
            toast.error(e.response.data);
        }
    }

    useEffect(() => {
        totemLogins();
    },[])

    return(

        <PageDefault>
            <h1>Gerenciamento do Totem</h1>
            <OpcaoWrapper>
                <Button
                    as = { Link } 
                    to = '/Gerenciar/consult'
                    children = 'Consultar por dia/mês'
                />

                <Button 
                    as = { Link }
                    to = '/Gerenciar/top'
                    children = 'Consultar os top 10'
                />

                <Button 
                    children = 'Consultar'
                    onClick = {totemLogins}
                />
            </OpcaoWrapper>
            
            <GrafiWrapper>

                <Chart
                    width =  {'500px'}
                    height= {'320px'}
                    chartType='PieChart'
                    loader={<div style = {{'text-align' : 'center', 'font-size' : '25px', color : 'white'}}>Loading Login utilizado</div>}
                    data={[
                        ['Login', 'tipo'],
                        ['Totem', totem] ,
                        ['Usuario', login],  
                    ]}
                    options={{
                        title: 'Login de Usuarios',
                        // Just add this option
                        is3D: true,
                    }}
                    rootProps={{ 'data-testid': '2' }}
                />             

            </GrafiWrapper>

            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>            
            <ToastContainer/>
        </PageDefault>
    );

}