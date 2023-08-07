<template>
    <div>
      <v-btn rounded small outlined color="primary" @click="getRecords"><v-icon>mdi-plus</v-icon> Add Programme</v-btn>
      <v-dialog v-model="AddModel" width="700px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
             Select Programme
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-text-field v-model="search"
        append-icon="mdi-magnify"
        label="Search"
        single-line
        dense
        outlined 
        hide-details
      ></v-text-field>
        <v-data-table
    :headers="headers"
    :items="programmes"
    :items-per-page="20"
    :search="search"
    class="mt-2"
  >
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
      <v-btn fab small color="primary" depressed @click="addProgramme(item)"><v-icon>mdi-plus</v-icon></v-btn>
    </div>
     

    </template>
</v-data-table>
          </v-card-text>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:["application"],
      data(){
          return{
              AddModel:false,
              loading:false,
              search:"",
              headers: [
          {
            text: 'Code',
            align: 'start',
            sortable: true,
            value: 'code',
          },
          {
            text: 'Name',
            align: 'start',
            sortable: true,
            value: 'description',
          },
          {
            text: 'Actions',
            align: 'end',
            value: 'actions',
          }
        ],
          form:{
            code:"",
            Name:"",
            departmentId:"",
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async getRecords(){
        await this.$store.dispatch("programmes/getProgrammesByType",this.application.programmeTypeId);
        this.AddModel=true
    },
     async addProgramme(item){
        this.loading = true
        var payload = {applicationId:this.application.id,applicantId:this.application.applicantId,programmeId:item.id,AttendenceTypeId:this.application.attendencetypeId,status:"PENDING"}
          await this.$store.dispatch("applicationprogramme/addItem",payload);        
          this.loading = false  
    }
      },
    computed:{
    programmes() {
      return this.$store.state.programmes.records;
    }
  }
   }
  </script>