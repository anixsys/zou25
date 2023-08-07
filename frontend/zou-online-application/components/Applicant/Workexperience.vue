<template>
    <div>
        <v-card outlined class="mt-2">   
            <v-card-title>
                5. Working Experience
                <v-spacer/><v-btn outlined rounded color="primary" :to="`/otherqualification/`+uuid">Edit</v-btn>
            </v-card-title>     
            <v-card-text>
               <v-row class="mt-3">
                <v-col>
                  <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr>
                    <th>Company</th>
                    <th>Job Title</th>
                    <th>Duration</th>
                  </tr>
                  </thead>
                  <tbody>
                    <template v-if="applicant && applicant.workexperiences.length>0">
                     <tr v-for="other in applicant.workexperiences">
                       <td>{{ other.company }}</td>
                       <td>{{ other.jobtitle }}</td>
                       <td>{{ other.duration }}</td>                      
                     </tr>
                    </template>
                    <template v-else>
                      <tr>
                        <td colspan="3" class="text-center red--text">No records found</td>
                      </tr>
                    </template>
                  </tbody>
                 
                </template>
              </v-simple-table>
                </v-col>
               </v-row>
            </v-card-text>
          </v-card>
    </div>
</template>
<script>
 export default{
    props:['applicant','uuid']
 }
</script>