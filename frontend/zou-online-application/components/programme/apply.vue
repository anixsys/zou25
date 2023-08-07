<template>
    <div>
        <v-btn rounded depressed color="primary"  @click="getData">Apply</v-btn>
        <v-dialog v-model="ProgrammeDialog" width="400px">
          <v-form ref="form" lazy-validation>
          <v-card>
          
            <v-system-bar
      window
      dark
      color="primary"
    >
      <span>Programme Detail</span>
      <v-spacer></v-spacer>
      <v-icon @click="ProgrammeDialog=false">mdi-close</v-icon>
    </v-system-bar>
    
            <v-card-text>
                <v-simple-table>
                    <template v-slot:default>
                        <tbody>
                            <tr>
                                <th>Code</th>
                                <td>{{ programme.programme.code }}</td>
                            </tr>
                            <tr>
                                <th>Nmae</th>
                                <td>{{ programme.programme.description }}</td>
                            </tr>
                        </tbody>
                    </template>
                </v-simple-table>

            </v-card-text>
            <v-card-actions>
                <v-btn depressed color="error" @click="ProgrammeDialog=false">Cancel</v-btn>
                <v-spacer/>
                <v-btn  depressed color="primary" @click="addRecord">Apply</v-btn>
            </v-card-actions>
          </v-card>
          </v-form>
        </v-dialog>
        <v-overlay :value="overlay">
        <v-progress-circular
          indeterminate
          size="64"
        ></v-progress-circular>
      </v-overlay>
    </div>
</template>
<script>
  export default{
    props:['programme','uuid'],
    data(){
        return{
            ProgrammeDialog:false,
            overlay:false,
            form:{
              uuid:"",
              ProgrammeId:""
            },
              rules: {
            required: value => !!value || 'Required.'
          }
        }
    },
    methods:{
        async getData(){
             this.overlay =true;
            this.ProgrammeDialog = true
            this.overlay = false
        },
       async addRecord(){
        if (this.$refs.form.validate()) {
          this.overlay = true;
          this.form.uuid  = this.uuid;
          this.form.ProgrammeId = this.programme.programme.id
          await this.$store.dispatch("applicationprogramme/addRecord",this.form);
          this.ProgrammeDialog = false
          this.overlay = false;
        }
       }
   
    },computed:{
        attendencetypes() {
      var data = this.programme.attendencetypes
      var types = []
     data.forEach(element => {
           types.push({id:element.attendenceType.id,name:element.attendenceType.name})
      });
      return types
    }
}
  }
</script>