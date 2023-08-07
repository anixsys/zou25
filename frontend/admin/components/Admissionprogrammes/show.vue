<template>
    <div>
      <v-btn icon outlined   @click="getData"><v-icon small>mdi-card-search-outline</v-icon></v-btn>
      
         <v-dialog v-model="AddModel" fullscreen>
        <v-card>
          <v-toolbar
      color="success"
      dark
      flat
     
    >
    <span> {{ admission.name }} </span>
    <v-spacer></v-spacer>
    
    <v-btn fab depressed color="error" @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>

    </v-toolbar>
  <v-card-title>
      
  </v-card-title>
  <v-card-text>
    
      <v-row class="mt-2">
        <v-col>
          <v-card outlined>
            <v-card-title>Available Programmes</v-card-title>
            <v-card-text>
              <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Search"
        single-line
        outlined
        dense
        hide-details
      ></v-text-field>
              <v-data-table
    :headers="headers"
    :items="programmes"
    :items-per-page="50"
    :search="search"
    class="mt-2"
  >
  <template v-slot:item.actions="{ item }">
    <div class="d-flex justify-end">   
    <v-btn fab small color="primary" @click="chooseType(item)"><v-icon>mdi-plus</v-icon></v-btn>
  </div>
    </template>
</v-data-table>
            </v-card-text>
          </v-card>
        
        </v-col>
        <v-col>
          <AdmissionprogrammesSelected :selected="selectedprogrammes" :admission="admission"/>
        
        </v-col>
      </v-row>
     
    
  </v-card-text>
</v-card>
      </v-dialog>

      <v-dialog v-model="choosedialog" width="400px">
        <v-card>
          <v-card-title>
            Select Attendence Type 
            <v-spacer/>
            <v-btn small icon @click="choosedialog=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-simple-table>
              <template v-slot:default>
                <thead>
                  <tr>
                    <th>Name</th>
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="att in attendencetypes">
                    <td>{{ att.name }}</td>
                    <td class="d-flex justify-end px-2"><v-btn small fab depressed @click="addSelection(att)"><v-icon>mdi-plus</v-icon></v-btn></td>
                  </tr>
                </tbody>
              </template>
            </v-simple-table>
          </v-card-text>
        </v-card>
      </v-dialog>
    </div>
  </template>
  <script>
   export default{
    props:["admission"],
      data(){
          return{
              AddModel:false,
              loading:false,
              selectedprogrammes:[],
              choosedialog:false,
              search:"",
              item:"",
              headers: [
          {
            text: 'Code',
            align: 'start',
            sortable: true,
            value: 'code',
          },
          {
            text: 'Description',
            align: 'start',
            sortable: true,
            value: 'description',
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
      methods:{
    async getData(){
        await this.$store.dispatch("admissionprogrammes/getData",this.admission.programmetypeId);
        await this.$store.dispatch("admissionprogrammes/getSelected",this.admission.id);
        await this.$store.dispatch("attendencetype/getData");
        this.updateselectedprogrammes()
        this.AddModel=true
    },
    chooseType(item){
     this.choosedialog = true
     this.item = item
     this.selectedprogrammes.push({id:item.id,code:item.code,description:item.description,attendencetypes:[]})
    },
    updateselectedprogrammes(){
      if(this.savedselection.length>0){
           this.savedselection.forEach(dt=>{
            var attendencetypes=[]
              dt.attendencetypes.forEach(att=>{
                attendencetypes.push(att.attendencetype)
              })
              this.selectedprogrammes.push({id:dt.programme.id,code:dt.programme.code,description:dt.programme.description,attendencetypes:attendencetypes})
 
           }) 
      }
    },
    addSelection(att){

     this.selectedprogrammes.forEach(selected=>{
      if(selected.id == this.item.id){
        selected.attendencetypes.push(att)
      }
     })
    }

      }, computed:{
  programmes() {
    var data =  this.$store.state.admissionprogrammes.records;
    var programmes = []
    if(data.length>0){
      data.forEach(edt => {
          programmes.push({id:edt.id,code:edt.code,description:edt.description,status:edt.status})
      });
    }
    
    return programmes;
  },
  savedselection(){
    return this.$store.state.admissionprogrammes.selected;
  },
  attendencetypes() {
      return this.$store.state.attendencetype.records;
    }
}
   }
  </script>