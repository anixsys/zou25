<template>
    <div>
      <v-btn rounded outlined depressed color="primary" @click="getRecords"><v-icon>mdi-plus</v-icon> New Application</v-btn>
      <v-dialog v-model="AddModel" width="700px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New Application
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
             <v-row>
              <v-col>
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
              </v-col>
              <v-col>
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
              </v-col>
             </v-row>
                
             <v-row>
              <v-col>
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
              </v-col>
              <v-col>
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
              </v-col>
             </v-row>
         
                 <v-row>
                  <v-col>
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
                  </v-col>
                  <v-col>
                    <v-select
                dense
              label="Select Entry Mode "
              v-model="form.EntryModeId"
              :items="entrymodes"
              item-value="id"
              item-text="name"
              outlined
              :rules="[rules.required]"
            ></v-select>
                  </v-col>
                 </v-row>
        
               
            
                
          
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
    props:['applicant'],
      data(){

          return{
              AddModel:false,
              loading:false,
          form:{
            ApplicantTypeId:"",
            ProgrammeTypeId:"",
            CampusId:"",
            AttendenceTypeId:"",
            ApplicantId:this.applicant.id,
            AdmissionSessionId:""
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
      await this.$store.dispatch("entrymodes/getData");
        this.AddModel=true
    },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("applications/addItem",this.form); 
          this.$refs.form.reset()
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
    ,
    entrymodes() {
      return this.$store.state.entrymodes.records;
    }
  }
   }
  </script>