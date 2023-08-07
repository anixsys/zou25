<template>
 <div>
  {{ activerole }}
    <template v-if="activerole=='Administrator'">
      <DashboardAdmin/>
    </template>
    <template v-else>
      <DashboardAcademic/>
    </template>
    </div>
</template>
<script>
  import { mapGetters } from 'vuex' 
 export default{
    name:'Dashboard',
    layout:"mainlayout",
    auth: true,
    computed:{
   ...mapGetters(['loggedInUser']),
    mainmenu() {
      return this.$store.state.mainmenu.records;
    },
    activerole(){
    return this.$store.state.activeview.record;
  }
  }
 }
</script>