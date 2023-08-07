<template>
    <div>
     
<v-container>
    <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
  <v-card>
    <v-card-title>
     My Profile
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
         
          <tbody>
       
            <tr>
             <th>uuid</th>
             <td>{{ loggedInUser.id }}</td>
            </tr>
            <tr>
             <th>Username</th>
             <td>{{ loggedInUser.username }}</td>
            </tr>
            <tr>
             <th>Name</th>
             <td>{{ loggedInUser.name }}</td>
            </tr>
            <tr>
             <th>Ecnumber</th>
             <td>{{ loggedInUser.ecnumber }}</td>
            </tr>
            <tr>
             <th>Role</th>
             <td>{{ loggedInUser.role}}</td>
            </tr>
            <tr>
             <th>Email</th>
             <td>{{ loggedInUser.status }}</td>
            </tr>
          
          
          </tbody>
        </template>
      </v-simple-table>
    </v-card-text>
  </v-card>

  <div class="mt-5">
   
  </div>
  
</v-container>

  
    </div>
</template>
<script>
 import { mapGetters } from 'vuex' 
  export default{
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
          text: 'My Profile',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
   
        computed:{
  ...mapGetters(['isAuthenticated', 'loggedInUser']),
   }
  
  }
</script>