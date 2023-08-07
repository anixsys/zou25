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
      Districts<v-spacer/>
      <DistrictAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Province</th>
              <th>Name</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="districts.length>0">
            <tr v-for="district in districts" :key="district.id">
             <td>{{district.province.name }}</td>
             <td>{{ district.name }}</td>
             <td class="d-flex justify-end">
              <DistrictEdit :district="district"/>
              <DistrictDelete :district="district"/>
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
    await this.$store.dispatch("districts/getData");
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
          text: 'Districts',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
    districts() {
      return this.$store.state.districts.records;
    },
  }
  }
</script>