<template>
    <div>
      <v-btn rounded outlined depressed color="primary" @click="getRecords"><v-icon>mdi-pencil</v-icon> Edit</v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Edit Application
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
           >
                <v-select
                dense
              label="Programme Type"
              v-model="form.ProgrammeTypeId"
              :items="programmetypes"
              item-value="id"
              item-text="name"
              outlined
              :rules="[rules.required]"
            ></v-select>
         
                <v-select
                dense
              label="Attendence Type"
              v-model="form.AttendenceTypeId"
              :items="attendencetypes"
              item-value="id"
              item-text="name"
              outlined
              :rules="[rules.required]"
            ></v-select>
        
                <v-select
                dense
              label="Applicant Type"
              v-model="form.ApplicantTypeId"
              :items="applicanttypes"
              item-value="id"
              item-text="name"
              outlined
              :rules="[rules.required]"
            ></v-select>
            
                <v-select
                dense
              label="Select Campus "
              v-model="form.CampusId"
              :items="campuses"
              item-value="id"
              item-text="name"
              outlined
              :rules="[rules.required]"
            ></v-select>
            <v-select
                dense
              label="Select Session "
              v-model="form.AdmissionSessionId"
              :items="sessions"
              item-value="id"
              item-text="name"
              outlined
              :rules="[rules.required]"
            ></v-select>
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80"  @click="AddModel=false">Cancel</v-btn>
                <v-spacer />
                <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="Submit" :loading="loading"
                  >Submit</v-btn
                >
              </v-card-actions>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:['application'],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            Id:this.application.id,
            ApplicantTypeId:this.application.applicanttypeId,
            ProgrammeTypeId:this.application.programmeTypeId,
            CampusId:this.application.campusId,
            AttendenceTypeId:this.application.attendencetypeId,
            ApplicantId:this.application.applicantId,
            AdmissionSessionId:this.application.admissionSessionId,
            PaymentStatus :this.application.paymentStatus,
            ApprovalStatus: this.application.approvalStatus
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async getRecords(){
      await this.$store.dispatch("campus/getData");
      await this.$store.dispatch("programmetype/getData");
      await this.$store.dispatch("applicanttypes/getData");
      await this.$store.dispatch("attendencetype/getData");
      await this.$store.dispatch("admissionsessions/getAllPublish");
        this.AddModel=true
    },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("applications/updateItem",this.form); 
          this.loading = false
      }
    }
      },
    computed:{
      attendencetypes() {
      return this.$store.state.attendencetype.records;
    },
    programmetypes() {
      return this.$store.state.programmetype.records;
    },
    applicanttypes() {
      return this.$store.state.applicanttypes.records;
    },
    campuses() {
      return this.$store.state.campus.records;
    }
    ,
    sessions() {
      return this.$store.state.admissionsessions.records;
    }
  }
   }
  </script>