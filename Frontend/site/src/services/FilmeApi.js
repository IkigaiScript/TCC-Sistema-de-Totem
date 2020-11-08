import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.208.155.192:5000/'
});

export default class Filme {
    async consultParcial(nome){
        const response = await api.get(`Filmes/Seach/${nome}`);
        return response.data;
    }

    async consult(){
        const response = await api.get(`Filmes`);
        return response.data;
    }

    async consultBreve(){
        const response = await api.get(`Filmes/Breve`);
        return response.data;
    }   

    async consultUNI(id){
        const response = await api.get(`Filmes/${id}`);
        return response.data;
    }

    async consultFilter(sala,genero,classificacao){
        const response = await api.get(`Filmes?classificacao=${classificacao}&sala=${sala}&genero=${genero}`);
        return response.data;
    }

    getPhoto(nome){
        const response = api.get(`Filmes/Foto/${nome}`);
        return response.data;
    }
}