<template>
    <div>
       
      <v-list-item link   @click="Submit">
          <v-list-item-title><v-icon small >mdi-trash-can</v-icon> Delete</v-list-item-title>
      </v-list-item>
       </div>
  </template>
  <script>
   export default{
    props:["parameter"],
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
    await this.$store.dispatch("academicregulationparameters/removeItem",this.parameter); 
  }
})
    }
      }
   }
  </script>