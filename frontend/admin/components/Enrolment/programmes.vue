<template>
    <div>
        <v-card outlined>
        <v-card-title>
            Selected Programmes
            <v-spacer/>
            <v-btn v-if="application.approvalStatus=='AWAITING'" small outlined rounded color="error" @click="rejectall">Reject All</v-btn>
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
                        <td :class="appl.status">
                            {{ appl.status }}
                        </td>
                        <td class="d-flex justify-end pt-2">
                            <v-btn v-if="application.approvalStatus=='AWAITING'"  small rounded color="success" outlined @click="Accepted(appl.id)">Accept</v-btn>
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
 export default{
    props:["application"] ,
    methods:{
        async rejectall(){
            this.$swal({
  title: 'Are you sure?',
  text: "You want to Permanently reject application",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes, reject'
}).then(async (result) => {
  if (result.isConfirmed) {
    await this.$store.dispatch("applicationprogramme/rejectAll",this.application); 
  }
})
        },
        async Accepted(id){
            this.$swal({
  title: 'Are you sure?',
  text: "You want to Accept application",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Yes, reject'
}).then(async (result) => {
  if (result.isConfirmed) {
    var payload = {applicationId:this.application.id,applicationprogrammeId:id,admissionSessionId:this.application.admissionSessionId}
    await this.$store.dispatch("applicationprogramme/Accepted",payload); 
  }
})
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
</style>