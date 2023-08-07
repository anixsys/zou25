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

        <v-stepper-step step="6" complete>
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
            <v-col md="10">
              <v-alert
      outlined
      type="warning"
      prominent
      border="left"
    >
     Read through your application details below and click submit application button at the end so that your application can be submitted for assessment   </v-alert>
             
                <ApplicantPersonal v-if="application" :applicant="application.applicant"/>           
            
              <ApplicantApplication :application="application"/>
              <ApplicantSubject :applicant="application.applicant" :uuid="uuid"/>
              <ApplicantOtherqualification :applicant="application.applicant" :uuid="uuid"/>
              <ApplicantWorkexperience :applicant="application.applicant" :uuid="uuid"/>
              <ApplicantProgramme :application="application"/>
              

              <template v-if="application">
                  <v-card class="mt-3" flat>
                    <v-card-actions>
                      <v-btn color="error" large to="/dashboard">Cancel Application</v-btn>
                      <v-spacer/>
                      <v-btn color="success" large @click="submit">Submit Application</v-btn>
                    </v-card-actions>
                  </v-card>
              </template>
              
              
            </v-col>
        </v-row>
  </v-container>
  <v-overlay :value="overlay">
        <v-progress-circular
          indeterminate
          size="64"
        ></v-progress-circular>
      </v-overlay>

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
      await this.$store.dispatch("applications/getApplication",this.$route.params.uuid);
      
         if(this.application.application!=null && this.application.application.paymentStatus !="PAID"){
            this.$router.push("/payment/"+this.$route.params.uuid);
         }else if(this.application==null){
            this.$router.push("/dashboard");
         }
      this.overlay = false;
    },methods:{
      async submit(){

        this.$swal({
  title: 'Are you sure?',
  text: "You want to submit your application for processing",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes Submit'
}).then(async (result) => {
  if (result.isConfirmed) {
    this.overlay = true
        await this.$store.dispatch("applications/confirm",this.uuid); 
        this.overlay = false 
  }
})
        
      
      }
    },computed:{
        application() {
      return this.$store.state.applications.record;
    }
  }

}
</script>