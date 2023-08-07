<template>
    <div>
      <v-btn small outlined depressed color="primary" @click="AddModel=true">View Profile</v-btn>
      <v-dialog v-model="AddModel" width="1200px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Application Profile
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
             <EnrolmentPersonal :applicant="application.applicant"/>
             <EnrolmentResults :applicant="application.applicant"/>
             <EnrolmentProgrammes :application="application"/>
             <EnrolmentEntryrequirements :requirements="application.applicationentrymodes"/>
             <ApplicantDocuments :documents="application.applicant.documents"/>
             <ApplicantOtherqualification :applicant="application.applicant"/>
             <ApplicantWorkexperience :applicant="application.applicant"/>
          </v-card-text>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:['application'],
    data(){
      return{
        AddModel:false
      }
    }
   }
  </script>