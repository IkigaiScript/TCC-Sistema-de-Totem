import React, { useState } from 'react';
import {Link} from 'react-router-dom'
import { PageDefault, SearchWrapper, SelectionWrapper, Select, FilmesWrapper } from './style';
import Relogio from '../../../components/Relogio';
import SelectFilme from '../../../components/SelectionFilme';
import Input from '../../../components/Input';
import FilmeApi from '../../../services/FilmeApi';

const filme = new FilmeApi();

export default function Busca (){
    
    const [sala,setSala] = useState('');
    const [genero,setGenero] = useState('');
    const [classificacao,setClassificacao] = useState('');
    const [seach,setSeach] = useState('');
    const [con,setCon] = useState([]);

    async function consultParcial(){
        try{
            setCon([]);
            const resp = await filme.consultParcial(seach);
            setCon([...resp]);
        }catch(e){
            console.error(e);
        }
    }
    
    async function consultFilter(){
        try{
            setCon([]);
            const resp = await filme.consultFilter(sala,genero,classificacao);
            setCon([...resp]);
            return resp;
        }
        catch(e){
            console.log(e)
        }
    }

    return (

        <PageDefault>

            <h1>Filmes em Cartaz</h1>  

            <SearchWrapper>
                <Input  
                    type='search'
                    width='35vw' 
                    placeholder= 'Pesquisar filme'
                    value={seach} 
                    onChange={(e) => {
                        setSeach(e.target.value)
                        consultParcial()
                    }}
                />
                
                <Relogio />   
            </SearchWrapper>

            <SelectionWrapper>

                <Select>

                    <option value="0">Livre</option>
                    <option value="10">10</option>
                    <option value="12">12</option>
                    <option value="14">14</option>
                    <option value="16">16</option>
                    <option value="18">18</option>

                </Select>
    
                <Select>

                    <option value="comedia">Comédia</option>
                    <option value="romance">Romance</option>
                    <option value="acao">Ação</option>
                    <option value="suspense">Suspense</option>
                    <option value="terror">Terror</option>
                    <option value="animacao">Terror</option>
                    <option value="aventura">Terror</option>
                    <option value="documnetario">Terror</option>
                    <option value="fantasia">Fantasia</option>
                    <option value="faroeste">Terror</option>
                    <option value="ficcao cientifica">Terror</option>
                    <option value="musical">Terror</option>
                    <option value="romance">Terror</option>
                    <option value="suspense">Terror</option>

                </Select>
        
                <Select>

                    <option value="3d">3D</option>
                    <option value="xd">XD</option>

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
