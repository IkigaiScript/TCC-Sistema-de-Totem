import axios from 'axios';

const api = axios.create({
    // baseURL:'http://54.89.253.106:5000/'
    baseURL:'http://localhost:5000/'
});

export class PedidoCombo {
    
    async registerComboOrden(reqs){
        const response = await api.post(`Pedidos/Combos/`,reqs)
        return response.data;
    }
}