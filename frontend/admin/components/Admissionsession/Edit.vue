<template>
    <div>
      <v-btn depressed text color="primary" @click="getData"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="800px">
        <v-form ref="form" lazy-validation>
      <v-card>
        <v-card-title>
           Update Admission Session
            <v-spacer/>
            <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
        </v-card-title>
        <v-card-text>
          <v-row>
            <v-col>
              <v-text-field
              label="Name"
              v-model="form.name"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
            </v-col>
            <v-col>
              <v-text-field
              label="Year"
              v-model="form.year"
              outlined
              :rules="[rules.required]"
            ></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col>
              <v-menu
        v-model="menu1"
        :close-on-content-click="false"
        :nudge-right="40"
        transition="scale-transition"
        offset-y
        min-width="auto"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-text-field
            v-model="date1"
            label="Start Date"
            prepend-icon="mdi-calendar"
            readonly
            v-bind="attrs"
            v-on="on"
            :rules="[rules.required]"
          ></v-text-field>
        </template>
        <v-date-picker
          v-model="date1"
          @input="menu1 = false"
        ></v-date-picker>
      </v-menu>
            </v-col>
            <v-col>
              <v-menu
        v-model="menu2"
        :close-on-content-click="false"
        :nudge-right="40"
        transition="scale-transition"
        offset-y
        min-width="auto"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-text-field
            v-model="date2"
            label="End Date"
            prepend-icon="mdi-calendar"
            readonly
            v-bind="attrs"
            v-on="on"
            :rules="[rules.required]"
          ></v-text-field>
        </template>
        <v-date-picker
          v-model="date2"
          @input="menu2 = false"
        ></v-date-picker>
      </v-menu>
            </v-col>
          </v-row>
          <v-row>
            <v-col md="6">
              <v-select
              label="Publish"
              :items="['Y','N']"
              v-model="form.isPublished"
              outlined
              :rules="[rules.required]"
            ></v-select>
            </v-col>
            </v-row>
          <v-row>
            <v-col>
              <div class="title">Select Admission Programme Templates</div>
              <v-simple-table>
                <template v-slot:default>
                   <tbody>
                    <tr v-for=" admissiontemplate in admissiontemplates">
                      <td>
                        <v-checkbox
                    v-model="selected"
                    :value="admissiontemplate.id"
                  ></v-checkbox>
                      </td>
                      <td>
                        {{ admissiontemplate.name }}
                      </td>
                    </tr>
                   </tbody>
                </template>
              </v-simple-table>
            </v-col>
          </v-row>
        </v-card-text>
        <v-card-actions>
              <v-btn rounded depressed class="no-uppercase error" max-width="80" @click="AddModel=true">Cancel</v-btn>
              <v-spacer />
              <v-btn rounded depressed class="no-uppercase success" max-width="80" @click="Submit" :loading="loading"
                >Submit</v-btn
              >
            </v-card-actions>
      </v-card>
    </v-form>
    </v-dialog>
  </div>
</template>
<script>
 export default{
  props:['admissionsession'],
    data(){
        return{
            AddModel:false,
            loading:false,
            date1: null,
            menu1: false,
            date2: null,
            menu2: false,
            selected:[],
        form:{
          id:"",
          name:"",
           StartDate:"",
           EndDate:"",
          year:"",
          templates:"",
          isPublished:""
        },
        rules: {
            required: value => !!value || 'Required.'
          },
      }
        
    },methods:{
  async getData(){
    await this.$store.dispatch("admissiontemplates/getData");
    this.form.name = this.admissionsession.name
    this.form.id = this.admissionsession.id
    this.date1 = this.admissionsession.startDate
    this.date2 = this.admissionsession.endDate
    this.form.year = this.admissionsession.year
    this.form.isPublished = this.admissionsession.isPublished ? "Y" :"N"

    this.admissionsession.admissionsessiontemplate.forEach(element => {
       this.selected.push(element.admissionTemplateId)
    });

    this.AddModel = true
  },
  async Submit(){
    if(this.$refs.form.validate()){
      if(this.selected.length==0){
        this.$swal("error","Please select Admission programme templates","error");
        return
      }
      this.form.templates = JSON.stringify(this.selected)
      this.form.StartDate = this.date1
      this.form.EndDate = this.date2
      this.form.isPublished = this.form.isPublished=="Y" ? true : false;
        this.loading = true
        await this.$store.dispatch("admissionsessions/updateItem",this.form); 
        //this.$refs.form.reset()
        this.loading = false
    }
  }
    },
    computed:{
    admissiontemplates() {
      return this.$store.state.admissiontemplates.records;
    },
  }
 }
</script>