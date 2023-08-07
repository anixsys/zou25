<template>
    <div>
      <v-btn fab depressed color="primary" @click="AddModel=true"><v-icon>mdi-plus</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="300px">
          <v-form ref="form" lazy-validation>
        <v-card>
            <v-system-bar
      window
      dark
      color="success"
    >
    <span> New Permission</span>
    <v-spacer/>
      
      <v-icon @click="AddModel=false">mdi-close</v-icon>
    </v-system-bar>
          <v-card-text>
              <v-text-field
                label="Name"
                placeholder="Name"
                v-model="form.name"
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
    props:["submodule"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            name:"",
            systemSubmoduleId:this.submodule.id
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("permissions/addItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      }
   }
  </script>