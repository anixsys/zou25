<template>
  <div>
    <v-btn text depressed color="primary" @click="getDistricts"><v-icon>mdi-pencil</v-icon></v-btn>
    <v-dialog v-model="AddModel" width="600px">
        <v-form ref="form" lazy-validation>
      <v-card>
        <v-card-title>
            Update Campus
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
            <v-row>
                <v-col>
                <v-text-field
                  label="Longitude"
                  placeholder="longitude"
                  v-model="form.longitude"
                  outlined
                  :rules="[rules.required]"
                ></v-text-field>
                </v-col>
                <v-col>
                <v-text-field
                  label="Latitude"
                  placeholder="Latitude"
                  v-model="form.latitude"
                  outlined
                  :rules="[rules.required]"
                ></v-text-field>
                </v-col>
          </v-row>
          <v-row>
                <v-col>
                <v-textarea
                  label="Address"
                  placeholder="Address"
                  v-model="form.address"
                  outlined
                  :rules="[rules.required]"
                ></v-textarea>
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
  props:["campus"],
    data(){
        return{
            AddModel:false,
            loading:false,
        form:{
          name:this.campus!=null ? this.campus.name :"",
          address: this.campus!=null ? this.campus.address :"",
          districtId: this.campus!=null ? this.campus.districtId :"",
          campustypeId: this.campus!=null ? this.campus.campusTypeId :"",
          latitude:this.campus!=null ? this.campus.latitude :"",
          longitude:this.campus!=null ? this.campus.longitude :"",
          status:this.campus!=null ? this.campus.status :"",
          id:this.campus!=null ? this.campus.id:""
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
        await this.$store.dispatch("campus/updateItem",this.form); 
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