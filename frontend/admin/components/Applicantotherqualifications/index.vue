<template>
    <div>     
    <v-form ref="form" lazy-validation>
          <v-card class="mt-5" outlined>   
            <v-card-title>
                4. Add  Other Qualifications
            </v-card-title>     
            <v-card-text>
                <v-row>
                    <v-col>
                        <v-text-field dense  outlined v-model="form.institution"  :rules="[rules.required]"  label="Institution Name"/>
                    </v-col>
                    <v-col>
                      <v-text-field dense outlined v-model="form.qualification"  :rules="[rules.required]"  label="Qualification Name"/>
                     </v-col>
                    <v-col>
                      <v-text-field dense outlined v-model="form.year"  :rules="[rules.required]"  label="Completion Year"/>
                   </v-col>
                   <v-col>
                      <v-text-field dense outlined v-model="form.grade"  :rules="[rules.required]"  label="Grade Obtained"/>
                   </v-col>
                    <v-col class="text-right">
                        <v-btn small rounded outlined color="primary" @click="addRecord"><v-icon>mdi-plus</v-icon> Add</v-btn>
                    </v-col>
                </v-row>
               <v-row class="mt-3">
                <v-col>
                  <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr>
                    <th>Institution</th>
                    <th>Qualification Name</th>
                    <th>Year of Completion</th>
                    <th>Grade</th>
                    <th></th>
                  </tr>
                  </thead>
                  <tbody>
                    <template v-if="applicant && applicant.otherqualifications.length>0">
                     <tr v-for="other in applicant.otherqualifications">
                       <td>{{ other.institution }}</td>
                       <td>{{ other.qualification }}</td>
                       <td>{{ other.year }}</td>
                       <td>{{ other.grade }}</td>
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
              institution:"",
              qualification:"",
              grade:"",
              year:"",
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
          this.overlay = true;
          await this.$store.dispatch("applicantotherqualifications/addRecord",this.form); 
          this.$refs.form.reset()     
          this.overlay = false;
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
    this.overlay = true;
        await this.$store.dispatch("applicantotherqualifications/deleteRecord",id);
        this.overlay = false;
  }
})
    }
   
    }
  }
</script>