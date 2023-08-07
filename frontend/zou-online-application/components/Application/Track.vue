<template>
    <div>
      <v-btn rounded depressed color="success" @click="AddModel=true"><v-icon>mdi-plus</v-icon> Track</v-btn>
      <v-dialog v-model="AddModel" width="800px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Programmes
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-simple-table>
                            <template v-slot:default>
                                <thead>
                                    <tr>
                                        <th>Programme</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                
                                    <tr v-for="prog in application.applicationprogrammes">
                                     <td>{{ prog.programme.description }}</td>
                                     <td :class="prog.status"><b>{{ prog.status }}</b></td>
                                    </tr>
                                
                                </tbody>
                            </template>
                        </v-simple-table>
          </v-card-text>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
  </template>
  <script>
  export default{
    props:['application'],
     data(){
         return{
             AddModel:false,
             loading:false,
         
       }
         
     }
  }
 </script>
 <style scoped>
 .REJECTED{
     color: red;
     font-weight: bolder;
 }
 .ACCEPTED{
     color: green;
     font-weight: bolder;
 }
 .PAID{
     color: green;
     font-weight: bolder;
 }
 .PENDING{
     color: orange;
     font-weight: bolder;
 }
 .AWAITING{
     color: blue;
     font-weight: bolder;
 }
 </style>