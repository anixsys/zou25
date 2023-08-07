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
      General Regulations <v-spacer/>
      <GeneralregulationAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Name</th>
              <th>Year</th>
              <th>Programme type</th>
              <th>Status</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="regulations.length>0">
            <tr v-for="regulation in regulations" :key="regulation.id">
                        <td>{{regulation.name }}</td>
             <td>{{regulation.year }}</td>
             <td>{{regulation.programmeType.name }}</td>
             <td><v-chip x-small :class="regulation.status=='PENDING' ? `primary` : regulation.status=='APPROVED' ? `success` : `error`">
                {{ regulation.status }}
              </v-chip></td>
             <td class="d-flex justify-end pt-2 pb-2">
               <GeneralregulationDuplicate :regulation="regulation"/>
               <GeneralregulationChangestatus :regulation="regulation"/>
              <v-btn :to="`/generalregulation/`+regulation.id" color="primary" outlined rounded depressed small>View Details</v-btn>
     
              
            
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="6" class="text-center red--text pt-3 pb-3">No records found</td></tr>
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
    await this.$store.dispatch("generalregulations/getData");
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
          text: 'General regulations',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
    regulations() {
      return this.$store.state.generalregulations.records;
    },
  }
  }
</script>