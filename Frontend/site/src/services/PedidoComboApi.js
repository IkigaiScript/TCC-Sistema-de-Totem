import axios from 'axios';

const api = axios.create({
    baseURL:'http://54.208.155.192:5000/'
});

export default class PedidoCombo {
    
    async RegisterComboOrden(reqs){
        const response = await api.post(`Pedidos/Combos/`,reqs)
        return response.data;
    }

}