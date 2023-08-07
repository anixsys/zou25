<template>
    <div>
   <v-btn small fab outlined color="success" @click="GetData"><v-icon>mdi-currency-usd</v-icon></v-btn>
  <v-dialog v-model="showDialog">
    <v-card>
    <v-card-title>
      Admission Fees<v-spacer/>
      <AdmissionfeeAdd :admissionFee="admissionfee"/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>ID</th>
              <th>Applicant Type</th>
              <th>Programme Type</th>
              <th>Cost</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="admissionfees.length>0">
            <tr v-for="fee in admissionfees" :key="fee.id">
             <td>{{fee.id }}</td>
             <td>{{fee.applicanttype.name }}</td>
             <td>{{ fee.programmeType.name }}</td>
             <td>{{ fee.currency.name }} {{ fee.amount  }}</td>
             <td class="d-flex justify-end">
              <AdmissionfeeEdit :admissionfee="fee"/>
              <AdmissionfeeDelete :admissionfee="fee"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="5" class="text-center text-danger">No records found</td></tr>
           </template>
          
          </tbody>
        </template>
      </v-simple-table>
    </v-card-text>
  </v-card>
</v-dialog>

 

  
    </div>
</template>
<script>
  export default{
    layout:"mainlayout",
    props:['admissionfee'],
    data(){
        return{
          overlay: false,
          showDialog:false
       
        }
    },
    methods:{
        async GetData() {
    this.overlay = true;
    await this.$store.dispatch("admissionfees/getData",this.admissionfee.id);
    this.showDialog=true
    this.overlay = false;
  }
    },
    computed:{
    admissionfees() {
      return this.$store.state.admissionfees.records;
    },
  }
}
</script>