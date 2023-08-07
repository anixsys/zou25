<template>
    <div>
       <v-card outlined class="mt-2">
        <v-card-title>
          3. Add Academic Results
           
        </v-card-title>
        <v-card-text>
            <v-simple-table>
                            <template v-slot:default>
                                <thead>
                                    <tr>
                                        <th>Document Name</th>
                                        <th>Status</th>
                                        <th>Verified</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>
                                <template v-if="documents.length>0">
                                    <tr v-for="doc in documents">
                                     <td>{{ doc.document.name }}</td>
                                     <td><v-chip small :class="doc.status=='MANDETORY' ? 'error' :'info'"> {{ doc.status }}</v-chip></td>
                                      <td>{{ doc.verified}}</td>
                                     <td class="text-right">
                                        <template v-if="doc.applicantdocuments && doc.applicantdocuments.length>0">
                                         <v-btn text color="success"><v-icon>mdi-check-circle-outline</v-icon>Uploaded</v-btn>
                                        </template>
                                        <template v-else>
                                           <ApplicantdocumentUpload :applicant="applicant" :application="application" :doc="doc"/>
                                        </template>
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
  export default{
    props:["applicant",'documents','application'],
    methods:{
        async deleterecord(item){
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
    var payload ={id:item.id,applicantId:this.applicant.id}
            await this.$store.dispatch("applicantdocuments/removeItem",payload);
  }
})
            
        }
    }
  }
</script>