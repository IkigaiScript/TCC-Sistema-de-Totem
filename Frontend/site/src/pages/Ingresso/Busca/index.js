import React, { useState } from 'react';
import { Link } from 'react-router-dom'
import { PageDefault, SearchWrapper, SelectionWrapper, Select, FilmesWrapper } from './style';
import Relogio from '../../../components/Relogio';
import SelectFilme from '../../../components/SelectionFilme';
import Input from '../../../components/Input';
import { Filme } from '../../../services/FilmeApi';

const filme = new Filme();

export default function Busca (){
    
    const [sala,setSala] = useState('');
    const [genero,setGenero] = useState('');
    const [classificacao,setClassificacao] = useState(0);
    const [seach,setSeach] = useState('');
    const [filmes,setFilmes] = useState([]);

    async function consultParcial(){
        try{
            setFilmes([]);
            const response = await filme.consultParcial(seach);
            console.log(response);
            setFilmes([...response]);
        }catch(e){
            console.error(e);
        }
    }
    
    async function consultFilter(){
        try{
            setFilmes([]);
            const response = await filme.consultFilter(sala,genero,classificacao);
            console.log(response);
            setFilmes([...response]);
            return response;
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
                        setSeach(e.target.value);
                        consultParcial();
                    }}
                />
                
                <Relogio />   
            </SearchWrapper>

            <SelectionWrapper>

                <Select onClick= {(e) => setClassificacao(e.target.value)}>
                    <option value={1}>Livre</option>
                    <option value={10}>10</option>
                    <option value={12}>12</option>
                    <option value={14}>14</option>
                    <option value={16}>16</option>
                    <option value={18}>18</option>
                </Select>
    
                <Select onClick= {(e) => setGenero(e.target.value)}>
                    <option value="comédia">Comédia</option>
                    <option value="ação">Ação</option>
                    <option value="suspense">Suspense</option>
                    <option value="terror">Terror</option>
                    <option value="animação">Animação</option>
                    <option value="aventura">Terror</option>
                    <option value="drama">Drama</option>
                    <option value="documentario">Documentario</option>
                    <option value="fantasia">Fantasia</option>
                    <option value="faroeste">Faroeste</option>
                    <option value="ficção científica">Ficção científica</option>
                    <option value="musical">Musical</option>
                    <option value="romance">Romance</option>
                </Select>
        
                <Select onClick= {(e) => setSala(e.target.value)}>
                    <option value="3d">3D</option>
                    <option value="xd">XD</option>
                </Select>

                <button
                    onClick= {consultFilter}
                >Consultar</button>
                
            </SelectionWrapper>

            <FilmesWrapper>

                {filmes.map(x => 
                    <Link to = {{
                        pathname:`/filme/${x.nome}`,
                        state:x.id
                    }}>
                        <SelectFilme 
                            name= {x.nome}
                            image= {x.imagem}
                        />
                    </Link>                    
                    )}
            </FilmesWrapper>

        </PageDefault>

    );
}
