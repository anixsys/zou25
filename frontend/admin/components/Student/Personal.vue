<template>
    <div>
        <v-card outlined>
           <v-card-text>
            <v-row>
                <v-col class="text-center">
                    <v-card outlined>
                        <v-card-title>
                            <v-spacer/>
                            <StudentUpload :student="profile"/>
                        </v-card-title>
                        <v-card-text>
                            <v-avatar  size="300">
           
           <v-img
         
           height="300"
           width="300"
           :src="profilepicture"
           ></v-img>
         
</v-avatar>
                        </v-card-text>
                    </v-card>
                   
                </v-col>
                <v-col>
                    <v-simple-table>
                <template v-slot:default>
                    <tbody>
                        <tr><th>Pin</th><td>{{ profile.pin }}</td></tr>
                        <tr><th>Title</th><td>{{ profile.title }}</td></tr>
                        <tr><th>Name</th><td>{{ profile.fullName }}</td></tr>
                        <tr><th>Email</th><td>{{ profile.email }}</td></tr>
                        <tr><th>D.O.B</th><td>{{ profile.dob }}</td></tr>
                        <tr><th>Gender</th><td>{{ profile.gender }}</td></tr>
                        <tr><th>Identification Type</th><td>{{ profile.identificationtype }}</td></tr>
                        <tr><th>Identification Number</th><td>{{ profile.identificationnumber }}</td></tr>
                        <tr><th>Intake</th><td>{{ profile.intake }}</td></tr>
                    </tbody>
                </template>
             </v-simple-table>
                </v-col>
            </v-row>
           
           </v-card-text>
        </v-card>
    </div>
</template>
<script>
   export default{
    props:['profile'],
    data(){
        return{
            showMenu: false,
      x: 0,
      y: 0,
        }
    },
    methods: {
      show (e) {
        e.preventDefault()
        this.showMenu = false
        this.x = e.clientX
        this.y = e.clientY
        this.$nextTick(() => {
          this.showMenu = true
        })
      },
    },
    computed:{
        profilepicture(){
          var name =  this.profile.profile ? this.profile.profile :"profile.jpg"
          return this.$store.state.servers.link+"/profile/"+name
        }
    }
   }
</script>