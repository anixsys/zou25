<template>
    <v-card flat outlined>
         <v-card-text>
           <v-list subheader two-line>
             <v-subheader class="title">Programme Types</v-subheader>
       <v-list-item v-for="tem in templates" style="border-bottom: 1px solid black;" link  :to="`/programme/`+tem.admissiontemplates.programmetypeId">
         <v-list-item-content>
           <v-list-item-title>{{tem.admissiontemplates.name}} </v-list-item-title>
        
         </v-list-item-content>
         <v-list-item-action>
            <v-avatar color="primary" size="40" class="white--text" dark>{{tem.admissiontemplates.programmes.length}} </v-avatar>
           </v-list-item-action>
     
       </v-list-item>
  
   
       
     </v-list>
         </v-card-text>
       </v-card>
    
</template>
<script>
 export default{
   props:['templates']
 }
</script>