import React,{ useState } from 'react';
import Input from '../../../components/Input'
import Relogio from '../../../components/Relogio';
import {PageDefault, SearchWrappper} from './style';
import { ToastContainer,toast } from 'react-toastify';
import { Gerente } from '../../../services/GerenteApi';
import Chart from "react-google-charts";
import Table from 'react-bootstrap/Table';
import Tabs from 'react-bootstrap/Tabs';
import Tab from 'react-bootstrap/Tab';
import 'bootstrap/dist/css/bootstrap.min.css';

const api = new Gerente();

export default function ConsultGerente() {

    const [dia,setDia] = useState(0);
    const [mesInicio,setMesInicio] = useState(0);
    const [mesFinal,setMesFinal] = useState(0);
    const [vendasDia,setVendasDia] = useState([])
    const [vendasMes,setVendasMes] = useState([]);

    async function consultVendasDoDia(){
        try{
            const response = await api.VendasDoDia(dia);
            setVendasDia([...response]);
            return response;
        }
        catch(e){
            toast.error(e.response.data.error);
        }
    }

    async function consultVendasDoMes(){
        try{
            const response = await api.VendasdoMes(mesInicio,mesFinal);
            setVendasMes([...response]);
            return response;
        }
        catch(e){
            toast.error(e.response.data.error);
        }
    }

    return(

        <PageDefault>

            <ToastContainer/>   
            <h1>Realizar  consulta por dia/mes</h1>

            <SearchWrappper>

                <div>

                    <span>Inicio</span>
                    <Input 

                        type = 'month'
                        value = {mesInicio}
                        onChange = {e => setMesInicio(e.target.value)}
                        
                        width = '16vw'
                    />

                </div>

                <div>

                    <span>Fim</span>
                    <Input 

                        type = 'month'    
                        value = {mesFinal}
                        onChange = {e => setMesFinal(e.target.value)}
                        
                        width = '16vw'
                    />

                </div>

                <Input 
                    type = 'date'
                    value = {dia}
                    onChange = {e => setDia(e.target.value)}
                    
                    width = '20vw'
                />    

            </SearchWrappper>

            <div>

            <Tabs defaultActiveKey="home" transition={false} id="noanim-tab-example">

                <Tab eventKey="Dia" title="Dia">


                    
                </Tab>

                <Tab eventKey="Mês" title="Mês">



                </Tab>

                

            </Tabs>

            </div>


            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>
        </PageDefault>
    );

}
