<template>
    <v-row>
      <v-col md="8" class="	hidden-sm-and-down">
        <img src="~/assets/images/landing.jpg" width="800px"/>
      </v-col>
      <v-col md="4" sm="12" xs="12">
        <v-form
      ref="form"
      v-model="valid"
      lazy-validation
    >
    <div class="text-center mt-5">
            <img src="~/assets/images/logo.png" width="150px"/>
            <div class="display-1">Welcome to ARIS</div>
          <div class="subtitle">Academic Registry Information System</div>
          </div>
      <v-card flat class="mt-5">
        <v-card-text>
         
          <v-text-field
              label="Username"
              placeholder="Username"
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
          
     <v-btn block color="primary" @click="Login()" :loading="loading">Submit</v-btn>
       
        </v-card-text>
      
     
      </v-card>
      </v-form>
  
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
            }
           // this.$router.push("dashboard");
          } catch (err) {
            this.loading= false;          
            this.$swal("error", err.response.data.message, "error");
          }
       }
      }
    }
    
  }
  </script>
  