<template>
       <v-card class="mt-3" outlined v-if="application.applicationprogrammes && application.applicationprogrammes.length>0">
                    <v-card-title>6. Selected Programmes<v-spacer/><v-btn outlined rounded color="primary" :to="`/selectprogrammes/`+application.uuid">Edit</v-btn></v-card-title>
                    <v-card-text>
                      <v-simple-table>
                            <template v-slot:default>
                                <thead>
                                    <tr>
                                        <th>Programme</th>
                                        <th>Attendence Type</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                
                                    <tr v-for="prog in application.applicationprogrammes">
                                     <td>{{ prog.programme.description }}</td>
                                     <td>{{ prog.attendenceType.name }}</td>
                                     <td>{{ prog.status }}</td>
                                    </tr>
                                
                                </tbody>
                            </template>
                        </v-simple-table>
                    </v-card-text>
                  </v-card>
</template>
<script>
export default{
    props:['application']
}
</script>