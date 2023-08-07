<template>
    <div>
      <v-btn icon @click="Submit">
        <v-icon color="error">mdi-trash-can</v-icon>
      </v-btn>
     
  
    </div>
  </template>
  <script>
   export default{
    props:["specialization"],
      data(){
          return{
             
        }
          
      },methods:{
    async Submit(){
        this.$swal({
  title: 'Are you sure?',
  text: "You want to Permanently delete record ",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes, delete it!'
}).then(async (result) => {
  if (result.isConfirmed) {
    await this.$store.dispatch("programmespecialization/removeItem",this.specialization.id); 
  }
})
    }
      }
   }
  </script>