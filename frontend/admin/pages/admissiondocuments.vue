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
      Admission Documents<v-spacer/>
      <DocumentAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Name</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="documents.length>0">
            <tr v-for="document in documents" :key="document.id">
             <td>{{document.name }}</td>
             <td class="d-flex justify-end">
              <DocumentEdit :document="document"/>
              <DocumentDelete :document="document"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="3" class="text-center red--text">No records found</td></tr>
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
    await this.$store.dispatch("admissiondocuments/getData");
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
          text: 'Admission Documents',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
    documents() {
      return this.$store.state.admissiondocuments.records;
    },
  }
  }
</script>