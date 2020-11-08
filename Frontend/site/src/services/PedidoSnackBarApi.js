import axios from 'axios'

const api = axios.create({
    baseURL:'http://54.174.164.124:5000'
});

export default class PedidoSnackBar {
    
    async RegisterSnackOrder(req){

        const response = await api.post('/Pedidos/SnackBars/${req}')
        return response;

    }

}