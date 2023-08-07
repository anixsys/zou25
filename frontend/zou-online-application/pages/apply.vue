<template>
    <div>
        <v-row>
        <v-col>
            <v-card dense>
                <v-card-text>
                    <v-breadcrumbs :items="items"></v-breadcrumbs>
                </v-card-text>
            </v-card>
        </v-col>
    </v-row>
      <v-container>
       <v-row class="mt-5">     
        <v-col>
          <WelcomeStart :admissionsession="admissionsession"/>
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
    async fetch(){
      this.overlay = true;
      await this.$store.dispatch("welcome/getData");
      this.overlay = false;
    },
    data(){
      return{
        overlay:false,
        items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/',
        },
        {
          text: 'Start Application',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ]
      }
    },computed:{
      admissionsession() {
        return this.$store.state.welcome.record;
      },
    }
  }
  </script>
  