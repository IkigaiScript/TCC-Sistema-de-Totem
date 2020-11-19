import React, {useState, useEffect} from 'react';
import {Link} from 'react-router-dom';
import { Multiselect } from 'multiselect-react-dropdown';
import {H1, PagesDefault, Option, ButtonWrapper, OptionWrapper, Select} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Dropdown from 'react-bootstrap/DropdownButton';
import { ToastContainer,toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { PedidoSnackBar } from '../../../services/PedidoSnackBarApi'
import { SnackBar } from '../../../services/SnackBarApi'
import { GetPhoto } from '../../../services/GetPhotoApi'
const snackbar = new SnackBar();
const getPhoto = new GetPhoto();
const pedidosnackbar = new PedidoSnackBar();

export default function Bebida (){

    const [history,setHistory] = useState([]);
    const [ped] = useState(localStorage.getItem('pedido'));
    const [bebidas, setBebidas] = useState([]);
    const [itens,setItens] = useState([]);

    async function consultBebida(){
        try{
            const response = await snackbar.consultProduto('bebida');
            console.log(response);
            setBebidas([...response]);
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
            const req = {
                Pedido:ped,
                Itens:itens
            }

            const response = await pedidosnackbar.registerSnackOrder(req)
            console.log(response);
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

    useEffect(() => {
        consultBebida();
        consulthistory();
    },[])

    return (
        <PagesDefault>
            
            <H1>Qual bebida deseja tomar?</H1>

            <ButtonWrapper>

                <Relogio />

                <Select>
                    <Option>Combo</Option>
                    <Option>Pipoca</Option>
                    <Option>Doce</Option>
                    <Option selected></Option>
                </Select>

            </ButtonWrapper>

            <OptionWrapper>
                
                {bebidas.map(x => 
                    <SelectionLanche key = {x.id}
                        imagem  =  {getPhoto.getPhoto(x.imagem)}
                        title   =  {x.nome}
                        peso    =  {x.peso}
                        sabor   =  {x.sabor}
                        preco   =  {`R$ ${x.preco}`}
                    />
                )};
                
            </OptionWrapper>

            <ButtonWrapper>

                <Button 
                        as = {Link}
                        to = '/sessaofilme'
                        children = 'Compra Ingreeso'
                        onClick = {() => {
                            if(itens.length > 0) cadastrarSnackBar();
                        }}
                    />

                <Button 
                        as = {Link}
                        to = '/escolha-pagamento'
                        children = 'Pagamento'
                        onClick = {() => {
                            if(itens.length > 0) cadastrarSnackBar();
                        }}
                    />

            </ButtonWrapper>
            <ToastContainer/>
        </PagesDefault>      
    );
}