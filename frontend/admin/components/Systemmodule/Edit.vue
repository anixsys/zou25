<template>
    <div>
      <v-btn  color="primary" class="mr-2" small @click="AddModel=true"><v-icon>mdi-pencil</v-icon> Edit</v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update System Module
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-text-field
                label="Icon"
                placeholder="Icon"
                v-model="form.Icon"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
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
    props:["systemmodule"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.systemmodule.id,
            name:this.systemmodule.name,
            Icon:this.systemmodule.icon
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("systemmodules/updateItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      }
   }
  </script>