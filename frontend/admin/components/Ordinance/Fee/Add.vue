<template>
    <div>
      <v-btn fab depressed color="primary" @click="AddModel=true"><v-icon>mdi-plus</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New Fee Structure
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-autocomplete
            v-model="form.FacultyId"
            :items="faculties"
            item-value="id"
            item-text="name"
            outlined
            label="Select Faculties"           
          ></v-autocomplete>
          <v-autocomplete
            v-model="form.ApplicantTypeId"
            :items="applicanttypes"
            item-value="id"
            item-text="name"
            outlined
            label="Select Student type"           
          ></v-autocomplete>
          <v-autocomplete
            v-model="form.ProgrammeTypeId"
            :items="programmetypes"
            item-value="id"
            item-text="name"
            outlined
            label="Select Programme type"           
          ></v-autocomplete>
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
     props:['record'],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            RegistrationFeeTemplateId:this.record.id,
            FacultyId:"",
            ApplicantTypeId:"",
            ProgrammeTypeId:"",
            CurrencyId:"",
            Cost:""
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("registrationfee/addItem",this.form); 
         
          this.loading = false
      }
    }
      },
      computed:{
        programmetypes() {
      return this.$store.state.programmetype.records;
    },
    currencies() {
      return this.$store.state.currency.records;
    },
    applicanttypes() {
      return this.$store.state.applicanttypes.records;
    },
    faculties() {
      return this.$store.state.faculties.records;
    }
      }
   }
  </script>