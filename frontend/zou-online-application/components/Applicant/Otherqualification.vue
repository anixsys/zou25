<template>
    <div>
        <v-card outlined class="mt-3">
                <v-card-title>4. Other Qualifications <v-spacer/><v-btn outlined rounded color="primary" :to="`/otherqualification/`+uuid">Edit</v-btn></v-card-title>
                <v-card-text>
                  <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr>
                    <th>Institution</th>
                    <th>Qualification Name</th>
                    <th>Year of Completion</th>
                    <th>Grade</th>
                  </tr>
                  </thead>
                  <tbody>
                    <template v-if="applicant && applicant.otherqualifications.length>0">
                     <tr v-for="other in applicant.otherqualifications">
                       <td>{{ other.institution }}</td>
                       <td>{{ other.qualification }}</td>
                       <td>{{ other.year }}</td>
                       <td>{{ other.grade }}</td>
                     </tr>
                    </template>
                    <template v-else>
                      <tr>
                        <td colspan="4" class="text-center red--text">No records found</td>
                      </tr>
                    </template>
                  </tbody>
                 
                </template>
              </v-simple-table>
                </v-card-text>
            </v-card>
    </div>
</template>
<script>
 export default{
    props:['applicant','uuid']
 }
</script>