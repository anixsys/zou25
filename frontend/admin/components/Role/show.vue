<template>
    <div>
        <v-btn depressed text color="primary" @click="getRecord"><v-icon>mdi-file-tree</v-icon></v-btn>
        <v-dialog v-model="AddModel" fullscreen>
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
              <div class="d-flex justify-end">
             <v-btn  color="primary" :loading="loading" v-if="systemmodule.length>0 && permission.length>0 && submodule.length>0" @click="assignFunctions">Update Permissions</v-btn>
             </div>
             <v-simple-table class="mt-3">
          <template v-slot:default>
            
            <tbody>
            <template v-if="systemmodules.length>0">
              <tr v-for="( item, index) in systemmodules">
              
               <td>   <v-checkbox
                       v-model="systemmodule"
                       :value="item.Id"
                      :label="item.Name"
                      @change="sysetemmoduleselected(item.Id)"
                    ></v-checkbox>
                  </td>
                <td>
                  <v-simple-table>
                    <template v-slot:default>
                     <thead>
                      <tr>
                        <th class="indigo lighten-5">Submodule</th>
                        <th class="blue lighten-3">Permissions</th>
                      </tr>
                     </thead>
                    <tbody>
                      <tr v-for=" submod in item.submodules">
                       <td class="indigo lighten-5">
                        <v-checkbox
                        v-model="submodule"
                        :value="submod.Id"
                      :label="submod.Name"
                      @change="addSubmodules(item.Id,submod.Id)"
                    ></v-checkbox>
                       </td>
                       <td>
                        <div class="d-flex justify-space-between">
                        <div v-for="perm in submod.permissions">
                        <v-checkbox
                        v-model="permission"
                       :value="perm.id"
                      :label="perm.Name"
                      @change="addPermission(item.Id,submod.Id,perm.id)"
                    ></v-checkbox>
                    </div>
                  </div>
                       </td>
                      </tr>
                    </tbody>
                    </template>
                  </v-simple-table>
                </td>
              </tr>
             </template>
             <template v-else>
                  <tr><td colspan="5" class="text-center red--text">No modules assigned to Role</td></tr>
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
             systemmodule:[], 
             submodule:[],
             permission:[],
             loading:false,
             payloadarray:[],
             systemmodulecheck:null
             
          }
            
        }
        ,methods:{

              sysetemmoduleselected(id){
                var el ={systemmoduleId : id,submodules:[]}
                this.payloadarray.push(el)
              },
              addSubmodules(systemmoduleId,submoduleId){
                 if(this.payloadarray.length>0){
                 for (let index = 0; index < this.payloadarray.length; index++) {
                  const element = this.payloadarray[index];
                  if(element.systemmoduleId==systemmoduleId){
                     var el = {submoduleId:submoduleId,permissions:[]}
                     element.submodules.push(el)
                  }
                  
                 }
                 }
              },
              addPermission(systemmoduleId,submoduleId,permissionId){
                 if(this.payloadarray.length>0){
                 for (let index = 0; index < this.payloadarray.length; index++) {
                  const element = this.payloadarray[index];
                  if(element.systemmoduleId==systemmoduleId){
                     for (let i= 0; i < element.submodules.length; i++) {
                      const ele = element.submodules[i];
                      if(ele.submoduleId==submoduleId){
                         var el = {permissionId:permissionId}
                         ele.permissions.push(el)
                      }
                     
                     }
                     
                  }
                  
                 }
                 }
              },
              async getRecord(){
                  await this.$store.dispatch("roles/getitems",this.role.id);
                  var records = this.systemmodules;
                
                   records.forEach(record => {
                    
                       if(record.roleSystems.length>0){
                        record.roleSystems.forEach(rsys=>{                         
                          if(rsys.RoleId == this.role.id){
                            this.systemmodule.push(rsys.SystemModuleId)
                            this.sysetemmoduleselected(rsys.SystemModuleId)
                          }
                        })
                       }

                       if(record.submodules.length>0){
                        record.submodules.forEach(subm=>{
                            if(subm.roles.length>0){
                               subm.roles.forEach(role=>{
                                if(role.RoleId== this.role.id){
                                  this.submodule.push(role.SubmoduleId)
                                  this.addSubmodules(record.Id,role.SubmoduleId)
                                }
                               })
                            }
                            var permissions = subm.permissions
                            if(permissions.length>0){
                              permissions.forEach(perm=>{
                                var RolePermissions = perm.RolePermissions
                               if(RolePermissions.length>0){
                                RolePermissions.forEach(roleperm=>{
                                  if(roleperm.RoleId == this.role.id){
                                    this.permission.push(roleperm.PermissionId)
                                    this.addPermission(subm.SystemmoduleId,subm.Id,roleperm.PermissionId)
                                  }
                                })

                               }
 
                              })
                            }

                        })
                       }
                   });
                  this.AddModel=true
              },
              async assignFunctions(){
                var payload ={RoleId:this.role.id,SystemModules:this.systemmodule,Submodules:this.submodule,Permissions:this.permission,payload:JSON.stringify(this.payloadarray)}
                this.loading = true
              await this.$store.dispatch("roles/assignFunctions",payload); 

        this.loading = false
              }
        },
        computed:{
          systemmodules() {
        return this.$store.state.roles.systemmodules;
      },
    }
     }
    </script>