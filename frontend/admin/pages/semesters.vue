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
     Semesters
      <v-spacer/>
      <SemesterAdd/>
    </v-card-title>
    <v-card-text>
        <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Search"
        single-line
        outlined 
        hide-details
      ></v-text-field>
           <v-simple-table>
            <template v-slot:default>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Name</th>
                        <th>Year</th>
                        <th>Status</th>
                        <th class="text--center">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <template v-if="semesters.length>0">
                        <tr v-for="semester in semesters" :key="semester.id">
                          <td>{{ semester.dateCreated | formatDate }}</td>
                          <td>{{ semester.name }}</td>
                          <td>{{ semester.year }}</td>
                          <td>{{ semester.status  }}</td>
                          <td class="d-flex justify-content-end">
                            <SemesterEdit :semester="semester"/>
                            <SemesterDelete :semester="semester"/>
                            <SemesterShow :semester="semester"/>
                          </td>
                        </tr>
                    </template>
                    <template v-else>
                       <tr><td colspan="5" class="text-center red--text">No records found</td></tr>
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
    await this.$store.dispatch("semesters/getData");
    this.overlay = false;
  },
    data(){
        return{
          overlay: false,
          search:"",
            items: [
                    {
                    text: 'Dashboard',
                    disabled: false,
                    href: '/dashboard',
                    },
                    {
                    text: 'Semesters',
                    disabled: true,
                    href: 'breadcrumbs_link_2',
                    },
                   ],

        }
    },
    computed:{
    semesters() {
      return this.$store.state.semesters.records;
    }
  }
  }
</script>