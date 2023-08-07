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
      Users <v-spacer/>
      <UserAdd/>
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
    :items="users"
    :items-per-page="20"
    :search="search"
  >
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
      <UserResetpassword :user="item"/>
      <UserEditpersonal :user="item"/>
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
    await this.$store.dispatch("users/getData");
    this.overlay = false;
  },
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
          text: 'Users',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
                   ],
      headers: [
          {
            text: 'Name',
            align: 'start',
            sortable: true,
            value: 'name',
          },
          {
            text: 'Surname',
            align: 'start',
            sortable: true,
            value: 'surname',
          },
          {
            text: 'Ecnumber',
            align: 'start',
            sortable: true,
            value: 'ecnumber',
          },
          {
            text: 'Email',
            align: 'start',
            sortable: true,
            value: 'email',
          },
          {
            text: 'Status',
            align: 'start',
            value: 'status',
          },
          {
            text: 'Action',
            align: 'end',
            value: 'actions',
          }
        ]
        }
    },
    computed:{
    users() {
      return this.$store.state.users.records;
    },
  }
  }
</script>