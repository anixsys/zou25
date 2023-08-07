<template>
    <div>
      <v-btn depressed text color="primary" @click="AddModel=true"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-system-bar
      window
      dark
    >
      <span> update General Settings</span>
      <v-spacer></v-spacer>
      <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
        </v-system-bar>
          <v-card-text>
              
            <p>Select <b>Decision mode</b> this setting will be used by the system  to make decision when processing examination marks</p>
            <ol>
                <li><b>SEMESTER </b> this means the system will make decision at the end of each SEMESTER</li>
                <li><b>LEVEL</b> this means the system will make decision at the end of each academic LEVEL</li>
            </ol>
     
        <v-select dense outlined  :items="['SEMESTER','LEVEL']" v-model="form.decisiontype"  :rules="[rules.required]"/>
 
            
            <p>Please enter the number of semesters that constitute an academic level</p>
      
        <v-text-field dense outlined  type="number"  v-model="form.semesters"  :rules="[rules.required]"/>

        <p>Description</p>
      
      <v-textarea dense outlined   v-model="form.description"  :rules="[rules.required]"/>
      <p>Year</p>
      
        <v-text-field dense outlined  type="number"  v-model="form.year"  :rules="[rules.required]"/>

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
    props:["setting"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.setting.id,
            decisiontype:this.setting.decisiontype,
            semesters:this.setting.semesters,
            description:this.setting.description,
            year:this.setting.year
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("generalsetting/updateItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      }
   }
  </script>