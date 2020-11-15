import axios from 'axios';

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
});

export default class Cartao {
    async Cadastrar(req){
        const response = api.post(`Cartoes`,req);
        return response.data;
    }
}