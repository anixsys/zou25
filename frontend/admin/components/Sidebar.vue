<template>
    <div>

      <v-list>
         
            <v-subheader class="text-md-body-1">
              <v-select outlined dense class="pt-2 px-2" v-model="currentrole" :items="roleview" item-value="index" item-text="name" @change="SwithView"></v-select> 
            </v-subheader>  
        
      <v-divider/>

 
          <template v-if="mainmenus && mainmenus.length>0">
            <v-list-group v-for="menu in mainmenus" style="border-bottom: 1px solid #E0E0E0;"  active-class="primary lighten-3 black--text">
          
              <template v-slot:activator>
                  <v-list-item-title ><v-icon small class="mr-1">{{ menu.icon }}</v-icon>{{menu.name}}</v-list-item-title>  
              </template>  
              
              <v-list-item  v-for="submenu in menu.submenues" link :to="submenu.url" dense subheader  active-class="black--text" style="border-top: 1px solid #E0E0E0;">
                  <v-list-item-title><v-icon x-small class="ml-1 mr-1">{{ submenu.icon }}</v-icon>{{ submenu.name }}</v-list-item-title>         
              </v-list-item>
              <v-divider/>        
          </v-list-group>
          </template>
          <template v-else>
            <p class="red--text text-center">--</p>
          </template>
        <v-divider/>
        </v-list>
    
       
    </div>
</template>
<script>
 import { mapGetters } from 'vuex' 
 export default{
  data(){
    return{
     currentrole:0
    }
  },
  fetch(){
     this.SwithView()
  },
  methods:{
    SwithView(){    
      var name = this.roleview[this.currentrole].name
      this.$store.dispatch("activeview/SetView",name); 
    }
  },
  computed:{
  ...mapGetters(['isAuthenticated', 'loggedInUser']), 
  mainmenus(){
   return this.loggedInUser.role[this.currentrole].mainmenu; 
   },
   roleview(){
  var array = [];
  var i = 0;
    this.loggedInUser.role.forEach(element => {
          var item = {index:i,name:element.name}
          i++
          array.push(item)
    });
    return array;
   },
  activerole(){
    return this.loggedInUser.role[this.currentrole].name;
  }

   }
 }
</script>