<template>
    <div>
        <v-card outlined class="mt-2">
        <v-card-text>
          <v-simple-table dense>
            <template v-slot:default>
              <thead>
                <tr>
                  <th></th>
                  <th>Name</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="role in roles" :key="role.id">
                  <td><v-checkbox
                v-model="rolelist"
                :value="role.name"
              ></v-checkbox></td>
              <td>{{ role.name }}</td>
                </tr>
              </tbody>
            </template>
          </v-simple-table>
        </v-card-text>
        <v-card-actions>
                      <v-spacer />
                <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="Submit" :loading="loading"
                  >Submit</v-btn
                >
              
        </v-card-actions>
      </v-card>
    </div>
</template>
<script>
 export default{
    props:['userId','roles','dbroles'],
    data(){
        return{
          rolelist:this.dbroles.length >0 ?this.dbroles :[] ,
          loading:false,
          form:{
            userId:'',
            roles:''
          }  
        }
    },
    methods:{        
    async Submit(){
        if(this.rolelist.length==0){
            this.errors.push("Please select Department")   
          }
         var roles=JSON.stringify(this.rolelist)
         this.form.userId = this.userId;
         this.form.roles = roles;
         this.loading = true;
         await this.$store.dispatch("userroles/addItem",this.form); 
         this.loading = false
    }
    }
 }
</script>