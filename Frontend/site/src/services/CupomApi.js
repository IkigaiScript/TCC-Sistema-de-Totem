import axios from 'axios';

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
});

export default class Cupom {
    async consult(Codigo, Pedido){
        const response = await api.get(`Cupons/codigo=${Codigo}&pedido=${Pedido}`);
        return response;
    }
}