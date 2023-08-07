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
      Programmes <v-spacer/>
      <ProgrammeAdd/>
      <ProgrammeImport/>
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
    :items="programmes"
    :items-per-page="20"
    :search="search"
    class="elevation-1 mt-2"
  >
  <template v-slot:item.specializations="{ item }">
    <div class="d-flex justify-center">
           <ProgrammeSpecialization :programme="item"/>
    </div>     
 </template>
 <template v-slot:item.history="{ item }">
    <div class="d-flex justify-center">
           <ProgrammeHistory :programme="item"/>
    </div>     
 </template>
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
          <ProgrammeEdit :programme="item"/>
         <ProgrammeDelete :programme="item"/>
         <v-btn icon  color="primary" rounded :to="`/programme/`+item.id"><v-icon>mdi mdi-check-decagram</v-icon></v-btn>
    
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
    await this.$store.dispatch("programmes/getData");
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
          text: 'Users',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
                   ],
      headers: [
         
          {
            text: 'Code',
            align: 'start',
            sortable: true,
            value: 'Code',
          },
          {
            text: 'Narration',
            align: 'start',
            sortable: true,
            value: 'narration',
          },
          {
            text: 'Programme type',
            align: 'start',
            sortable: true,
            value: 'programmetype',
          },
          {
            text: 'Department',
            align: 'start',
            sortable: true,
            value: 'department',
          },
          {
            text: 'Specializations',
            align: 'start',
            sortable: true,
            value: 'specializations',
          },
          {
            text: 'History',
            align: 'start',
            sortable: true,
            value: 'history',
          },
          {
            text: 'Status',
            align: 'start',
            sortable: true,
            value: 'status',
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
    programmes() {
      var data=  this.$store.state.programmes.records;
      var programmes = [];
      if(data.length>0){
              data.forEach(element => {
                  var el = {
                               id:element.id,
                               Code:element.code,
                               narration:element.description,
                               department:element.department.name,
                               programmetype:element.type.name,
                               programmeTypeId:element.programmeTypeId,
                               departmentId:element.departmentId,
                               history:element.history,
                               specializations:element.specializations,
                               status:element.status

                              }  
                   programmes.push(el)
                });
      }

      return programmes

    },
  }
  }
</script>