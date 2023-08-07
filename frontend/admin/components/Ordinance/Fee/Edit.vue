<template>
    <div>
      <v-btn depressed text color="primary" @click="AddModel=true"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Fee
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-autocomplete
            v-model="form.CurrencyId"
            :items="currencies"
            item-value="id"
            item-text="name"
            outlined
            label="Select Currency"           
          ></v-autocomplete>
          <v-text-field
              label="Cost"
              placeholder="Cost"
              v-model="form.Cost"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80" @click="AddModel=false">Cancel</v-btn>
                <v-spacer />
                <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="Submit" :loading="loading"
                  >Submit</v-btn
                >
              </v-card-actions>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:["record"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.record.id,
            RegistrationFeeTemplateId:this.record.registrationFeeTemplateId,
            CurrencyId : this.record.currencyId,
            Cost:this.record.cost
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("registrationfee/updateItem",this.form);         
          this.loading = false
      }
    }
      },
      computed:{
        currencies() {
      return this.$store.state.currency.records;
    },
      }
   }
  </script>