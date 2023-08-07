<template>
    <div>
        <v-card outlined class="mt-3">
            <v-card-title>
                Examination Periods
                <v-spacer/>
                <SemesterExamPeriodAdd :semester="semester"/>
            </v-card-title>
            <v-card-text>
                <v-simple-table>
                    <template v-slot:default>
                        <thead>
                            <tr>
                                <th>Type</th>
                                <th>Start Date</th>
                                <th>End Date</th>
                                <th>Status</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                           <template v-if="semester.examinationperiods && semester.examinationperiods.length>0">
                             <tr v-for="period in semester.examinationperiods">
                                <td>{{ period.name }}</td>
                              <td>{{ period.startDate|formatDate }}</td>
                              <td>{{ period.endDate|formatDate }}</td>
                              <td>{{ period.status }}</td>
                              <td class="d-flex">
                               <SemesterExamPeriodEdit :semester="semester" :period="period"/>
                                  <SemesterExamPeriodDelete :period="period" :semester="semester"/> 
                              </td>
                             </tr>
                           </template> 
                           <template v-else>
                            <tr>
                                <td colspan="4" class="text-center red--text"> No records found</td>
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
    props:['semester']
   }
</script>