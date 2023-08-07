<template>
    <div>
        <v-card>
          <v-card-title>
            Registration Rules
            <v-spacer/>
         
          </v-card-title>
          <v-card-text>
            <v-simple-table>
                <template v-slot:default>
                    <thead>
                        <tr>
                            <th>Programme type</th>
                            <th class="text-center">Maximum registration courses</th>
                            <th class="text-right">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                          <template v-if="regulation && regulation.generalregulationregistrationrules.length>0">
                            <tr v-for="rule in regulation.generalregulationregistrationrules" :key="rule.id">
                                                         <td>{{ regulation.programmeType.name }}</td>
                             <td class="text-center">{{ rule.maximumcourses }}</td>
                             <td class="d-flex justify-end pt-2">
                              <GeneralregulationacademicruleEdit v-if="regulation.status !='APPROVED'" :rule="rule" :id="regulation.id"/>
                              <GeneralregulationacademicruleDelete  v-if="regulation.status !='APPROVED'" :rule="rule" :id="regulation.id"/>
                            </td>
                            </tr>
                          </template>  
                          <template v-else>
                            <tr>
                              <td colspan="5" class="text-center pt-5 pb-5">
                                <div class="red--text">
                                  No records found
                                </div>
                                <GeneralregulationregistrationruleAdd :id="regulation.id"/>
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