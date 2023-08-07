<template>
    <div>
      <v-btn fab color="success" depressed @click="AddModel=true"><v-icon>mdi-upload-multiple</v-icon></v-btn>
    
      
         <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Upload Courses
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <p><v-icon>mdi-upload-multiple</v-icon></p> 
           <b>Upload Courses</b>
           <p><i>Csv file should have the following headings[Code,Name,DepartmentName]</i>
         </p>
            <v-file-input
              label="Click here to attach .csv"
              outlined
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
                formdata.append("file", this.file);
                let config = { headers: { "content-type": "multipart/form-data" } };
                await this.$axios({
                    method: "POST",
                    url: "Course/Import",
                    data: formdata,
                    config: config,
                })
                    .then(async (res) => {
                      this.loading = false;
                      var status = "success"
                      if(!res.data.status){
                          status ="error"
                      }
            this.$toaster.show(res.data.message,status)
                    await this.$store.dispatch("course/getData");
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