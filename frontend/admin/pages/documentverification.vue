<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
<v-container fluid>
    <div class="text-h5 mt-2 mb-2"> Applicant Document Verification</div>
        <v-form ref="form" lazy-validation>
    <v-card>
    <v-card-text>
      <v-row>
        <v-col class="d-flex justify-content-between">
            <v-text-field
              label="APP NUMBER"
              placeholder="Application Numberf"
              v-model="form.AppNumber"
              outlined
              :rules="[rules.required]"
            ></v-text-field>  
        <v-btn  depressed class="rounded-0" large height="55px" color="primary" :loading="loading" @click="getApplications">Search</v-btn></v-col>
       </v-row>
       <v-row class="mt-2" v-if="documentverification">
        <v-col>
          
             <div v-if="documentverification && documentverification.applicant">
                <v-alert
      prominent
      type="error"
      v-if="documentverification.applicant.studentnumber.docVerified=='N'"
    >
      <v-row align="center">
        <v-col class="grow">
            Please carefully validate the authenticity of original documents aganist documents uploaded by the applicant 
         </v-col>
        <v-col class="shrink">
          <v-btn @click="Verify(documentverification.applicant.studentnumber.applicationId)">Validated</v-btn>
        </v-col>
      </v-row>
    </v-alert>
    <v-alert
      prominent
      type="success"
      v-else
    >
      <v-row align="center">
        <v-col class="grow">
         Documents successfully verified
        </v-col>
      </v-row>
    </v-alert>
                <EnrolmentPersonal :applicant="documentverification.applicant"/>
                <EnrolmentDocuments :documents="documentverification.applicant.documents"/>
             </div>
            
            
     
        </v-col>
       </v-row>
      </v-card-text>
  </v-card>
  </v-form>
    
</v-container>

  
    </div>
</template>
<script>
  export default{
    layout:"mainlayout",
    data(){
        return{
          loading: false,
          form:{
            AppNumber:""
          },
          rules: {
            required: value => !!value || 'Required.'
          },
            items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: 'Applicant Document Verification',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    methods:{
        async getApplications(){
            if(this.$refs.form.validate()){
        this.loading = true
        await this.$store.dispatch("documentverification/Search",this.form); 
        this.$refs.form.reset()
        this.loading = false
    }
        },
        Verify(id){
            this.$swal({
  title: 'Are you sure?',
  text: "You want verify applicant profile ",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes,'
}).then(async (result) => {
  if (result.isConfirmed) {
    await this.$store.dispatch("documentverification/Verify",id); 
  }
})
        }
    },
    computed:{
        documentverification() {
      return this.$store.state.documentverification.record;
    },
  }
  }
</script>