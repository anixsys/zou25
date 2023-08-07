<template>
    <div>
      <v-btn color="success"  @click="Submit" icon :loading="loading"><v-icon>mdi mdi-thumb-up</v-icon></v-btn>
  
    </div>
  </template>
  <script>
   export default{
    props:["record"],
      data(){
          return{
            loading:false   
        }
          
      },methods:{
    async Submit(){
        this.$swal({
  title: 'Are you sure?',
  text: "You have captured all fee ordinace entries , The system will check if there are any invoices generated using previous template  and generate top up entry ",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes,Approve'
}).then(async (result) => {
  if (result.isConfirmed) {
    this.loading =true
    await this.$store.dispatch("regfeetemplates/Approve",this.record); 
    this.loading=false
  }
})
    }
      }
   }
  </script>