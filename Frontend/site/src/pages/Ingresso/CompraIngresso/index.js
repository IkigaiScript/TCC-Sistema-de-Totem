import React from 'react'
import { Wrapper, FilmeWrapper, TitleWrapper, TitleFilmeWrapper, ImgWrapper, RelogioWrapper,
         InputWrapper, InputSecondWrapper, InputOne, InputTwo, NomeWrapper, UltDiv} from './style';
import Relogio from '../../../components/Relogio/';
import Button from '../../../components/Buttons/';
import { BiReset } from "react-icons/bi";

export default function CompraIngresso (){
    return (
        <Wrapper>
            <TitleWrapper>
                <h1>Ingresso</h1>

                <RelogioWrapper>
                    <Relogio />
                </RelogioWrapper>
            </TitleWrapper>

            <FilmeWrapper>
                <ImgWrapper>
                    <img src="" alt="" height = '80px' width = '120px' />
                </ImgWrapper>

                <TitleFilmeWrapper>
                    <h2>Nome do Filme</h2>
                </TitleFilmeWrapper>
            </FilmeWrapper>

            <InputWrapper>
                <h2>Assentos</h2>
                <input type="text" size="28"  />
            </InputWrapper>

            <InputSecondWrapper>
                <InputOne>
                    <h3>Sala</h3>
                    <input type="text" size="15"  />
                </InputOne>

                <InputTwo>
                    <h3>Sessão</h3>
                    <input type="text" size="15"  />
                </InputTwo>
            </InputSecondWrapper>


            <InputSecondWrapper>
                <InputOne>
                    <h4>Inteira R$ 00,00</h4>
                    <input type="number" min="1" max="5" />
                </InputOne>
                
                <InputTwo>
                    <h4>Meia-Entrada R$ 00,00</h4>
                    <input type="number" min="1" max="5" />
                </InputTwo>
            </InputSecondWrapper>

            <NomeWrapper>
                <h4>Qual seu nome?</h4>
                <input type="text" size="30" />
            </NomeWrapper>

            <UltDiv>
                    <Button 
                        to = '/' children = "Comprar ingresso" />
                <a href="" alt="Desfazer"><BiReset/>  Desfazer </a>
                    <Button 
                        to = '/' children = "Pagamento" />
            </UltDiv>
        </Wrapper>
    );
}