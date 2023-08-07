<template>
    <div>
      <v-btn fab depressed color="primary" @click="AddModel=true"><v-icon>mdi-plus</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="900px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              New User
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
                dense
                outlined
                :rules="[rules.required]"
              ></v-text-field></v-col>
                <v-col>
                    <v-text-field
                label="Surname"
                placeholder="Surname"
                v-model="form.surname"
                dense
                outlined
                :rules="[rules.required]"
              ></v-text-field>
                </v-col>
            </v-row>
            <v-row>
                <v-col>
                    <v-text-field
                label="Email"
                type="email"
                placeholder="Email"
                v-model="form.email"
                dense
                outlined
                :rules="[rules.required]"
              ></v-text-field>
                </v-col>
                <v-col>
                    <v-text-field
                label="Phonenumber"
                placeholder="Phonenumber"
                v-model="form.phonenumber"
                dense
                outlined
                :rules="[rules.required]"
              ></v-text-field>
                </v-col>
            </v-row>
            <v-row>
                <v-col>
                  <v-select
                label="Select Gender"
                v-model="form.gender"
                :items="['M','F']"
                dense
                outlined
                :rules="[rules.required]"
              ></v-select>
                </v-col>
                <v-col>
                    <v-select
                label="Title"
                v-model="form.title"
                :items="['Mr','Mrs','Miss','Ms','Dr','Prof','Eng']"
                dense
                outlined
                :rules="[rules.required]"
              ></v-select>
                </v-col>
            </v-row>
        
           
        
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
            surname:"",
            username:"",
            email:"",
            phonenumber:"",
            gender:"",
            title:""
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async Submit(){
      if(this.$refs.form.validate()){        
            this.loading = true
            this.form.username = this.form.email
          await this.$store.dispatch("users/addItem",this.form); 
          this.AddModel=false     
          this.loading = false
          
      }
    }
      }
   }
  </script>