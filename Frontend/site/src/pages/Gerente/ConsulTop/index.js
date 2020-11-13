import React,{ useState, useEffect } from 'react'
import Relogio from '../../../components/Relogio';
import Button from '../../../components/Buttons';
import {PageDefault, ClassificarWrapper, TopWrapper} from './style';
import { ToastContainer,toast } from 'react-toastify';
import { Gerente } from '../../../services/GerenteApi';
import Chart from "react-google-charts";
const api = new Gerente();

"use strict"

export default function ConsulTop (){
    
    async function consultTopFilmes(){
        try{
            const response = await api.TopFilmes();
            return response;
        }
        catch(e){
            toast.error(e.response.data)
        }
    }

    async function consultTopProdutos(){
        try{
            const response = api.TopProdutos();
            return response;
        }
        catch(e){
            toast.error(e.response.data);
        }
    }

    useEffect(() => {
        consultTopFilmes();
        consultTopProdutos();
    },[]);
    
    return(
        <PageDefault>
            <ToastContainer/>
            <h1>Classificação dos Top 10</h1>
            
            <ClassificarWrapper>

                <TopWrapper>

                    <Button 
                        children = 'Top 10 mais Vendidas'
                    />

                </TopWrapper>

                <TopWrapper>

                    <Button 
                        children = 'Top 10 mais Vendidas'
                    />

                    <div style={{ display: 'flex', maxWidth: 900 }}>
                        
                        <Chart
                            width={400}
                            height={300}
                            chartType="ColumnChart"
                            loader={<div>Loading Chart</div>}
                            data={[
                            ['City', '2010 Population', '2000 Population'],
                            ['New York City, NY', 8175000, 8008000],
                            ['Los Angeles, CA', 3792000, 3694000],
                            ['Chicago, IL', 2695000, 2896000],
                            ['Houston, TX', 2099000, 1953000],
                            ['Philadelphia, PA', 1526000, 1517000],
                            ]}
                            options={{
                            title: 'Population of Largest U.S. Cities',
                            chartArea: { width: '30%' },
                            hAxis: {
                                title: 'Total Population',
                                minValue: 0,
                            },
                            vAxis: {
                                title: 'City',
                            },
                            }}
                            legendToggle
                        />

                    </div>

                </TopWrapper>

            </ClassificarWrapper>



            <div style = {{visibility: 'hidden'}}>
                <Relogio />
            </div>


        </PageDefault>
    );
}