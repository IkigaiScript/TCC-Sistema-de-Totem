import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
   
});

export class Cartao {

    async cadastrar(req){
        const response = api.post(`Cartoes`,req);
        return response.data;
    }
}