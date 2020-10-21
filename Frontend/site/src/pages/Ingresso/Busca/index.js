import React from 'react';
import { Wrapper, SearchWrapper, Input, SelectionWrapper } from './style';
import Relogio from '../../../components/Relogio/';
import SelectionFilme from '../../../components/SelectionFilme/';
import SelectFilme from '../../../components/SelectionFilme/';
export default function Busca (){
    return (
        <Wrapper>
            <h1>Filmes em Cartaz</h1>  

            <SearchWrapper>
                    <Input type="text" size="45" placeholder="Pesquisar filme" />
                    <Relogio />   
            </SearchWrapper>

            <SelectionWrapper>
                <div>
                    <select>
                        <option>Livre</option>
                        <option>12</option>
                        <option>14</option>
                        <option>16</option>
                        <option>18</option>
                    </select>
                </div>

                <div>
                    <select>
                        <option>Comédia</option>
                        <option>Romance</option>
                        <option>Ação</option>
                        <option>Suspense</option>
                        <option>Terror</option>
                    </select>
                </div>

                <div>
                    <select>
                        <option>3D</option>
                    </select>
                </div>
            </SelectionWrapper>

            <SelectFilme />
            <SelectFilme />
            <SelectFilme />
            <SelectFilme />
            
        </Wrapper>
    );
}