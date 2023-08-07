<template>
    <div>
       <v-card outlined class="mt-2">
        <v-card-title>
          2. Add Academic Results
            <v-spacer/>
           
        </v-card-title>
        <v-card-text>
          <ApplicantsubjectsAdd :applicant="applicant"/>
                    <v-simple-table>
                <template v-slot:default>
                    <thead>
                        <tr>
                            <th>Level</th>
                            <th>Subject</th>
                            <th>Grade</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <template v-if="applicant && applicant.subjects.length>0">
                          <tr v-for="subject in applicant.subjects" :key="subject.id">
                        <td>{{ subject.level }}</td>
                        <td>
                          {{ subject.subject.name }}
                        </td>
                        <td>
                            {{ subject.grade }}
                        </td>
                        <td class="d-flex justify-end pt-2">
                            <v-btn small fab depressed color="error" @click="deleterecord(subject)"><v-icon>mdi-trash-can</v-icon></v-btn>
                        </td>
                    </tr>
                        </template>
                        <template v-else>
                            <tr>
                                <td  colspan="4" class="text-center red--text">No Subjects Selected As Yet</td>
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
    props:["applicant"],
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
            await this.$store.dispatch("applicantsubject/removeItem",payload);
  }
})
            
        }
    }
  }
</script>