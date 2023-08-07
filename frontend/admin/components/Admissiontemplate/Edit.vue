<template>
    <div>
      <v-btn depressed icon outlined color="primary" @click="getRecords"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Province
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
              label="Programme Type"
              v-model="form.ProgrammeTypeId"
              :items="programmetypes"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
      
          <v-select
                label="Status"
                :items="['PENDING','ACTIVE','ARCHIEVED']"
                v-model="form.status"
                outlined
                :rules="[rules.required]"
              ></v-select>
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
    props:["admission"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.admission.id,
            name:this.admission.name,
            status:this.admission.status,
            ProgrammeTypeId:this.admission.programmetypeId
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
        async getRecords(){
    this.overlay = true;
    await this.$store.dispatch("programmetype/getData");
    this.AddModel = true
    this.overlay = false;
  },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("admissiontemplates/updateItem",this.form); 
        
          this.loading = false
      }
    }
      }  ,
    computed:{
    programmetypes() {
      return this.$store.state.programmetype.records;
    }
  }
   }
  </script>