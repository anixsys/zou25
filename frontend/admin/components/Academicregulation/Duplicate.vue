<template>
    <div>
      <v-list-item link  @click="addModel=true">
          <v-list-item-title><v-icon small>mdi-content-copy</v-icon> Duplicate</v-list-item-title>
        </v-list-item>
        <v-dialog v-model="AddModel" width="900px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Duplicate Regulation for {{ programme.name }}
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-row>
              <v-col>
                <v-text-field
                label="Intake name"
                v-model="form.intake"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                label="Programme duration(Years)"
                v-model="form.duration"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                label="Maximum Permitted Duration"
                v-model="form.maximum"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                label="Year"
                v-model="form.year"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-select
                label="Programme type"
                v-model="form.attendencetypeId"
                :items="attendencetypes"
                item-text="name"
                item-value="id"
                outlined
                :rules="[rules.required]"
              ></v-select>
              </v-col>
              <v-col>
                <v-select
                label="Attached General Regulation"
                v-model="form.generalregulationId"
                :items="generalregulations"
                item-value="id"
                item-text="name"
                outlined
                :rules="[rules.required]"
              ></v-select>
              </v-col>
            </v-row>
              
            
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80" to="/dashboard">Cancel</v-btn>
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
    props:["programme",'regulation'],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            intake:"",
            programmeId:"",
            programmeTypeId:"",
            attendencetypeId:"",
            generalregulationId:"",
            duration:"",
            maximum:"",
            year:"",
            academicregulationId:""

          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },
      async created(){
        this.overlay = true;
        await this.$store.dispatch("attendencetype/getData");
    await this.$store.dispatch("generalregulations/getListByProgrammetype",this.programme.programmetypeId);
    this.overlay = false;
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          this.form.programmeId = this.programme.id,
          this.form.programmeTypeId = this.programme.programmetypeId
          this.form.academicregulationId = this.regulation.id
          await this.$store.dispatch("academicregulations/duplicateItem",this.form); 
         // this.$refs.form.reset()
          this.loading = false
      }
    }
      },
    computed:{
    generalregulations() {
      return this.$store.state.generalregulations.records;
    },
    attendencetypes() {
      return this.$store.state.attendencetype.records;
    }
  }
   }
  </script>