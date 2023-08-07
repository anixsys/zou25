<template>
  <v-app dark>
   
    <v-app-bar     
      app
      height="120px"
      color="#183B6E"
      dark
      flat
    >

    <img src="/logo.png"  to="/" width="100px">
      <v-toolbar-title>
        <div class="display-1 hidden-sm-and-down">Zimbabwe Open University</div> 
       
      </v-toolbar-title>
      <v-spacer />
      
      <v-btn text class="ml-2 hidden-sm-and-down" to="/" rounded>
      Home
      </v-btn>
      <v-btn text class="ml-2 hidden-sm-and-down" to="/programme" rounded>
      Programmes
      </v-btn>
      <v-btn text class="ml-2 hidden-sm-and-down" to="https://www.zou.ac.zw" rounded>
      Main Website
      </v-btn>
      <template v-if="!isAuthenticated">
        <v-btn rounded depressed outlined  to="/register" >
     Sign Up
      </v-btn>
      <v-btn rounded outlined  class="ml-2" to="/login">
      Sign In
      </v-btn>
      </template>
      <template v-else>
        <v-menu offset-y>
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          text
          v-bind="attrs"
          v-on="on"
        >
        <v-icon>mdi-account-circle</v-icon>
          {{ loggedInUser.name }}
          {{ loggedInUser.surname }}
        </v-btn>
      </template>
      <v-list>
        <v-list-item link to="/dashboard">
          <v-list-item-title>Dashboard</v-list-item-title>
        </v-list-item>
        <v-list-item link to="profile">
          <v-list-item-title>Profile</v-list-item-title>
        </v-list-item>
        <v-list-item link to="passwordchange">
          <v-list-item-title>Change Password</v-list-item-title>
        </v-list-item>
        <v-list-item link @click="logout()">
          <v-list-item-title>Logout</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
      </template>
      

   

    </v-app-bar>
    <v-main>
 
        <Nuxt />
   
    </v-main>

    <v-footer
    dark
      :absolute="!fixed"
      color="#183B6E"
      app
    >
      <div class="mr-2">Zimbabwe Open University</div> <span>&copy; {{ new Date().getFullYear() }}</span>
      <v-spacer/>
      Developed By:<v-btn text to="http://www.anixsys.co.zw">AnixSys Pvt Ltd</v-btn>
    </v-footer>
  </v-app>
</template>

<script>
import { mapGetters } from 'vuex' 
export default {
  name: 'DefaultLayout',
  data () {
    return {
      fixed: false,
    }
  }, methods:{

async logout(){
await this.$auth.logout()
}
},
      computed:{
  ...mapGetters(['isAuthenticated', 'loggedInUser']),
   }
}
</script>
