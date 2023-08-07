<template>
  <div>
      <v-btn small color="info" class="ml-2" @click="getRecords"><v-icon>mdi-file-tree</v-icon> Submodules</v-btn>
      <v-dialog v-model="AddModel" width="800px">
          <v-form ref="form" lazy-validation>
        <v-card>
            <v-system-bar
      window
      dark
    >
    <span><b>{{systemmodule.name}}</b> => Sub Modules</span>
    <v-spacer/>
      
      <v-icon @click="AddModel=false">mdi-close</v-icon>
    </v-system-bar>
          <v-card-text>
            <SubmodulesAdd :systemmodule="systemmodule"/>
            <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>ID</th>
              <th>Icon</th>
              <th>Name</th>
              <th>Url</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="submodules.length>0">
            <tr v-for="submodule in submodules" :key="submodule.id">
             <td>{{submodule.id }}</td>
             <td><v-icon>{{submodule.icon }}</v-icon></td>
             <td>{{submodule.name }}</td>
             <td>{{submodule.url }}</td>
             <td class="d-flex justify-end pt-2">
              <SubmodulesEdit :submodule="submodule"/>
              <SubmodulesDelete :submodule="submodule"/>
              <Permissions :submodule="submodule"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="5" class="text-center red--text">No records found</td></tr>
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
    props:["systemmodule"],
      data(){
          return{
           AddModel:false  
        }
          
      },methods:{
            async getRecords(){
                await this.$store.dispatch("submodules/getData",this.systemmodule.id);
                this.AddModel=true
            }
      },
      computed:{
    submodules() {
      return this.$store.state.submodules.records;
    },
  }
   }
  </script>