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
      Programmes 
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
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
      <AcademicregulationShow :programme="item"/>
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
          text: 'Programmes',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
                   ],
                   headers: [
         
          {
            text: 'Code',
            align: 'start',
            sortable: true,
            value: 'code',
          },
          {
            text: 'Narration',
            align: 'start',
            sortable: true,
            value: 'description',
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
      var data  =  this.$store.state.programmes.records;
      var programmes = [];

      if(data.length>0){
          data.forEach(element => {
             programmes.push({id:element.id,code:element.code,description:element.description,department:element.department.name,programmeTypeId:element.programmeTypeId})
          });
      }

      return programmes;


    },
  }
  }
</script>