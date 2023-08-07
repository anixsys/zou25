<template>
    <div>
        <v-icon
        small
        class="mr-2"
        @click="getRecords"
      >
        mdi-pencil
      </v-icon>
        <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Course
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-text-field
                label="Code"
                placeholder="Code"
                v-model="form.code"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
              <v-text-field
                label="Name"
                placeholder="Name"
                v-model="form.Name"
                outlined
                :rules="[rules.required]"
              ></v-text-field>
              <v-select
                label="Department"
                placeholder="Department"
                v-model="form.departmentId"
                :items="departments"
                item-value="id"
                item-text="name"
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
    props:["course"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.course.id,
            code:this.course.Code,
            Name:this.course.name,
            departmentId:this.course.departmentId,
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async getRecords(){
        await this.$store.dispatch("department/getData");
        this.AddModel=true
    },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("course/updateItem",this.form); 
          this.$refs.form.reset()
          this.loading = false
      }
    }
      },
    computed:{
    departments() {
      return this.$store.state.department.records;
    }
  }
   }
  </script>