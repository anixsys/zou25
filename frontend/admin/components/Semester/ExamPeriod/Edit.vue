<template>
    <div>
      <v-btn depressed text color="primary" @click="AddModel=true"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Registration Period
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-text-field
              label="Name"
              placeholder="Name"
              v-model="form.name"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
            <v-text-field
              label="Start Date"
              placeholder="Start Date"
              v-model="form.StartDate"
              type="date"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
            <v-text-field
              label="End Date"
              placeholder="End Date"
              v-model="form.EndDate"
              type="date"
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
  import moment from 'moment'
   export default{
    props:['semester','period'],
      data(){
          return{
                AddModel:false,
                loading:false,
          form:{
            id:this.period.id,
            SemesterId:this.semester.id,
            Name:this.period.name,
            StartDate:moment(this.period.startDate, "MM-DD-YYYY"),
            EndDate:moment(this.period.endDate,"dd/mm/yyyy"),
            uuid:this.semester.uuid
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },watch: {
      menu (val) {
        val && setTimeout(() => (this.activePicker = 'YEAR'))
      },
    },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("examinationperiods/updateItem",this.form);         
          this.loading = false
      }
    }
      }
   }
  </script>