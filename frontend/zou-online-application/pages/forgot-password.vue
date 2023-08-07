<template>
    <v-row justify="center" align="center" class="mt-5">
      <v-col md="4">
        <v-card>
            <v-card-text>
                <v-row>
            <v-col md="12" sm="12" xs="12">
                <div class="text-h4 mb-5">Forgot Password</div>
        <v-form
      ref="form"
      v-model="valid"
      lazy-validation
    >
     
      <v-row>
        <v-col>
            <v-text-field
            dense
              label="Email"
              v-model="email"
              outlined
              :rules="[rules.required]"
            ></v-text-field> 
        </v-col>
      
      </v-row>                    
   
      </v-form>
  
      </v-col>
        </v-row>
       
            </v-card-text>
            <v-card-actions>
                <v-btn  color="error" to="/" depressed  :loading="loading">Cancel</v-btn>
                <v-spacer/>
                <v-btn  color="primary" depressed @click="Login()" :loading="loading">Submit</v-btn>
            </v-card-actions>
        </v-card>
      </v-col>
      
    </v-row>
  </template>
  
  <script>
  export default {
    name: 'Login',
    auth: 'guest',
    data(){
      return{
        email:"",
        valid:false,
        loading:false,
       
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
      ],
         
      }
    },methods:{
      
      async Login(){
        if (this.$refs.form.validate()) {
        this.valid = true;
        this.overlay = true;
        try {
          this.$axios
            .get("Auth/ForgotPassword/"+this.email)
            .then((res) => {
                if(res.data.status)
                {
                this.$swal("success", res.data.message, "success");
                this.$router.push("/");
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
  