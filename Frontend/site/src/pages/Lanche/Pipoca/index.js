import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import {H1, PagesDefault, Option, ButtonWrapper, OptionWrapper, Select} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { PedidoSnackBar } from '../../../services/PedidoSnackBarApi';
import { SnackBar } from '../../../services/SnackBarApi';
import { GetPhoto } from '../../../services/GetPhotoApi';
const snackbar = new SnackBar();
const getPhoto = new GetPhoto();
const pedidosnackbar = new PedidoSnackBar();

export default function Pipoca (){

    const [history,setHistory] = useState([]);
    const [ped] = useState(localStorage.getItem('pedido'));
    const [pipocas, setPipocas] = useState([]);
    const [itens] = useState([]);

    async function consultBebida(){
        try{
            const response = await snackbar.consultProduto('pipoca');
            setPipocas([...response]);
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

    async function cadastrarSnackBar(){
        try{

            pipocas.map(x => 
                    itens.push(
                        {
                            Qtd:Number(window.localStorage.getItem(`id ${x.id}`)),
                            SnackBar:Number(x.id)
                        }
                    )
                );
            
            const req = {
                Pedido:Number(ped),
                Itens:itens.filter(x => x.Qtd != 0)
            };
            
            const response = await pedidosnackbar.registerSnackOrder(req);
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

    async function consulthistory(){
        try{
            const response = await pedidosnackbar.history(ped);
            console.log(response);
            setHistory([...response]);
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

    function switchRoutes(route){
        if(route !== 'master'){
            window.location.assign(`${window.location.origin}/compra/lanche/${route}`);
        }
    }

    function takeQtd(id){
        
        if(history.some(x => x.snackBar === id)){
            return history.find(x => x.snackBar === id).qtd;
        }
        else return 0;
    }

    useEffect(() => {
        consulthistory();
        consultBebida();
    },[])

    return (
        <PagesDefault>
            
            <H1>Qual pipoca deseja tomar?</H1>

            <ButtonWrapper>

                <Relogio />

                <Select onClick={e => switchRoutes(e.target.value)}>
                    <Option> Combo </Option>
                    <Option selected value='master'> Pipoca </Option>
                    <Option value='doces'> Doce </Option>
                    <Option> Bebida </Option>
                </Select>

            </ButtonWrapper>

            <OptionWrapper>
                
                {pipocas.map(x => 
                    <SelectionLanche key = {x.id}
                        id      = {x.id}
                        imagem  =  {getPhoto.getPhoto(x.imagem)}
                        title   =  {x.nome}
                        peso    =  {x.peso}
                        sabor   =  {x.sabor}
                        preco   =  {`R$ ${x.preco}`}
                        qtd     =  {takeQtd(x.id)}
                    />
                )};
                
            </OptionWrapper>

            <ButtonWrapper>

                <Button 
                        as = {Link}
                        to = '/sessaofilme'
                        children = 'Compra Ingreeso'
                        onClick = {() => {
                            cadastrarSnackBar();
                        }}
                    />

                <Button 
                        as = {Link}
                        to = '/escolha-pagamento'
                        children = 'Pagamento'
                        onClick = {() => {
                            cadastrarSnackBar();
                        }}
                    />

            </ButtonWrapper>
            <ToastContainer/>
        </PagesDefault>      
    );
}