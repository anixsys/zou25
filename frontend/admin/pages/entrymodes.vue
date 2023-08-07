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
   Entry Modes <v-spacer/>
      <ModeAdd/>
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
          <template v-if="entrymodes.length>0">
            <tr v-for="mode in entrymodes" :key="mode.id">
             <td>{{mode.name }}</td>
             <td class="d-flex justify-end">
              <ModeEdit :mode="mode"/>
              <ModeDelete :mode="mode"/>
              <Moderequirement :mode="mode"/>
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
    await this.$store.dispatch("entrymodes/getData");
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
          text: 'Entry Modes',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
  entrymodes() {
      return this.$store.state.entrymodes.records;
    },
  }
  }
</script>