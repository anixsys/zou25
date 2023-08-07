<template>
    <div>
        <v-overlay :value="overlay">
        <v-progress-circular
          indeterminate
          size="64"
        ></v-progress-circular>
      </v-overlay>
    </div>
</template>
<script>
export default{
    data(){
        return{
            overlay:false
        }
    },
    async created(){
        this.overlay = true;
      this.uuid = this.$route.params.uuid
      await this.$store.dispatch("payment/CheckPayment",this.$route.params.uuid);
      this.overlay = false;
    }
}
</script>