<template>
    <div>
        <v-breadcrumbs :items="items">
      <template v-slot:divider>
        <v-icon>mdi-chevron-right</v-icon>
      </template>
    </v-breadcrumbs>
<v-container fluid>
    <v-row justify="center" class="mt-5">
        <v-col md="4" sm="12" xs="12" offset-md4>
            <v-card>
            <v-card-text class="text-center">
                <div class="display-1 mt-5 mb-5">Access Denied</div>
                <v-alert type="error">
                    You do not have permissions to access resource
                  </v-alert>
                  <v-btn rounded class="primary">Go Back</v-btn>
            </v-card-text>
        </v-card>
        </v-col>
    </v-row>

</v-container>

  
    </div>
</template>
<script>
  export default{
    layout:"mainlayout",
    data(){
        return{
          overlay: false,
            items: [
        {
          text: 'Dashboard',
          disabled: false,
          href: '/dashboard',
        },
        {
          text: '403',
          disabled: true,
          href: 'breadcrumbs_link_2',
        },
      ],
        }
    }
  }
</script>