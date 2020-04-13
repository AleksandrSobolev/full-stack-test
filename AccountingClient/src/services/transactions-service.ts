import Transaction from '@/models/transaction';
import Axios, { AxiosRequestConfig, AxiosInstance } from 'axios';

class TransactionsService {
    private httpClient: AxiosInstance;    
    private BASE_URL = "http://localhost:5000"

    constructor() {
        this.httpClient = Axios.create();
    }

    async GetTransactionsList(): Promise<Transaction[]> {
        const config: AxiosRequestConfig = {
            baseURL: this.BASE_URL,
            url: '/api/transactions',
            method: "GET",
            headers: { "Content-Type": "application/json" }
        };

        const response = await this.httpClient.request<Transaction[]>(config);

        return response.data.map(Transaction.parseJson);
    }
}

export const transactionsService = new TransactionsService();