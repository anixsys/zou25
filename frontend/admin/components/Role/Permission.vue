<template>
    <div>
        <v-btn  color="success" depressed @click="getRecord">Permissions</v-btn>
        <v-dialog v-model="AddModel" width="400px">
            <v-form ref="form" lazy-validation>
          <v-card>
              <v-system-bar
              color="green"
        window
        dark
      >
      <span><b>{{submodule.name}}</b> => Permissions</span>
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
                        <template v-if="permissions.length>0">
                           <tr v-for="permission in permissions" :key="permission.id">
                             <td>{{permission.name }}</td>
                             <td class="d-flex justify-end pt-2 pb-2">
                                <template v-if="checkRole(permission.rolePermissions)">
                                    <v-btn color="error" depressed  @click="Assign(permission.id, 'UNASSIGN')">Unassign</v-btn>
                              
                                </template>
                                <template v-else>
                                    <v-btn color="primary" depressed  @click="Assign(permission.id,'ASSIGN')">Assign</v-btn>
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
      props:["role",'submodule','roleSubmoduleId'],
        data(){
            return{
             AddModel:false,
             loading:false,             
          }            
        }
        ,methods:{            
              async getRecord(){
                  await this.$store.dispatch("roles/getPermissions",this.submodule.id);
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
              async Assign(id,action){
                var payload ={
                              RoleId:this.role.id,
                              PermissionId:id,
                              RoleSubmoduleId:this.roleSubmoduleId,
                              SubModuleId:this.submodule.id,
                              Action:action
                            }
                this.loading = true
              await this.$store.dispatch("roles/AssignPermission",payload); 

        this.loading = false
              }
        },
        computed:{
          permissions() {
        return this.$store.state.roles.permissions;
      },
    }
     }
    </script>