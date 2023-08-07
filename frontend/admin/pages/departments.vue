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
      Departments <v-spacer/>
       <DepartmentImport/>
      <DepartmentAdd/>
    </v-card-title>
    <v-card-text>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Name</th>
              <th>Faculty</th>
              <th class="text-right">
                Actions
              </th>
            </tr>
          </thead>
          <tbody>
          <template v-if="departments.length>0">
            <tr v-for="department in departments" :key="department.id">
             <td>{{department.name }}</td>
             <td>{{department.faculty.name }}</td>
             <td class="d-flex justify-end">
              <DepartmentEdit :department="department"/>
              <DepartmentDelete :department="department"/>
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
    await this.$store.dispatch("department/getData");
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
          text: 'Departments',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    },
    computed:{
    departments() {
      return this.$store.state.department.records;
    },
  }
  }
</script>