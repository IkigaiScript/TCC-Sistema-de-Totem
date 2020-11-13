import React,{ useState } from 'react';
import Input from '../../../components/Input'
import Relogio from '../../../components/Relogio';
import {PageDefault, SearchWrappper} from './style';
import { ToastContainer,toast } from 'react-toastify'
import { Gerente } from '../../../services/GerenteApi'
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
    );

}
