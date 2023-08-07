<template>
  <div>
    <v-btn icon depressed color="primary" @click="getData"><v-icon>mdi-currency-usd</v-icon></v-btn>
    <v-dialog v-model="AddModel" width="1000px">
        <v-form ref="form" lazy-validation>
      <v-card>
        <v-card-title>
            Ordinance Fee Structure
            <v-spacer/>
            <OrdinanceFeeAdd v-if="record.status=='PENDING'" :record="record"/>
            <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
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
    :items="regfees"
    :items-per-page="20"
    :search="search"
    class="mt-2"
  >
  
  <template v-slot:item.cost="{ item }">
      {{ item.currency.name }} {{ item.cost }}
  </template>
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">
        <OrdinanceFeeEdit v-if="record.status=='PENDING'" :record="item"/>
         <OrdinanceFeeDelete v-if="record.status=='PENDING'" :record="item"/>
    </div>    
</template>
</v-data-table>
        </v-card-text>
      </v-card>
    </v-form>
    </v-dialog>
  </div>
</template>
<script>
   export default{
    props:['record'],
    data(){
        return{
          AddModel:false,
          loading:false,
          search:"",
          headers: [
          {
            text: 'Faculty',
            align: 'start',
            sortable: true,
            value: 'faculty.name',
          },
          {
            text: 'Student Type',
            align: 'start',
            sortable: true,
            value: 'applicanttype.name',
          },
          {
            text: 'Programme Type',
            align: 'start',
            sortable: true,
            value: 'programmetype.name',
          },
          {
            text: 'Cost',
            align: 'start',
            sortable: true,
            value: 'cost',
          },
          {
            text: 'Actions',
            align: 'end',
            value: 'actions',
          }
        ]
        }
    },
    methods:{
        async getData(){
            await this.$store.dispatch("registrationfee/getData",this.record.id);
            await this.$store.dispatch("currency/getData");
        await this.$store.dispatch("applicanttypes/getData");
        await this.$store.dispatch("programmetype/getData");
        await this.$store.dispatch("faculties/getData");
            this.AddModel = true
        }
    },
    computed:{
      regfees(){
        return this.$store.state.registrationfee.records;
      }  
    }
   }
</script>