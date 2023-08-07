<template>
    <div v-if="applications && applications.length>0">
        <v-card class="mt-3">
            <v-card-title>
                {{ applications.length }} Latest Applicants
            </v-card-title>
            <v-card-text>
                <v-text-field
          v-model="search"
          outlined
          dense
          append-icon="mdi-magnify"
          label="Search"
          single-line
          hide-details
        ></v-text-field>
        <v-data-table :headers="headers" :items="applicationlist" :search="search">
          <template v-slot:item.actions="{ item }">
            <div class="d-flex justify-end">
              <v-btn small rounded color="primary" depressed :to="`/applicant/`+item.uuid">View details</v-btn>
            </div>
          </template>
        </v-data-table>
            </v-card-text>
        </v-card>
    </div>
</template>
<script>
 export default{
    props:['applications'],
    data(){
        return{
            overlay: false,
      search: "",
      headers: [
        {
          text: "Id",
          align: "start",
          value: "Id",
        },
        { text: "UniqueId", value: "uuid" },
        { text: "App Number", value: "appNumber" },
        { text: "Name", value: "name" },
        { text: "Programme Type", value: "programmetype" },
        { text: "Campus", value: "campus" },
        { text: "Payment Status", value: "paymentStatus" },
        { text: "Approval Status", value: "approvalStatus" },
        { text: "Approved By", value: "user" },
        { text: "Actions", value: "actions", sortable: false },
      ],
        }
    },
    computed:{
        applicationlist(){
            var data = []
            if(this.applications.length>0)
            {
                     this.applications.forEach(element => {
                      var user = element.user ? element.user.name +" "+element.user.surname:"--"
                       data.push({Id:element.id,uuid:element.uuid,appNumber:element.appNumber,name:element.applicant.name+" "+element.applicant.surname,programmetype:element.programmeType.name,campus:element.campus.name,paymentStatus:element.paymentStatus,approvalStatus:element.approvalStatus,user:user}) 
                     });
            }
            return data;
        }
    }
 }
</script>
