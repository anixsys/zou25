<template>
 <v-card class="mt-3" outlined v-if="applicant">
    <v-card-title>3. Academic Results  <v-spacer/><v-btn outlined rounded color="primary" :to="`/academic/`+uuid">Edit</v-btn></v-card-title>
    <v-card-text>
      <v-simple-table dense>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Level</th>
              <th>Subject</th>
              <th>Grade</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="subject in applicant.subjects">
             <td>{{ subject.level }}</td>
             <td>{{ subject.subject ? subject.subject.name :"" }}</td>
             <td>{{ subject.grade}}</td>
            </tr>
             
          </tbody>
        </template>
      </v-simple-table>
    </v-card-text>
  </v-card> 
</template>
<script>
  export default{
    props:['applicant','uuid']
  }
</script>
