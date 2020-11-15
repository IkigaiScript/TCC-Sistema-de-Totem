import React,{ useState } from 'react';
import Input from '../../../components/Input'
import Relogio from '../../../components/Relogio';
import {PageDefault, SearchWrappper} from './style';
import { Gerente } from '../../../services/GerenteApi';
import Chart from "react-google-charts";
import Table from 'react-bootstrap/Table';
import Tabs from 'react-bootstrap/Tabs';
import Tab from 'react-bootstrap/Tab';
import 'bootstrap/dist/css/bootstrap.min.css';
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const api = new Gerente();

export default function ConsultGerente() {

    const [dia,setDia] = useState(new Date().toISOString().substr(0, 10));
    const [mesInicio,setMesInicio] = useState(new Date().toISOString().substr(0, 10));
    const [mesFinal,setMesFinal] = useState();
    const [vendasDia,setVendasDia] = useState([])
    const [vendasMes,setVendasMes] = useState([]);

    async function consultVendasDoDia(){
        try{
            setVendasDia([]);
            const response = await api.VendasDoDia(new Date(dia).getDate() + 1);
            setVendasDia([...response]);
            return response;
        }
        catch(e){
            console.log(e);
            toast.error(e);
        }
    }

    async function consultVendasDoMes(){
        try{
             
            setVendasMes([]);

            const req = {
                Inicio:mesInicio,
                Final:mesFinal
            };

            const response = await api.VendasdoMes(req);
            setVendasMes([...response]);
            return response;
        }
        catch(e){
            console.log(e);
            toast.error(e);
        }
    }

    return(
        <PageDefault>
            <h1>Realizar  consulta por dia/mes</h1>

            <SearchWrappper>
                <div>
                    <label>Inicio</label>
                    <Input 
                        type = 'date'
                        value = {mesInicio}
                        onChange = {(e) => setMesInicio(e.target.value)}
                        width = '16vw'
                        min = {new Date(new Date().getFullYear() -2 ,12,30)}
                        max = {new Date()}
                    />
                </div>

                <div>
                    <label>Fim</label>
                    <Input 
                        type = 'date'    
                        value = {mesFinal}
                        onChange = {(e) => setMesFinal(e.target.value)}
                        width = '16vw'
                        min = {new Date(new Date().getFullYear() -2 ,12,30)}
                        max = {new Date()}
                    />
                </div>
                <div>
                    <label>Dia</label>
                    <Input 
                        type = 'date'
                        value = {dia}
                        onChange = {e => setDia(e.target.value)}             
                        width = '20vw'
                    />    
                </div>
            </SearchWrappper>
            <div>
                <button onClick = {consultVendasDoMes}>Consulta Mes</button>
                <button onClick = {consultVendasDoDia}>Consultar dia</button>
            </div>                
            <div>
                <Tabs defaultActiveKey="home" transition={false} id="noanim-tab-example">
                    <Tab eventKey="Dia" title="Dia">
                        <table>
                            <thead>
                                <tr>
                                    <th>Pedido</th>
                                    <th>Nome</th>
                                    <th>Hora</th>
                                    <th>Dia</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                {vendasDia.map(x =>
                                        <tr key={x.pedido}>
                                            <td>{x.pedido}</td>
                                            <td>{x.cliente}</td>
                                            <td>{x.hora}</td>
                                            <td>{x.dia}</td>
                                            <td>{x.total}</td>
                                        </tr>
                                    )}
                            </tbody>
                        </table>
                    </Tab>

                    <Tab eventKey="Mês" title="Mês">
                        <table>
                            <thead>
                                <tr>
                                    <th>Mês</th>
                                    <th>Quantidade</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                {vendasMes.map(x => 
                                        <tr key={x.mes}>
                                            <td>{x.mes}</td>
                                            <td>{x.qtd}</td>
                                            <td>{x.total}</td>
                                        </tr>
                                    )}
                            </tbody>
                        </table>
                    </Tab>
                </Tabs>
            </div>

            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>

            <ToastContainer/>   
        </PageDefault>
    );
}
