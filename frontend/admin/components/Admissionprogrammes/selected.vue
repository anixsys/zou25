<template>
    <div>
        <v-card outlined v-if="selected.length>0">
            <v-card-title>
                Unsaved Selected Programmes 
                <v-spacer/>
                <v-btn depressed color="primary" v-if="selected.length>0" @click="submit"><v-icon>mdi-plus</v-icon> Commit records</v-btn>
            </v-card-title>
            <v-card-text>
                <v-simple-table>
            <template v-slot:default>
                <thead>
                    <tr>
                        <th>Code</th>
                        <th>Description</th>
                        <th>Attendence Types</th>
                        <td></td>
                    </tr>
                </thead>
                <tbody>
                    <template v-if="selected.length>0">
                        <tr v-for="(select,index) in selected" :key="index">
                    <td>{{ select.code }}</td>
                    <td>{{ select.description }}</td>
                    <td>
                        <template v-if="select.attendencetypes.length>0">
                         <ol>
                            <li v-for="att in select.attendencetypes" class="d-flex justify-space-between">
                              <div>{{ att.name }}</div>
                              <div></div>
                            </li>
                         </ol>
                        </template>
                       
                    
                    </td>
                    <td>
                        <v-btn small icon color="error" @click="removeItem(index)"><v-icon>mdi-trash-can</v-icon></v-btn>
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
    props:['selected','admission'],
    methods:{
        async submit(){
            var payload = { selectedprogrammes:JSON.stringify(this.selected),AdmissionTemplateId:this.admission.id}
          await this.$store.dispatch("admissionprogrammes/addItem",payload); 
          await this.$store.dispatch("admissionprogrammes/getSelected",this.admission.id);
          await this.$store.dispatch("admissionprogrammes/getData",this.admission.programmetypeId);
        },
        removeItem(index){
                this.selected.splice(index,1)
        }
    }
}
</script>