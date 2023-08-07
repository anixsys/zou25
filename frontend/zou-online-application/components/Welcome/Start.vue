<template>
    <div>
        <template v-if="admissionsession && admissionsession.isPublished">
            <WelcomeCall :admissionsession="admissionsession"/>

                
                <v-row class="my-10">
                <v-col v-for="prog in admissionsession.admissionsessiontemplate" md="4" xs="12" sm="12">
                    <v-card
                    
    :loading="loading"
    class="border-t"
    outlined
  >
    <template slot="progress">
      <v-progress-linear
        color="deep-purple"
        height="10"
        indeterminate
      ></v-progress-linear>
    </template>

    <v-card-text class="text-center">
        <div class="text-h4">{{ prog.admissiontemplates.programmes.length }}</div> 
         <div class="text-h5">{{ prog.admissiontemplates.name }} </div>
    </v-card-text>
    <v-card-actions class="d-flex justify-center">
                <v-btn color="primary" rounded depressed :to="`/programme/`+prog.admissiontemplates.id">View programmes</v-btn>
            </v-card-actions>
   
  </v-card>
                
                 
                   
                </v-col>
                
                </v-row>
        </template>
        <template v-else>
            <v-card outlined>
                <v-card-text class="text-center">
                    <v-alert type="error">Sorry we currently do not have any enrollment sessions open please try again later </v-alert>
                </v-card-text>
           
            </v-card>
           
        </template>

  </div>

</template>
<script>
  export default{
   props:["admissionsession"],
   data(){
    return{
        loading:false
    }
   }
  }
</script>