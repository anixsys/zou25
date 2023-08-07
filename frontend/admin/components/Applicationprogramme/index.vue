<template>
    <div>
       <v-card outlined>
        <v-card-title>
            <div class="red--text">*</div> Selected Programmes
            <v-spacer/>
            <ApplicationprogrammeAdd v-if="application.approvalStatus!='AWAITING'"  :application="application"/>
        </v-card-title>
        <v-card-text>
            <v-simple-table>
                <template v-slot:default>
                    <thead>
                        <tr>
                            <th>Programme</th>
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <template v-if="application && application.applicationprogrammes.length>0">
                          <tr v-for="appl in application.applicationprogrammes" :key="appl.id">
                        <td>
                            <div>{{ appl.programme.description }}</div>
                            <small>{{ appl.programme.code }}</small>
                        </td>
                        <td>
                            {{ appl.status }}
                        </td>
                        <td class="d-flex justify-end pt-2" style="text-align: center;">
                            <v-btn small fab depressed color="error" v-if="application.approvalStatus=='AWAITING'"  @click="deleterecord(appl)"><v-icon>mdi-trash-can</v-icon></v-btn>
                            <v-btn small rounded depressed color="success" v-if="appl.status=='ACCEPTED'" @click="viewdocument">Download Offer letter</v-btn>
                        </td>
                    </tr>
                        </template>
                        <template v-else>
                            <tr>
                                <td  colspan="3" class="text-center red--text">No Programmes Selected As Yet</td>
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
    props:["application"],
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
    var payload ={id:item.id,applicantId:this.application.applicantId}
            await this.$store.dispatch("applicationprogramme/removeItem",payload);
  }
})
            
        },
        async viewdocument(){
            
            this.loading = true; 
            await this.$axios({
                method: "GET",
                url: "Application/record/"+this.application.uuid,
                responseType: 'blob',
            }).then(async (res) => {
                saveAs(res.data, "Offerletter_"+this.application.uuid+".pdf");
            })
        

    
       }
    }
  }
</script>