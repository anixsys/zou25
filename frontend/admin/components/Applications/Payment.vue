<template>
    <div>
      <v-btn rounded outlined depressed color="success" class="ml-2" @click="getData"><v-icon>mdi-printer-pos-plus</v-icon> Receipt</v-btn>
      <v-dialog v-model="AddModel" width="900px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New Payment
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-row >
              <v-col> <v-select
                label="Payment Method"
                placeholder="Method"
                v-model="form.paymentmethod"
                outlined
                :items="['ECOCASH','NETONE','TELECASH','CASH','SWIPE']"
                :rules="[rules.required]"
              ></v-select></v-col>
              <v-col>
                <v-select
                label="Select Currency"
                v-model="form.CurrencyId"
                outlined
                :items="currencylist"
                item-value="id"
                item-text="name"
                :rules="[rules.required]"
              ></v-select>
              </v-col>
              <v-col>                
              <v-text-field
              label="Phone number"
              placeholder="Phone number"
              v-model="form.phonenumber"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
          </v-col>
          <v-col v-if="form.paymentmethod =='CASH' || form.paymentmethod =='SWIPE'">
            <v-text-field          
           
              label="Receipt Number"
              placeholder="receiptnumber"
              v-model="form.receiptnumber"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
              </v-col>
              <v-col>
                <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="Submit" :loading="loading"
                  >Submit</v-btn>
              </v-col>
            </v-row>
           <v-row class="mt-2">
            <v-col>
              <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr><th>Date</th><th>Method</th><th>Amount</th><th>Status</th><th></th></tr>
                  </thead>
                  <tbody>
                    <template v-if="payments.length>0">
                      <tr v-for="payment in payments" :key="payment.id">
                        <td>{{ payment.dateCreated |formatDate }}</td>
                        <td>{{ payment.paymentmethod }}</td>
                        <td>{{ payment.currency }} {{ payment.amount }}</td>
                        <td>{{ payment.status }}</td>
                        <td>
                           <v-btn v-if="payment.status !='PAID'" rounded color="primary"  @click="checkPayment(payment)" :loading="loading">Check Payment</v-btn>
                        </td>
                      </tr>
                    </template>
                    <template v-else>
                      <tr><td colspan="5" class="text-center red--text">No payment attempts</td></tr>
                    </template>
                  </tbody>
                </template>
              </v-simple-table>
            </v-col>
           </v-row>  
              

          </v-card-text>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:['application'],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            paymentmethod:"",
            CurrencyId:"",
            phonenumber:"",
            applicationId:this.application.id,
            receiptnumber:''
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async getData(){
      await this.$store.dispatch("currency/getData"); 
      await this.$store.dispatch("applicationpayment/getData",this.application.id);
      this.AddModel = true 
    },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("applicationpayment/addItem",this.form); 
         
          this.loading = false
      }
    },
    async checkPayment(payment){
      this.loading = true
          await this.$store.dispatch("applicationpayment/updateItem",payment);          
          this.loading = false
    }
      },
      computed:{
        payments(){
          return this.$store.state.applicationpayment.records;
        },
        currencylist(){
          return this.$store.state.currency.records
        }
      }
   }
  </script>