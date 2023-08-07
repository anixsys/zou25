<template>
    <div>
      <v-btn color="error" @click="Submit" icon><v-icon>mdi-trash-can</v-icon></v-btn>
  
    </div>
  </template>
  <script>
   export default{
    props:["campus"],
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
    await this.$store.dispatch("campus/removeItem",this.campus.id); 
  }
})
    }
      }
   }
  </script>