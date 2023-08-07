<template>
    <div>
      <v-btn icon depressed color="primary" @click="getData" :loading="loading"><v-icon>mdi mdi-magnify</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="1000px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
             {{ semester ? semester.name :"" }}
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <SemesterPeriod :semester="record"/>

            <SemesterExamPeriod :semester="record"/>
          </v-card-text>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:['semester'],
      data(){
          return{
              AddModel:false,
              loading:false,
        }
          
      },methods:{
    async getData(){
          this.loading = true
          await this.$store.dispatch("semesters/getRecord",this.semester.uuid);  
          this.AddModel = true       
          this.loading = false
      }
         },
         computed:{
         record() {
      return this.$store.state.semesters.record;
    }
}
      
   }
  </script>