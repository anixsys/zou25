<template>
    <div>
        <v-form ref="form" lazy-validation>
        <v-card outlined class="mt-2">
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
                label="Account Status"
                v-model="form.status"
                :items="['ACTIVE','BLOCKED']"
                dense
                outlined
                :rules="[rules.required]"
              ></v-select>
              </v-col>
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
                <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="submit" :loading="loading"
                  >Submit</v-btn
                >
              </v-card-actions>
      </v-card>
      </v-form>
      
    </div>
</template>
<script>
  export default{
    props:['user'],
    data(){
        return{
            form:{
            id:this.user.id,
            name:this.user.name,
            surname:this.user.surname,
            email:this.user.email,
            gender:this.user.gender,
            title:this.user.title,
            phonenumber:this.user.phonenumber,
            status:this.user.status
          },
          rules: {
              required: value => !!value || 'Required.'
            },
          loading:false,
        }
    },
    methods:{
        async submit(){
            if(this.$refs.form.validate()){
                this.loading = true
                await this.$store.dispatch("users/updateItem",this.form); 
                this.loading = false
            }
        }
    }
  }
</script>