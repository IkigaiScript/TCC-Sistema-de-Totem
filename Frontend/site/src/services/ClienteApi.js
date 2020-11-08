import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.174.164.124:5000/'
});

export default class Cliente {
    async consult(id){
        const response = await api.get(`Clientes/${id}`)
        return response;
    }
}