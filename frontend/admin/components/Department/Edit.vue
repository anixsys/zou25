<template>
    <div>
      <v-btn depressed text color="primary" @click="GetRecords"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Department
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
            
            <v-select
              label="Faculty"
              placeholder="Faculty"
              v-model="form.FacultyId"
              :items="faculties"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80" to="/dashboard">Cancel</v-btn>
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
    props:["department"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.department.id,
            name:this.department.name,
            FacultyId:this.department.faculty.id
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
        async GetRecords(){
        await this.$store.dispatch("faculties/getData");
        this.AddModel=true
      },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("department/updateItem",this.form);
          this.loading = false
      }
    }
      },
    computed:{
    faculties() {
      return this.$store.state.faculties.records;
    },
  }
   }
  </script>