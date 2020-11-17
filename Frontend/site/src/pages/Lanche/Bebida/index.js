import React, {useState, useEffect} from 'react';
import {Link} from 'react-router-dom';
import { Multiselect } from 'multiselect-react-dropdown';
import {PagesDefault, ButtonWrapper, OptionWrapper} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import SnackBar from '../../../services/SnackBarApi';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Dropdown from 'react-bootstrap/DropdownButton';
import 'react-toastify/dist/ReactToastify.css';

const api = new SnackBar();

export default function Bebida (){

    const [req, setReq] = useState('');
    

    const consultDrink = async() => {
        try{
            const drink = await api.consult('bebida');
            setReq([...drink]);
            return drink;
        }catch(e){
            console.error('Falha na interegração');
        }
    }

    useEffect(() => {
        consultDrink();
    },[])

    const options = {
        select: [{name: "Pipoca", id: "1"},
                 {name: "Combo", id: "2"},
                 {name: "Doce", id: "3"},
                 {name: "Bebida", id: "4"}],

        selectedValues: [{name: "Pipoca", id: "1"},
                       {name: "Combo", id: "2"},
                       {name: "Doce", id: "3"},
                       {name: "Bebida", id: "4"}]
   };

   const style = {
        chips: {
            color: "white"
        },
        searchBox: {
            width: "150px",
            height: "35px"
        },
        multiselectContainer: {
            width: "150px",
            height: "35px"
        }
    };
   

    return (
        <PagesDefault>
            
            <h1>Qual Bebida deseja tomar?</h1>

            <ButtonWrapper>

                <Button
                    as = {Link}
                    to = '/compra/lanche'
                    children = 'Voltar'
                />

                <Relogio />

            </ButtonWrapper>

            <OptionWrapper>
                
                
                {req.map(x => 
                    <SelectionLanche key = ''
                        imagem  =  ''
                        title   =  ''
                        peso    =  ''
                        sabor   =  ''
                        preco   =  ''
                    />
                )}
                

            </OptionWrapper>

            <ButtonWrapper>

                <Button 
                    as = {Link}
                    to = '/sessaofilme'
                    children = 'Compra Ingreeso'
                />

                
                <Button 
                    as = {Link}
                    to = '/escolha-pagamento'
                    children = 'Pagamento'
                />

            </ButtonWrapper>
            
            
        </PagesDefault>      
    );
}