<template>
     <v-card v-if="payment.application && payment.application.payments.length>0">
                <v-app-bar>
                  <v-toolbar-title>Payment Attempts</v-toolbar-title>
                </v-app-bar>
                <v-card-text>
                  <v-simple-table>
                    <template v-slot:default>
                      <thead>
                        <tr>
                          <td>Date Created</td>
                          <td>Amount</td>
                          <td>Status</td>
                          <td>Action</td>
                        </tr>
                      </thead>
                      <tbody>
                        <tr v-for="attempt in payment.application.payments">
                          <td>{{ attempt.dateCreated }}</td>
                          <td>{{ attempt.currency.name }}{{ attempt.amount }}</td>
                          <td>{{ attempt.status }}</td>
                          <td></td>
                        </tr>
                      </tbody>
                    </template>
                  </v-simple-table>
                </v-card-text>
              </v-card>
</template>
<script>
 export default{
    props:["payment"]
 }
</script>