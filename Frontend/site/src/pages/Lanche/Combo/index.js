import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import {H1, PagesDefault, Option, ButtonWrapper, OptionWrapper, Select} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { PedidoCombo } from '../../../services/PedidoComboApi'
import { Combo } from '../../../services/ComboApi'
import { GetPhoto } from '../../../services/GetPhotoApi'
const combo = new Combo();
const getPhoto = new GetPhoto();
const pedidocombo = new PedidoCombo();

export default function Combos (){

    const [history,setHistory] = useState([]);
    const [ped] = useState(localStorage.getItem('pedido'));
    const [combos, setCombos] = useState([]);
    const [itens] = useState([]);

    async function consultBebida(){
        try{
            const response = await combo.consultCombo();
            setCombos([...response]);
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

    async function cadastrarCombo(){
        try{

            combos.map(x => 
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
            
            const response = await pedidocombo.registerComboOrden(req);
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
            const response = await pedidocombo.history(ped);
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
        
        if(history.some(x => x.combo === id)){
            return history.find(x => x.combo === id).qtd;
        }
        else return 0;
    }

    useEffect(() => {
        consulthistory();
        consultBebida();
    },[])

    return (
        <PagesDefault>
            
            <H1>Qual bebida deseja tomar?</H1>

            <ButtonWrapper>

                <Relogio />

                <Select onClick={e => switchRoutes(e.target.value)}>
                    <Option> Combo </Option>
                    <Option> Pipoca </Option>
                    <Option value='doces'> Doce </Option>
                    <Option selected value='master'> Bebida </Option>
                </Select>

            </ButtonWrapper>

            <OptionWrapper>
                
                {combos.map(x => 
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
                            cadastrarCombo();
                        }}
                    />

                <Button 
                        as = {Link}
                        to = '/escolha-pagamento'
                        children = 'Pagamento'
                        onClick = {() => {
                            cadastrarCombo();
                        }}
                    />

            </ButtonWrapper>
            <ToastContainer/>
        </PagesDefault>      
    );
}