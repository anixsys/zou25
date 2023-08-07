<template>

<v-dialog v-model="openModel" width="500px">
    <v-card>
        <v-card-title>
            Action Responses
            <v-spacer/>
            <v-btn icon @click="showDailog=false"><v-icon>mdi-close</v-icon></v-btn>
        </v-card-title>
        <v-card-text>
            <v-alert v-for="(res,index) in responselist" :type="res.status ? `success` :`error`" :key="index">
                {{ res.message }}
             </v-alert>
         
        </v-card-text>
    </v-card>
</v-dialog>
</template>
<script>
export default{
    props:["openModel","responselist"],
    data(){
        return{
            showDailog : this.openModel
        }
    }
}
</script>