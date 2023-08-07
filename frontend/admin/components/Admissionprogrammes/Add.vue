<template>
    <div>
      <v-btn fab depressed color="primary" @click="getData"><v-icon>mdi-plus</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="900px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New Admission Programme
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-row>
                <v-col>
                    <v-select
                label="Select Programme"
                :items="programmes"
                item-text="description"
                item-value="id"
                v-model="form.programmeId"
                outlined
                dense
                :rules="[rules.required]"
              ></v-select>
                </v-col>
                <v-col>
                    <v-select
                label="Select Attendence Type"
                :items="attendencetypes"
                item-text="name"
                item-value="id"
                multiple
                dense
                chips
                v-model="attendencetype"
                outlined
                :rules="[rules.required]"
              ></v-select>
                </v-col>
            </v-row>
            <v-row>
                <v-col>
                  <label>Entry Requirements</label>
                    <client-only>
  <VueEditor v-model="form.EntryRequirements" :rules="[rules.required]" />
</client-only>
                  
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <label>Career Prospects</label>
                    <client-only>
  <VueEditor v-model="form.CareerProspects" :rules="[rules.required]" />
</client-only>
                    
                </v-col>
              </v-row>
            </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80" @click="AddModel=true">Cancel</v-btn>
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
    props:['admission'],
      data(){
          return{
              AddModel:false,
              loading:false,
              attendencetype:"",
          form:{
            programmeId:"",
            AdmissionTemplateId:"",
            attendencetypes:"",
            EntryRequirements:"",
            CareerProspects:""
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async getData(){
        await this.$store.dispatch("programmes/getProgrammesByType",this.admission.programmetypeId); 
        await this.$store.dispatch("attendencetype/getData");
        this.AddModel=true
    },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          this.form.AdmissionTemplateId = this.admission.id
          this.form.attendencetypes = JSON.stringify(this.attendencetype)
          await this.$store.dispatch("admissionprogrammes/addItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      },
    computed:{
    attendencetypes() {
      return this.$store.state.attendencetype.records;
    },   programmes() {
      return this.$store.state.programmes.records;
    }
  }
   }
  </script>