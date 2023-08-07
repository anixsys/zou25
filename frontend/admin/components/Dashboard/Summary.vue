<template>
   
        <v-col md="3">
            <v-card>              
               <v-card-text>
                  <div class="d-flex justify-space-between">
                     <div>
                         <div class="text-lg-h6">{{ summary.total }}</div>
                         <div>{{ summary.name }} Admissions</div>
                     </div>
                     <div>
                        <v-btn large height="60px" :color="color"><v-icon>mdi mdi-school</v-icon></v-btn>
                     </div>
                  </div>
               </v-card-text>
            </v-card>
         </v-col>
    
</template>
<script>
  export default{
    props:['summary'],
    computed:{
        color(){
            var color="primary";
            if(this.summary.name=='Pending'){
                color="warning"
            }else if(this.summary.name=='Awaiting'){
                color="info"
            }else if(this.summary.name=='Accepted'){
                color="success"
            }else if(this.summary.name=='Rejected'){
                color="error"
            }
            return color
        }
    }
  }
</script>