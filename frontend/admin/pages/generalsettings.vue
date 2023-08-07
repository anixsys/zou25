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
      General Settings <v-spacer/>
      <GeneralsettingAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Description</th>
              <th>Year</th>
              <th>Decision Type</th>
              <th>Semesters per level</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <template v-if="generalsettings.length>0">
                <tr v-for="setting in generalsettings" :key="setting.Id">
                 <td>{{ setting.description }}</td>
                 <td>{{ setting.year }}</td>
                 <td>{{ setting.decisiontype }}</td>
                 <td>{{ setting.semesters }}</td>
                 <td class="d-flex justify-end pt-3">
                  <GeneralsettingEdit :setting="setting"/>
                     <GeneralsettingDelete :setting="setting"/>
                 </td>
                </tr>
            </template>
            <template v-else>
              <tr>
                <td colspan="6" class="text-center red--text"> No settings found</td>
              </tr>
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
    await this.$store.dispatch("generalsetting/getRecords");
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
          text: 'General Settings',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
      loading:false,
        }
    },
    computed:{
    generalsettings() {
      return this.$store.state.generalsetting.records;
    },
  }
  }
</script>