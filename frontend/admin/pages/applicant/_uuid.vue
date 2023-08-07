<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
<v-container fluid>
  <v-card>
    <v-card-title>
      Application
    </v-card-title>
    <v-card-text>
        <template v-if="application.applicant">
                <v-card outlined>
                  <v-card-title>1. Personal Details</v-card-title>
                  <v-card-text>
                    <v-simple-table dense>
                      <template v-slot:default>
                        <tbody>
                          <tr><th>Title</th><td>{{ application.applicant.title }}</td></tr>
                          <tr><th>Name</th><td>{{ application.applicant.name }}</td></tr>
                          <tr><th>Surname</th><td>{{ application.applicant.surname }}</td></tr>
                          <tr><th>Marital Status</th><td>{{ application.applicant.maritalStatus }}</td></tr>
                          <tr><th>Maiden name</th><td>{{ application.applicant.maidenname }}</td></tr>
                          <tr><th>D.O.B</th><td>{{ application.applicant.dob }}</td></tr>
                          <tr><th>Passport number</th><td>{{ application.applicant.passportnumber }}</td></tr>
                          <tr><th>National ID</th><td>{{ application.applicant.nationalID }}</td></tr>
                          <tr><th>Gender</th><td>{{ application.applicant.gender }}</td></tr>
                          <tr><th>Address</th><td>{{ application.applicant.address }}</td></tr>
                          <tr><th>City</th><td>{{ application.applicant.city }}</td></tr>
                          <tr><th>Country</th><td>{{ application.applicant.country }}</td></tr>
                        </tbody>
                      </template>
                    </v-simple-table>
                  </v-card-text>
                </v-card>
            
              </template>
              <template v-if="application">
                <v-card class="mt-3" outlined>
                  <v-card-title>2. Application Details</v-card-title>
                  <v-card-text>
                    <v-simple-table dense>
                      <template v-slot:default>
                        <tbody>
                          <tr><th>Application Number</th><td>{{ application.appNumber }}</td></tr>
                          <tr><th>Application Type</th><td>{{ application.applicanttype ? application.applicanttype.name :"" }}</td></tr>
                          <tr><th>Programme Type</th><td>{{ application.programmeType ? application.programmeType.name :"" }}</td></tr>
                          <tr><th>Campus</th><td>{{ application.campus ? application.campus.name :""  }}</td></tr>
                          <tr><th>Application fee</th><td>{{ application.paymentStatus }}</td></tr>
                          <tr><th>Application Status</th><td>{{ application.approvalStatus }}</td></tr>
                       
                        </tbody>
                      </template>
                    </v-simple-table>
                  </v-card-text>
                </v-card>            
                
              </template>
              <template v-if="application.applicant && application.applicant.subjects.length>0">
                <v-card class="mt-3" outlined>
                  <v-card-title>3. Academic Results</v-card-title>
                  <v-card-text>
                    <v-simple-table dense>
                      <template v-slot:default>
                        <thead>
                          <tr>
                            <th>Level</th>
                            <th>Subject</th>
                            <th>Grade</th>
                          </tr>
                        </thead>
                        <tbody>
                          <tr v-for="subject in application.applicant.subjects">
                           <td>{{ subject.level }}</td>
                           <td>{{ subject.subject.name }}</td>
                           <td>{{ subject.grade}}</td>
                          </tr>
                           
                        </tbody>
                      </template>
                    </v-simple-table>
                  </v-card-text>
                </v-card>            
                
              </template>
              <template v-if="application.applicant && application.applicant.otherqualifications">
                <v-card class="mt-3" outlined>
                  <v-card-title>4. Other Qualifications</v-card-title>
                  <v-card-text>
                    <v-simple-table>
                      <template v-slot:default>
                        <thead>
                          <tr><th>Institution</th><th>Qualification Name</th><th>Year</th><th>Grade</th></tr>
                        </thead>
                        <tbody>
                          <tr v-for="other in application.applicant.otherqualifications">
                            <td>{{ other.institution }}</td>
                            <td>{{ other.qualification }}</td>
                            <td>{{ other.year }}</td>
                            <td>{{ other.grade }}</td>
                          </tr>
                        </tbody>
                      </template>
                    </v-simple-table>
                  
                  </v-card-text>
                </v-card>            
                
              </template>
              <template v-if="application.applicant && application.applicant.workexperiences.length>0">
                <v-card class="mt-3" outlined>
                  <v-card-title>5. Work Experience</v-card-title>
                  <v-card-text>
                    <v-simple-table>
                      <template v-slot:default>
                        <thead>
                          <tr><th>Company</th><th>Job Title</th><th>Duration</th></tr>
                        </thead>
                        <tbody>
                          <tr v-for="work in application.applicant.workexperiences">
                            <td>{{work.company }}</td>
                            <td>{{ work.jobtitle }}</td>
                            <td>{{ work.duration }}</td>
                          </tr>
                        </tbody>
                      </template>
                    </v-simple-table>
                  
                  </v-card-text>
                </v-card>            
                
              </template>
              <template v-if="application.applicant && application.applicant.applicationDocuments.length>0">
                  <v-card class="mt-3" outlined>
                    <v-card-title>6. Acompanying Documents</v-card-title>
                    <v-card-text>
                      <v-simple-table>
                            <template v-slot:default>
                                <thead>
                                    <tr>
                                        <th>Document Name</th>
                                        <th>Status</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                
                                    <tr v-for="doc in application.applicant.applicationDocuments">
                                     <td>{{ doc.requireddocument.document.name }}</td>
                                     <td><v-chip small :class="doc.requireddocument.status=='MANDETORY' ? 'error' :'info'"> {{ doc.requireddocument.status }}</v-chip></td>
                                     <td class="text-right">
                                        <v-btn color="primary" depressed @click=" viewdocument(doc.filename)">View Doc</v-btn>
                                    </td>
                                    </tr>
                                
                                </tbody>
                            </template>
                        </v-simple-table>
                    </v-card-text>
                  </v-card>
              </template>
              <template v-if="application.applicationprogrammes && application.applicationprogrammes.length>0">
                  <v-card class="mt-3" outlined>
                    <v-card-title>
                        7. Selected Programmes
                        <v-spacer/>
                        <v-btn color="error"  small @click="rejectall">Reject All</v-btn>
                    </v-card-title>
                    <v-card-text>
                      <v-simple-table>
                            <template v-slot:default>
                                <thead>
                                    <tr>
                                        <th>Programme</th>
                                        <th>Attendence Type</th>
                                        <th>Status</th>
                                        <th>Actions</th>
                                    </tr>
                                </thead>
                                <tbody>
                                
                                    <tr v-for="prog in application.applicationprogrammes">
                                     <td>{{ prog.programme.description }}</td>
                                     <td>{{ prog.attendenceType.name }}</td>
                                     <td>{{ prog.status }}</td>
                                     <td class="text-right">
                                        <v-btn color="success"  small @click="makedecison(prog.id,prog.programme.description)">Approve</v-btn>  
                                     </td>
                                    </tr>
                                
                                </tbody>
                            </template>
                        </v-simple-table>
                    </v-card-text>
                  </v-card>
              </template>
    
    </v-card-text>
  </v-card>
</v-container>

  
    </div>
</template>
<script>
  export default{
    layout:"mainlayout",
    async fetch() {
    this.overlay = true;
    this.uuid = this.$route.params.uuid
    await this.$store.dispatch("applicants/getRecord",this.uuid);
    this.overlay = false;
  },
    data(){
        return{
          overlay: false,
          uuid:"",
            items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: 'Applications',
          disabled: false,
          href: '/applicants',
        },
        {
          text: 'Application',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    methods:{
       viewdocument(name){
        let params = `scrollbars=no,resizable=no,status=no,location=no,toolbar=no,menubar=no,width=800,height=800,left=100,top=100`;
         open('https://localhost:7033/api/Application/file/download/'+name,'test',params)
    
       },
       makedecison(id,name){
        this.$swal({
  title: 'Are you sure?',
  text: "You want to accept applicant into :"+name,
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes, Accept'
}).then(async (result) => {
  if (result.isConfirmed) {
    var payload ={id:this.application.id,ApplicationProgrammeId:id,status:"ACCEPTED",uuid:this.uuid}
    await this.$store.dispatch("applicants/makedecision",payload); 
  }
})
       },
       rejectall(){
        this.$swal({
  title: 'Are you sure?',
  text: "You want to reject all programmes applied ",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes, Accept'
}).then(async (result) => {
  if (result.isConfirmed) {
    var payload ={uuid:this.uuid}
    await this.$store.dispatch("applicants/rejectall",payload); 
  }
})
       }
    },
    computed:{
    application() {
      return this.$store.state.applicants.record;
    },
  }
  }
</script>