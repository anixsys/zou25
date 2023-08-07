<template>
    <div>
        <v-btn rounded outlined small color="error" @click="Submit">Reset Password</v-btn>
  
    </div>
  </template>
  <script>
   export default{
    props:["user"],
      data(){
          return{
             
        }
          
      },methods:{
    async Submit(){
        this.$swal({
  title: 'Are you sure?',
  text: "You want to Reset User Password ",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes, Reset!'
}).then(async (result) => {
  if (result.isConfirmed) {
    await this.$store.dispatch("users/resetPassword",this.user.id); 
  }
})
    }
      }
   }
  </script>