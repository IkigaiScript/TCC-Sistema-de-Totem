import React,{ useState, useEffect } from 'react'
import { Link } from 'react-router-dom';
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import { PageDefault, ClassificarWrapper, TopWrapper, RankingWrapper, Posicao ,Primeiro, Segundo, Terceiro } from './style';
import { ToastContainer,toast } from 'react-toastify';
import { Gerente } from '../../../services/GerenteApi';
import { Chart } from 'react-google-charts'
import 'bootstrap/dist/css/bootstrap.min.css';
// import Ouro from '../../../assets/Img/Ouro.png';
// import Prate from '../../../assets/Img/Prate.png';
// import Bronze from '../../../assets/Img/Bronze.png';
// import { GiConsoleController } from 'react-icons/gi';

const gerente = new Gerente();

export default function ConsulTop (){
    
    const [primeiroFilme,setPrimeiroFilme] = useState();
    const [segundoFilme,setSegundoFilme] = useState();
    const [terceiroFilme,setTerceiroFilme] = useState();
    const [primeiroProduto,setPrimeiroProduto] = useState();
    const [segundoProduto,setSegundoProduto] = useState();
    const [terceiroProduto,setTerceiroProduto] = useState();
 
    let topFilmes = [];
    let topProdutos = [];

    async function consultTopFilmes(){
        try{
            const response = await gerente.topFilmes();
            console.log([...response]);

            topFilmes =  [...response];
            setPrimeiroFilme(response[1]);
            setSegundoFilme(response[0]);
            setTerceiroFilme(response[2]);

            for(let i = 0; i < topFilmes.length; i++){
                topFilmes[i].Posicao = i;
            }

            topFilmes = topFilmes.map(x => [x.nome,x.qtd]);
            console.log(...topFilmes);
            console.log(primeiroFilme);
            console.log(segundoFilme);
            console.log(terceiroFilme);
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
            const response = await gerente.topProdutos();

            topProdutos = [...response]
            setPrimeiroProduto(response[1]);
            setSegundoProduto(response[0]);
            setTerceiroProduto(response[2]);

            for(let i = 0; i < topProdutos.length; i++){
                topProdutos[i].posicao = i;
                console.log(topProdutos[i]);
            }

            topProdutos = topProdutos.map(x => [x.nome,x.qtd]);
            console.log(typeof topProdutos[0][0]);
            console.log(typeof topProdutos[0][1]);
            console.log(primeiroProduto);
            console.log(segundoProduto);
            console.log(terceiroProduto);

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
    
    useEffect(() => {
        consultTopFilmes();
        consultTopProdutos();
    },[])

    return(
        <PageDefault>
            
            <ToastContainer/>
            <h1>Classificação dos Top 10</h1>
            
            <Button 
                as = { Link }
                to = '/Gerenciar'
                children = 'Voltar'
            />

            <ClassificarWrapper>

                <TopWrapper>
{/* 
                    <Button 
                        onClick = {consultTopProdutos}
                        children = 'Top 10 mais Vendidas'
                    /> */}
                    <Chart
                        width={'500px'}
                        height={'300px'}
                        chartType="BarChart"
                        loader={<div>Loading Chart</div>}
                        data={[
                            ['Filme', 'Position'],
                            ...topFilmes
                        ]}
                        options={{
                                title: 'Population of Largest U.S. Cities',
                                chartArea: { width: '50%' },
                                hAxis: {
                                title: 'Top 15 filmes mais vendidos',
                                minValue: 0,
                            },
                            vAxis: {
                                title: 'City',
                            },
                        }}
                        // For tests
                        rootProps={{ 'data-testid': '1' }}
                    />

                    {/* <RankingWrapper>                        

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

                        </RankingWrapper> */}

                    
                    {/* {produtos.map(x =>

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
                    )} */}

                </TopWrapper>

                <TopWrapper>

                    <Button 
                        onClick = {consultTopFilmes}
                        children = 'Top 15  filmes mais Vendidas'
                    />

                    <Chart
                        width={'500px'}
                        height={'300px'}
                        chartType="BarChart"
                        loader={<div>Loading Chart</div>}
                        data={[
                            ['Produtos', 'Quantidade'],
                            ...topProdutos
                        ]}
                        options={{
                                title: 'Population of Largest U.S. Cities',
                                chartArea: { width: '50%' },
                                hAxis: {
                                title: 'Total Population',
                                minValue: 0,
                            },
                            vAxis: {
                                title: 'City',
                            },
                        }}
                        // For tests
                        rootProps={{ 'data-testid': '1' }}
                    />

                    {/* {filmees.map(x =>
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
                    )} */}

                </TopWrapper>

            </ClassificarWrapper>

            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>
        </PageDefault>
    );
}