<template>
  <div>
    <div>
    <v-btn fab depressed small color="accent" @click="AddModel=true">{{ programme.specializations.length }}</v-btn>
    <v-dialog v-model="AddModel" width="500px">
        <v-form ref="form" lazy-validation>
      <v-card>
        <v-card-title>
           Specializations
            <v-spacer/>
            <v-btn  fab small depressed color="error" @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
            <ProgrammeSpecializationAdd :programmeId="programme.id"/>
        </v-card-title>
        <v-card-text>
            <v-simple-table>
                <template v-slot:default>
                    <thead>
                        <tr>
                            <th>Code</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <template v-if="programme && programme.specializations.length>0">
                          <tr v-for="spec in programme.specializations">
                           <td>{{spec.area  }}</td>
                           <td class="d-flex justify-end">
                              <ProgrammeSpecializationEdit :specialization="spec"/>
                              <ProgrammeSpecializationDelete :specialization="spec"/>
                           </td>
                         </tr>
                        </template>
                        <tr v-else><td colspan="2" class="text-center red--text">No records found</td></tr>
                    </tbody>
                </template>
            </v-simple-table>
        </v-card-text>
      </v-card>
    </v-form>
    </v-dialog>
  </div>
  </div>
</template>
<script>
 export default{
    props:['programme'],
    data(){
        return{
            AddModel:false
        }
    }  
 }
</script>