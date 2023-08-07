<template>
    <div>
              <v-card>
            <v-card-title>
                My Applications
                <v-spacer/>
                <v-btn large depressed color="primary" to="/myapplication/programmetype"><v-icon>mdi-plus</v-icon>New Application</v-btn>
            </v-card-title>
            <v-divider/>
            <v-card-text>
                <template v-if="applications.length>0">
                <v-simple-table>
                  <template v-slot:default>
                    <thead>
                      <tr>
                        <th>Application Number</th>
                        <th>Session</th>
                        <th>Programme Type</th>
                        <th> Applicant type</th>
                        <th> Payment Status</th>
                        <th> Application Status</th>
                        <th class="text-right pt-2 pb-2"> Action</th>
                      </tr>
                    </thead>
                    <tbody>
                       <tr v-for="app in applications">
                        <td>{{ app.appNumber }}</td>
                         <td>{{ app.admissionSession.name }}</td>
                         <td>{{ app.programmeType.name }}</td>
                         <td>{{ app.applicanttype.name }}</td>
                         <td :class="app.paymentStatus">{{ app.paymentStatus }}</td>
                         <td :class="app.approvalStatus"><b>{{ app.approvalStatus }}</b></td>
                         <td class="text-right pt-2 pb-2">
                          <template v-if=" app.approvalStatus =='PENDING' || app.approvalStatus=='' ">
                             <v-btn color="warning" outlined :to="`/selectprogrammes/`+app.uuid">Resume</v-btn>
                          </template>
                          <template v-else-if=" app.approvalStatus =='ACCEPTED'">
                             <v-btn color="success" outlined @click="viewdocument(app)" :loading="loading">Download Offer Letter</v-btn>
                          </template>
                          <template v-else>
                      <ApplicationTrack :application="app"/>                             
                          </template>
                            </td>
                       </tr> 
                    </tbody>
                  </template>
                </v-simple-table>
                </template>
                <template v-else>
                  <v-alert
      prominent
      type="error"
    >
      <v-row align="center">
        <v-col class="grow">
         No Application Found  click Get Started to apply
        </v-col>
        <v-col class="shrink">
          <v-btn to="/myapplication/programmetype">Get Started</v-btn>
        </v-col>
      </v-row>
    </v-alert>
                </template>
               
                
            </v-card-text>
        </v-card>
        <v-overlay :value="overlay">
      <v-progress-circular
        indeterminate
        size="64"
      ></v-progress-circular>
    </v-overlay>
    </div>
</template>
<script>
import {saveAs} from 'file-saver';
export default{
    async fetch(){
      try {
        this.overlay = true;
    await this.$store.dispatch("applications/getData");
    this.overlay = false; 
      } catch (error) {
         this.overlay = false
      }
  
  },
  data(){
    return{
      overlay:false,
      loading:false,
    }
  },methods:{
    async viewdocument(app){
            
            this.loading = true; 
            await this.$axios({
                method: "GET",
                url: "Application/record/letter/"+app.uuid,
                responseType: 'blob',
            }).then(async (res) => {
                saveAs(res.data, "Offerletter_"+app.uuid+".pdf");
            })
        
          this.loading =false
    
       }
  },computed:{
    applications() {
      return this.$store.state.applications.records;
    },
  }
}
</script>
<style scoped>
.REJECTED{
    color: red;
    font-weight: bolder;
}
.ACCEPTED{
    color: green;
    font-weight: bolder;
}
.PAID{
    color: green;
    font-weight: bolder;
}
.PENDING{
    color: orange;
    font-weight: bolder;
}
.AWAITING{
    color: blue;
    font-weight: bolder;
}
</style>