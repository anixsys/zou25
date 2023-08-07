<template>
<v-row v-if="admissionsession && admissionsession.isPublished=='Y'">
      <v-col>
          <v-card flat outlined  color="primary">
                 <v-card-text dark class="d-flex justify-space-between">
                  <div class="white--text">
                    <div class="title">Applications for admission to our programmes is  currently OPEN closing on the {{ admissionsession.endDate }}</div>
                    <div class="subtitle-1">Please note you can apply and choose a period to start your studies </div>
                  </div>
                  <v-btn outlined x-large depressed  color="white" rounded to="/apply">Apply Now</v-btn>
                     </v-card-text>
          </v-card>
      </v-col>
     </v-row>
</template>
<script>
export default{
    props:["admissionsession"]
}
</script>