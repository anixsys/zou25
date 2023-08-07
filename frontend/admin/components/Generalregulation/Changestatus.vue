<template>
    <div>
        <template v-if="regulation.status=='PENDING'">
            <v-btn small outlined rounded depressed class="mr-2" color="success"  @click="ChangeStatus('APPROVED')"> Approve</v-btn>
        </template>
        <template v-else>
            <div class="d-flex">
                <v-btn small outlined rounded depressed class="mr-2" color="primary" @click="ChangeStatus('PENDING')"><v-icon>mdi-clock-edit</v-icon> MODIFY</v-btn>
           <v-btn small outlined rounded depressed color="error" @click="ChangeStatus('ARCHIEVED')"><v-icon>mdi-archive</v-icon>ARCHIEVE</v-btn>
          
            </div>
            
         
        </template>
        
    </div>
  </template>
  <script>
   export default{
    props:['regulation'],
      data(){
          return{
              AddModel:false,
              loading:false,
        }
          
      },methods:{
    async ChangeStatus(status){
        var payload = {Id:this.regulation.id,Status:status}
          await this.$store.dispatch("generalregulations/changestatus",payload); 
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