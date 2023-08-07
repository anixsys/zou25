<template>
    <div>
      <v-btn color="error" @click="Submit" icon :loading="loading"><v-icon>mdi-trash-can</v-icon></v-btn>
  
    </div>
  </template>
  <script>
   export default{
    props:["semester"],
      data(){
          return{
            loading:false   
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
    this.loading =true
    await this.$store.dispatch("semesters/removeItem",this.semester.uuid); 
    this.loading=false
  }
})
    }
      }
   }
  </script>