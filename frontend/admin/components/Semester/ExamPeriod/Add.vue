<template>
    <div>
      <v-btn fab depressed color="primary" @click="AddModel=true"><v-icon>mdi-plus</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New Exam Period
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-text-field
              label="Name"
              placeholder="Name"
              v-model="form.name"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
            <v-menu
      ref="menu"
      v-model="menu"
      :close-on-content-click="false"
      transition="scale-transition"
      offset-y
      min-width="auto"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-text-field
          v-model="date"
           outlined
          label="Start Date"
          prepend-icon="mdi-calendar"         
          readonly
          :rules="[rules.required]"
          v-bind="attrs"
          v-on="on"
        ></v-text-field>
      </template>
      <v-date-picker
        v-model="date"
        @input="menu = false"
      ></v-date-picker>
    </v-menu>
    <v-menu
      ref="menu"
      v-model="menu2"
      :close-on-content-click="false"
      transition="scale-transition"
      offset-y
      min-width="auto"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-text-field
          v-model="date2"
          outlined
          label="End Date"
          prepend-icon="mdi-calendar"         
          readonly
          :rules="[rules.required]"
          v-bind="attrs"
          v-on="on"
        ></v-text-field>
      </template>
      <v-date-picker
        v-model="date2"
        :min="date"
        @input="menu2 = false"
      ></v-date-picker>
    </v-menu>
    </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80" @click="AddModel=false">Cancel</v-btn>
                <v-spacer />
                <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="Submit" :loading="loading"
                  >Submit</v-btn
                >
              </v-card-actions>
        </v-card>
      </v-form>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:['semester'],
      data(){
          return{
              AddModel:false,
              loading:false,
              activePicker: null,
      date: null,
      date2:null,
      menu: false,
      menu2: false,
        valid:false,
        show1:false,
          form:{
            SemesterId:this.semester.id,
            StartDate:"",
            EndDate:"",
            Name:"",
            uuid:this.semester.uuid
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },watch: {
      menu (val) {
        val && setTimeout(() => (this.activePicker = 'YEAR'))
      },
    },methods:{
        save (date) {
        this.$refs.menu.save(date)
      },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          this.form.StartDate = this.date
          this.form.EndDate = this.date2
          await this.$store.dispatch("examinationperiods/addItem",this.form); 
     
          this.loading = false
      }
    }
      }
   }
  </script>