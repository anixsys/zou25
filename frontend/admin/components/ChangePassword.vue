<template>

    <div>
        <v-form
      ref="form"
      v-model="valid"
      lazy-validation
    >
        <v-card>
            <v-card-title>Change Password</v-card-title>
            <v-card-text>
                <v-text-field
              label="Current Password"
              placeholder="Current Password"
              v-model="form.oldpassword"
              :type="show1 ? 'text' : 'password'"
              outlined
              :rules="passwordRule"
              class="mt-3"
              :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
              @click:append="show1 = !show1"
            ></v-text-field>
                <v-text-field
              label="New Password"
              placeholder="new Password"
              v-model="form.newpassword"
              :type="show1 ? 'text' : 'password'"
              outlined
              :rules="passwordRule"
              class="mt-3"
              :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
              @click:append="show1 = !show1"
            ></v-text-field>
            <v-text-field
              label="Confirm New Password"
              placeholder="Confirm New Password"
              v-model="form.confirmpassword"
              :type="show1 ? 'text' : 'password'"
              outlined
              :rules="confirmpasswordRule"
              class="mt-3"
              :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
              @click:append="show1 = !show1"
            ></v-text-field>
            </v-card-text>
            <v-card-actions>
              <v-btn rounded depressed class="no-uppercase error" max-width="80" @click="AddModel=false">Cancel</v-btn>
              <v-spacer />
              <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="ChangePassword"
                :loading="loading" >Submit</v-btn
              >
            </v-card-actions>
        </v-card>
        </v-form>

    </div>
</template>
<script>
import { mapGetters } from 'vuex' 
 export default{
    data(){
        return{
            valid:false,
            loading:false,
            show1:false,
            form:{
                id:"",
                oldpassword:"",
                newpassword:"",
                confirmpassword:""
            },
            passwordRule: [
        (v) => !!v || "Password is required",
        (v) =>
          (v && v.length >= 10) ||
          "Password must be greater than 10 characters",
      ],
      confirmpasswordRule: [
        (v) => !!v || "Password is required",
        (v) =>
          (v && v.length >= 10) ||
          "Password must be greater than 10 characters",
        (v) =>
          (v && v.length == this.form.newpassword.length) ||
          "Passwords must match",
      ]
        }
    },
    methods:{
        async ChangePassword(){
            if(this.$refs.form.validate()){
                this.valid = true;
                this.loading = true;
                this.form.id = this.loggedInUser.id
                await this.$axios.post("/Profile/ChangePassword",this.form).then(response=>{
                 this.loading = false;
                     if(response.data.status){
                        this.$swal("success", response.data.message, "success")
                        //this.$router.push("dashboard");
                        this.$router.go()
                     }
                }).catch(error=>{
                  this.loading = false
                        this.$swal("error", error.response.data.message, "error");
                })
            }
        }
    },
    computed:{
  ...mapGetters(['isAuthenticated', 'loggedInUser']),
   }
 }
</script>