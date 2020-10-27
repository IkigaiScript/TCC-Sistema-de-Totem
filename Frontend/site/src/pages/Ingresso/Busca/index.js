import React from 'react';
import { PageDefault, SearchWrapper, Input, SelectionWrapper, Select } from './style';
import Relogio from '../../../components/Relogio/';
import SelectFilme from '../../../components/SelectionFilme/';

export default function Busca (){
    return (
        <PageDefault>
            <h1>Filmes em Cartaz</h1>  

            <SearchWrapper>
                    <Input type="text" size="45" placeholder="Pesquisar filme" />
                    <Relogio />   
            </SearchWrapper>

            <SelectionWrapper>
                <div>
                    <Select>
                        <option>Livre</option>
                        <option>12</option>
                        <option>14</option>
                        <option>16</option>
                        <option>18</option>
                    </Select>
                </div>

                <div>
                    <Select>
                        <option>Comédia</option>
                        <option>Romance</option>
                        <option>Ação</option>
                        <option>Suspense</option>
                        <option>Terror</option>
                    </Select>
                </div>

                <div>
                    <Select>
                        <option>3D</option>
                    </Select>
                </div>
            </SelectionWrapper>

            <SelectFilme />
            <SelectFilme />
            <SelectFilme />
            <SelectFilme />
        </PageDefault>
    );
}
