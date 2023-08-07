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
    Campus Types <v-spacer/>
      <CampustypeAdd/>
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
          <template v-if="campustypes.length>0">
            <tr v-for="ctype in campustypes" :key="ctype.id">
             <td>{{ctype.name }}</td>
             <td class="d-flex justify-end">
              <CampustypeEdit :campustype="ctype"/>
              <CampustypeDelete :campustype="ctype"/>
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
    await this.$store.dispatch("campustypes/getData");
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
          text: 'Campus Types',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
  campustypes() {
      return this.$store.state.campustypes.records;
    },
  }
  }
</script>