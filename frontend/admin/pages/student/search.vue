<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
<v-container>
  <v-row>
    <v-col>
      <div class="text-h5 mt-2 mb-2"> 
      Student Search
    </div>
    </v-col>
    <v-col>
       <v-form ref="form" lazy-validation>
        <v-row>
        <v-col  class="d-flex justify-content-between">
            <v-text-field
              label="Search"
              placeholder="Search By Name / Pin number"
              v-model="form.Needle"
             
              outlined
              :rules="[rules.required]"
            ></v-text-field>  
        <v-btn  depressed class="rounded-0" large height="55px" color="primary" :loading="loading" @click="getApplications">Search</v-btn></v-col>
       </v-row>
       </v-form>
    </v-col>
  </v-row>


        
    <v-card>
    <v-card-text>
      
       <v-row class="mt-2">
        <v-col>
          <v-card outlined>
            <v-card-title>
              <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="filter"
        single-line
        dense
        hide-details
      ></v-text-field>
            </v-card-title>
            <v-card-text>
              <v-data-table
    :headers="headers"
    :items="students"
    :items-per-page="20"
    :search="search"
    class="mt-2"
  >
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
        <StudentProfile :student="item"/>
    </div>
     

    </template>
</v-data-table>
            </v-card-text>
          </v-card>
          
       
          
            
     
        </v-col>
       </v-row>
      </v-card-text>
  </v-card>

    
</v-container>

  
    </div>
</template>
<script>
  export default{
    layout:"mainlayout",
    data(){
        return{
          loading: false,
          search:"",
          form:{
            Needle:""
          },
          rules: {
            required: value => !!value || 'Required.'
          },
            items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: 'Students',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
      headers: [
          {
            text: 'Pin',
            align: 'start',
            sortable: true,
            value: 'pin',
          },
          {
            text: 'Name',
            align: 'start',
            sortable: true,
            value: 'fullName',
          },
          {
            text: 'Gender',
            align: 'start',
            sortable: true,
            value: 'gender',
          },
          {
            text: 'Identification Type',
            align: 'start',
            sortable: true,
            value: 'identificationtype',
          },
          {
            text: 'Identification Number',
            align: 'start',
            sortable: true,
            value: 'identificationnumber',
          },
         
          {
            text: 'Actions',
            align: 'end',
            value: 'actions',
          }
        ]
        }
    },
    methods:{
        async getApplications(){
            if(this.$refs.form.validate()){
        this.loading = true
        await this.$store.dispatch("student/Search",this.form); 
    
        this.loading = false
    }
        },
    },
    computed:{
       students() {
      return this.$store.state.student.records;
    },
  }
  }
</script>