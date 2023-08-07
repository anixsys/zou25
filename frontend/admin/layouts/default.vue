<template>
  <v-app dark>
      
    <v-main class="#fafbfd">
     
      <v-container>
        <Nuxt />
      </v-container>
      
   
    </v-main>
 
    <v-footer
      app
      dark
      color="primary"
    >
      <span>&copy; Anxsys Pvt Ltd {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: 'DefaultLayout',
  data () {
    return {
     
      title: 'Vuetify.js'
    }
  }
}
</script>
