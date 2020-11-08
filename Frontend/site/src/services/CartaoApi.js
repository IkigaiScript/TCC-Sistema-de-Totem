import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.208.155.192:5000/'
});

export default class Cartao {
    async Cadastrar(req){
        const response = api.post(`Cartoes`,req)
        return response.data
    }
}