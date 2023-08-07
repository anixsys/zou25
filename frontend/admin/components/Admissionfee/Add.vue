<template>
  <div>
    <v-btn fab depressed color="primary" @click="getData"><v-icon>mdi-plus</v-icon></v-btn>
    <v-dialog v-model="AddModel" width="500px">
        <v-form ref="form" lazy-validation>
      <v-card>
        <v-card-title>
            New Admission Fees
            <v-spacer/>
            <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-col>
              <v-select
              label="Applicant Type"
              v-model="form.applicanttypeId"
              :items="applicanttypes"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
            <v-col>
              <v-select
              label="Programme Type"
              v-model="form.programmetypeId"
              :items="programmetypes"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
          </v-row>
          
         <v-row>
          <v-col>
            <v-select
              label="Currency"
              v-model="form.currencyId"
              :items="currencies"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
          </v-col>
          <v-col>
            <v-text-field
              label="Cost"
              v-model="form.amount"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
          </v-col>
         </v-row>
           
           
        </v-card-text>
        <v-card-actions>
              <v-btn rounded depressed class="no-uppercase error" max-width="80" @click="AddModel=true">Cancel</v-btn>
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
  props:['admissionFee'],
    data(){
        return{
            AddModel:false,
            loading:false,
        form:{
          programmetypeId:"",
          applicanttypeId:"",
          AdmissionFeeTemplateId:this.admissionFee.id,
          currencyId:"",
          amount:""

        },
        rules: {
            required: value => !!value || 'Required.'
          },
      }
        
    },methods:{
  async getData(){
    await this.$store.dispatch("applicanttypes/getData");
    await this.$store.dispatch("programmetype/getData");
    await this.$store.dispatch("currency/getData");
     this.AddModel = true
  },
  async Submit(){
    if(this.$refs.form.validate()){
        this.loading = true
        await this.$store.dispatch("admissionfees/addItem",this.form); 
        this.$refs.form.reset()
        this.loading = false
    }
  }
    },
    computed:{
      applicanttypes() {
      return this.$store.state.applicanttypes.records;
    },
    programmetypes() {
      return this.$store.state.programmetype.records;
    },
    currencies() {
      return this.$store.state.currency.records;
    }
    }
 }
</script>