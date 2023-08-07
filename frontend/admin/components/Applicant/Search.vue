<template>
    <div>
      <v-btn rounded outlined color="success" @click="AddModel=true" class="mr-1"><v-icon>mdi mdi-search-web</v-icon>Search Applicant</v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
            Search Applicant
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-text-field
                label="Search"
                placeholder="Search Term"
                v-model="form.needle"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
            
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80"  @click="AddModel=false">Cancel</v-btn>
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
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            needle:"29249778L26",
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("applicant/Search",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      },
    computed:{
    departments() {
      return this.$store.state.department.records;
    }
  }
   }
  </script>