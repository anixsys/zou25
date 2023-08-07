<template>
  <div>
    <v-card outlined class="mt-2">
        <v-card-text>
          
              <v-simple-table>
                <template v-slot:default>
                  <thead>
                    <tr><th><v-checkbox 
                value="*"
                @change="selectAll($event)"
              ></v-checkbox></th><th>Name</th></tr>
                  </thead>
                  <tbody>
                    <tr v-for="campus in campuses" :key="campus.id">
                     <td>   
                      <v-checkbox
                v-model="campuslist"
                :value="campus.id"
              ></v-checkbox></td>
              <td>
                {{ campus.name }}
              </td>
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
    props:['campuses','userId','dbcampus'],
    data(){
       return{
        campuslist:this.dbcampus.length>0 ? this.dbcampus :[],
        errors:[],
        loading:false,
        form:{
            userId:"",
            campuses:""
        }
       }
    },
    methods:{
        selectAll(event){
      if(event =="*"){
          this.campuses.forEach(campus=>{
            this.campuslist.push(campus.id)
          })
      }else{
       this.campuslist=[]
      }        
    },
    async Submit(){
        if(this.campuslist.length==0){
            this.errors.push("Please select Campues")   
          }
         var campuses =JSON.stringify(this.campuslist)
         this.form.userId = this.userId;
         this.form.campuses = campuses;
         this.loading = true;
         await this.$store.dispatch("usercampus/addItem",this.form); 
         this.loading = false
    }
    }
 }
</script>