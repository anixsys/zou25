<template>
    <div>
      
      <v-btn fab color="accent" depressed @click="AddModel=true"><v-icon>mdi-upload-multiple</v-icon></v-btn>
      
         <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Upload Regulation Parameters
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <p><i>Csv file should have the following headings</i> </p>
           <ul>
            <li>level</li>
        <li>semester</li>
        <li>Code</li>
        <li>CourseType</li>
        <li>ExamContribution</li>
        <li>CourseworkContribution</li>
        <li>CourseWeight</li>
        <li>CourseTake</li>
        <li>prerequisitecourses</li>
        <li>alternativecourses</li>
           </ul>
            <v-file-input
            class="mt-2"
              label="Click here to attach .csv"
              v-model="file"
              :rules="fileRule"
            ></v-file-input>
          </v-card-text>
          <v-card-actions>
                <v-btn rounded depressed class="no-uppercase error"  @click="AddModel=false">Cancel</v-btn>
                <v-spacer />
                <v-btn rounded depressed class="no-uppercase success" @click="Submit" :loading="loading"
                  >Submit</v-btn
                >
              </v-card-actions>
        </v-card>
      </v-form>
      </v-dialog>

      <MultelineResponseDialog :openModel="openModel"  :responselist="responselist"/>
    </div>
  </template>
  <script>

import MultelineResponseDialog from '../MultelineResponseDialog.vue';
   export default{
    props:["regulation"],
    data() {
        return {
            AddModel: false,
            loading: false,
            file: null,
            openModel:false,
            responselist:[],
            fileRule: [(v) => !!v || "File is required"],
        };
    },
    methods: {
        async Submit() {
            if (this.$refs.form.validate()) {
                this.loading = true;
                const formdata = new FormData();
                formdata.append('academicregulationId',this.regulation.id)
                formdata.append("file", this.file);
                let config = { headers: { "content-type": "multipart/form-data" } };
                await this.$axios({
                    method: "POST",
                    url: "Academicregulationparameter/Import/"+this.regulation.id,
                    data: formdata,
                    config: config,
                })
                    .then(async (res) => {
                     this.openModel = true;
                     this.responselist = res.data;
                    this.loading = false;
                    await this.$store.dispatch('academicregulationparameters/getData',this.regulation.id)
                  
                })
                    .catch((err) => {
                    this.$swal("error", err.response.message, "error");
                    this.loading = false;
                });
            }
        }
    },
    components: { MultelineResponseDialog }
}
  </script>