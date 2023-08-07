<template>
    <div>
        <v-btn small color="info" class="ml-1" @click="getRecord"><v-icon>mdi-file-tree</v-icon> System modulea</v-btn>
        <v-dialog v-model="AddModel"  fullscreen>
            <v-form ref="form" lazy-validation>
          <v-card>
              <v-system-bar
        window
        dark
      >
      <span><b>{{role.name}}</b> => System Modules</span>
      <v-spacer/>
      
        <v-icon @click="AddModel=false">mdi-close</v-icon>
      </v-system-bar>
            <v-card-text>
               <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr>
                      <th>System Modules</th>
                      <th>Sub Modules</th>
                    </tr>
                  </thead>
                  <tbody>
                    <template v-if="systemmodules.length>0">
                      <tr v-for="system in systemmodules">
                       <td>                        
                      <v-checkbox
                          color="primary"
                          value
                          :label="system.name"
                          id="systemid"
                          @change="assignsystemmodule($event,system.id)"
                          :input-value="system.rolesystemmodules.length>0 ? true :false"
                        ></v-checkbox>
                    
                       </td>
                       <td>
                         <v-simple-table dense v-if="system.rolesystemmodules.length>0">
                          <template v-slot:default>
                          <thead>
                            <tr>
                              <th>Sub Modules</th>
                              <th>Permissions</th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr v-for="submodule in system.submodules">
                              <td>
                                <v-checkbox
                          color="primary"
                          value
                          :label="submodule.name"
                          @change="assignsystemsubmodule($event,submodule.id,system.rolesystemmodules[0].id)"
                          :input-value="submodule.rolesystemsubmodules.length>0 ? true :false"
                        ></v-checkbox>
                            </td>
                            <td>
                              <table dense v-if="submodule.rolesystemsubmodules.length>0 ">
                                <tbody>
                                  <tr>
                                    <td v-for="permission in submodule.permissions">
                                      <v-checkbox
                          color="primary"
                          value
                          :label="permission.name"
                          :input-value="permission.rolepermissions.length>0 ? true :false"
                          @change="assignpermission($event,permission.id,submodule.rolesystemsubmodules[0].id)"
                        ></v-checkbox>
                                    </td>
                                  </tr>
                                </tbody>
                              </table>
                            </td>
                            </tr>
                          </tbody>
                        </template>
                        </v-simple-table>
                       </td>
                      </tr>
                    </template>
                    <template v-else>
                      <tr>
                        <td colspan="4" class="text-center red--text">No  records found</td>
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
      props:["role"],
        data(){
            return{
             AddModel:false,
             loading:false,             
          }            
        }
        ,methods:{            
              async getRecord(){
                  await this.$store.dispatch("roles/getSystemmodules",this.role.id);
                 this.AddModel=true
              },
              async assignsystemmodule(event,id){
                if(event && event>0){
                  var payload = {RoleId:this.role.id,SystemModuleId:id,action:"ASSIGN"}
                  await this.$store.dispatch("roles/AssignSystemModule",payload);
                }else{
                  var payload = {RoleId:this.role.id,SystemModuleId:id,action:"UNASSIGN"}
                  await this.$store.dispatch("roles/AssignSystemModule",payload);
                }
              },
              async assignsystemsubmodule(event,submoduleId,Id){
                if(event && event>0){
                  var payload = {RoleId:this.role.id,RoleSystemmoduleId:Id,SystemSubmoduleId:submoduleId,action:"ASSIGN"}
                  await this.$store.dispatch("roles/AssignSystemSubmodule",payload);
                }else{
                  var payload = {RoleId:this.role.id,RoleSystemmoduleId:Id,SystemSubmoduleId:submoduleId,action:"UNASSIGN"}
            
                  await this.$store.dispatch("roles/AssignSystemSubmodule",payload);
                }
              },
              async assignpermission(event,permissionId,Id){
                if(event && event>0){
                  var payload = {RoleId:this.role.id,RoleSystemSubmoduleId:Id,permissionId:permissionId,action:"ASSIGN"}
                  await this.$store.dispatch("roles/AssignPermission",payload);
                }else{
                  var payload = {RoleId:this.role.id,RoleSystemSubmoduleId:Id,permissionId:permissionId,action:"UNASSIGN"}
                   await this.$store.dispatch("roles/AssignPermission",payload);
                }
              }
             
        },
        computed:{
          systemmodules() {
        return this.$store.state.roles.systemmodules;
      },
    }
     }
    </script>