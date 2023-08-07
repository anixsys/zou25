<template>
    <div>
        <v-card outlined>
            <v-card-title>
                Registration Periods
                <v-spacer/>
                <SemesterPeriodAdd :semester="semester"/>
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
                           <template v-if="semester.registrationperiods && semester.registrationperiods.length>0">
                             <tr v-for="period in semester.registrationperiods">
                                <td>{{ period.type }}</td>
                              <td>{{ period.startDate|formatDate }}</td>
                              <td>{{ period.endDate|formatDate }}</td>
                              <td>{{ period.status }}</td>
                              <td class="d-flex">
                               <SemesterPeriodEdit :semester="semester" :period="period"/>
                                  <SemesterPeriodDelete :period="period" :semester="semester"/> 
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