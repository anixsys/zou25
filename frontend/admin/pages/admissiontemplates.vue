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
      Admission Templates <v-spacer/>
      <AdmissiontemplateAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Name</th>
              <th>Programme Type</th>
              <th>Status</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="admissiontemplates.length>0">
            <tr v-for="admission in admissiontemplates" :key="admission.id">
             <td>{{admission.name }}</td>
             <td>{{ admission.programmeType.name }}</td>
             <td>{{ admission.status }}</td>
             <td class="d-flex justify-end pt-2">
              <AdmissiontemplateEdit :admission="admission"/>
              <AdmissiontemplateDelete :admission="admission"/>
              <AdmissionprogrammesShow :admission="admission"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="4" class="text-center text-danger">No records found</td></tr>
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
    await this.$store.dispatch("admissiontemplates/getData");
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
          text: 'Admission Templates',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
    admissiontemplates() {
      return this.$store.state.admissiontemplates.records;
    },
  }
  }
</script>