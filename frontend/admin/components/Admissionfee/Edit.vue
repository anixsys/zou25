<template>
    <div>
      <v-btn depressed text color="primary" @click="getData"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
        <v-form ref="form" lazy-validation>
      <v-card>
        <v-card-title>
           Update Admission Fee
            <v-spacer/>
            <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
        </v-card-title>
        <v-card-text>
          <v-select
              label="Applicant Type"
              v-model="form.applicanttypeId"
              :items="applicanttypes"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
            <v-select
              label="Programme Type"
              v-model="form.programmetypeId"
              :items="programmetypes"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
            <v-select
              label="Currency"
              v-model="form.currencyId"
              :items="currencies"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
            <v-text-field
              label="Cost"
              v-model="form.amount"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
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
  props:['admissionfee'],
    data(){
        return{
            AddModel:false,
            loading:false,
        form:{
          id:"",
          programmetypeId:"",
          applicanttypeId:"",
          AdmissionFeeTemplateId:this.admissionfee.admissionFeeTemplateId,
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
    this.form.applicanttypeId = this.admissionfee.applicanttypeId
    this.form.programmetypeId = this.admissionfee.programmeTypeId
    this.form.currencyId = this.admissionfee.currencyId
    this.form.amount = this.admissionfee.amount
    this.form.id = this.admissionfee.id
     this.AddModel = true
  },
  async Submit(){
    if(this.$refs.form.validate()){
        this.loading = true
        await this.$store.dispatch("admissionfees/updateItem",this.form); 
        
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