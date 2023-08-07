<template>
<v-container fluid>
          <v-stepper alt-labels flat>
      <v-stepper-header>
        <v-stepper-step step="1"  complete
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
      
   
    <v-row justify="center" align="center" class="mt-5">
        <v-col md="8" sm="12">
            <v-form
      ref="form"
      lazy-validation
    >
            <v-card>
        <v-system-bar
      window
      dark
      color="primary"
      class="white--text"
    >
      
      <span>1 Select Programme Type</span>
    </v-system-bar>
    <v-card-text>
        <v-row>
            <v-col>
                <v-select
              label="Choose programme Type"
              v-model="form.ProgrammeTypeId"
              :items="settings.programmetypes"
              item-value="id"
              item-text="name"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
            <v-col>
                <v-select
              label="Choose attendence Type"
              v-model="form.AttendenceTypeId"
              :items="settings.attendencetypes"
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
              label="choose applicant Type"
              v-model="form.ApplicantTypeId"
              :items="settings.applicanttypes"
              item-value="id"
              item-text="name"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
            <v-col>
                <v-select
              label="Choose campus nearest to you "
              v-model="form.CampusId"
              :items="settings.campuses"
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
              label="Choose Entry Mode"
              v-model="form.EntryModeId"
              :items="settings.entrymodes"
              item-value="id"
              item-text="name"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
            <v-col>
                <v-select
              label="Choose year to start study "
              v-model="form.AdmissionSessionId"
              :items="settings.sessions"
              item-value="id"
              item-text="year"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
        </v-row>
       
    </v-card-text>
    <v-card-actions>
        <v-btn large depressed to="/dashboard" color="error">Cancel</v-btn>
        <v-spacer/>
        <v-btn depressed large color="primary" @click="Submit">Submit </v-btn>
    </v-card-actions>
    </v-card>
    </v-form>
        </v-col>
    </v-row>
    
</v-container>
</template>
<script>
   export default{
    async fetch(){
    this.overlay = true;
    await this.$store.dispatch("settings/getData");
    this.overlay = false;
  },
  data(){
    return{
      overlay:false,
      rules: {
            required: value => !!value || 'Required.'
          },
          form:{
            ApplicantTypeId:"",
            ProgrammeTypeId:"",
            CampusId:"",
            AttendenceTypeId:"",
            AdmissionSessionId:"",
            EntryModeId:""

          },
      items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: 'Select Programme Type',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ]
    }
  },methods:{
    async Submit(){
        if (this.$refs.form.validate())
         {
       
        this.overlay = true;
        await this.$store.dispatch("applications/addItem",this.form);
        this.overlay = false;
            
      }
      }
  },computed:{
    settings() {
      return this.$store.state.settings.records;
    },
  }
   }
</script>