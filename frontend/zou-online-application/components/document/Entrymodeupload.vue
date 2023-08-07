<template>
    <div>
        <v-btn color="primary" large  @click="dailog=true"><v-icon>mdi-upload</v-icon> Upload</v-btn>
        <v-dialog width="400px" v-model="dailog">
            <v-form ref="form" lazy-validation>
         <v-card>
            <v-card-title>
                {{ doc.name }}
                <v-spacer/>
                <v-btn small outlined fab @click="dailog=false"><v-icon>mdi-close</v-icon></v-btn>
            </v-card-title>
            <v-card-text>
                <v-file-input
                  label="Click here to attach Document"
                  outlined
                  v-model="file"
                  :rules="fileRule"
                ></v-file-input>
            </v-card-text>
            <v-card-actions>
                <v-btn color="error" small @click="dailog=false">Cancel</v-btn>
                <v-spacer/>
                <v-btn color="primary" small @click="Submit" :loading="loading">Upload</v-btn>
            </v-card-actions>
         </v-card>
        </v-form>
        </v-dialog>
    </div>
    </template>
    <script>
      export default{
        props:['doc','uuid'],
        data(){
            return{
                dailog:false,
                loading:false,
                fileRule: [(v) => !!v || "File is required"],
                file:null
            }
        },
        methods:{
            async Submit() {
                if (this.$refs.form.validate()) {
                    this.loading = true;
                    const formdata = new FormData();
                    formdata.append("file", this.file);
                    formdata.append("uuid",this.uuid)
                    formdata.append("DocumentId",this.doc.id)
                    let config = { headers: { "content-type": "multipart/form-data" } };
                    await this.$axios({
                        method: "POST",
                        url: "EntryMode",
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
                        await this.$store.dispatch("applicationdocuments/getData",this.uuid);
                        await this.$store.dispatch("entrymoderequirements/getData",this.uuid);
                    })
                        .catch((err) => {
                        this.$swal("error", err.response.message, "error");
                        this.loading = false;
                    });
                }
            }
        }
      }
    </script>