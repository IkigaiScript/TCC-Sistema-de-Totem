import axios from 'axios';

const api = axios.create({
    //baseURL:'http://54.208.155.192:5000/'
    baseURL:'http://localhost:5000/'
});

export default class Filme {
    
    async consultParcial(nome){
        const response = await api.get(`Filmes/Seach/${nome}`);
        return response.data;
    }

    async consult(){
        const response = await api.get(`Filmes/Seach`);
        return response.data;
    }

    // combo
    // ingresso    
}