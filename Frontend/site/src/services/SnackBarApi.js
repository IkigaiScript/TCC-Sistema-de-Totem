import axios from 'axios';

const api = axios.create({
   //baseURL:'http://54.208.155.192:5000/'
   baseURL:'http://localhost:5000/'
});

export default class SnackBar {
    
    ConsultFoto(nome){
        const response = api.get(`SnackBars/Fotos/${nome}`)
        return response.data;
    }

    async Produto(tipoProduto){
        const response = await api.get(`SnackBars?tipoProduto=${tipoProduto}`)
        return response.data;
    }
}