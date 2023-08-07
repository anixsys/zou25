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
      Bulk Imports
    </v-card-title>
    <v-card-text>
        <v-row>
            <v-col>
            <FacultyImport/>
            </v-col>
            <v-col>
            <DepartmentImport/>
            </v-col>
            <v-col><ProgrammeImport/></v-col>
            <v-col><CourseImport/></v-col>
            
        </v-row>
  </v-card-text>
  </v-card>
</v-container>

  
    </div>
</template>
<script>
  export default{
    layout:"mainlayout",
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
          text: 'Bulk Imports',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    }
  }
</script>