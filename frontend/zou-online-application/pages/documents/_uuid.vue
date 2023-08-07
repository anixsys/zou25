<template>
    <div>
        <v-stepper alt-labels flat>
      <v-stepper-header>
        <v-stepper-step step="1"  complete >
        <small> Select Programme Type</small>
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="2" complete>
          <small> Make Payment</small>
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="3" complete>
          <small>Programme Selection</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="4" complete>
          <small>Academic Qualifications</small>
        </v-stepper-step>
        <v-divider></v-divider>
        <v-stepper-step step="5" complete>
          <small>Other Qualifications</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="6">
          <small> Attach Documents</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="7">
          <small>Confirm Application</small>
        </v-stepper-step>
      </v-stepper-header>
    </v-stepper>
    <v-container>
        <v-row justify="center">
            <v-col md="8">
              <v-alert v-if="computeuploaded>0 || computeentryuploaded >0" text prominent type="error"> 
                Please Upload {{ computeuploaded }} Mandetory Documents 
                 <template v-if="computeentryuploaded>0">
                  And {{ computeentryuploaded }} Entry Mode  Documents
                </template>
              </v-alert>
                    <v-alert
                     v-else
                        prominent
                        type="success"
                        >
                        <v-row align="center">
                            <v-col class="grow">
                            You have successfully uploaded all mandetory documents
                            </v-col>
                            <v-col class="shrink">
                            <v-btn :to="`/confirm/`+uuid"> Proceed >> </v-btn>
                            </v-col>
                        </v-row>
                        </v-alert>
                <v-card >
                    <v-card-title>Required Documents</v-card-title>
                    <v-card-text>
                      <v-simple-table>
                            <template v-slot:default>
                                <thead>
                                    <tr>
                                        <th>Document Name</th>
                                        <th>Status</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                <template v-if="documents.length>0">
                                    <tr v-for="doc in documents">
                                     <td>{{ doc.document.name }}</td>
                                     <td><v-chip small :class="doc.status=='MANDETORY' ? 'error' :'info'"> {{ doc.status }}</v-chip></td>
                                     <td class="text-right">
                                        <template v-if="doc.applicantdocuments && doc.applicantdocuments.length>0">
                                         <v-btn text color="success"><v-icon>mdi-check-circle-outline</v-icon>Uploaded</v-btn>
                                        </template>
                                        <template v-else>
                                           <DocumentUpload :uuid="uuid" :doc="doc"/>
                                        </template>
                                    </td>
                                    </tr>
                                </template>
                                <template v-else>
                                    <tr>
                                        <td colspan="3" class="text-center red--text">No Required document found</td>
                                    </tr>
                                </template>
                                </tbody>
                            </template>
                        </v-simple-table>
                      
                    </v-card-text>
                </v-card>
                <v-row v-if="moderequirements && moderequirements.length>0" class="mt-5">
          <v-col>
            <v-card>
              <v-card-title>Entry Mode Requirements</v-card-title>
              <v-card-text>
                <v-simple-table>
                   <thead>
                    <tr>
                      <th>Document Name</th>
                      <th>Required Status</th>
                      <th>Action</th>
                    </tr>
                   </thead>
                   <tbody>
                    <tr v-for=" mode in moderequirements">
                      <td>{{ mode.name }}</td>
                      <td>
                        <v-chip small class="error">MANDETORY</v-chip>
                      </td>
                      <td class="text-right">
                                        <template v-if="mode.applications && mode.applications.length>0">
                                         <v-btn text color="success"><v-icon>mdi-check-circle-outline</v-icon>Uploaded</v-btn>
                                        </template>
                                        <template v-else>
                                          <DocumentEntrymodeupload :uuid="uuid" :doc="mode"/>
                                        </template>
                                    </td>
                     </tr>
                   </tbody>
                </v-simple-table>
              </v-card-text>
            </v-card>
          </v-col>
        </v-row>
            </v-col>
        </v-row>
      
   
    </v-container>
    </div>
</template>
<script>
export default{
    data(){
        return{
            overlay:false,
            filter:"",
            uuid:""
        }
    },
    async created(){
        this.overlay = true;
      this.uuid = this.$route.params.uuid
      await this.$store.dispatch("applications/getRecord",this.$route.params.uuid);
      await this.$store.dispatch("applicationdocuments/getData",this.uuid);
      await this.$store.dispatch("entrymoderequirements/getData",this.uuid);
      
         if(this.application!=null && this.application.paymentStatus !="PAID"){
            this.$router.push("/payment/"+this.$route.params.uuid);
         }else if(this.application==null){
            this.$router.push("/dashboard");
         }else{
            await this.$store.dispatch("admisssiontemplates/getDataByType",this.application.programmeTypeId);  
         }
      this.overlay = false;
    },computed:{
        application() {
      return this.$store.state.applications.record;
    },
    documents() {
      return this.$store.state.applicationdocuments.records;
    },
    moderequirements() {
      return this.$store.state.entrymoderequirements.records;
    },
    computeuploaded(){
       var data = this.$store.state.applicationdocuments.records;
       var modedata = this.$store.state.entrymoderequirements.records;
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
    },
    computeentryuploaded(){
       var modedata = this.$store.state.entrymoderequirements.records;
       
       var uploaded = 0;
       
       modedata.forEach(doc => {
                if(doc.applications.length>0){
                    uploaded++
                }
            
       });

       return modedata.length-uploaded
    }
    }
}
</script>