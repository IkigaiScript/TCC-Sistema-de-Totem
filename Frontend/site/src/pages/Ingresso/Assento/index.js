import React, { useState } from 'react';
import { PageDefault, SalaWrapper, Assento, Select, Fileira, Cadeira } from './style';
import Button from '../../../components/Buttons';
import Relogio from '../../../components/Relogio';
import { Link } from 'react-router-dom';
import { MdEventSeat } from 'react-icons/md';
import { Ingresso } from "../../../services/IngressoApi";
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const ingresso = new Ingresso();

export default function Lugar(props){   

    const [meiaEntrada,setMeiaEntrada] = useState([]);
    const [cadeira,setCadeira] = useState([]);
    const [valor,setValor] = useState();
    const [sessao,setSessao] = useState(0);
    const [ped,setPed] = useState(localStorage.getItem('pedido'));
    const [sessoes,setSessoes] = useState(props.location.state);
    const [toogle, setToogle] = useState(true);
    const [cor, setCor] = useState('#c3c3c3');

    function Click(){
        setCor((state) => toogle ? '#c3c3c3': '#446677');

        return  setToogle(state => !state);
    }

    function valueSala(){
        console.log(sessao)

        if(sessao != 0){
            const item = sessoes.find(x => x.id == sessao);
            let r = item.valor;
            setValor(r);
        }

        else {
            setValor(0);
        }
    }

    async function consultPoltrona(){
        try{
            const response = await ingresso.consultPlaces(sessao);
            console.log(response);
            
        }
        catch(e){
            if(e.response.data.error){
                console.log(e.response.data);
                toast.error(e.response.data.error);
              }
              else {
                console.log(e.response.data);
                toast.error("Algo deu errado!");
              }
        }
    }

    async function cadastrar(){
        try{

            const cad = [];

            for(let x in cadeira){
                cad.push({
                        Fileira:String(x).substr(0,1),
                        Poltrona:Number(String(x).substr(1)),
                        MeiaEntrada:meiaEntrada.findIndex(x => x.assento == x)
                    }
                );
            }

            const req = {
                Pedido:ped,
                Sessao:sessao,
                Assento:cad
            };

            console.log(req);

            const response = await ingresso.registerTicket(req);
            return response;
        }
        catch(e){
            if(e.response.data.error){
                console.log(e.response.data);
                toast.error(e.response.data.error);
              }
              else {
                console.log(e.response.data);
                toast.error("Algo deu errado!");
              }
        }
    }

    const fileira01 = [
        {assento:'A01'},
        {assento:'B01'},
        {assento:'C01'},
        {assento:'D01'},
        {assento:'E01'},
        {assento:'F01'},
        {assento:'G01'}
    ]

    const fileira02 = [
        {assento:'A02'},
        {assento:'B02'},
        {assento:'C02'},
        {assento:'D02'},
        {assento:'E02'},
        {assento:'F02'},
        {assento:'G02'}
    ]

    const fileira03 = [
        {assento:'A03'},
        {assento:'B03'},
        {assento:'C03'},
        {assento:'D03'},
        {assento:'E03'},
        {assento:'F03'},
        {assento:'G03'}
    ]

    const fileira04 = [
        {assento:'A04'},
        {assento:'B04'},
        {assento:'C04'},
        {assento:'D04'},
        {assento:'E04'},
        {assento:'F04'},
        {assento:'G04'}
    ]

    const fileira05 = [
        {assento:'A05'},
        {assento:'B05'},
        {assento:'C05'},
        {assento:'D05'},
        {assento:'E05'},
        {assento:'F05'},
        {assento:'G05'}
    ]

    const fileira06 = [
        {assento:'A06'},
        {assento:'B06'},
        {assento:'C06'},
        {assento:'D06'},
        {assento:'E06'},
        {assento:'F06'},
        {assento:'G06'}
    ]

    const fileira07 = [
        {assento:'A07'},
        {assento:'B07'},
        {assento:'C07'},
        {assento:'D07'},
        {assento:'E07'},
        {assento:'F07'},
        {assento:'G07'}
    ]

    return (
        <PageDefault>

            <h1>Cadeiras</h1>

            <SalaWrapper>

                <Select onClick={(e) => {
                                        setSessao(e.target.value);
                                        valueSala();
                                    }}>
                    <option value = {0} selected>Escolha sua sala</option>
                    {sessoes.map(x => 
                        <option value = {x.id}>{`Sala ${x.sala} ${x.tipoSala}`}</option>
                    )}
                </Select>

                <input  type="number" 
                        value={valor}
                        disabled
                    />

                <Select>
                    {sessoes.map(x => 
                        <option>{String(x.horario).substring(String(x.horario).indexOf("T") + 1,String(x.horario).lastIndexOf(":"))}</option>
                    )}
                </Select>

            </SalaWrapper>

            <Assento>

                <Fileira>

                    {fileira01.map(valor => {

                        if(valor.assento === 'Ocupado'){
                            return (

                                <Cadeira background = 'gray'> 

                                    <MdEventSeat size = '60px' color = 'black'/> 
                                    <button disabled>{valor.assento}</button> 

                                </Cadeira>

                            )
                        }else{
                            return (
                                
                                <Cadeira style = {{backgroundColor:cor}} >

                                    <MdEventSeat size = '60px'  color = 'orange'/> 
                                    <button id = {valor.assento}
                                            onClick={() => cadeira.push(valor.assento)}
                                        >{valor.assento}</button> 

                                </Cadeira>
                                
                            )
                        }
                    })} 

                </Fileira>

                <Fileira>

                    {fileira02.map(valor => {

                        if(valor.assento === 'Ocupado'){
                            return (

                                <Cadeira background = 'gray'> 

                                    <MdEventSeat size = '60px' color = 'black'/> 
                                    <button disabled>{valor.assento}</button> 

                                </Cadeira>

                            )
                        }else{
                            return (

                                
                                <Cadeira style = {{backgroundColor:cor}} >

                                    <MdEventSeat size = '60px'  color = 'orange'/> 
                                    <button id = {valor.assento}
                                            onClick={() => cadeira.push(valor.assento)}
                                        >{valor.assento}</button> 

                                </Cadeira>
                                
                            )
                        }
                    })} 

                </Fileira>

                <Fileira>

                    {fileira03.map(valor => {

                        if(valor.assento === 'Ocupado'){
                            return (

                                <Cadeira background = 'gray'> 

                                    <MdEventSeat size = '60px' color = 'black'/> 
                                    <button disabled>{valor.assento}</button> 

                                </Cadeira>

                            )
                        }else{
                            return (

                                
                                <Cadeira style = {{backgroundColor:cor}} >

                                    <MdEventSeat size = '60px'  color = 'orange'/> 
                                    <button id = {valor.assento}
                                            onClick={() => cadeira.push(valor.assento)}
                                        >{valor.assento}</button> 

                                </Cadeira>
                                
                            )
                        }
                    })} 

                </Fileira>

                <Fileira>

                    {fileira04.map(valor => {

                        console.log('Ls1' + valor.assento)
                        if(valor.assento === 'Ocupado'){
                            return (

                                <Cadeira background = 'gray'> 

                                    <MdEventSeat size = '60px' color = 'black'/> 
                                    <button disabled>{valor.assento}</button> 

                                </Cadeira>

                            )
                        }else{
                            return (

                                
                                <Cadeira style = {{backgroundColor:cor}} >

                                    <MdEventSeat size = '60px'  color = 'orange'/> 
                                    <button id = {valor.assento}
                                            onClick={() => cadeira.push(valor.assento)}
                                        >{valor.assento}</button> 
                                        
                                </Cadeira>
                            )
                        }
                    })} 

                </Fileira>

                <Fileira>

                    {fileira05.map(valor => {

                        console.log('Ls1' + valor.assento)
                        if(valor.assento === 'Ocupado'){
                            return (

                                <Cadeira background = 'gray'> 

                                    <MdEventSeat size = '60px' color = 'black'/> 
                                    <button disabled>{valor.assento}</button> 

                                </Cadeira>

                            )
                        }else{
                            return (

                                
                                <Cadeira style = {{backgroundColor:cor}} >

                                    <MdEventSeat size = '60px'  color = 'orange'/> 
                                    <button id = {valor.assento}
                                            onClick={() => cadeira.push(valor.assento)}
                                        >{valor.assento}</button> 

                                </Cadeira>
                                
                            )
                        }
                    })} 

                </Fileira>

                <Fileira>

                    {fileira06.map(valor => {

                        console.log('Ls1' + valor.assento)
                        if(valor.assento === 'Ocupado'){
                            return (

                                <Cadeira background = 'gray'> 

                                    <MdEventSeat size = '60px' color = 'black'/> 
                                    <button disabled>{valor.assento}</button> 

                                </Cadeira>

                            )
                        }else{
                            return (

                                
                                <Cadeira style = {{backgroundColor:cor}} >

                                    <MdEventSeat size = '60px'  color = 'orange'/> 
                                    <button id = {valor.assento}
                                            onClick={() => cadeira.push(valor.assento)}
                                        >{valor.assento}</button> 

                                </Cadeira>
                                
                            )
                        }
                    })} 

                </Fileira>

                <Fileira>

                    {fileira07.map(valor => {

                        console.log('Ls1' + valor.assento)
                        if(valor.assento === 'Ocupado'){
                            return (

                                <Cadeira background = 'gray'> 

                                    <MdEventSeat size = '60px' color = 'black'/> 
                                    <button disabled>{valor.assento}</button> 

                                </Cadeira>

                            )
                        }else{
                            return (

                                
                                <Cadeira style = {{backgroundColor:cor}} >

                                    <MdEventSeat size = '60px'  color = 'orange'/> 
                                    <button id = {valor.assento}
                                            onClick={() => cadeira.push(valor.assento)}
                                        >{valor.assento}</button> 

                                </Cadeira>
                                
                            )
                        }
                    })} 

                </Fileira>

            </Assento>
            
            <SalaWrapper>

                <Button 
                    as = {Link}
                    to = '/sessaofilme'
                    children = 'Voltar'
                />

                <Relogio />

                <Button 
                    as = {Link}
                    to = '/compra/ingresso'
                    children = 'Proximo'
                />

            </SalaWrapper>          
            <ToastContainer />
        </PageDefault>
    );   
}