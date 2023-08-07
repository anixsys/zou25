<template>
<div>
    <v-card outlined class="mt-2">
        <v-card-title>
            Applications <v-spacer/>
            <ApplicationsAdd :applicant="applicant"/>
        </v-card-title>
       <v-card-text>
        <v-simple-table>
            <template v-slot:default>
                <thead>
                    <tr>
                        <th>Date </th>
                        <th>App Number</th>
                        <th>Type</th>
                        <th>Attype</th>
                        <th>Programme Type</th>
                        <th>Campus</th>
                        <th>Application fee</th>
                        <th>Application Status</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <template v-if="applicant && applicant.applications.length>0">
                        <tr v-for="application in applicant.applications" :key="application.id">
                         <td>{{ application.dateCreated | formateHumanDiff }}</td>
                          <td>{{ application.appNumber }}</td>
                          <td>{{ application.applicanttype.name }}</td>
                          <td>{{ application.attendenceType.name }}</td>
                          <td>{{ application.programmeType.name }}</td>
                          <td>{{ application.campus.name }}</td>
                          <td :class="application.paymentStatus"><b>{{ application.paymentStatus }}</b></td>
                          <td :class="application.approvalStatus"><b>{{ application.approvalStatus }}</b></td>
                          <td class="d-flex justify-content-end pt-2">
                            <ApplicationsEdit :application="application" v-if="application.paymentStatus=='PENDING'"/>
                            <ApplicationsPayment :application="application" v-if="application.paymentStatus=='PENDING'"/>
                            <ApplicationsResume :application="application" :applicant="applicant" v-if="application.paymentStatus=='PAID'"/>
                          </td>
                        </tr>
                    </template>
                    <template v-else>
                        <tr>
                            <td colspan="7" class="text-center red--text">No Applications found</td>
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
    props:["applicant"]
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
.PENDING{
    color: orange;
    font-weight: bolder;
}
.AWAITING{
    color: blue;
    font-weight: bolder;
}
</style>