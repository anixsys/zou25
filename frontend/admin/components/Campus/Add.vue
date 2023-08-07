<template>
  <div>
    <v-btn fab depressed color="primary" @click="getDistricts"><v-icon>mdi-plus</v-icon></v-btn>
    <v-dialog v-model="AddModel" width="600px">
        <v-form ref="form" lazy-validation>
      <v-card>
        <v-card-title>
            New campus
            <v-spacer/>
            <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
        </v-card-title>
        <v-card-text>
          <v-row>
                <v-col>
                <v-text-field
                  label="Name"
                  placeholder="Name"
                  v-model="form.name"
                  outlined
                  :rules="[rules.required]"
                ></v-text-field>
                </v-col>
                <v-col>
                <v-select
                  label="Status"
                  v-model="form.status"
                  :items="['ACTIVE','CLOSED']"
                  outlined
                  :rules="[rules.required]"
                ></v-select>
                </v-col>
                

            </v-row>

            <v-row>
                <v-col>
                  <v-select
                  label="District"
                  v-model="form.districtId"
                  :items="districts"
                  item-text="name"
                  item-value="id"
                  outlined
                  :rules="[rules.required]"
                ></v-select>
                </v-col>
                <v-col>
                <v-select
                  label="Campus Type"
                  v-model="form.campustypeId"
                  :items="campustypes"
                  item-text="name"
                  item-value="id"
                  outlined
                  :rules="[rules.required]"
                ></v-select>
                </v-col>
                

            </v-row>
            


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
          address:"",
          districtId:"",
          campustypeId:"",
          latitude:"",
          longtide:"",
          status:""
        },
        rules: {
            required: value => !!value || 'Required.'
          },
      }
        
    },methods:{

      async getDistricts(){
        await this.$store.dispatch("districts/getData");
        await this.$store.dispatch("campustypes/getData");
        this.AddModel = true
      },
  async Submit(){
    if(this.$refs.form.validate()){
        this.loading = true
        await this.$store.dispatch("campus/addItem",this.form); 
        this.$refs.form.reset()
        this.loading = false
    }
  }
    },
    computed:{
      districts() {
      return this.$store.state.districts.records;
    },
    campustypes() {
      return this.$store.state.campustypes.records;
    }
    }
 }
</script>