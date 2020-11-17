import axios from 'axios'

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
});

export class PedidoSnackBar {
    
    async registerSnackOrder(reqs){
        const response = await api.post(`Pedidos/SnackBars`,reqs)
        return response.data;
    }
}