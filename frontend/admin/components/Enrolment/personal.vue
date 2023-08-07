<template>
  <div>
    <v-card outlined class="mt-2">
                  <v-card-text>
                    <v-simple-table dense>
                      <template v-slot:default>
                        <tbody>
                          <tr><th>Title</th><td>{{ applicant.title }}</td></tr>
                          <tr><th>Name</th><td>{{ applicant.name }}</td></tr>
                          <tr><th>Surname</th><td>{{ applicant.surname }}</td></tr>
                          <tr><th>Email</th><td>{{ applicant.email }}</td></tr>
                          <tr><th>Marital Status</th><td>{{ applicant.maritalStatus }}</td></tr>
                          <tr><th>Maiden name</th><td>{{ applicant.maidenname }}</td></tr>
                          <tr><th>D.O.B</th><td>{{ applicant.dob }}</td></tr>
                          <tr><th>Identification Type</th><td>{{ applicant.identificationType }}</td></tr>
                          <tr><th>Identification Number</th><td>{{applicant.identification }}</td></tr>
                          <tr><th>Gender</th><td>{{ applicant.gender }}</td></tr>
                          <tr><th>Address</th><td>{{ applicant.address }}</td></tr>
                          <tr><th>City</th><td>{{ applicant.city }}</td></tr>
                          <tr><th>Country</th><td>{{ applicant.country }}</td></tr>
                        </tbody>
                      </template>
                    </v-simple-table>
                  </v-card-text>
                </v-card>
  </div>
</template>
<script>
 export default{
    props:['applicant']
 }
</script>