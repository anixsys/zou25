<template>
    <div>
      <v-btn color="error" @click="Submit" small ><v-icon>mdi-trash-can</v-icon> delete</v-btn>
      <v-overlay :value="overlay">
        <v-progress-circular
          indeterminate
          size="64"
        ></v-progress-circular>
      </v-overlay>
    </div>
  </template>
  <script>
   export default{
    props:["id","uuid"],
      data(){
          return{
          overlay:false    
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
    this.overlay = true;
        var payload = {uuid:this.uuid,id:this.id}
        await this.$store.dispatch("applicationprogramme/deleteRecord",payload);
        this.overlay = false;
  }
})
    }
      }
   }
  </script>