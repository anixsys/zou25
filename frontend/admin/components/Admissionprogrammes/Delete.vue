<template>
    <div>
      <v-btn color="error" @click="Submit" icon outlined><v-icon>mdi-trash-can</v-icon></v-btn>
  
    </div>
  </template>
  <script>
   export default{
    props:["admission"],
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
    var payload = {id:this.admission.id,AdmissiontemplateId:this.admission.admissionTemplateId}
    await this.$store.dispatch("admissionprogrammes/removeItem",payload); 
  }
})
    }
      }
   }
  </script>