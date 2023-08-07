<template>
  <div>
    <v-btn fab depressed color="primary" @click="AddModel=true"><v-icon>mdi-plus</v-icon></v-btn>
    <v-dialog v-model="AddModel" width="500px">
        <v-form ref="form" lazy-validation>
      <v-card>
        <v-system-bar
      window
      dark
      color="success"
    >
    <span> New Role</span>
    <v-spacer/>
      
      <v-icon @click="AddModel=false">mdi-close</v-icon>
    </v-system-bar>
        <v-card-text>
            <v-text-field
              label="Name"
              placeholder="Name"
              v-model="form.name"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
            <v-select outlined label="Dashboard View" v-model="form.View" :rules="[rules.required]" :items="['Administration','Academic']"/>
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
    data(){
        return{
            AddModel:false,
            loading:false,
        form:{
          name:"",
          View:""
        },
        rules: {
            required: value => !!value || 'Required.'
          },
      }
        
    },methods:{
  async Submit(){
    if(this.$refs.form.validate()){
        this.loading = true
        await this.$store.dispatch("roles/addItem",this.form); 
        this.$refs.form.reset()
        this.loading = false
    }
  }
    }
 }
</script>