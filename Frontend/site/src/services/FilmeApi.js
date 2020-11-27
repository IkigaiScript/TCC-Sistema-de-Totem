import axios from 'axios';

const api = axios.create({
     baseURL:'http://54.89.253.106:5000/'
    
});

export class Filme {
    
    async consultParcial(nome){
        const response = await api.get(`Filmes/Seach/${nome}`);
        return response.data;
    }

    async consultFilmes(){
        const response = await api.get(`Filmes`);
        console.log("Consultar");
        return response.data;
    }   

    async consultUni(id){
        const response = await api.get(`Filmes/${id}`);
        return response.data;
    }

    async consultFilter(sala,genero,classificacao){
        const response = await api.get(`Filmes/Seach?classificacao=${classificacao}&sala=${sala}&genero=${genero}`);
        return response.data;
    }
}