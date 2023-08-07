<template>
    <div>
        <v-btn small color="info" class="ml-1" @click="getRecords"><v-icon>mdi-file-tree</v-icon> Permissions</v-btn>
        <v-dialog v-model="AddModel" width="400px">
            <v-form ref="form" lazy-validation>
          <v-card>
              <v-system-bar
        window
        dark
        color="primary"
      >
      <span><b>{{submodule.name}}</b> => Permissions</span>
      <v-spacer/>
        
        <v-icon @click="AddModel=false">mdi-close</v-icon>
      </v-system-bar>
            <v-card-text>
              <PermissionsAdd :submodule="submodule"/>
              <v-simple-table>
          <template v-slot:default>
            <thead>
              <tr>
                <th>ID</th>
                <th>Name</th>
                <th class="text-right">
                  Actions
                </th>
              </tr>
            </thead>
            <tbody>
            <template v-if="permissions.length>0">
              <tr v-for="permission in permissions" :key="permission.id">
               <td>{{permission.id }}</td>
               <td>{{permission.name }}</td>
               <td class="d-flex justify-end">
                <PermissionsEdit :permission="permission"/>
                <PermissionsDelete :permission="permission"/>
               </td>
              </tr>
             </template>
             <template v-else>
                  <tr><td colspan="3" class="text-center red--text">No records found</td></tr>
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
      props:["submodule"],
        data(){
            return{
             AddModel:false  
          }
            
        },methods:{
              async getRecords(){
                  await this.$store.dispatch("permissions/getData",this.submodule.id);
                  this.AddModel=true
              }
        },
        computed:{
      permissions() {
        return this.$store.state.permissions.records;
      },
    }
     }
    </script>