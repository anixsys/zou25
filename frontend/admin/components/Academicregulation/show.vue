<template>
    <div>
      <v-btn  rounded depressed color="primary" @click="getData">View regulations</v-btn>
      <v-dialog v-model="AddModel" width="">
        <v-card>
          <v-toolbar
      color="primary"
      dark
      flat
    >
    <span>Academic Regulations for {{ programme.code }}</span>
    <v-spacer></v-spacer>
    <academicregulationAdd :programme="programme"/>
    <v-btn fab depressed color="error" @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>

    </v-toolbar>
  <v-card-title>
      
  </v-card-title>
  <v-card-text>
    <v-simple-table class="mt-2 mb-3">
    <template v-slot:default>
      <thead dark>
        <tr>
          <th>Intake</th>
          <th>Programme type</th>
          <th>Attendence Type</th>
          <th>Year</th>
          <th>Approved</th>
          <th>Default</th>
          <th class="text-right">Action</th>
        </tr>
      </thead>
      <tbody>
        
            <template v-if="academicregulations.length>0">
               <tr v-for="academic in academicregulations">
                <td>{{ academic.name }}</td>
                <td>{{ academic.programmetype }}</td>
                <td>{{ academic.attendencetype }}</td>
                <td>{{ academic.year }}</td>
                <td>{{ academic.isApproved }}</td>
                <td>{{ academic.isActive }}</td>
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
        <v-list-item link v-if="academic.isApproved=='NO'" @click="changestatus(academic.id,true)">
          <v-list-item-title><v-icon small>mdi-check-decagram</v-icon>Approve</v-list-item-title>
        </v-list-item>
        <v-list-item link v-else @click="changestatus(academic.id,false)">
          <v-list-item-title><v-icon small>mdi-close-circle-multiple-outline</v-icon>Revoke</v-list-item-title>
        </v-list-item>
        <v-list-item link @click="SetAsDefault(academic.id)">
          <v-list-item-title><v-icon small>mdi-close-circle-multiple-outline</v-icon>Set As Default</v-list-item-title>
        </v-list-item>
        <AcademicregulationDuplicate :regulation="academic" :programme="programme"/>
                    <AcademicregulationEdit v-if="academic.isApproved=='NO'" :programme="programme" :regulation="academic"/>
                    <AcademicregulationDelete v-if="academic.isApproved=='NO'" :regulation="academic"/>
                    <AcademicregulationparameterShow :regulation="academic" :programme="programme"/>
      </v-list>
    </v-menu>
                  
                
                
               </td>

               </tr>
            </template>
            <template v-else>
              <tr>
                <td colspan="7" class="text-center pt-4 pb-4 red--text">
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
    props:["programme"],
      data(){
          return{
              AddModel:false,
              loading:false,
         
        }
          
      },
      methods:{
    async getData(){
        await this.$store.dispatch("academicregulations/getData",this.programme.id);
        this.AddModel=true
    },async changestatus(id,status){
     var payload = {programmeId:this.programme.id,status:status,id:id}
     await this.$store.dispatch("academicregulations/Changestatus",payload);
    }
    ,async SetAsDefault(id){
     var payload = {programmeId:this.programme.id,id:id}
     await this.$store.dispatch("academicregulations/SetAsDefault",payload);
    }
      }, computed:{
  academicregulations() {
    var records =  this.$store.state.academicregulations.records;

    var  regulations = [];

    if(records.length>0){
      records.forEach(record => {
         var el = {id:record.id,
                   name:record.name,
                   programmetype:record.programmeType.name,
                   attendencetype:record.attendencetype.name,
                   status:record.status,
                   year:record.year,
                   programmetypeId:record.programmeType.id,
                   attendencetypeId:record.attendencetype.id,
                   programmeId:record.programmeId,
                   generalregulationId:record.generalregulationId,
                   maximum:record.maximum,
                   duration:record.duration,
                   isActive:record.isActive ? 'YES' :'NO',
                   isApproved:record.isApproved ? 'YES' : 'NO'
                }
         regulations.push(el)
        });
    }
    return regulations
  },
}
   }
  </script>