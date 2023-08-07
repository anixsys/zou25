<template>
    <div>
    <v-btn icon depressed color="primary" @click="getRecord"><v-icon>mdi-account-search</v-icon></v-btn>
      <v-dialog
       v-model="AddModel" 
         width="1200"
      hide-overlay >
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
             Student Profile
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-tabs  v-model="tabs"  dark  background-color="grey darken-3">
              <v-tab>
                <v-icon left>
                  mdi-account-key
        </v-icon>
                  Personal Details
              </v-tab>
              <v-tab>
                <v-icon left>
          mdi-cogs
        </v-icon>
                   Statement
              </v-tab>
              <v-tab>
                <v-icon left>
          mdi-cogs
        </v-icon>
                 Programmes
              </v-tab>
              <v-tab>
                <v-icon left>
          mdi-file
        </v-icon>
                 Payments
              </v-tab>
              <v-tab>
                <v-icon left>mdi-file-check</v-icon>
                   Registrations
              </v-tab>
             
           </v-tabs>
            <v-tabs-items v-model="tabs">
              <v-tab-item>
                <StudentPersonal :profile="profile"/>
              </v-tab-item>
              <v-tab-item>
                sdfsfsd
              </v-tab-item>
              <v-tab-item>
                sdfsdfdsdsfdsf
              </v-tab-item>
              <v-tab-item>
                tytry
              </v-tab-item>
              <v-tab-item>
                jhkhkjhk
              </v-tab-item>
              <v-tab-item>
                tyjjtjty
              </v-tab-item>
           </v-tabs-items>

          </v-card-text>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
</template>
<script>
  export default{
    props:['student'],
    data(){
        return{
          AddModel:false,
          tabs:null,
        }
    },
    methods:{
       async getRecord(){
            await this.$store.dispatch("student/getRecord",this.student.pin); 
            this.AddModel = true  
        }
    },
    computed:{
       profile() {
      return this.$store.state.student.record;
    },
   }
  }
</script>