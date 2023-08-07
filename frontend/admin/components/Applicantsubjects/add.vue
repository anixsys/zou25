<template>
    <div>
    <v-form ref="form" lazy-validation>
          <v-card outlined>     
            <v-card-text>
                <v-row>
                    <v-col>
                        <v-select  outlined v-model="form.level" dense  :rules="[rules.required]" :items="['ALEVEL','OLEVEL']" label="Select Level"/>
                    </v-col>
                    <v-col>
                        <v-select  outlined v-model="form.SubjectId" dense :rules="[rules.required]" :items="subjects" label="Select Subject" item-value="id" item-text="name"/>
                    </v-col>
                    <v-col>
                        <v-select  outlined v-model="form.grade" dense  :rules="[rules.required]" :items="['A','B','C','D','E','F']" label="Select Grade"/>
                    </v-col>
                    <v-col class="text-right">
                        <v-btn small rounded outlined color="primary" @click="addRecord"><v-icon>mdi-plus</v-icon> Add Subject</v-btn>
                    </v-col>
                </v-row>

            </v-card-text>
          </v-card>
        </v-form>
       
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
    props:['applicant'],
    data(){
        return{
            ProgrammeDialog:false,
            overlay:false,
            form:{
              level:"",
              SubjectId:"",
              grade:"",
              applicantId:this.applicant.id
            },
              rules: {
            required: value => !!value || 'Required.'
          }
        }
    },
    methods:{
       async addRecord(){
        if (this.$refs.form.validate()) {
          this.overlay = true;
          await this.$store.dispatch("applicantsubject/addItem",this.form);        
          this.overlay = false;
        }
       }
   
    },
    computed:{
      subjects(){
        return this.$store.state.admissionsubjects.records;
      }  
    }
  }
</script>