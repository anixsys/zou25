<template>
  <div>

    <v-btn color="success" @click="downloadletter">Download Letter</v-btn>  
      <div id="printletter">
        <v-container>
            <div class="text-center">ACCEPTANCE LETTER</div>
            <hr  style="border: 2px solid black;"/>
            <hr  style="border: 1px solid black;"/>
            <div class="d-flex justify-space-between">
                <div><img src="~/assets/images/logo2.png" width="200px"/></div>
                 <div class="text-center">
                    <div class="title"> ZIMBABWE OPEN UNIVERISTY</div>
                    <div class="content">Telephone : +263 242 793 002/7/8</div>
                    <div class="content">Email : admissions@zou.ac.zw</div>
                 </div>
                 <div class="text-center">
                    2nd Floor Corner House
Cnr. Samora Machel Avenue/Leopold Takawira Street
Harare
                 </div>
            </div>
            <hr  style="border: 2px solid black;"/>
            <hr  style="border: 1px solid black;"/>
        </v-container>
        
    </div>
    
</div>
</template>
<script>
import html2pdf from "html2pdf.js";
 export default{
    layout:"blank",
    async fetch() {
    this.overlay = true;
    this.uuid = this.$route.params.uuid
    await this.$store.dispatch("applications/getRecord",this.uuid);
    this.overlay = false;
  },
  methods:{
    downloadletter(){
        html2pdf(document.getElementById("printletter"), {
				margin: 1,
  			filename: "i-was-html.pdf",
			});
    }
  },
  computed:{
    application(){
        return this.$store.state.applications.record;
    }
  }
 }
</script>