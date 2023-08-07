<template>
    <div>
      <div>
      <v-btn fab depressed small color="secondary" @click="AddModel=true">{{ programme.history.length }}</v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
             Programme History
              <v-spacer/>
              <v-btn  fab small depressed color="error" @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
               <ProgrammeHistoryAdd :programmeId="programme.id"/>
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
                          <template v-if="programme && programme.history.length>0">
                            <tr v-for="his in programme.history">
                             <td>{{his.code  }}</td>
                             <td class="d-flex justify-end">
                              <ProgrammeHistoryEdit :history="his"/>
                              <ProgrammeHistoryDelete :history="his"/>
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