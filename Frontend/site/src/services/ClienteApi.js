import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    
});

export class Cliente {

    async consultCliente(id){
        const response = await api.get(`Clientes/${id}`);
        return response.data;
    }
}