<template>
    <div>
      <v-btn depressed text color="primary" @click="AddModel=true"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Rule
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-text-field
                label="Maximum Permitted Courses"
                v-model="form.maximumcourses"
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
    props:["rule","id"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.rule.id,
            generalregulationId:this.id,
            maximumcourses:this.rule.maximumcourses
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("generalregulationacademicrule/updateItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      }
   }
  </script>