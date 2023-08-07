<template>
    <div>
        <v-card outlined class="mt-2">
        <v-card-text>
          <v-checkbox
                label="Select All"                
                value="*"
                @change="selectAllDepartments($event)"
              ></v-checkbox>
          <v-row v-for="faculty in faculties" :key="faculty.id">
              <v-col>
              <v-card outlined dense>
                <v-card-title>                  
                  {{ faculty.name }}
                  <v-spacer/>
                
                </v-card-title>
                <v-card-text>
                  <v-simple-table dense>
                    <template v-slot:default>
                      <thead>
                        <tr>
                          <th>  <v-checkbox                
                :value="faculty.id"
                @change="selectAllByfaculty($event)"
              ></v-checkbox></th>
                          <th>Name</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr v-for="department in faculty.departments" :key="department.id">
                         <td><v-checkbox
                v-model="departmentlist"
                :value="department.id"
              ></v-checkbox></td>
              <td>{{ department.name }}</td>
                        </tr>
                      </tbody>
                    </template>
                  </v-simple-table>
                </v-card-text>
                <v-card-actions>
                      <v-spacer />
                <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="Submit" :loading="loading"
                  >Submit</v-btn
                >
              
        </v-card-actions>
              </v-card>
              </v-col>
            </v-row>
        </v-card-text>
      </v-card>
    </div>
</template>
<script>
  export default{
    props:['faculties','userId','dbdepartments'],
    data(){
        return{
            facultylist:[],
          departmentlist:this.dbdepartments.length>0 ? this.dbdepartments : [],
          errors:[],
          loading:false,
          form:{
            userId:"",
            departments:""
          }
        }
    },
    methods:{
        selectAllByfaculty(event){
         this.faculties.forEach(faculty=>{
          if(faculty.id==event){
            faculty.departments.forEach(department=>{
              this.departmentlist.push(department.id)
            })
          }
         })
    },
    selectAllDepartments(event){
      this.faculties.forEach(faculty=>{
            faculty.departments.forEach(department=>{
              this.departmentlist.push(department.id)
            })          
         })
    },
    async Submit(){
        if(this.departmentlist.length==0){
            this.errors.push("Please select Department")   
          }
         var departments =JSON.stringify(this.departmentlist)
         this.form.userId = this.userId;
         this.form.departments = departments;
         this.loading = true;
         await this.$store.dispatch("userdepartment/addItem",this.form); 
         this.loading = false
    }
    }
  }
</script>