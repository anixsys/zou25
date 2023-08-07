<template>
    <div>
      <v-btn icon depressed color="primary" @click="Submit"><v-icon>mdi-file</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="700px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
             Entry Mode Documents
              <v-spacer/>
              <ModerequirementAdd :mode="mode"/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
              <v-card-text>
                <v-simple-table>
                  <template v-slot:default>
                    <thead>
                     <tr><th>Name</th><th></th></tr>
                    </thead>
                    <tbody>
                     <template v-if="requirements.length>0">
                      <tr v-for="rq in requirements" :key="rq.id">
                      <td>{{ rq.name }}</td>
                      <td class="d-flex justify-end mt-2">
                        <ModerequirementEdit :requirement="rq"/>
                        <ModerequirementDelete :requirement="rq"/>
                      </td>
                     </tr>
                    </template>
                    <template v-else>
                      <tr>
                        <td colspan="2" class="text-center red--text">No requirements</td>
                      </tr>
                    </template>
                    
                    </tbody>
                  </template>
                </v-simple-table>
              </v-card-text>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:['mode'],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            name:""
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){    
          this.loading = true
          await this.$store.dispatch("entrymoderequirements/getData",this.mode.id); 
           this.AddModel =true
          this.loading = false      
    }
      },
      computed:{
         requirements(){
          return this.$store.state.entrymoderequirements.records
         } 
      }
   }
  </script>