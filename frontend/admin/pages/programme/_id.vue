<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
     <v-container fluid>
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th>Programme code</th>
              <th>Programme description</th>
              <th>Programe Type</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>{{ programme.code }}</td>
              <td>{{ programme.description }}</td>
              <td>{{ programme.type ? programme.type.name :"" }}</td>
            </tr>
          </tbody>
        </template>
      </v-simple-table>

      <v-card class="mt-5">
    <v-card-title>
      Academic Regulations
      <v-spacer/>
       <AcademicregulationAdd :programme="programme"/>
    </v-card-title>
    <v-card-text>
      <v-simple-table class="mt-2 mb-3">
    <template v-slot:default>
      <thead dark>
        <tr>
          <th>Intake</th>
          <th>Programme type</th>
          <th>Attendence Type</th>
          <th>Year</th>
          <th>Approved</th>
          <th>Default</th>
          <th class="text-right">Action</th>
        </tr>
      </thead>
      <tbody>
        
            <template v-if="programme.academicregulations && programme.academicregulations.length>0">
               <tr v-for="academic in programme.academicregulations">
                <td>{{ academic.name }}</td>
                <td>{{ programme.type.name }}</td>
                <td>{{ academic.attendencetype.name }}</td>
                <td>{{ academic.year }}</td>
                <td>{{ academic.isApproved }}</td>
                <td>{{ academic.isActive }}</td>
                <td class="d-flex justify-end pt-2">
                  <v-menu>
                <template v-slot:activator="{ on, attrs }">
                  <v-btn
                    color="primary"
                    dark
                    v-bind="attrs"
                    v-on="on"
                    small
                    rounded 
                    outlined
                  >
                  <v-icon>mdi-cogs</v-icon> Settings
                  </v-btn>
                </template>
                  <v-list>
                    <v-list-item link v-if="!academic.isApproved" @click="changeStatus(academic.id,true)">
                      <v-list-item-title><v-icon small color="success" class="mr-2">mdi-thumb-up</v-icon>Approve</v-list-item-title>
                    </v-list-item>
                    <v-list-item link v-else @click="changeStatus(academic.id,false)">
                      <v-list-item-title><v-icon small color="error" class="mr-2">mdi-thumb-down</v-icon>Revoke</v-list-item-title>
                    </v-list-item>
                    <v-list-item link @click="SetDefault(academic.id)">
                      <v-list-item-title><v-icon small class="mr-2">mdi-close-circle-multiple-outline</v-icon>Set As Default</v-list-item-title>
                    </v-list-item>
                    <AcademicregulationparameterShow :regulation="academic" :programme="programme"/>
                    
                  </v-list>
                </v-menu>
                </td>
                  </tr>
                  </template>
                  <template v-else>
                    <tr>
                      <td colspan="7" class="text-center red--text">No records found</td>
                    </tr>
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
      async mounted() {
      this.overlay = true;
      this.id = this.$route.params.id
      await this.$store.dispatch("programmes/getProgramme",this.$route.params.id);
      this.overlay = false;
    },
      data(){
          return{
            overlay: false,
            id:"",
              items: [
          {
            text: 'Dashboard',
            disabled: false,
            href: '/dashboard',
          },
          {
            text: 'Programme List',
            disabled: false,
            href: '/academicregulations',
          },
          {
            text: "Acadmic Regulation",
            disabled: true,
            href: 'breadcrumbs_link_2',
          },
        ],
          }
      },methods:{
        async changeStatus(id,status){
          var payload = {id:id,status:status,programmeId:this.id}
          await this.$store.dispatch("academicregulations/Changestatus",payload);
        },
        async SetDefault(id){
          var payload = {id:id,programmeId:this.id}
          await this.$store.dispatch("academicregulations/SetAsDefault",payload);
        }
      }, 
      computed:{
    programme() {
      return this.$store.state.programmes.record;
    }
  }
    }

</script>