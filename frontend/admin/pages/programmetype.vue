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
      Programme Types <v-spacer/>
      <ProgrammetypeAdd/>
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
          <template v-if="programmetypes.length>0">
            <tr v-for="programmetype in programmetypes" :key="programmetype.id">
             <td>{{programmetype.name }}</td>
             <td class="d-flex justify-end">
              <ProgrammetypeEdit :programmetype="programmetype"/>
              <ProgrammetypeDelete :programmetype="programmetype"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="3" class="text-center text-danger">No records found</td></tr>
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
    await this.$store.dispatch("programmetype/getData");
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
          text: 'Programme Types',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
    programmetypes() {
      return this.$store.state.programmetype.records;
    },
  }
  }
</script>