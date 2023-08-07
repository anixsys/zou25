<template>
    <div>
      <v-btn rounded small outlined color="primary" @click="getRecords"><v-icon>mdi mdi-account-cog</v-icon> View Profile</v-btn>
          
      <v-dialog v-model="AddModel" width="900px">
      
        <v-card>
          <v-card-title>
              Update Profile
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <template v-if="errors.length>0">
              <v-alert  border="top" color="red lighten-2" dark v-for="error in errors">{{ error }}</v-alert>
            </template>
              <v-tabs  v-model="tab">
                <v-tab dark class="pa-4 text-center grey lighten-2 rounded-lg rounded-b-0 mr-1"><v-icon>mdi-account</v-icon>Personal Detaails</v-tab>
                <v-tab dark class="pa-4 text-center grey lighten-2 rounded-lg rounded-b-0 mr-1"><v-icon>mdi-lock</v-icon>System Roles</v-tab>
                <v-tab dark class="pa-4 text-center grey lighten-2 rounded-lg rounded-b-0 mr-1">Campus Access</v-tab>
                <v-tab dark class="pa-4 text-center grey lighten-2 rounded-lg rounded-b-0 ">Faculty Access</v-tab>
              </v-tabs>
              <v-tabs-items v-model="tab">
                <v-tab-item>
                <UserPersonal :user="user"/>
                </v-tab-item>
                <v-tab-item>
                <UserRole :roles="roles" :userId="user.id" :dbroles="rolelist"/>  
                </v-tab-item>
                <v-tab-item>
                  <UserCampus :campuses="campuses" :userId="user.id" :dbcampus="campuslist"/>  
                </v-tab-item>
                <v-tab-item>
                  <UserDepartment :faculties="faculties" :userId="user.id" :dbdepartments="departmentlist"/>  
                </v-tab-item>
                </v-tabs-items>
           </v-card-text>
         
        </v-card>
   
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:['user'],
      data(){
          return{
              AddModel:false,
              loading:false,
              tab:null,
              errors:[],
          rolelist:[],
          campuslist:[],
          facultylist:[],
          departmentlist:[],
       
        }
          
      },methods:{
    async getRecords(){

        //await this.$store.dispatch('users/getUser',this.user.id)
        await this.$store.dispatch("roles/getData");
        await this.$store.dispatch("faculties/getData");
        await this.$store.dispatch("campus/getData");
        await this.$store.dispatch("department/getData");
        await this.$store.dispatch("department/getData");
        await this.getRoles();
        this.AddModel =true

    },
    async getRoles(){
      await this.$axios.get('User/'+this.user.id).then((res)=>{
              var roles = res.data.roles
              var departments = res.data.departments
              var campuses = res.data.campuses
             departments.forEach(element => {
               this.departmentlist.push(element.departmentId)
             });

             campuses.forEach(element => {
               this.campuslist.push(element.campusId)
             });
              roles.forEach(element => {
                console.log(element)
                this.rolelist.push(element)
              });
           
          })
    }
      },computed:{
        campuses() {
      return this.$store.state.campus.records;
    },
    faculties() {
      return this.$store.state.faculties.records;
    },
    roles() {
      return this.$store.state.roles.records;
    },
    departments() {
      return this.$store.state.department.records;
    }
      }
   }
  </script>