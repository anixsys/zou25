<template>
    <div>     
    <v-form ref="form" lazy-validation>
          <v-card class="mt-5">   
            <v-card-title>
                5. Add Your Working Experience
            </v-card-title>     
            <v-card-text>
                <v-row>
                    <v-col>
                        <v-text-field dense outlined v-model="form.Company"  :rules="[rules.required]"  label="Company Name"/>
                    </v-col>
                    <v-col>
                      <v-text-field dense outlined v-model="form.Jobtitle"  :rules="[rules.required]"  label="Job Title"/>
                     </v-col>
                    <v-col>
                      <v-text-field dense outlined v-model="form.duration"  :rules="[rules.required]"  label="Duration " placeholder="for example 2010 to 2018"/>
                   </v-col>
                   
                    <v-col class="text-right">
                        <v-btn rounded outlined color="primary" @click="addRecord"><v-icon>mdi-plus</v-icon> Add</v-btn>
                    </v-col>
                </v-row>
               <v-row class="mt-3">
                <v-col>
                  <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr>
                    <th>Company</th>
                    <th>Job Title</th>
                    <th>Duration</th>
                    <th></th>
                  </tr>
                  </thead>
                  <tbody>
                    <template v-if="applicant && applicant.workexperiences.length>0">
                     <tr v-for="other in applicant.workexperiences">
                       <td>{{ other.company }}</td>
                       <td>{{ other.jobtitle }}</td>
                       <td>{{ other.duration }}</td>
                       <td class="text-right">
                        <v-btn small color="error" @click="deleteRecord(other.id)">Delete</v-btn>
                       </td>
                     </tr>
                    </template>
                    <template v-else>
                      <tr>
                        <td colspan="5" class="text-center red--text">No records found</td>
                      </tr>
                    </template>
                  </tbody>
                 
                </template>
              </v-simple-table>
                </v-col>
               </v-row>
            </v-card-text>
          </v-card>
        </v-form>
       
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
    props:['applicant'],
    data(){
        return{
            ProgrammeDialog:false,
            overlay:false,
            form:{
              Company:"",
              Jobtitle:"",
              duration:"",
              applicantId:this.applicant.id
            },
              rules: {
            required: value => !!value || 'Required.'
          }
        }
    },
    methods:{
       async addRecord(){
        if (this.$refs.form.validate()) {
         
          await this.$store.dispatch("applicantworkexperience/addRecord",this.form); 
          this.$refs.form.reset()     
        
        }
       },
       async deleteRecord(id){
        this.$swal({
  title: 'Are you sure?',
  text: "You want to Permanently delete record ",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes, delete it!'
}).then(async (result) => {
  if (result.isConfirmed) {
          var payload = {id:id,applicantId:this.applicant.id}
        await this.$store.dispatch("applicantworkexperience/deleteRecord",payload);
        
  }
})
    }
   
    }
  }
</script>