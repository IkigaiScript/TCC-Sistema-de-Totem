import React from 'react'
import { Link } from 'react-router-dom';
import {Wrapper, WrapperSecondary, SelectWrapper, LancheWrapper, ButtonWrapper} from './style';
import SelectionLanche from '../../../components/SelectionLanche';
import Relogio from '../../../components/Relogio';
import Buttons from '../../../components/Buttons';
import Button from '../../../components/Buttons';

export default function Pipoca (){
    return (
        <Wrapper>
            <h1>Qual pipoca deseja?</h1>

        <WrapperSecondary>
            <Buttons to="/" children="Voltar" />
            <Relogio />

            <SelectWrapper>
                <select>
                    <option>Combo</option>
                    <option>Bebida</option>
                    <option>Doce</option>
                    <option selected disabled>Adicionar outros</option>
                </select>
            </SelectWrapper>
        </WrapperSecondary>

        <LancheWrapper>
            <SelectionLanche />
            <SelectionLanche />
        </LancheWrapper>

        <ButtonWrapper>
            <Button to="/" children="Comprar Ingresso" />
            <Button to="/" children="Pagamento" />
        </ButtonWrapper>
        </Wrapper>     
    );
}