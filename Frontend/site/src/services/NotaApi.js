import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.208.155.192:5000/'
});

export default class Nota {
    async cadastrar(req){
        const response = await api.post(`Notas`,req);
        return response.data;
    }

    async sendEmail(pedido){
        const response = await api.post(`Notas/Email/${pedido}`);
        console.log(response);
    }
}