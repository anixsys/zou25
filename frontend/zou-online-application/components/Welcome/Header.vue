<template>
  <div>
  <v-row class="hidden-sm-and-down"  justify="center" align="center">
    <v-col md="12">
      <v-row >
      <v-col md="6" sm="12" class="pt-32 pl-16">
                     <template v-if="session">
                     <div class="display-2 white--text mb-5">Applications for {{ session.year }} academic year is open</div>
                     <div class="title"></div>
                        <div class="d-flex mt-5">
                      <v-btn dark outlined x-large depressed  rounded to="/register">New Applicant</v-btn>
                      <v-btn dark outlined x-large depressed  rounded to="/login" class="mr-2 ml-2">Returning Applicant</v-btn>
                      <v-btn dark outlined x-large depressed  rounded to="/programme/1">View Programmes</v-btn>
                    
                    </div>
                    </template>
                    <template v-else>
                      <div class="display-1">Welcome to our online application portal</div>
                    </template>
                    
      </v-col>
      <v-col class="hidden-md-and-down" md="6">
        <img src="/header.png" width="650px">
      </v-col>
     </v-row>
    </v-col>
  </v-row>
  <v-row class="hidden-md-and-up">
    <v-col class="text-center">
      <div class="title white--text mb-5 ">Applications for {{ session.year }} academic year is open</div>
      <v-row>
        <v-col><v-btn dark outlined depressed  rounded to="/register">New Applicant</v-btn></v-col>
        <v-col>  <v-btn dark outlined  depressed  rounded to="/login" class="mr-2 ml-2">Returning Applicant</v-btn>
                </v-col>
        <v-col><v-btn dark outlined  depressed  rounded to="/programme/1">View Programmes</v-btn>
                      </v-col>
      </v-row>
      
                                   
    </v-col>
  </v-row>
  </div>
   
  
   
</template>
<script>
 export default{
   props:["session"]
 }
</script>
<style scoped>
.pt-32{
  padding-top: 135px;
}
</style>