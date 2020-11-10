import React, { useState } from 'react';
import {Link} from 'react-router-dom'
import { PageDefault, SearchWrapper, Input, SelectionWrapper, Select, FilmesWrapper } from './style';
import Relogio from '../../../components/Relogio';
import SelectFilme from '../../../components/SelectionFilme';
import FilmeApi from '../../../services/FilmeApi'

const filme = new FilmeApi();

export default function Busca (){
    
    const [sala,setSala] = useState('');
    const [genero,setGenero] = useState('');
    const [classificacao,setClassificacao] = useState('');
    const [seach,setSeach] = useState('');
    const [con,setCon] = useState([]);

    async function consultParcial(){
        try{
            const resp = await filme.consultParcial(seach);
            setCon([...resp])
        }catch(e){
            console.error(e);
        }
    }

    return (
        <PageDefault>
            <h1>Filmes em Cartaz</h1>  

            <SearchWrapper>
                <Input  type="text" 
                        size="45" 
                        placeholder="Pesquisar filme" 
                        value={seach} 
                        onChange={(e) => {
                            setSeach(e.target.value)
                            consultParcial()
                        }}/>
                
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
                    <option>XD</option>
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
