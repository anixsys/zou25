<template>
  <div>
    <v-container fluid>
    <v-row>
        <v-col>
          <v-system-bar light>
            <v-breadcrumbs :items="items"></v-breadcrumbs>
          </v-system-bar>
          </v-col>
    </v-row>
    <v-row>
        <v-col md="12">
          <v-card>
                <v-card-title dark>
                    Available Programmes 
                </v-card-title>
              
                <v-card-text>
                  <v-text-field  label="Search for Programme" outlined v-model="filter"/>
                  <v-data-table
    :headers="headers"
    :items="programmes.programmes"
    :items-per-page="20"
    :search="filter"
    class="mt-2"
  >
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
      <v-btn  depressed color="primary" to="/Login">Apply</v-btn>
    </div>
     

    </template>
</v-data-table>
                </v-card-text>
            </v-card>          
        </v-col>
    </v-row>
    <v-overlay :value="overlay">
      <v-progress-circular
        indeterminate
        size="64"
      ></v-progress-circular>
    </v-overlay>
  </v-container>
  </div>
</template>
<script>
 export default{ 
   auth:false,
    async mounted() {
    this.overlay = true;
    this.id = this.$route.params.id ? this.$route.params.id :1
    await this.$store.dispatch("admisssiontemplates/getDataByType",this.id);
    await this.$store.dispatch("welcome/getData");
    this.overlay = false;
  },data(){
    return{
        overlay:false,
        filter:"",
        headers: [
          {
            text: 'Code',
            align: 'start',
            sortable: true,
            value: 'programme.code',
          },
          {
            text: 'Description',
            align: 'start',
            sortable: true,
            value: 'programme.description',
          },
          {
            text: 'Actions',
            align: 'end',
            value: 'actions',
          }
        ],
        items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/',
        },
        {
          text: 'Programmes',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ]
    }
  },
    computed:{
    programmes() {
      let data = [];
      data = this.$store.state.admisssiontemplates.records;
      return data
    },
    admissionsession() {
      return this.$store.state.welcome.record;
    }
  }
 }
</script>