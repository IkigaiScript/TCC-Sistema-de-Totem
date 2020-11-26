import axios from 'axios';

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
});

export class Ingresso {

    async consultPlaces(sessao){
        const response = await api.get(`Ingressos/${sessao}`);
        return response;
    } 

    async registerTicket(reqs){
        const response = await api.post(`Ingressos`,reqs);
        return response;
    }
}