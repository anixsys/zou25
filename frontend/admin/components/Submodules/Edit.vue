<template>
    <div>
        <v-btn small color="primary" class="mr-1" @click="AddModel=true"><v-icon>mdi-pencil</v-icon> Edit</v-btn>
       <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New Sub Module
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
          </v-card-text>
          <v-card-text>
              <v-text-field
                label="Icon"
                placeholder="Icon"
                v-model="form.Icon"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
          </v-card-text>
          <v-card-text>
              <v-text-field
                label="Url"
                placeholder="Url"
                v-model="form.Url"
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
            name:this.submodule.name,
            Icon:this.submodule.icon,
            Url:this.submodule.url,
            id:this.submodule.id,
            SystemmoduleId:this.submodule.systemModuleId
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("submodules/updateItem",this.form); 
         this.AddModel = false
          this.loading = false
      }
    }
      }
   }
  </script>