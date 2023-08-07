<template>
    <v-row justify="center" align="center" class="mt-5">
      <v-col md="4">
        <v-card outlined>
            <v-card-text>
                <v-row>
           
            <v-col sm="12" xs="12">
                <div class="text-h4 mb-5">Login</div>
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
          
     <v-btn block color="primary" depressed @click="Login()" :loading="loading">Submit</v-btn>
       
        <v-btn text block to="/register">Create An Account</v-btn>
        <v-btn text block to="/forgot-password">Forgot Password</v-btn>
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
    name: 'Login',
    auth: 'guest',
    data(){
      return{
        valid:false,
        show1:false,
        loading:false,
        form:{
          email:"",
          password:""
        },
        rules: {
            required: value => !!value || 'Required.',
            min: v => v.length >= 8 || 'Min 8 characters',
            emailMatch: () => (`The email and password you entered don't match`),
          },
      }
    },methods:{
      async Login(){
       if(this.$refs.form.validate()){
        this.valid = true;
          this.loading = true;
          try {
            const response = await this.$auth.loginWith("local", {
              data: this.form,
            });
            this.loading = false;
            if(response.data.status){
              this.$router.push("dashboard");
            }else{
              this.$swal("error",response.data.message,"error")
            }
           // this.$router.push("dashboard");
          } catch (err) {
            this.loading= false;           
            this.$swal("error", "Failed to connect to  server main system is down please try again later", "error");
          }
       }
      }
    }
    
  }
  </script>
  