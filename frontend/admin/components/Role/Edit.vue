<template>
    <div>
      <v-btn depressed small color="primary" class="mr-1" @click="AddModel=true"><v-icon>mdi-pencil</v-icon> Edit</v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-system-bar
      window
      dark
      color="success"
    >
    <span> Update Role</span>
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
              <v-select outlined label="Dashboard View" v-model="form.View" :rules="[rules.required]" :items="['Administration','Academic']"/>
      
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
    props:["role"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.role.id,
            name:this.role.name,
            View:this.role.view
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("roles/updateItem",this.form); 
          this.AddModel = false
          this.loading = false
      }
    }
      }
   }
  </script>