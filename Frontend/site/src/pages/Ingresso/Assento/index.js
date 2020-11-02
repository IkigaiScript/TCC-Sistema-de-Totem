import React from 'react';
import { PageDefault, SalaWrapper, Assento, Select  } from './style';
import Button from '../../../components/Buttons';
import Relogio from '../../../components/Relogio'
import CircleLoader from "react-spinners/CircleLoader";

export default function Lugar(){

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
                
                <CircleLoader size = '50vh' color = 'red' margin = '30px'/>

                <span>Desculpe mas essa parte ainda não esta concluida</span>

            </Assento>
            
            <SalaWrapper>

                <Button 
                    to = '/sessaofilme'
                    children = 'Voltar'
                />

                <Relogio />

                <Button 
                    to = '/compra/ingresso'
                    children = 'Proximo'
                />

            </SalaWrapper>

        </PageDefault>
    );
    
}