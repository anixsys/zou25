<template>
   <div>
    <template v-if="application">
                <v-card class="mt-3" outlined>
                  <v-card-title>2. Application Details</v-card-title>
                  <v-card-text>
                    <v-simple-table dense>
                      <template v-slot:default>
                        <tbody>
                          <tr><th>Application Number</th><td>{{ application.appNumber }}</td></tr>
                          <tr><th>Application Type</th><td>{{ application.applicanttype ? application.applicanttype.name :"" }}</td></tr>
                          <tr><th>Programme Type</th><td>{{ application.programmeType ? application.programmeType.name :"" }}</td></tr>
                          <tr><th>Campus</th><td>{{ application.campus ? application.campus.name :"" }}</td></tr>
                          <tr><th>Application fee</th><td>{{ application.paymentStatus }}</td></tr>
                          <tr><th>Application Status</th><td>{{ application.approvalStatus }}</td></tr>
                       
                        </tbody>
                      </template>
                    </v-simple-table>
                  </v-card-text>
                </v-card>            
                
              </template>
   </div>
</template>
<script>
 export default{
    props:['application']
 }
</script>