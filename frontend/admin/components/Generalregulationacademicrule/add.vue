<template>
    <div>
      <v-btn small depressed color="primary" @click="getRecords" :loading="loading"><v-icon>mdi-plus</v-icon> Add Rule</v-btn>
      <v-dialog v-model="AddModel" width="800px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New  Academic Rule
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-row>
              <v-col>
                <v-text-field
                label="level"
                v-model="form.level"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
              </v-col>
              <v-col>
                <v-select
                label="Semester"
                v-model="form.semester"
                :items="computesemesters"
                outlined
                :rules="[rules.required]"
              ></v-select>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                label="Required level"
                v-model="form.requiredlevel"
                outlined
              ></v-text-field>
              </v-col>
              <v-col>
                <v-select
                label="Required Semester"
                v-model="form.requiredsemester"
                :items="computesemesters"
                outlined
              ></v-select>
              </v-col>
            </v-row>
         <v-row>
          <v-col>
            <v-text-field
                label="Minimum Core Courses Pass(%)"
                v-model="form.corepercentage"
                type="number"
                max="100"
                min="0"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
          </v-col>
          <v-col>
            <v-text-field
                label="Minimum Elective Courses Pass(%)"
                v-model="form.electivepercentage"
                type="number"
                max="100"
                min="0"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
          </v-col>
         </v-row>         
            
              
             
              
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80" @click="AddModel=false">Cancel</v-btn>
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
     props:["regulation"],
      data(){
          return{
              AddModel:false,
              loading:false,
              facultylist:"",
          form:{
            generalregulationId:"",
            level :"",
            semeser:"",
            requiredlevel:"",
            requiredsemester:"",
            corepercentage:"",
            electivepercentage:""

          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async getRecords(){
      this.loading = true;
      await this.$store.dispatch("generalsetting/getRecords");
           this.AddModel=true
      this.loading =false
    },
   
    async Submit(){
      if(this.$refs.form.validate()){
        if(this.form.level == this.form.requiredlevel && this.form.semester == this.form.requiredsemester){
          this.$swal("error","Required  level and semester cannot be the same as level and semester","error")
          return;
        }
        if(this.form.level< this.form.requiredlvel){
          this.$swal("error","Required  level cannot be greater the level","error")
          return;
        }
          this.loading = true
          this.form.generalregulationId = this.regulation.id,
          await this.$store.dispatch("generalregulationacademicrule/addItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      },
      computed:{
        computesemesters(){
         var semesters = [];
         for (let index = 0; index < this.regulation.globalsettingtemplate.semesters; index++) {
            semesters.push(index+1)
          
         }

         return semesters
    }
      }
   }
  </script>