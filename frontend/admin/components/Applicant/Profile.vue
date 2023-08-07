<template>
    <div>
      <v-btn fab small outlined color="success" class="ml-1" @click="getData"><v-icon>mdi-account-search</v-icon></v-btn>
      <v-dialog v-model="profileModel" fullscreen>
         <v-card>
            <v-app-bar color="primary" dark elevation="1">
                <v-toolbar-title>Applicant Profile: {{ applicant.name }} {{ applicant.surname }} </v-toolbar-title>
                <v-spacer/>
                <v-btn icon @click="profileModel=false"><v-icon>mdi-close</v-icon></v-btn>
                <template v-slot:extension>
                    <v-tabs  v-model="tab">
                    <v-tab>Applications</v-tab>
                    <v-tab>Personal Details</v-tab>                 
                    <v-tab>Academic Documents</v-tab>
                    <v-tab>Academic Transcript</v-tab>
                    <v-tab>Other Qualifications</v-tab>
                    <v-tab>Working experience</v-tab>
                </v-tabs>
               </template>
            </v-app-bar>
            <v-card-text>
             
                <v-tabs-items v-model="tab">
                        <v-tab-item>
                            <ApplicantApplication :applicant="applicant"/>
                        </v-tab-item>
                        <v-tab-item>
                            <ApplicantPersonal :applicant="applicant"/>
                        </v-tab-item>
                        <v-tab-item>
                            <ApplicantDocuments :documents="applicant.documents"/>
                        </v-tab-item>
                        <v-tab-item>
                            <EnrolmentResults :applicant="applicant"/>
                        </v-tab-item>
                        <v-tab-item>
                            <ApplicantOtherqualification :applicant="applicant"/>
                        </v-tab-item>
                        <v-tab-item>
                            <ApplicantWorkexperience :applicant="applicant"/>
                        </v-tab-item>
                 </v-tabs-items>

                
            
            </v-card-text>
         </v-card>

      </v-dialog>
    </div>
</template>
<script>
export default  {
    props:["id"],    
      data(){
          return{
            profileModel:false,
            tab:null,
          }
        },
        methods:{
            async getData(){
                await this.$store.dispatch("applicant/getProfile",this.id);
                await this.$store.dispatch("admissionsubjects/getData"); 
                
                this.profileModel=true
            }
        },
        computed:{
            applicant(){
                return this.$store.state.applicant.record;
            }
        }
    }
    </script>
