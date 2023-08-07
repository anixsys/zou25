<template>
    <div>
      <v-stepper alt-labels flat>
      <v-stepper-header>
        <v-stepper-step step="1"  complete>
        <small> Select Programme Type</small>
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="2" complete>
          <small> Make Payment</small>
        </v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="3">
          <small>Programme Selection</small>
        </v-stepper-step>
        <v-divider></v-divider>

        <v-stepper-step step="4" editable :to="`/academic/`+uuid">
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
    <v-row justify="center">
        <v-col md="10" sm="12">
          <v-alert
      icon="mdi-shield-lock-outline"
      prominent
      text
      type="info"
    >
   Filter and select atleast 3 Programmes of your choice  
  </v-alert>
    
    <v-row>
      <v-col>
        <v-card>
                <v-card-title dark>
                    Available Programmes 
                </v-card-title>
              
                <v-card-text>
                  <v-text-field  label="Search for Programme" outlined v-model="filter"/>
                  <v-data-table
    :headers="headers"
    :items="programmes.programmes"
    :items-per-page="20"
    :search="filter"
    class="mt-2"
  >
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end" v-if="applicationprogrammes.length<3">
      <ProgrammeApply  :programme="item" :uuid="uuid"/>
    </div>
     

    </template>
</v-data-table>
                </v-card-text>
            </v-card>
      </v-col>
      <v-col>
        <v-card>
      <v-toolbar dark color="success"> 
        <v-toolbar-title>Programme Selected</v-toolbar-title>
        <v-spacer/>
        <v-btn large color="primary" :to="`/academic/`+uuid">Save & Proceed >> </v-btn>
        
      </v-toolbar>
      <v-card-text>
        <v-simple-table>
          <template v-slot:default>
            <thead>
              <tr>
                <th>Code</th>
                <th>Description</th>
                <th>Attendece Type</th>
                <th>Acceptance Status</th>
                <th class="text-right">Action</th>
              </tr>
            </thead>
            <tbody>
              <template v-if="applicationprogrammes && applicationprogrammes.length>0">
               <tr v-for="applicant in applicationprogrammes">
                <td>{{ applicant.programme.code }}</td>
                <td>{{ applicant.programme.description }}</td>
                <td>{{ applicant.attendenceType.name }}</td>
                <td>{{ applicant.status }}</td>
                <td class="text-right">
                  <template v-if="applicant.status =='PENDING'">
                   <ProgrammeDelete :id="applicant.id" :uuid="uuid"/>
                  </template>

                </td>
               </tr>
              </template>
              <template v-else>
                <tr><td colspan="5" class="text-center red--text">No Programmes Selected</td></tr>
              </template>
            </tbody>
          </template>
        </v-simple-table>       
      </v-card-text>
      <v-card-actions>
          <v-spacer/>
         
      </v-card-actions>
    </v-card>
      </v-col>
    </v-row>
           
        </v-col>
    </v-row>
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
            uuid:"",
            headers: [
          {
            text: 'Code',
            align: 'start',
            sortable: true,
            value: 'programme.code',
          },
          {
            text: 'Description',
            align: 'start',
            sortable: true,
            value: 'programme.description',
          },
          {
            text: 'Actions',
            align: 'end',
            value: 'actions',
          }
        ]
        }
    },
    async created(){
        this.overlay = true;
      this.uuid = this.$route.params.uuid
      await this.$store.dispatch("applications/getRecord",this.$route.params.uuid);
      await this.$store.dispatch("applicationprogramme/getData",this.$route.params.uuid);
      
         if(this.application!=null && this.application.paymentStatus !="PAID"){
            this.$router.push("/payment/"+this.$route.params.uuid);
         }else if(this.application==null){
            this.$router.push("/dashboard");
         }else{
            await this.$store.dispatch("admisssiontemplates/getDataByType",this.application.programmeTypeId);  
         }
      this.overlay = false;
    },methods:{
      async deleteRecord(id){
        this.overlay = true;
        var payload = {applicationId:this.uuid,id:id}
        await this.$store.dispatch("applicationprogramme/deleteRecord",payload);
        this.overlay = false;
      }
    },computed:{
        application() {
      return this.$store.state.applications.record;
    },
    applicationprogrammes() {
      return this.$store.state.applicationprogramme.records;
    },
    programmes() {
      let data = [];
      data = this.$store.state.admisssiontemplates.records;
      return data
     
   
    }
    }
}
</script>