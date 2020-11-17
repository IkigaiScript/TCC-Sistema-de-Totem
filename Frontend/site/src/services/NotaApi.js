import axios from 'axios';

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
});

export class Nota {

    async cadastrar(req){
        const response = await api.post(`Notas`,req);
        return response.data;
    }

    async sendEmail(pedido){
        const response = await api.post(`Notas/Email/${pedido}`);
        console.log(response);
    }
}