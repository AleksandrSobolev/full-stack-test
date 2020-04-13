<template>
  <b-container>
    <b-row>
      <b-col>
        <div v-if="transactions && transactions.length > 0">
          <div role="tablist" v-for="(transaction, index) in transactions" :key="index">
            <b-card no-body class="mb-1">
              <b-card-header header-tag="header" class="p-0" role="tab">
                <b-button
                  block
                  href="#"
                  v-b-toggle="`${index}-transaction`"
                  :variant="transaction.type.toLowerCase() == 'credit' ? 'warning' : 'success'">
                  {{transaction.type}}: {{transaction.amount.toFixed(2)}}
                </b-button>
              </b-card-header>
              <b-collapse
                :id="`${index}-transaction`"
                accordion="transactions-list"
                role="tabpanel">
                <b-card-body>
                  <transaction :transaction="transaction" />
                </b-card-body>
              </b-collapse>
            </b-card>
          </div>
        </div>
        <div v-else>No Transactions for display
        </div>      
      </b-col>
    </b-row>
  </b-container>
</template>

<script src="./transactions-list.ts" />
