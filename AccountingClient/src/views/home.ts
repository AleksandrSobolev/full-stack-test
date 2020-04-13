import TransactionsListComponent from '@/components/transactions-list.vue'
import { Component, Vue } from 'vue-property-decorator';

@Component({
    components: {
        "transactions-list-component": TransactionsListComponent,
    }
})
export default class HomeComponent extends Vue {
}