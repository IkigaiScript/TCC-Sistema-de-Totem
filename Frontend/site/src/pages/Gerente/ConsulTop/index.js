import React,{ useState, useEffect } from 'react'
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import {PageDefault, ClassificarWrapper, TopWrapper, RankingWrapper, Posicao ,Primeiro, Segundo, Terceiro} from './style';
import { ToastContainer,toast } from 'react-toastify';
import { Gerente } from '../../../services/GerenteApi';
import Table from 'react-bootstrap/Table';
import { Chart } from 'react-google-charts'
import 'bootstrap/dist/css/bootstrap.min.css';
import Ouro from '../../../assets/Img/Ouro.png';
import Prate from '../../../assets/Img/Prate.png';
import Bronze from '../../../assets/Img/Bronze.png';

const api = new Gerente();

export default function ConsulTop (){
    
    const [filmees,setFilmees] = useState([]);
    const [produtos,setProdutos] = useState([]);
    const [topFilmes,setTopFilmes] = useState([]);
    const [topPrdotutos,setTopProdutos] = useState([]);

    async function consultTopFilmes(){
        try{
            const response = await api.TopFilmes();
            setTopFilmes([...response])
            
            for(let i=4; i < topFilmes.length; i++){
                const filme = topFilmes[i].Posicao = i;
                console.log(filme);
                setFilmees(filmees.push(filme));
            }
            
            return response;
        }
        catch(e){
            if(e.response.data.error){
              console.log(e.response.data);
              toast.error(e.response.data.error);
            }
            else {
              console.log(e.response.data);
              toast.error("Algo deu errado!");
            }
          }
    }

    async function consultTopProdutos(){
        try{
            const response = api.TopProdutos();
            setTopProdutos([...response])
            
            for(let i = 4; i < topPrdotutos.length; i++){
                const prodo = topPrdotutos[i].Posicao = i;
                console.log(prodo);
                setProdutos(produtos.push(prodo));
            }

            return response;
        }
        catch(e){
            if(e.response.data.error){
              console.log(e.response.data);
              toast.error(e.response.data.error);
            }
            else {
              console.log(e.response.data);
              toast.error("Algo deu errado!");
            }
          }
    }
    
    return(
        <PageDefault>
            
            <ToastContainer/>
            <h1>Classificação dos Top 10</h1>
            
            <Button 
                to = '/Gerenciar'
                children = 'Voltar'
            />

            <ClassificarWrapper>

                <TopWrapper>

                    <Button 
                        onClick = {consultTopProdutos}
                        children = 'Top 10 mais Vendidas'
                    />

                        

                    <RankingWrapper>
                        
                            <Posicao>

                                <span>Nome</span>

                                <Segundo>

                                    <img src = {Prate} alt = ''  height = '100px'/>

                                    <span>Valor und: 10.90</span>
                                    <span>Total: 55000</span>

                                </Segundo>

                            </Posicao>

                            <Posicao>

                            

                                <span>Nome</span>

                                <Primeiro>

                                <img src = {Ouro} alt = '' height = '120px'/>

                                    <span>Valor und:10.90</span>
                                    <span>Total:60000 </span>

                                </Primeiro>

                            </Posicao>

                            <Posicao>

                                <span>Nome</span>

                                <Terceiro>

                                    <img src = {Bronze} alt = '' height = '100px'/>

                                    <span>Valor und:10.90</span>
                                    <span>Total:50000 </span>

                                </Terceiro>

                            </Posicao>

                        </RankingWrapper>

                    
                    {produtos.map(x =>

                        <Table striped bordered hover>

                            <thead>

                                <tr>

                                    <th>Posição</th>
                                    <th>Item</th>
                                    <th>Tipo</th>
                                    <th>valor un</th>
                                    <th>Quantidade</th>
                                    <th>Total</th>
                                    <th>Imagem </th>

                                </tr>

                            </thead>

                            <tbody>

                                <tr>

                                    <td>{x.Posicao}</td>
                                    <td >{x.Nome}</td>
                                    <td>{x.Tipo}</td>
                                    <td>{x.Valor}</td>
                                    <td>{x.Qtd}</td>
                                    <td>{x.Total}</td>
                                    <td>{x.Imagem} </td>
                                
                                </tr>   

                            </tbody>

                        </Table>    
                    )}

                </TopWrapper>

                <TopWrapper>

                    <Button 
                        onClick = {consultTopFilmes}
                        children = 'Top 15  filmes mais Vendidas'
                    />

                    
                    {filmees.map(x =>
                        <>
                            <RankingWrapper>
                            
                                <Posicao>

                                    <img src = {x.imagem} alt = '' height= '100px' />
                                    <span>{x.Filmes}</span>

                                    <Segundo>

                                        <img src = {Prate} alt = ''  height = '100px'/>
                                        <span>Genero: {x.Genero}</span>
                                        <span>Quantidade: {x.Qtd}</span>

                                    </Segundo>

                                </Posicao>

                                <Posicao>

                                    <img src = {x.imagem} alt = '' height= '100px' />
                                    <span>{x.Filmes}</span>

                                    <Primeiro>

                                        <img src = {Ouro} alt = '' height = '120px'/>
                                        <span>Genero: {x.Genero}</span>
                                        <span>Quantidade: {x.Qtd}</span>

                                    </Primeiro>

                                </Posicao>

                                <Posicao>

                                    <img src = {x.imagem} alt = '' height= '100px' />
                                    <span>{x.Filmes}</span>

                                    <Terceiro>

                                        <img src = {Bronze} alt = '' height = '100px'/> 
                                        <span>Genero</span>
                                        <span>Quantidade</span>

                                    </Terceiro>

                                </Posicao>
                            </RankingWrapper>
                    
                            <Table striped bordered hover>
                                <thead>
                                    <tr>

                                        <th>Posição</th>
                                        <th>Filme</th>
                                        <th>Genero</th>
                                        <th>Quantidade</th>
                                        <th>Imagem</th>

                                    </tr>
                                </thead>
                                <tbody>

                                    <tr>
                                        <td>{x.Id}</td>
                                        <td>{x.Nome}</td>
                                        <td>{x.Genero}</td>
                                        <td>{x.Qtd}</td>
                                        <td>{x.Imagem} </td>
                                    </tr>   

                                </tbody>
                            </Table>
                        </>
                    )}

                </TopWrapper>

            </ClassificarWrapper>

            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>
        </PageDefault>
    );
}