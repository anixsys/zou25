<template>
    <div>
        <v-card class="mt-5">
          <v-card-title>
           Academic Rules
            <v-spacer/>
            <GeneralregulationacademicruleAdd v-if="regulation.status !='APPROVED'" :regulation="regulation"/>
          </v-card-title>
          <v-card-text>
            <v-simple-table>
                <template v-slot:default>
                    <thead>
                        <tr>
                            <th>Level</th>
                            <th>Semester</th>
                            <th>Required level</th>
                            <th>Required Semester</th>
                            <th>Core Course</th>
                            <th>Elective Course</th>
                            <th class="text-right">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                          <template v-if="regulation && regulation.generalregulationacademicrules.length>0">
                            <tr v-for="rule in regulation.generalregulationacademicrules" :key="rule.id">
                            
                             <td class="text-center">{{ rule.level}}</td>
                             <td class="text-center">{{ rule.semester}}</td>
                             <td class="text-center">{{ rule.requiredlevel}}</td>
                             <td class="text-center">{{ rule.requiredsemester}}</td>
                             <td class="text-center">{{ rule.corepercentage+`%`}}</td>
                             <td class="text-center">{{ rule.electivepercentage+`%`}}</td>
                             <td class="d-flex justify-end pt-2">
                              <GeneralregulationregistrationruleEdit v-if="regulation.status !='APPROVED'" :rule="rule" :id="regulation.id"/>
                              <GeneralregulationacademicruleDelete v-if="regulation.status !='APPROVED'" :rule="rule" :id="regulation.id"/>
                            </td>
                            </tr>
                          </template>  
                          <template v-else>
                            <tr>
                              <td colspan="8" class="text-center pt-5 pb-5">
                                <div class="red--text">
                                  No records found
                                </div>
                               
                            </td>
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
  props:["regulation"]
}
</script>