<template>
    <div>
      <v-stepper alt-labels flat>
      <v-stepper-header>
        <v-stepper-step step="1"  complete editable :to="``">
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

        <v-stepper-step step="4">
          <small>Academic Qualifications</small>
        </v-stepper-step>
        <v-divider></v-divider>
        <v-stepper-step step="5">
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
        <SubjectAdd/>
        <template v-if="subjects && subjects.length>0">
            <v-alert
      prominent
      type="info"
      class="mt-2"
    >
      <v-row align="center">
        <v-col class="grow">
         If you have added  all your academic results click the proceed button
        </v-col>
        <v-col class="shrink">
          <v-btn :to="`/otherqualification/`+uuid">Save && Proceed >> </v-btn>
        </v-col>
      </v-row>
    </v-alert>
            <Subject  :subjects="subjects"/>
        </template>
        <template v-else>
            <v-alert
      border="top"
      color="red lighten-2"
      class="mt-5"
      dark
    >
      Please add your academic transcript
    </v-alert>
        </template>
      
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
      await this.$store.dispatch("applications/getRecord",this.$route.params.uuid);
      await this.$store.dispatch("applicationsubject/getData");
      
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
    subjects() {
      return this.$store.state.applicationsubject.records;
    }
    }
}
</script>