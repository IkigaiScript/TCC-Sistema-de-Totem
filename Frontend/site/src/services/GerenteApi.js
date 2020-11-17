import axios from 'axios'

const api = axios.create({
    baseURL:'http://54.89.253.106:5000/'
    //baseURL:'http://localhost:5000/'
})

export class Gerente {
    async TopFilmes(){
        const response = await api.get(`Gerente/Top/Filmes`);
        return response.data
    }

    async VendasDoDia(dia){
        console.log(dia);
        const response = await api.get(`Gerente/Vendas/Dia/${dia}`,);
        return response.data;
    }

    async VendasdoMes(req){
        console.log(req);
        const response = await api.get(`Gerente/Vendas`,req);
        return response.data;
    }

    async TopProdutos(){
        const response = await api.get(`Gerente/Top/Produtos`);
        return response.data;
    }

    async TotemLogins(){
        const response = await api.get(`Gerente/Logins`);
        return response.data;
    }
}