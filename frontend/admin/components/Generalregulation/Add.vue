<template>
  <div>
    <v-btn fab depressed color="primary" @click="getRecords"><v-icon>mdi-plus</v-icon></v-btn>
    <v-dialog v-model="AddModel" width="500px">
        <v-form ref="form" lazy-validation>
      <v-card>
        <v-card-title>
            New General Regulation
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
              label="Programme Type"
              v-model="form.ProgrammetypeId"
              :items="programmetypes"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
            <v-textarea
              label="Description"
              placeholder="Description"
              v-model="form.description"
              outlined
              :rules="[rules.required]"
            ></v-textarea>
            <v-select
              label="Select General Setting"
              v-model="form.GlobalsettingtemplateId"
              :items="generalsettings"
              item-text="description"
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
    data(){
        return{
            AddModel:false,
            loading:false,
        form:{
          name:"",
          GlobalsettingtemplateId:"",
          Description:"",
          ProgrammetypeId:"",
          Year:""
        },
        rules: {
            required: value => !!value || 'Required.'
          },
      }
        
    },methods:{

      async getRecords(){
        await this.$store.dispatch("programmetype/getData");
        await this.$store.dispatch("generalsetting/getRecords");
        this.AddModel=true
      },
  async Submit(){
    if(this.$refs.form.validate()){
        this.loading = true
        await this.$store.dispatch("generalregulations/addItem",this.form); 
        this.$refs.form.reset()
        this.loading = false
    }
  }
    },
    computed:{
    programmetypes() {
      return this.$store.state.programmetype.records;
    },
    generalsettings() {
      return this.$store.state.generalsetting.records;
    }
  }
 }
</script>