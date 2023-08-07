<template>
    <div>
        <v-btn small outlined rounded depressed class="mr-2" color="indigo" @click="Submit"> <v-icon >mdi-content-copy</v-icon> Duplicate</v-btn>
    
    </div>
  </template>
  <script>
   export default{
    props:['regulation'],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            name:"",
            year:"",
            description:"",
            id:"",
            DecisionsettingId:"",
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
          await this.$store.dispatch("generalregulations/duplicaterecord",this.regulation.id); 
          this.loading = false
      
    }
      },
    computed:{
    generalsettings() {
      return this.$store.state.generalsetting.records;
    }
  }
   }
  </script>