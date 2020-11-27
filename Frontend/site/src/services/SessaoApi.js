import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    
});

export class Sessao {
 
    async consultSessao(id) {
        const resp = await api.get(`Sessao?id=${id}`)
        return resp.data;
    } 
}