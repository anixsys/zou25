<template>

<div>
    <v-row class="mt-5">
       <v-col>
        <v-card>
            <v-card-title>Academic Transcript</v-card-title>
            <v-card-text>
                <v-simple-table>
                    <template v-slo:default>
                        <thead>
                            <tr><th>level</th><th>Subject</th><th>Grade</th><th></th></tr>
                        </thead>
                        <tbody>
                            <tr v-for="sub in subjects">
                             <td>{{ sub.level }}</td>
                             <td>{{ sub.subject.name }}</td>
                             <td>{{ sub.grade }}</td>
                             <td class="text-right"><SubjectDelete :id="sub.id"/></td>
                            </tr>
                        </tbody>
                    </template>
                </v-simple-table>
            </v-card-text>
        </v-card>
       </v-col>
    </v-row>
</div>
</template>
<script>
   export default{
    props:['subjects']
   }
</script>
