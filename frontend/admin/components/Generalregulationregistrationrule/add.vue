<template>
    <div>
      <v-btn small depressed color="primary" @click="getRecords" :loading="loading"><v-icon>mdi-plus</v-icon> Add Rule</v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New  Registration Rule
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
     props:["id"],
      data(){
          return{
              AddModel:false,
              loading:false,
              facultylist:"",
          form:{
            generalregulationId:"",
            maximumcourses :""
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async getRecords(){
      this.loading = true;
           this.AddModel=true
      this.loading =false
    },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          this.form.generalregulationId = this.id,
          await this.$store.dispatch("generalregulationregistrationrule/addItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      },
    computed:{
    faculties() {
      return this.$store.state.faculties.records;
    },
  }
   }
  </script>