import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.174.164.124:5000'
});

export default class Cupom {
    async consult(codigo, pedido){
        const resp = await api.get('/Cupons/${codigo},${Pedido}')
        return resp;
    }
}