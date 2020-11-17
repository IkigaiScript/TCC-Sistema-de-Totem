import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    // baseURL:'http://localhost:5000/'
});

export default class Ingresso {

    async ConsultPlaces(sessao){

        const response = await api.get(`Ingressos?sessao=${sessao}`);
        return response;

    } 

    async RegisterTicket(reqs){

        const response = await api.post(`Ingressos`,reqs);
        return response;

    }