<template>
    <div>
       <v-card outlined class="mt-2">
        <v-card-title>
         Uploaded Documents
           
        </v-card-title>
        <v-card-text>
            <v-simple-table>
                            <template v-slot:default>
                                <thead>
                                    <tr>
                                        <th>Document Name</th>
                                        <th>Status</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                <template v-if="documents.length>0">
                                    <tr v-for="doc in documents">
                                     <td>{{ doc.admissionDocument.document.name }}</td>
                                     <td><v-chip small :class="doc.admissionDocument.status=='MANDETORY' ? 'error' :'info'"> {{ doc.admissionDocument.status }}</v-chip></td>
                                     <td class="text-right">
                                       <v-btn rounded outlined color="primary" @click="viewfiles(doc.filename)">View document</v-btn>
                                       
                                    </td>
                                    </tr>
                                </template>
                                <template v-else>
                                    <tr>
                                        <td colspan="3" class="text-center red--text">No Required document found</td>
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
    props:['documents'],
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