<template>
    <div v-if="applications && applications.length>0">
        <v-card class="mt-3">
            <v-card-title>
                {{ applications.length }} Latest Applicants
                <v-spacer/>
                <v-btn large color="primary" to="/applicants">View All</v-btn>
            </v-card-title>
            <v-card-text>
                <v-simple-table>
                    <template v-slot:default>
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>App Number</th>
                                <th>Name</th>
                                <th>Programme Type</th>
                                <th>Campus</th>
                                <th>Payment Status</th>
                                <th>Approval Status</th>
                                <th>Approved By</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <template v-if="applications && applications.length>0">
                                <tr v-for="appl in applications">
                                    <td>{{ appl.id }}</td>
                                    <td>{{ appl.appNumber }}</td>
                                    <td>{{ appl.applicant.name }} {{ appl.applicant.surname }}</td>
                                    <td>{{ appl.programmeType.name }}</td>
                                    <td>{{ appl.campus.name }}</td>
                                    <td>{{ appl.paymentStatus }}</td>
                                    <td>{{ appl.approvalStatus }}</td>
                                    <td>{{ appl.user ? appl.user.name+" "+appl.user.surname :"--" }}</td>
                                    <td class="text--center">
                                        <v-btn small rounded color="primary" depressed :to="`/applicant/`+appl.uuid">View details</v-btn>
               </td>
                                 </tr>
                            </template>
                            <template v-else>
                                <tr>
                                    <td colspan="8" class="text-center red--text">No Applications found</td>
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
    props:['applications']
 }
</script>
