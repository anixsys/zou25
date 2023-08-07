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
      Courses 
      <v-spacer/>
      <CourseImport/>
      <CourseAdd/>
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
        <v-data-table
    :headers="headers"
    :items="courses"
    :items-per-page="20"
    :search="search"
    class="mt-2"
  >
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
        <CourseEdit :course="item"/>
         <CourseDelete :course="item"/>
    </div>
     

    </template>
</v-data-table>
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
    await this.$store.dispatch("course/getData");
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
          text: 'Courses',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
                   ],
      headers: [
          {
            text: 'Department',
            align: 'start',
            sortable: true,
            value: 'department',
          },
          {
            text: 'Code',
            align: 'start',
            sortable: true,
            value: 'Code',
          },
          {
            text: 'Name',
            align: 'start',
            sortable: true,
            value: 'name',
          },
          {
            text: 'Actions',
            align: 'end',
            value: 'actions',
          }
        ]
        }
    },
    computed:{
    courses() {
      var data=  this.$store.state.course.records;
      var courses = [];
      if(data.length>0){
              data.forEach(element => {
                  var el = {
                               id:element.id,
                               Code:element.code,
                               name:element.name,
                               department:element.department.name,
                               departmentId:element.departmentId
                              }  
                   courses.push(el)
                });
      }

      return courses

    },
  }
  }
</script>