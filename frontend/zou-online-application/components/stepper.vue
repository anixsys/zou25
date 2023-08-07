<template>
       <v-stepper  flat>
      <v-stepper-header>
        <v-stepper-step step="1" 
        editable>
        <small> Select Programme Type</small>
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="2">
          <small> Make Payment</small>
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="3">
          <small>Academic Qualifications</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="4">
          <small>Other Qualifications</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="5">
          <small> Attach Documents</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="6">
          <small>Confirm Application</small>
        </v-stepper-step>
      </v-stepper-header>
    </v-stepper>
      
</template>
<script>
export default{
    props:['step']
}
</script>