<template>
    <div>
       <v-card outlined class="mt-2" v-if="requirements && requirements.length>0">
        <v-card-title>
        Entry Requirements
           
        </v-card-title>
        <v-card-text>
            <v-simple-table>
                            <template v-slot:default>
                                <thead>
                                    <tr>
                                        <th>Document Name</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                <template v-if="requirements.length>0">
                                    <tr v-for="doc in requirements">
                                     <td>{{ doc.modeRequirement.name }}</td> <td class="text-right">
                                       <v-btn rounded outlined color="primary" @click="viewfiles(doc.filename)">View document</v-btn>
                                       
                                    </td>
                                    </tr>
                                </template>
                                <template v-else>
                                    <tr>
                                        <td colspan="3" class="text-center red--text">No Entry requirement document found</td>
                                    </tr>
                                </template>
                                </tbody>
                            </template>
                        </v-simple-table>
        </v-card-text>
       </v-card>
    </div>
</template>
<script>
import {saveAs} from 'file-saver';
  export default{
    props:['requirements'],
    methods:{
        async viewfiles(filename){
            
                    this.loading = true; 
                    await this.$axios({
                        method: "GET",
                        url: "ApplicantDocument/viewdocument/"+filename,
                        responseType: 'blob',
                    }).then(async (res) => {
                        saveAs(res.data, filename);
                    })
                
        }
    }
   
  }
</script>