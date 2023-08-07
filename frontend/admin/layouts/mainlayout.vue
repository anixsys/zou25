<template>
    <v-app id="inspire">
      <v-navigation-drawer v-model="drawer" app dark color="primary">
        <Sidebar/>
      </v-navigation-drawer>
  
      <v-app-bar app absolute flat  class="px-2 white">
        <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>  
        <img src="~/assets/images/logo2.png" width="300px"/>
         <v-spacer/>
         <v-btn outlined v-if="active" rounded color="primary" class="mr-2"><v-icon>mdi-account-school</v-icon>Search Student</v-btn>
         
        <v-menu offset-y>
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          color="secondary"
          dark
          text
          v-bind="attrs"
          v-on="on"
        >
        <v-icon>mdi-account-circle</v-icon>
          {{ loggedInUser.name }}  {{ loggedInUser.surname }}
        </v-btn>
      </template>
      <v-list>
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
      </v-app-bar>
  
      <v-main class="grey lighten-4">
        <Nuxt />
      </v-main>
      <v-dialog v-model="changepasswordModel" width="400px" persistent>
       <ChangePassword/>
      </v-dialog>

    </v-app>
  </template>
  
  <script>
  import { mapGetters } from 'vuex' 
    export default {
        name:"Mainlayout",
      data: () => ({ drawer: true,changepasswordModel:false,active:true,loading:false,SwitchViewModel:false }),
      fetch(){
              if(this.loggedInUser && this.loggedInUser.passwordexpired){
                this.changepasswordModel = true
              }
      },
      methods:{

        async logout()
        {
          await this.$auth.logout()
        },
        async SelectMenu(role){
          this.loading = true;
          await this.$store.dispatch("mainmenu/getData",role);
          this.$router.go()
          this.loading = false;
        }
      },
      computed:{
  ...mapGetters(['isAuthenticated', 'loggedInUser']),
  mainmenus(){
    return this.$store.state.mainmenu.records;
  }
 
   }
    }
  </script>