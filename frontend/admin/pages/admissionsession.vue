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
      Admission Sessions<v-spacer/>
      <AdmissionsessionAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Name</th>
              <th>Year</th>
              <th>Start Date</th>
              <th>End Date</th>
              <th>Published</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="admissionsessions.length>0">
            <tr v-for="admissionsession in admissionsessions" :key="admissionsession.id">
             <td>{{admissionsession.name }}</td>
             <td>{{admissionsession.year }}</td>
             <td>{{admissionsession.startDate }}</td>
             <td>{{admissionsession.endDate }}</td>
             <td :class="admissionsession.isPublished ? `green--text` :`orange--text`"><b>{{ admissionsession.isPublished ? `Y` :`N` }}</b></td>
             <td class="d-flex justify-end">
                    <AdmissionsessionEdit :admissionsession="admissionsession"/>
              <AdmissionsessionDelete :admissionsession="admissionsession"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="7" class="text-center red--text">No records found</td></tr>
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
    await this.$store.dispatch("admissionsessions/getData");
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
          text: 'Admission Sessions',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },methods:{
     async ChangeStatus(id,status){
      var payload ={id:id,status:status}
      await this.$store.dispatch("admissionsessions/changeStatus",payload);
     }
    },
    computed:{
    admissionsessions() {
      return this.$store.state.admissionsessions.records;
    },
  }
  }
</script>