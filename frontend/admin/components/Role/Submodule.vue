<template>
    <div>
        <v-btn  color="info" depressed @click="getRecord">Submodules</v-btn>
        <v-dialog v-model="AddModel" width="600px">
            <v-form ref="form" lazy-validation>
          <v-card>
              <v-system-bar
              color="indigo"
        window
        dark
      >
      <span><b>{{systemmodule.name}}</b> => Sub Modules</span>
      <v-spacer/>
        
        <v-icon @click="AddModel=false">mdi-close</v-icon>
      </v-system-bar>
            <v-card-text>
                <v-simple-table class="mt-3">
                   <template v-slot:default>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th class="d-flex justify-end p-2">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <template v-if="submodules.length>0">
                           <tr v-for="submodule in submodules" :key="submodule.id">
                             <td>{{submodule.name }}</td>
                             <td class="d-flex justify-end pt-2 pb-2">
                                <template v-if="checkRole(submodule.roles)">
                                    <v-btn color="error" depressed  @click="Assign(submodule.id, 'UNASSIGN')">Unassign</v-btn>
                                    <RolePermission :role="role" :submodule="submodule" :roleSubmoduleId="getrolesubmodule(submodule.roles)"/>
                          
                                </template>
                                <template v-else>
                                    <v-btn color="primary" depressed  @click="Assign(submodule.id,'ASSIGN')">Assign</v-btn>
                                         </template>
                             </td>

                           </tr>
                        </template>
                        <template v-else>
                           <tr><td colspan="2" class="text-center red--text">No records found</td></tr>
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
      props:["role",'systemmodule','roleSystemmoduleId'],
        data(){
            return{
             AddModel:false,
             loading:false,             
          }            
        }
        ,methods:{            
              async getRecord(){
                  await this.$store.dispatch("roles/getSubmodules",this.systemmodule.id);
                 this.AddModel=true
              },
              checkRole(roles){
                var  assign = false;
                     roles.forEach(element => {
                          if(element.RoleId == this.role.Id){
                            assign = true
                          } 
                     });
                     return assign;
              },
              getrolesubmodule(roles){
                var  assign = null;
                     roles.forEach(element => {
                          if(element.RoleId == this.role.Id){
                            assign = element.id
                          } 
                     });
                     return assign;
              },
              async Assign(id,action){
                var payload ={
                             RoleId:this.role.id,
                             SubmoduleId:id,
                              RoleSystemmoduleId:this.roleSystemmoduleId,
                              SystemModuleId:this.systemmodule.id,
                              Action:action
                            }
                this.loading = true
              await this.$store.dispatch("roles/AssignSubModule",payload); 

        this.loading = false
              }
        },
        computed:{
          submodules() {
        return this.$store.state.roles.submodules;
      },
    }
     }
    </script>