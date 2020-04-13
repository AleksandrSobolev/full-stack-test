<template>
  <b-container class="text-align-left">
    <b-row class="text-align-left">
      <b-col>ID:</b-col>
      <b-col>{{transaction.id}}</b-col>
    </b-row>
    <b-row>
      <b-col>Type:</b-col>
      <b-col>{{transaction.type}}</b-col>
    </b-row>
    <b-row>
      <b-col>Amount:</b-col>
      <b-col>{{transaction.amount.toFixed(2)}}$</b-col>
    </b-row>
    <b-row>
      <b-col>Effective Date:</b-col>
      <b-col>{{transaction.effectiveDate.toLocaleString()}}</b-col>
    </b-row>
  </b-container>
</template>

<script src="./transaction.ts" />
<style src="./transaction.scss" lang="scss" />
