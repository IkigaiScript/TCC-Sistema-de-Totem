import axios from 'axios';

const api = axios.create({
 baseURL:'http://54.89.253.106:5000/'
   
});

export class SnackBar {

    async consultProduto(tipoProduto){
        console.log(tipoProduto);
        const response = await api.get(`SnackBars?tipoProduto=${tipoProduto}`)
        return response.data;
    }
}