<template>
    <div>
      <v-btn fab depressed color="info" @click="getData"><v-icon>mdi-plus</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="900px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New Regulation for {{ programme.name }}
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-row>
              <v-col>
                <v-text-field
                label="Intake name"
                v-model="form.Name"
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
                v-model="form.MaximumYears"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                label="Year"
                v-model="form.Year"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-select
                label="Programme type"
                v-model="form.AttendencetypeId"
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
                v-model="form.GeneralregulationId"
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
    props:["programme"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            Name:"",
            ProgrammeId:"",
            ProgrammeTypeId:"",
            AttendencetypeId:"",
            GeneralregulationId:"",
            duration:"",
            MaximumYears:"",
            year:""

          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{

    async getData(){
      this.overlay = true;
        await this.$store.dispatch("attendencetype/getData");
    await this.$store.dispatch("generalregulations/getListByProgrammetype",this.programme.programmeTypeId);
    this.overlay = false;
    this.AddModel=true
    },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          this.form.ProgrammeId = this.programme.id,
          this.form.ProgrammeTypeId = this.programme.programmeTypeId
          await this.$store.dispatch("academicregulations/addItem",this.form); 
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