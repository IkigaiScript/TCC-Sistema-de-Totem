import axios from 'axios'

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
   
});

export class PedidoSnackBar {
    
    async registerSnackOrder(reqs){
        const response = await api.post(`Pedidos/SnackBars`,reqs);
        return response.data;
    }

    async history(id){
        const response = await api.get(`Pedidos/SnackBars/History/${id}`);
        return response.data;
    }

    async deletar(pedido,snackbar){
        const response = await api.delete(`Pedidos/SnackBars?pedido${pedido}&snackbar=${snackbar}`);
        return response.data;
    }
}