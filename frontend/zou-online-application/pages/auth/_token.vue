<template>
    <v-row justify="center" align="center" class="mt-5">
      <v-col md="6">
        <v-card outlined>
            <v-card-text>
                <v-row>
            <v-col>
                <div class="text-h4 mb-5">Reset Password</div>
        <v-form
      ref="form"
      v-model="valid"
      lazy-validation
    >
     
         
          <v-text-field
              label="Email"
              v-model="form.email"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
            <v-text-field
              label="Password"
              placeholder="Password"
              v-model="form.password"
              :type="show1 ? 'text' : 'password'"
              outlined
              :rules="[rules.required, rules.min]"
              class="mt-3"
              :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
              @click:append="show1 = !show1"
            ></v-text-field>
            <v-text-field
              label="Confirm Password"
              placeholder="Confirm Password"
              v-model="form.password_confirmation"
              :type="show1 ? 'text' : 'password'"
              outlined
              :rules="confirmpasswordRule"
              class="mt-3"
              :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
              @click:append="show1 = !show1"
            ></v-text-field>
          
     <v-btn block color="primary" depressed @click="Login()" :loading="loading">Submit</v-btn>
       
      
      </v-form>
  
      </v-col>
        </v-row>
       
            </v-card-text>
        </v-card>
       
      </v-col>
      
    </v-row>
  </template>
  
  <script>
  export default {
    name: 'resetpassword',
    auth: 'guest',
    data(){
      return{
        valid:false,
        show1:false,
        loading:false,
        form:{
          email:"",
          password:"",
          password_confirmation:"",
          token:""
        },
        rules: {
            required: value => !!value || 'Required.',
            min: v => v.length >= 8 || 'Min 8 characters',
            emailMatch: () => (`The email and password you entered don't match`),
          },
          confirmpasswordRule: [
        (v) => !!v || "Password is required",
        (v) =>
          (v && v.length == this.form.password.length) ||
          "Passwords must match",
      ]
      }
    },methods:{
      async Login(){
       if(this.$refs.form.validate()){
        this.valid = true;
          this.loading = true;
          try {
          this.$axios
            .post("Auth/ResetPassword", this.form)
            .then((res) => {
                if(res.data.status)
                {
                this.$swal("success", res.data.message, "success");
                this.$router.push("login");
                }else{
                    this.$swal("error", res.data.message, "error");  
                }
             
            })
            .catch((err) => {
              this.overlay = false;
              this.$swal("error", err.response.data.message, "error");
            });
        } catch (err) {
          this.overlay = false;
          this.$swal("error", err.response.data.message, "error");
        }
       }
      }
    }
    
  }
  </script>
  