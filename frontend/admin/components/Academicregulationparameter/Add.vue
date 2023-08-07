<template>
    <div>
      <v-btn fab depressed color="info" @click="getRecords"><v-icon>mdi-plus</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="900px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New Regulation Regulation Parameter
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>

            <v-row>
              <v-col class="d-flex">
                <v-text-field
                label="Course Code"
                v-model="Course"
                outlined
                :rules="[rules.required]"
              >
            </v-text-field>
            <v-btn fab color="primary" depressed class="ml-1" @click="CourseModel=true"><v-icon>mdi-plus</v-icon></v-btn>
          
              </v-col>
              <v-col>
                <v-select label="Course Type" v-model="form.CourseType" outlined  :rules="[rules.required]" :items="['CORE','ELECTIVE']"/>
              </v-col>

            </v-row>
            <v-row>
              <v-col class="d-flex">
                <v-select
                label="Level"
                v-model="form.level"
                :items="[1,2,3,4,5,6]"
                outlined
                :rules="[rules.required]"
              >
              </v-select>
              </v-col>
              <v-col>
                <v-select
                label="Semester"
                v-model="form.semester" 
                outlined 
                :rules="[rules.required]"
                :items="[1,2]"
                   />
              </v-col>
            </v-row>
            <v-row>
              <v-col class="d-flex">
                <v-text-field
                label="Coursework Contribution(%)"
                v-model="form.CourseworkContribution"
                type="number"
                min="0"
                max="100"
                outlined
                :rules="[rules.required]"
              >
              </v-text-field>
              </v-col>
              <v-col>
                <v-text-field 
                label="Exam Contribution(%)"
                v-model="form.ExamContribution" 
                outlined 
                :rules="[rules.required]"
                type="number"
                min="0"
                max="100"
                   />
              </v-col>
            </v-row>
            <v-row>
              <v-col class="d-flex">
                <v-text-field
                label="Course Weight"
                v-model="form.CourseWeight"
                type="number"
                min="0"
                max="100"
                outlined
                :rules="[rules.required]"
              >
              </v-text-field>
              </v-col>
              <v-col>
                <v-text-field 
                label="Number of Takes"
                v-model="form.CourseTake" 
                outlined 
                :rules="[rules.required]"
                type="number"
                min="0"
                max="100"
                   />
              </v-col>
            </v-row>
           
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80" to="/dashboard">Cancel</v-btn>
                <v-spacer />
                <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="Submit" :loading="loading"
                  >Submit</v-btn
                >
              </v-card-actions>
        </v-card>
      </v-form>
      </v-dialog>

      <v-dialog v-model="CourseModel" width="600px">
        <v-card>
          <v-card-title>
            Select Course
            <v-spacer/>
            <v-btn icon @click="CourseModel=false"><v-icon>mdi-close</v-icon></v-btn>
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
                      <td><v-btn fab small color="primary" @click="AddCourse(course)"><v-icon>mdi-plus</v-icon></v-btn></td>
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
      <v-dialog v-model="PrereqModel" width="600px">
        <v-card>
          <v-card-title>
            Select Course
            <v-spacer/>
            <v-btn icon @click="PrereqModel=false"><v-icon>mdi-close</v-icon></v-btn>
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
                      <td><v-btn fab small color="primary" @click="AddPrereq(course)"><v-icon>mdi-plus</v-icon></v-btn></td>
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

      <v-dialog v-model="AlterModel" width="600px">
        <v-card>
          <v-card-title>
            Select Course
            <v-spacer/>
            <v-btn icon @click="AlterModel=false"><v-icon>mdi-close</v-icon></v-btn>
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
                      <td><v-btn fab small color="primary" @click="AddAlter(course)"><v-icon>mdi-plus</v-icon></v-btn></td>
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
    props:["regulation","programme"],
      data(){
          return{
              AddModel:false,
              PrereqModel:false,
              AlterModel:false,
              CourseModel:false,
              filter:"",
              loading:false,
              Course:"",
              CourseId:"",
              prerequisitecourses:[],
              alternativecourses:[],
          form:{
            CourseId:"",
            semester:"",
            level:"",
            programmeId:"",
            CourseType:"",           
            ExamContribution:"",
            CourseworkContribution:"",
            CourseWeight:"",
            CourseTake:"",
            AcademicRegulationId:"",

          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){
        var contribution =Number(this.form.CourseworkContribution) + Number(this.form.ExamContribution)
        if(contribution>100){
          this.$swal("error","Course work and Examination Contribution cannot be greater than 100%","error")

        }else if(contribution<100){
          this.$swal("error","Course work and Examination Contribution cannot be lees than 100%","error")
 
        }else{
          this.loading = true
          this.form.CourseId = this.CourseId
          this.form.AcademicRegulationId = this.regulation.id
          this.form.programmeId = this.programme.id       
          await this.$store.dispatch("academicregulationparameters/addItem",this.form); 
         this.$refs.form.reset()
          this.loading = false
        }
      }
    },
      async getRecords(){
        this.overlay = true;
        await this.$store.dispatch("course/getData");
        await this.$store.dispatch("generalsetting/getRecords");
        this.AddModel = true
       this.overlay = false;
      },
      AddCourse(course){
        this.Course = course.Code
        this.CourseId = course.id
        this.CourseModel = false
      }
      },
    computed:{
      courses() {
      var data=  this.$store.state.course.records;
      var courses = [];
      if(data.length>0){
              data.forEach(element => {
                  var el = {
                               id:element.id,
                               Code:element.code,
                               name:element.name
                              }  
                   courses.push(el)
                });
      }

      return courses

    }
  }
   }
  </script>