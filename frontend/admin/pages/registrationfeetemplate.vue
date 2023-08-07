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
      Fee Ordinances <v-spacer/>
      <OrdinanceAdd/>
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
    :items="regfeetemplates"
    :items-per-page="20"
    :search="search"
    class="mt-2"
  >
  <template v-slot:item.dateCreated="{ item }">
    {{ item.dateCreated | formatDate }}
  </template>
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
        <OrdinanceEdit v-if="item.status=='PENDING'" :record="item"/>
         <OrdinanceDelete v-if="item.status=='PENDING'" :record="item"/>
         <OrdinanceFee :record="item"/>
         <OrdinanceApprove v-if="item.status=='PENDING' && item.registrationfees.length>0" :record="item"/>
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
    this.overlay = true;
    await this.$store.dispatch("regfeetemplates/getData");
    this.overlay = false;
  },
    data(){
        return{
          overlay: false,
            items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: 'Registration Fee Templates',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
      search:"",
      headers: [
         {
            text: 'Date',
            align: 'start',
            sortable: true,
            value: 'dateCreated',
          },
          {
            text: 'Name',
            align: 'start',
            sortable: true,
            value: 'name',
          },
          {
            text: 'Year',
            align: 'start',
            sortable: true,
            value: 'year',
          },
          {
            text: 'Status',
            align: 'start',
            sortable: true,
            value: 'status',
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
    regfeetemplates() {
      return this.$store.state.regfeetemplates.records;
    },
  }
  }
</script>