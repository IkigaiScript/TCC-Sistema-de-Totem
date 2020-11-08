import axios from 'axios'

const api = axios.create({
    baseURL:'http://54.208.155.192:5000/'
});

export default class PedidoSnackBar {
    
    async RegisterSnackOrder(reqs){
        const response = await api.post(`Pedidos/SnackBars`,reqs)
        return response.data;
    }

}