<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
<v-container fluid>
  <div v-if="regulation">
  <v-system-bar
      window
      dark
    >   
      <span>{{ regulation.name }} => {{ regulation.programmeType.name }}</span>
      <v-spacer></v-spacer>
      <v-icon>mdi-close</v-icon>
    </v-system-bar>
   
  <Generalregulationregistrationrule :regulation="regulation"/>
  <Generalregulationacademicrule :regulation="regulation"/>
</div>
</v-container>

  
    </div>
</template>
<script>
  export default{
    layout:"mainlayout",
    async mounted() {
    this.overlay = true;
    this.id = this.$route.params.id
    await this.$store.dispatch("generalregulations/getRecord",this.$route.params.id);
    this.overlay = false;
  },
    data(){
        return{
          overlay: false,
          id:"",
            items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: 'General regulations',
          disabled: false,
          href: '/generalregulations',
        },
        {
          text: "General Regulation",
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },methods:{
       changestatus(status){
        
        this.$swal({
  title: 'Are you sure?',
  text: "You want  change status to:  "+status,
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes,'
}).then(async (result) => {
  if (result.isConfirmed) {
    var payload = {status:status,id:this.regulation.id}
    await this.$store.dispatch("generalregulations/changestatus",payload); 
  }
})
    
       }
    },
    computed:{
    regulation() {
      return this.$store.state.generalregulations.record;
    },
  }
  }
</script>