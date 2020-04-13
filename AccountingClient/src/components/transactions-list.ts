import { Component, Vue } from 'vue-property-decorator';
import Transaction from '@/models/transaction';
import { transactionsService } from '@/services/transactions-service';
import TransactionComponent from './transaction.vue';

@Component({
    components: {
        "transaction": TransactionComponent,
    }
})
export default class TransactionsListComponent extends Vue {
    private transactions: Transaction[] = [];

    async mounted() {
        this.transactions = await transactionsService.GetTransactionsList();
    }
}