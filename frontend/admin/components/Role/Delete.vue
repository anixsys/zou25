<template>
    <div>
      <v-btn color="error"  small @click="Submit"><v-icon>mdi-trash-can</v-icon> Delete</v-btn>
  
    </div>
  </template>
  <script>
   export default{
    props:["role"],
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
    await this.$store.dispatch("roles/removeItem",this.role.id); 
  }
})
    }
      }
   }
  </script>