<template>
    <div>
      <v-btn depressed fab small outlined color="primary" @click="AddModel=true"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Admission Fee
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

              <v-select 
               label="Status"
               v-model="form.status"
               outlined
               :rules="[rules.required]"
               :items="['PENDING','PUBLISHED','ARCHIEVED']"
               ></v-select>
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
    props:["admissionfee"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.admissionfee.id,
            name:this.admissionfee.name,
            status:this.admissionfee.status
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("admissionfeetemplate/updateItem",this.form); 
        
          this.loading = false
      }
    }
      }
   }
  </script>