<template>
    <div>
       
      <v-list-item link   @click="getRecords">
          <v-list-item-title><v-icon small >mdi-add</v-icon> Add Prerequisite</v-list-item-title>
      </v-list-item>
      <v-dialog v-model="AddModel" width="600px">
        <v-card>
          <v-card-title>
            Select Course
            <v-spacer/>
            <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-text-field outlined label="Filter courses" v-model="filter"/>
            <v-simple-table>
              <template v-slot:default>
                <thead>
                  <tr>
                    <th>Code</th>
                    <th>Description</th>
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                  <template v-if="courses.length>0">
                     <tr v-for=" course in courses">
                      <td>{{ course.Code }}</td>
                      <td>{{ course.name }}</td>
                      <td><v-btn fab small color="primary" @click="AddPrerequisite(course)"><v-icon>mdi-plus</v-icon></v-btn></td>
                     </tr>
                  </template>
                  <template v-else>
                    <tr>
                      <td colspan="3" class="text-center red--text">No courses found</td>
                    </tr>
                  </template>
                </tbody>
              </template>
            </v-simple-table>
           
          </v-card-text>
        </v-card>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:["parameter"],
      data(){
          return{
          AddModel:false, 
          filter:"" 
        }
          
      },methods:{
        async getRecords(){
        this.overlay = true;
        await this.$store.dispatch("course/getData");
        this.AddModel = true
       this.overlay = false;
      },
      async AddPrerequisite(course){
        var payload = {AcademicregulationparameterId:this.parameter.id,AcademicRegulationId:this.parameter.academicRegulationId,CourseId:course.id}
        await this.$store.dispatch("prerequisite/addItem",payload); 
      }
      },
    computed:{
      courses() {
      var data=  this.$store.state.course.records;
      var courses = [];
      if(data.length>0){
              data.forEach(element => {
                if(this.parameter.courseId != element.id)
                {
                  var el = {
                               id:element.id,
                               Code:element.code,
                               name:element.name
                              }  
                   courses.push(el)
                            }
                });
      }
      if(this.filter){
     courses =courses.filter(
          (dt) =>{
            return dt.name.toUpperCase().includes(this.filter.toUpperCase()) || dt.Code.toUpperCase().includes(this.filter.toUpperCase()) 
          }
        )
      }

      return courses

    }
  }
   }
  </script>