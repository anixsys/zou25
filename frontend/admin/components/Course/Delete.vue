<template>
    <div>
     <v-icon color="error" small @click="Submit">mdi-trash-can</v-icon>
  
    </div>
  </template>
  <script>
   export default{
    props:["course"],
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
    await this.$store.dispatch("course/removeItem",this.course.id); 
  }
})
    }
      }
   }
  </script>