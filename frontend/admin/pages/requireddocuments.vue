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
      Required Documents <v-spacer/>
      <RequireddocumentAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Applicant Type</th>
              <th> Programme Type</th>
              <th>Document name</th>
              <th>Requirement Status</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="documents.length>0">
            <tr v-for="document in documents" :key="document.id">
             <td>{{document.applicanttype.name }}</td>
             <td>{{document.programmeType.name }}</td>
             <td>{{document.document.name }}</td>
             <th><v-chip small :class="document.status =='MANDETORY' ? 'error' :'success'">{{ document.status }}</v-chip></th>
             <td class="d-flex justify-end">
              <RequireddocumentEdit :document="document"/>
              <RequireddocumentDelete :document="document"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="7" class="text-center text-danger">No records found</td></tr>
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
    await this.$store.dispatch("requireddocuments/getData");
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
          text: 'Required Documents',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
    documents() {
      return this.$store.state.requireddocuments.records;
    },
  }
  }
</script>