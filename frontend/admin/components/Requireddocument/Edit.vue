<template>
    <div>
      <v-btn icon outlined depressed color="primary" @click="getData"><v-icon>mdi-pencil</v-icon></v-btn>
      <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Update Required Document
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
              <v-select
                label="Select Programme Type"
                :items="programmetypes"
                item-value="id"
                item-text="name"
                v-model="form.programmetypeId"
                outlined
                :rules="[rules.required]"
              ></v-select>
              <v-select
                label="Select Applicant Type"
                :items="applicanttypes"
                item-value="id"
                item-text="name"
                v-model="form.ApplicanttypeId"
                outlined
                :rules="[rules.required]"
              ></v-select>
              <v-select
                label="Select Required Documet"
                :items="documents"
                item-value="id"
                item-text="name"
                v-model="form.documentId"
                outlined
                :rules="[rules.required]"
              ></v-select>
              <v-select
                label="Select Requirement Status"
                :items="['MANDETORY','OPTIONAL']"
                v-model="form.status"
                outlined
                :rules="[rules.required]"
              ></v-select>
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error" max-width="80" @click="AddModel=false">Cancel</v-btn>
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
    props:['document'],
      data(){
          return{
              AddModel:false,
              loading:false,
          form:{
            Id:this.document.id,
            programmetypeId:this.document.programmeTypeId,
            ApplicanttypeId:this.document.applicanttypeId,
            documentId:this.document.documentId,
            status:this.document.status
          },
          rules: {
              required: value => !!value || 'Required.'
            },
        }
          
      },methods:{
    async getData(){
      await this.$store.dispatch("admissiondocuments/getData");
      await this.$store.dispatch("programmetype/getData");
      await this.$store.dispatch("applicanttypes/getData");
            this.form.Id=this.document.id,
            this.form.programmetypeId=this.document.programmeType.id,
            this.form.ApplicanttypeId=this.document.applicanttype.id,
            this.form.documentId=this.document.document.id,
            this.form.status=this.document.status
      this.AddModel =true
    },
    async Submit(){
      if(this.$refs.form.validate()){
          this.loading = true
          await this.$store.dispatch("requireddocuments/updateItem",this.form); 
          
          this.loading = false
      }
    }
      },
      computed:{
      documents() {
        return this.$store.state.admissiondocuments.records;
      },
      programmetypes() {
        return this.$store.state.programmetype.records;
      },
      applicanttypes() {
        return this.$store.state.applicanttypes.records;
      }
    }
   }
  </script>