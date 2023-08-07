<template>
    <div>
      <v-btn depressed text color="primary" @click="AddModel=true"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Province
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
              label="Type"
              placeholder="Type"
              v-model="form.type"
              :items="['ACADEMIC','NON-ACADEMIC']"
              outlined
              :rules="[rules.required]"
            ></v-select>
              <v-text-field
                label="Code"
                placeholder="Code"
                v-model="form.code"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80" to="/dashboard">Cancel</v-btn>
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
    props:["faculty"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.faculty.id,
            name:this.faculty.name,
            type:this.faculty.type,
            code:this.faculty.code
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("faculties/updateItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      }
   }
  </script>