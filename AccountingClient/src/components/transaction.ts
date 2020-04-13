import { Component, Prop, Vue } from 'vue-property-decorator';
import Transaction from '@/models/transaction';

@Component
export default class TransactionComponent extends Vue {
    @Prop() transaction!: Transaction;
}