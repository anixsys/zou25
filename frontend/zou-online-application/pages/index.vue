<template>
  <div>
   <div class="dark-blue">
    <WelcomeHeader :session="admissionsession"/>
   </div>
  
   <v-container>
   <div class="display-1 mt-10 my-4">How to apply </div>
   <v-divider width="200px" color="primary"/>
   <v-row class="my-2">
    <v-col>
      <v-alert
      border="left"
      colored-border
      color="deep-purple accent-4"
      elevation="2"
    >
    <v-btn fab color="success" depressed class="mx-1">1</v-btn>Scan your academic documents
     </v-alert>
    
    </v-col>
    <v-col>
      <v-alert
      border="left"
      colored-border
      color="deep-purple accent-4"
      elevation="2"
    >
    <v-btn fab color="success" depressed class="mx-1">2</v-btn>Create an account and sign in
     </v-alert>
    
    </v-col>
    <v-col>
      <v-alert
      border="left"
      colored-border
      color="deep-purple accent-4"
      elevation="2"
    >
    <v-btn fab color="success" depressed class="mx-1">3</v-btn>click on New Application 
     </v-alert>
    
    </v-col>
    </v-row>
    <v-row>
    <v-col>
      <v-alert
      border="left"
      colored-border
      color="deep-purple accent-4"
      elevation="2"
    >
    <div class="d-flex">  <v-btn fab color="success" depressed class="mx-1">4</v-btn>
    <div>Select Programme maximum 3 chooses</div></div>
  
     </v-alert>
    
    </v-col>
    <v-col>
      <v-alert
      border="left"
      colored-border
      color="deep-purple accent-4"
      elevation="2"
    >
    <div class="d-flex">
      <v-btn fab color="success" depressed class="mx-1">5</v-btn>
      <div>Pay fee using ECOCASH,ONEMONEY,VISA</div>
    </div>
      </v-alert>
    
    </v-col>
    <v-col>
      <v-alert
      border="left"
      colored-border
      color="deep-purple accent-4"
      elevation="2"
    >
    <v-btn fab color="success" depressed class="mx-1">6</v-btn>Capture academic qualifications
     </v-alert>
    
    </v-col>
   </v-row>
   <v-row class="my-2">
  
    <v-col>
      <v-alert
      border="left"
      colored-border
      color="deep-purple accent-4"
      elevation="2"
    >
    <v-btn fab color="success" depressed class="mx-1">7</v-btn>Capture other qualifications 
     </v-alert>
    
    </v-col>
    <v-col>
      <v-alert
      border="left"
      colored-border
      color="deep-purple accent-4"
      elevation="2"
    >
    <v-btn fab color="success" depressed class="mx-1">8</v-btn>Upload mandetory documents 
     </v-alert>
    
    </v-col>
    <v-col>
      <v-alert
      border="left"
      colored-border
      color="deep-purple accent-4"
      elevation="2"
    >
  
      <v-btn fab color="success" depressed class="mx-1">9</v-btn>
      Confirm and submit application 
      
   
     </v-alert>
    
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
export default {
  name: 'IndexPage',
  auth: 'guest',
  async fetch(){
    this.overlay = false;
    await this.$store.dispatch("welcome/getData");
    this.overlay = false;
  },
  data(){
    return{
      overlay:false
    }
  },computed:{
    admissionsession() {
      return this.$store.state.welcome.record;
    },
  }
}
</script>
<style>
  .dark-blue{
    background-color: #183B6E;
  }
</style>
