<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
<v-container fluid>
  <v-form ref="form" lazy-validation>
    <v-card>
    <v-card-text>
      <v-row>
        <v-col class="d-flex justify-content-between"><v-select  outlined class="rounded-0" label="Select Enrolment Session" :items="sessions"  :rules="[rules.required]" item-value="id" item-text="name" v-model="admissionsessionId"/> <v-btn  depressed class="rounded-0" large height="55px" color="primary" @click="getApplications">Search</v-btn></v-col>
       </v-row>
      </v-card-text>
  </v-card>
  </v-form>
  
  <v-card class="mt-2">
    <v-card-title>
     Enrolment Management
     <v-spacer/>    
    </v-card-title>
    <v-card-text>

      <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Search"
        single-line
        outlined 
        hide-details
      ></v-text-field>
        <v-data-table
    :headers="headers"
    :items="applications"
    :items-per-page="20"
    :search="search"
    class="mt-2"
  >
  <template v-slot:item.dateCreated="{ item }">
    <div>
      {{ item.dateCreated | formateHumanDiff}}
    </div>
 </template>
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
      <EnrolmentShow :application="item"/>
    </div>     
 </template>
 <template v-slot:item.approvalStatus="{ item }">
    <div :class="item.approvalStatus">
      {{ item.approvalStatus }}
    </div>     
 </template>
</v-data-table>
    </v-card-text>
  </v-card>
</v-container>

  
    </div>
</template>
<script>
  export default{
    layout:"mainlayout",
    async fetch() {

    await this.$store.dispatch("admissionsessions/getData");
  
  },
    data(){
        return{
          loading: false,
          search:"",
            items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: 'Enrolment Management',
          disabled: true,
          href: 'breadcrumbs_link_2',
        }],
        headers: [
          {
            text: 'Date',
            align: 'start',
            sortable: true,
            value: 'dateCreated',
          },
          {
            text: 'App Number',
            align: 'start',
            sortable: true,
            value: 'appNumber',
          },
          {
            text: 'Name',
            align: 'start',
            sortable: true,
            value: 'applicant.name',
          },
          {
            text: 'Surname',
            align: 'start',
            sortable: true,
            value: 'applicant.surname',
          },
          {
            text: 'Country',
            align: 'start',
            sortable: true,
            value: 'applicant.country',
          },
          {
            text: 'Campus',
            align: 'start',
            sortable: true,
            value: 'campus.name',
          },
          {
            text: 'Status',
            align: 'start',
            sortable: true,
            value: 'approvalStatus',
          },
          {
            text: 'Actions',
            align: 'end',
            value: 'actions',
          }
        ],
        admissionsessionId:"",
        rules: {
            required: value => !!value || 'Required.'
          },
        }
    },
    methods:{
         async getApplications(){
          if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("applications/getData",this.admissionsessionId);
          this.loading = false
          }
         }
    },
    computed:{
   sessions() {
      return this.$store.state.admissionsessions.records;
    },
    applications(){
      return this.$store.state.applications.records
    }
  }
  }
</script>
<style scoped>
.REJECTED{
    color: red;
    font-weight: bolder;
}
.ACCEPTED{
    color: green;
    font-weight: bolder;
}
</style>