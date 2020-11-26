import React, {useState,useEffect} from 'react';
import { PageDefault, SalaWrapper, Assento, Select, Fileira, Cadeira } from './style';
import Button from '../../../components/Buttons';
import Relogio from '../../../components/Relogio';
import {Link} from 'react-router-dom';
import {MdEventSeat} from 'react-icons/md';


export default function Lugar(){   

    const [toogle, setToogle] = React.useState(true);
    const [cor, setCor] = React.useState('#c3c3c3');

    function Click(){
        setCor((state) => toogle ? '#c3c3c3': '#446677');

        return  setToogle(state => !state);
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

                <Select>
                    <option value = '0'>Escolha uma sala</option>
                    <option value = '1'>Sala 12-3D</option>
                    <option value = '2'>Sala 09-XD</option>
                    <option value = '1'>Sala 01</option>
                </Select>

                <Select>
                    <option value = '0'>Escolha um horario da sessão</option>
                    <option value = '1'>12:00</option>
                    <option value = '1'>08:30</option>
                    <option value = '1'>09:25</option>
                </Select>

            </SalaWrapper>

            <Assento>

                <Fileira>

                    {fileira01.map(valor => {

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
                                    <button id = {valor.assento}>{valor.assento}</button> 

                                </Cadeira>
                                
                            )
                        }
                    })} 

                </Fileira>

                <Fileira>

                    {fileira02.map(valor => {

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
                                    <button id = {valor.assento}>{valor.assento}</button> 

                                </Cadeira>
                                
                            )
                        }
                    })} 

                </Fileira>

                <Fileira>

                    {fileira03.map(valor => {

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
                                    <button id = {valor.assento}>{valor.assento}</button> 

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
                                    <button id = {valor.assento}>{valor.assento}</button> 

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
                                    <button id = {valor.assento}>{valor.assento}</button> 

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
                                    <button id = {valor.assento}>{valor.assento}</button> 

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
                                    <button id = {valor.assento}>{valor.assento}</button> 

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

           

        </PageDefault>
    );
    
}