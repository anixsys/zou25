<template>
    <div>
        <v-card outlined class="mt-2">
        <v-card-title>
         Academic Results
            <v-spacer/>
           
        </v-card-title>
        <v-card-text>
                    <v-simple-table>
                <template v-slot:default>
                    <thead>
                        <tr>
                            <th>Level</th>
                            <th>Subject</th>
                            <th>Grade</th>
                        </tr>
                    </thead>
                    <tbody>
                        <template v-if="applicant && applicant.subjects.length>0">
                          <tr v-for="subject in applicant.subjects" :key="subject.id">
                        <td>{{ subject.level }}</td>
                        <td>
                          {{ subject.subject.name }}
                        </td>
                        <td>
                            {{ subject.grade }}
                        </td>
                     
                    </tr>
                        </template>
                        <template v-else>
                            <tr>
                                <td  colspan="4" class="text-center red--text">No Subjects Selected As Yet</td>
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
      props:['applicant']
   }
  </script>