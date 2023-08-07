<template>
    <div>
     <v-btn rounded outlined depressed color="warning" class="mr-1" @click="getData"><v-icon>mdi-import</v-icon> Import Batch</v-btn>
      
        <v-dialog v-model="AddModel" width="500px">
          <v-form ref="form" lazy-validation>
        <v-card>
          <v-card-title>
              Import Applicants
              <v-spacer/>
              <v-btn icon @click="AddModel=false"><v-icon>mdi-close</v-icon></v-btn>
          </v-card-title>
          <v-card-text>
            <v-file-input
              label="Click here to attach .csv"
              outlined
              v-model="file"
              :rules="fileRule"
            ></v-file-input>
            <v-select
              label="Intake"
              placeholder="Intake"
              v-model="AdmissionSessionId"
              :items="admissionsessions"
              item-text="name"
              item-value="id"
              outlined
              :rules="[rules.required]"
            ></v-select>
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
    </div>
  </template>
  <script>


   export default{
    data() {
        return {
            AddModel: false,
            loading: false,
            file: null,
            AdmissionSessionId:null,
            openModel:false,
            responselist:[],
            fileRule: [(v) => !!v || "File is required"],
            rules: {
            required: value => !!value || 'Required.'
          },
        };
    },
    methods: {
        async getData(){
            await this.$store.dispatch("admissionsessions/getData");
            this.AddModel = true;
        },
        async Submit() {
            if (this.$refs.form.validate()) {
                this.loading = true;
                const formdata = new FormData();
                formdata.append("file", this.file);
                formdata.append("AdmissionSessionId",this.AdmissionSessionId)
                let config = { headers: { "content-type": "multipart/form-data" } };
                await this.$axios({
                    method: "POST",
                    url: "Applicant/Import",
                    data: formdata,
                    config: config,
                })
                    .then(async (res) => {
                      var status = "success"
            if(!res.data.status){
                status ="error"
            }
                      this.$toaster.show(res.data.message,status)
                    this.loading = false;
                    this.loading = false;
                    await this.$store.dispatch("Applicant/getData");
                })
                    .catch((err) => {
                    this.$swal("error", err.response.message, "error");
                    this.loading = false;
                });
            }
        }
    },
    computed:{
    admissionsessions() {
      return this.$store.state.admissionsessions.records;
    },
}
}
  </script>