<template>
    <div>
        <v-btn small rounded color="info" depressed @click="ProgrammeDialog=true">Read more</v-btn>
        <v-dialog v-model="ProgrammeDialog" width="300px">
          <v-card>
          
            <v-system-bar
      window
      dark
      color="primary"
    >
      <span>Attendence Types</span>
      <v-spacer></v-spacer>
      <v-icon @click="ProgrammeDialog=false">mdi-close</v-icon>
    </v-system-bar>
            <v-card-text>
            
                                    <ol>
                                        <li v-for="attype in programme.attendencetypes ">{{ attype.attendenceType.name }}</li>
                                    </ol>
                        

            </v-card-text>
            <v-card-actions>
                <v-btn rounded depressed color="error" @click="ProgrammeDialog=false">Close</v-btn>
          
                <v-spacer/>
                <v-btn rounded depressed color="success" to="/myapplication/programmetype">Apply Now</v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
    </div>
</template>
<script>
  export default{
    props:['programme'],
    data(){
        return{
            ProgrammeDialog:false
        }
    }
  }
</script>