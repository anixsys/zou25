<template>
    <div>
      <v-btn icon>
        <v-icon
        class="mr-2"
        @click="getRecords"
      >
        mdi-pencil
      </v-icon>
      </v-btn>
        
        <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Programme
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
                label="Description"
                placeholder="Description"
                v-model="form.description"
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
              <v-select
                label="Programme type"
                placeholder="Programme Type"
                v-model="form.programmeTypeId"
                :items="programmetypes"
                item-value="id"
                item-text="name"
                outlined
                :rules="[rules.required]"
              ></v-select>
              <v-select
                label="Status"
                placeholder="Status"
                v-model="form.status"
                :items="['ACTIVE','ARCHIEVED']"
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
    props:["programme"],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            Id:this.programme.id,
            code:this.programme.Code,
            description:this.programme.narration,
            departmentId:this.programme.departmentId,
            programmeTypeId:this.programme.programmeTypeId,
            status:this.programme.status
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async getRecords(){
        await this.$store.dispatch("department/getData");
        await this.$store.dispatch("programmetype/getData");
        this.AddModel=true
    },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("programmes/updateItem",this.form); 
          this.loading = false
      }
    }
      },
    computed:{
    programmetypes() {
      return this.$store.state.programmetype.records;
    },
    departments() {
      return this.$store.state.department.records;
    }
  }
   }
  </script>