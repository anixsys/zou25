<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
<v-container fluid>
  <v-card>
    <v-card-title>
      Applicants <v-spacer/>
      <ApplicantImport/>
      <ApplicantSearch/>
      <ApplicantAdd/>
    </v-card-title>
    <v-card-text>
      <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Filter"
        single-line
        outlined 
        hide-details
      ></v-text-field>
        <v-data-table
    :headers="headers"
    :items="applicants"
    :items-per-page="20"
    :search="search"
    class="mt-2"
  >
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
        <ApplicantEdit :applicant="item"/>
        <ApplicantProfile :id="item.id"/>
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
    data(){
        return{
          overlay: false,
          search:"",
            items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: 'Applicant',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
      headers: [
          {
            text: 'Type',
            align: 'start',
            sortable: true,
            value: 'type',
          },
          {
            text: 'Name',
            align: 'start',
            sortable: true,
            value: 'name',
          },
          {
            text: 'Country',
            align: 'start',
            sortable: true,
            value: 'country',
          },
          {
            text: 'Surname',
            align: 'start',
            sortable: true,
            value: 'surname',
          },
          {
            text: 'Email',
            align: 'start',
            sortable: true,
            value: 'email',
          },
          {
            text: 'Phonenumber',
            align: 'start',
            sortable: true,
            value: 'phonenumber',
          },
          {
            text: 'Gender',
            align: 'start',
            sortable: true,
            value: 'gender',
          },
          {
            text: 'Id Type',
            align: 'start',
            sortable: true,
            value: 'identificationType',
          },
          {
            text: 'Id Number',
            align: 'start',
            sortable: true,
            value: 'identification',
          },
          {
            text: 'Actions',
            align: 'end',
            value: 'actions',
          }
        ]
        }
    },
    computed:{
    applicants() {
      return this.$store.state.applicant.records;
    },
  }
  }
</script>