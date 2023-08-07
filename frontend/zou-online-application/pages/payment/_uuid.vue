<template>
    <div>
      <v-stepper alt-labels flat>
      <v-stepper-header>
        <v-stepper-step step="1"  complete>
        <small> Select Programme Type</small>
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="2">
          <small> Make Payment</small>
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="3">
          <small>Programme Selection</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="4">
          <small>Academic Qualifications</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="5">
          <small> Attach Documents</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="6">
          <small>Confirm Application</small>
        </v-stepper-step>
      </v-stepper-header>
    </v-stepper>
      
     
      <v-container>
        <v-row justify="center" align="center" class="mt-5">
        <v-col md="5">
               <template v-if="payment">
                
              <v-card>
                  <v-card-title dark class="primary white--text">
                      Application Fees
                  </v-card-title>
                  <v-divider/>
                  <v-card-text>
                      <v-simple-table>
                          <template v-slot:default>
                               <thead>
                                <tr>
                                  <th>Cost</th>
                                  <th class="text-right"> Action</th>
                                </tr>
                               </thead>
                              <tbody>
                                <tr v-for="fee in payment.fees" :key="fee.id">
                                  <td>{{ fee.currency.name }} {{ fee.amount }}</td>
                                  <td class="text-right"> <v-btn small rounded color="primary" depressed @click="initiatePayment(fee.id)">Make Payment</v-btn></td>
                                </tr>
                              </tbody>
                          </template>
                      </v-simple-table>
                  </v-card-text>
                
              </v-card>

             <PaymentAttempt :payment="payment"/>
              <div class="text-center mt-5">

                <div class="d-flex justify-center">                     
                     <img src="/icon/paynow.png"/>
                </div>
              </div>
            
            </template>
            
          </v-col>
      </v-row>
      </v-container>
         
      <v-overlay :value="overlay">
        <v-progress-circular
          indeterminate
          size="64"
        ></v-progress-circular>
      </v-overlay>
    </div>
  </template>
  <script>
   export default{
      async mounted() {
      this.overlay = true;
      this.uuid = this.$route.params.uuid
      await this.$store.dispatch("payment/getData",this.$route.params.uuid);
      //await this.$store.dispatch("settings/getData");

      this.overlay = false;
    },data(){
      return{
          overlay:false,
          uuid:"",
          currencyId:""
      }
    },
    methods:{
     async initiatePayment(id){
      this.overlay = true
      var payload = {AdmissionFeeId:id,applicationId:this.payment.application.id,uuid:this.$route.params.uuid}
      await this.$store.dispatch("payment/InitiatePayment",payload);
      this.overlay = false;  
     }
    },
      computed:{
     payment() {
        return this.$store.state.payment.record;
      },
      settings() {
      return this.$store.state.settings.records;
    },

    }
   }
  </script>