<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
        <v-container>
   
        <ChangePassword/>
        </v-container>
    </div>
    </template>
    <script>
    export default {
        layout:"mainlayout",
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
          text: 'Change Password',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    }
    
    }
    </script>
    