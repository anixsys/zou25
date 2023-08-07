<template>
    <v-container fluid>
           <v-row >       
          <DashboardSummary :summary="status" v-for=" status in dashboard.statussummary"/>                
       </v-row>
       <v-row>
          <v-col md="6">
             <v-card height="400px" outlined>
                <v-card-title>Admissions By Gender</v-card-title>
                <v-card-text>
                   <ChartsDonut :summary="dashboard.gendersummary"/>
                </v-card-text>
             </v-card>
          </v-col>
          <v-col md="6">
             <v-card height="400px" outlined>
                <v-card-title>Admissions By Country</v-card-title>
                <v-card-text>
                   <ChartsBar :summary="dashboard.countrysummary"/>
                </v-card-text>
             </v-card>
          </v-col>
       </v-row>
       <v-row>
          <v-col md="6">
             <v-card height="400px" outlined>
                <v-card-title>Admissions By Programem Type</v-card-title>
                <v-card-text>
                   <ChartsDonut :summary="dashboard.programmetypesummary"/>
                </v-card-text>
             </v-card>
          </v-col>
          <v-col md="6">
             <v-card height="400px" outlined>
                <v-card-title>Admissions By Campus</v-card-title>
                <v-card-text>
                   <ChartsBar :summary="dashboard.campussummary"/>
                </v-card-text>
             </v-card>
          </v-col>
       </v-row>
     
       
    </v-container>
 </template>
 <script>
  export default{
     name:'Dashboard',
     layout:"mainlayout",
     auth: true,
     async fetch() {
     this.overlay = true;
  
            await this.$store.dispatch("admissionsessions/getData");
           
      if(this.admissionsessions && this.admissionsessions.length>0)
      {
         var date = new Date();
         var year = date.getFullYear()
         var admissionsessionid = null;
       this.admissionsessions.forEach(element => {
         console.log(year)
          if(element.year== year){
            admissionsessionid=element.id
          }
       });
         await this.$store.dispatch("dashboard/getData",admissionsessionid);
        this.overlay = false;
      }
     
   },data(){
      return{
         admissionsessionid:null  
      }
   },methods:{
      async getData(){
         this.overlay = true;
         await this.$store.dispatch("dashboard/getData",this.admissionsessionid);
        this.overlay = false;   
      }
   },
     computed:{
     dashboard() {
       return this.$store.state.dashboard.records;
     },
     admissionsessions() {
      return this.$store.state.admissionsessions.records;
    },
   }
  }
 </script>