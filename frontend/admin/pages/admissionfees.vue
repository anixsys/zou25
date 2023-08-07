<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
<v-container fluid>
  <v-card>
    <v-card-title>
      Admission Fees<v-spacer/>
      <AdmissionfeetemplateAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Name</th>
              <th>Status</th>
              <th>Date Created</th>
              <th>Date Updated</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="admissionfees.length>0">
            <tr v-for="admissionfee in admissionfees" :key="admissionfee.id">
             <td>{{admissionfee.name }}</td>
             <td :class="admissionfee.status==`PENDING` ?`orange--text`: `green--text`"><b>{{ admissionfee.status }}</b></td>
             <td>{{ admissionfee.dateCreated | formatDate}}</td>
             <td>
              <template v-if="admissionfee.dateUpdated">
                {{ admissionfee.dateUpdated | formatDate }}
              </template>
              <template v-else>
                99-99-9999
              </template>
              
            
            </td>
             <td class="d-flex justify-end pt-2">
              <AdmissionfeeShow :admissionfee="admissionfee"/>
              <AdmissionfeetemplateEdit :admissionfee="admissionfee"/>
              <AdmissionfeetemplateDelete :admissionfee="admissionfee"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="6" class="text-center text-danger">No records found</td></tr>
           </template>
          
          </tbody>
        </template>
      </v-simple-table>
    </v-card-text>
  </v-card>
</v-container>

  
    </div>
</template>
<script>
  export default{
    layout:"mainlayout",
    async fetch() {
    this.overlay = true;
    await this.$store.dispatch("admissionfeetemplate/getData");
    this.overlay = false;
  },
    data(){
        return{
          overlay: false,
            items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: 'Admission Fees',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
    admissionfees() {
      return this.$store.state.admissionfeetemplate.records;
    },
  }
  }
</script>