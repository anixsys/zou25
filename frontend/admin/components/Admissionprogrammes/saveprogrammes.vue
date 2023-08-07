<template>
    <div>
        <v-card outlined class="mt-3">
            <v-card-title>
                Saved Selected Programmes 
             </v-card-title>
            <v-card-text>
                <v-simple-table>
            <template v-slot:default>
                <thead>
                    <tr>
                        <th>Code</th>
                        <th>Description</th>
                        <th>Attendence Types</th>
                    </tr>
                </thead>
                <tbody>
                    <template v-if="selected.length>0">
                        <tr v-for="select in selected">
                    <td>{{ select.programme.code }}</td>
                    <td>{{ select.programme.description }}</td>
                    <td>
                        <template v-if="select.attendencetypes.length>0">
                         <ol>
                            <li v-for="att in select.attendencetypes" class="d-flex justify-space-between">
                              <div>{{ att.attendencetype.name }}</div>
                            </li>
                         </ol>
                        </template>
                       
                    
                    </td>
                 </tr>
                    </template>
                    <template v-else>
                        <tr>
                            <td colspan="3" class="text-center red--text"> No programmes selected</td>
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
    props:['selected'],
   
}
</script>