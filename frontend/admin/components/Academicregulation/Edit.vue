<template>
    <div>
      <v-list-item link   @click="getRecords">
          <v-list-item-title><v-icon small>mdi-pencil</v-icon> Edit</v-list-item-title>
      </v-list-item>
      <v-dialog v-model="AddModel" width="900px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Regulation for {{ programme.name }}
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
    props:["programme","regulation"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.regulation.id,
            intake:this.regulation.intake,
            programmeId:this.regulation.programmeId,
            programmeTypeId:this.regulation.programmetypeId,
            attendencetypeId:this.regulation.attendencetypeId,
            generalregulationId:this.regulation.generalregulationId,
            duration:this.regulation.duration,
            maximum:this.regulation.maximum,
            year:this.regulation.year

          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
        
      async getRecords(){
        this.overlay = true;
        await this.$store.dispatch("attendencetype/getData");
    await this.$store.dispatch("generalregulations/getListByProgrammetype",this.programme.programmetypeId);
    this.AddModel = true
    this.overlay = false;
      },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("academicregulations/updateItem",this.form); 
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