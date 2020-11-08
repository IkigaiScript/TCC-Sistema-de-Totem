import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.174.164.124:5000'
});

export default class SnackBar {
    
    async ConsultFoto(nome){

        const response = await api.get('/SnackBars/Fotos/${nome}')
        return response;
    }

    async Produto(){

        const response = await api.get('/SnackBars/')
        return response;
    }

}