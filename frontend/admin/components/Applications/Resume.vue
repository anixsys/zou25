<template>
    <div>
      <v-btn rounded outlined color="success" @click="getData">
        <template v-if="application.approvalStatus =='PENDING'">
          <v-icon>mdi-plus</v-icon> Continue
        </template>
        <template v-else>
          View Application
        </template>
        
      </v-btn>
      <v-dialog v-model="AddModel" fullscreen>
        
        <v-card>
          <v-card-title>
              Application details
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <template v-if="application.approvalStatus =='PENDING'">
            <v-card outlined v-if="application.applicationprogrammes.length==0 || applicant.subjects.length==0 || computeuploaded>0">
              <v-card-text>
                <ul>
                  <li v-if="application.applicationprogrammes.length==0" class="red--text">Select atleast a maximum of 3 programme choices</li>
                  <li v-if="applicant.subjects.length==0" class="red--text">Add all your Secondary and High school results</li>
                  <li v-if="computeuploaded>0" class="red--text">Please Scan and upload all mandetory documents</li>
                  <li v-if="entryrequirements.length >0 && computedentryrequirements>0" class="red--text">Please Scan and upload Entry mode documents</li>
             
                </ul>
 
              </v-card-text>
            </v-card>
            <v-alert
            v-else
      prominent
      type="success"
    >
      <v-row align="center">
        <v-col class="grow">
          All mandetory requirements have been met submit application for approval
        </v-col>
        <v-col class="shrink">
          <v-btn @click="update">Submit applicaiton</v-btn>
        </v-col>
      </v-row>
    </v-alert>
    </template>
          
            <Applicationprogramme class="mt-2" :application="application" :applicant="applicant"/>
            <Applicantsubjects :applicant="applicant"/>
            <Applicationentrydocument :requirements="entryrequirements" :application="application"/>
            <Applicantdocument :documents="documents" :applicant="applicant" :application="application"/>
            <Applicantotherqualifications :applicant="applicant"/>
            <Applicantworkexperience :applicant="applicant"/>
          </v-card-text>
          
        </v-card>
  
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:['application','applicant'],
      data(){
          return{
              AddModel:false,
              loading:false,
         
        }
          
      },methods:{
        async getData(){
          this.loading=true
          await this.$store.dispatch("applicantdocuments/getData",this.application.id); 
          await this.$store.dispatch("applicationentrydocuments/getData",this.application.id)
          this.AddModel = true
          this.loading = false
        },
        async update(){
          this.$swal({
  title: 'Are you sure?',
  text: "You want to submit application for approval",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes, Submit'
}).then(async (result) => {
  if (result.isConfirmed) {
        await this.$store.dispatch("applications/SubmitForApproval",this.application);
        
  }
})
        }
      },
      computed:{
       documents(){
        return this.$store.state.applicantdocuments.records;
       },
       entryrequirements(){
        return this.$store.state.applicationentrydocuments.records;
       },
       computedentryrequirements(){
          var data = this.$store.state.applicationentrydocuments.records;
          var uploaded = 0;
          if(data.length >0){
            
             data.forEach(dt=>{
                 if(dt.applications.length>0){
                    uploaded ++;
                 }
             })
          }
          return data.length - uploaded
       },
       computeuploaded(){
       var data = this.$store.state.applicantdocuments.records;
       var mandetory = 0;
       var uploaded = 0;
       
       data.forEach(doc => {
            if(doc.status=='MANDETORY'){
                mandetory++
                if(doc.applicantdocuments.length>0){
                    uploaded++
                }
            }
       });

       return mandetory-uploaded
    }
      }
   }
  </script>