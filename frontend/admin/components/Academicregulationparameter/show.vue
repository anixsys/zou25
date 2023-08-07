<template>
    <div>
      <v-list-item link    @click="getData">
          <v-list-item-title><v-icon small>mdi-cogs</v-icon>Parameters</v-list-item-title>
      </v-list-item>
         <v-dialog v-model="AddModel" width="1200px">
        <v-card>
          <v-toolbar
      color="success"
      dark
      flat
    >
    <span>Regulation Parameters</span>
    <v-spacer></v-spacer>
    <academicregulationparameterImport :regulation="regulation"/>
    <academicregulationparameterAdd :regulation="regulation" :programme="programme"/>
    <v-btn fab depressed color="error" @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>

    </v-toolbar>
  <v-card-title>
      
  </v-card-title>
  <v-card-text>
    <v-simple-table class="mt-2 mb-3">
    <template v-slot:default>
      <thead dark>
        <tr>
          <th>Level</th>
          <th>Semester</th>
          <th>Course</th>
          <th>isCore</th>
          <th>Csw Contribution</th>
          <th>Exm Contribution</th>
          <th>Course Weight</th>
          <th>Takes</th>
          <th>Alternatives</th>
          <th>Prerequisite</th>
          <th class="text-right">Action</th>
        </tr>
      </thead>
      <tbody>
        
            <template v-if="regulationparameters.length>0">
               <tr v-for="academic in regulationparameters">
                <td>{{ academic.level }}</td>
                <td>{{ academic.semester }}</td>
                <td>{{ academic.course.code}}</td>
                <td>{{ academic.courseType }}</td>
                <td>{{ academic.courseworkContribution}}</td>
                <td>{{ academic.examContribution }}</td>
                <td>{{ academic.courseWeight }}</td>
                <td>{{ academic.courseTake }}</td>
                <td>
                  <template v-if="academic.alternatives.length>0">
                    <ul>
                       <li v-for="alter in academic.alternatives">{{ alter.course.code }}<v-btn icon color="error" @click="deleteAlternative(alter.id,academic.academicRegulationId)"><v-icon>mdi-close</v-icon></v-btn></li>
                      </ul>
                  </template>
                  <template v-else>
                    <div class="text-center red--text">--</div>
                  </template>
                 
                </td>
                <td>
                  <template v-if="academic.prerequisites.length>0">
                    <ul>
                       <li v-for="pre in academic.prerequisites">{{ pre.course.code }}<v-btn icon color="error" @click="deleteItem(pre.id,academic.academicRegulationId)"><v-icon>mdi-close</v-icon></v-btn></li>
                      </ul>
                  </template>
                  <template v-else>
                    <div class="text-center red--text">--</div>
                  </template>
                </td>
              
                  <td class="d-flex justify-end pt-2">
                  <v-menu>
                <template v-slot:activator="{ on, attrs }">
                  <v-btn
                    color="primary"
                    dark
                    v-bind="attrs"
                    v-on="on"
                    small
                    rounded 
                    outlined
                  >
                  <v-icon>mdi-cogs</v-icon> Settings
                  </v-btn>
                </template>
                  <v-list>
                    <academicregulationparameterEdit :regulation="regulation" :programme="programme" :parameter="academic"/> 
                    <academicregulationparameterDelete :parameter="academic"/> 
                    <academicregulationparameterAddprerequisite :parameter="academic"/> 
                    <academicregulationparameterAddalternative :parameter="academic"/>       
                  
                  </v-list>
                </v-menu>
                </td>
                

               </tr>
            </template>
            <template v-else>
              <tr>
                <td colspan="11" class="text-center pt-4 pb-4 red--text">
                  No records found
                </td>
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
              loading:false,
         
        }
          
      },
      methods:{
    async getData(){
        await this.$store.dispatch("academicregulationparameters/getData",this.regulation.id);
        this.AddModel=true
    },
    async deleteItem(id,academicRegulationId){
      var payload = {id:id,AcademicRegulationId:academicRegulationId}
        await this.$store.dispatch("prerequisite/deleteItem",payload);  
    },
    async deleteAlternative(id,academicRegulationId){
      var payload = {id:id,AcademicRegulationId:academicRegulationId}
        await this.$store.dispatch("alternative/deleteItem",payload);  
    }
      }, computed:{
  regulationparameters() {
    return this.$store.state.academicregulationparameters.records;

  },
}
   }
  </script>