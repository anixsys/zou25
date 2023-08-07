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
      System modules <v-spacer/>
      <SystemmoduleAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Icon</th>
              <th>Name</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="systemmodules.length>0">
            <tr v-for="systemmodule in systemmodules" :key="systemmodule.id">
             <td><v-icon>{{systemmodule.icon }}</v-icon></td>
             <td>{{systemmodule.name }}</td>
             <td class="d-flex justify-end pt-2">
              <SystemmoduleEdit :systemmodule="systemmodule"/>
              <SystemmoduleDelete :systemmodule="systemmodule"/>
              <Submodules :systemmodule="systemmodule"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="4" class="text-center red--text">No records found</td></tr>
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
    await this.$store.dispatch("systemmodules/getData");
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
          text: 'systemmodules',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
    systemmodules() {
      return this.$store.state.systemmodules.records;
    },
  }
  }
</script>