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
      Campus Management<v-spacer/>
      <CampusAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Name</th>
              <th>Address</th>
              <th>Type</th>
              <th>District</th>
              <th>Status</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="campuses.length>0">
            <tr v-for="campus in campuses" :key="campus.id">
             <td>{{campus.name }}</td>
             <td>{{campus.address }}</td>
             <td>{{campus.campusType.name }}</td>
             <td>{{ campus.district.name }}</td>
             <td>
              <v-chip
                class="ma-2"
                small
                text-color="white"
                :color="campus.status=='ACTIVE' ? `green` :`red`"
              >
              {{ campus.status }}
             </v-chip>
            </td>
             <td class="d-flex justify-end">
              <CampusEdit :campus="campus"/>
              <CampusDelete :campus="campus"/>
             </td>
            </tr>
           </template>
           <template v-else>
                <tr><td colspan="6" class="text-center red--text">No records found</td></tr>
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
    await this.$store.dispatch("campus/getData");
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
          text: 'Campuses',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
   campuses() {
      return this.$store.state.campus.records;
    },
  }
  }
</script>