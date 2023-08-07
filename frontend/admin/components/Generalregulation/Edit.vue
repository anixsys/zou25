<template>
    <div>
      <v-btn small @click="getRecords" outlined rounded depressed class="mr-2" color="primary"> <v-icon >mdi-pencil</v-icon> Edit</v-btn>
    
 
      <!-- <v-btn depressed text color="primary" @click="getRecords"></v-btn> -->
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update General Regulation
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
            <v-text-field
              label="Year"
              placeholder="Year"
              v-model="form.Year"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
            <v-select
              label="Year"
              placeholder="Year"
              v-model="form.ProgrammetypeId"
              :items="programmetypes"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>

            <v-select
              label="Status"
              placeholder="Status"
              v-model="form.Status"
              :items="['PENDING','APPROVED','ARCHIEVED']"
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
    props:["regulation"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            id:this.regulation.id,
            name:this.regulation.name,
            ProgrammetypeId:this.regulation.programmetypeId,
            Status:this.regulation.status,
            Year:this.regulation.year
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{

        async getRecords(){
        await this.$store.dispatch("programmetype/getData");
        this.AddModel=true
      },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("generalregulations/updateItem",this.form); 
          this.loading = false
      }
    }
      },
    computed:{
    programmetypes() {
      return this.$store.state.programmetype.records;
    }
  }
   }
  </script>