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
        <v-stepper-step step="5" active editable>
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
        <v-alert
      prominent
      type="info"
      class="mt-2"
    >
      <v-row align="center">
        <v-col class="grow">
         If you have added  all necessary records click the proceed button
        </v-col>
        <v-col class="shrink">
          <v-btn :to="`/documents/`+uuid">Save && Proceed >> </v-btn>
        </v-col>
      </v-row>
    </v-alert>
        <OtherQualification/>
        <OtherExperience/>
    </v-container>
    
    </div>
</template>
<script>
 export default{
    data(){
        return{
            uuid:""
        }
    },
    created(){
        this.uuid = this.$route.params.uuid
    }
 }
</script>