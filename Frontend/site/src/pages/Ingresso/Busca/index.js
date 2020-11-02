import React from 'react';
import {Link} from 'react-router-dom'
import { PageDefault, SearchWrapper, Input, SelectionWrapper, Select, FilmesWrapper } from './style';
import Relogio from '../../../components/Relogio';
import SelectFilme from '../../../components/SelectionFilme';

export default function Busca (){
    return (
        <PageDefault>
            <h1>Filmes em Cartaz</h1>  

            <SearchWrapper>

                <Input type="text" size="45" placeholder="Pesquisar filme" />
                <Relogio />   

            </SearchWrapper>

            <SelectionWrapper>
            
                <Select>

                    <option>Livre</option>
                    <option>12</option>
                    <option>14</option>
                    <option>16</option>
                    <option>18</option>

                </Select>
            
    
                <Select>

                    <option>Comédia</option>
                    <option>Romance</option>
                    <option>Ação</option>
                    <option>Suspense</option>
                    <option>Terror</option>

                </Select>
            
        
                <Select>

                    <option>3D</option>

                </Select>
                
            </SelectionWrapper>

            <FilmesWrapper>
                
                <Link to = '/compra/assento'>
                    <SelectFilme />
                </Link>
                <Link to = '/compra/assento'>
                    <SelectFilme />
                </Link>
                
            </FilmesWrapper>

        </PageDefault>
    );
}
