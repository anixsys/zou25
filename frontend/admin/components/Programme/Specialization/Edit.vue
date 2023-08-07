<template>
    <div>
      <v-btn icon>
        <v-icon
        class="mr-2"
        @click="AddModel=true"
      >
        mdi-pencil
      </v-icon>
      </v-btn>
        
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Edit Programme Specialization
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-text-field
                label="Area"
                placeholder="Area"
                v-model="form.area"
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
    props:["specialization"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.specialization.id,
            area:this.specialization.area,
            programmeId:this.specialization.programmeId
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("programmespecialization/updateItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      }
   }
  </script>