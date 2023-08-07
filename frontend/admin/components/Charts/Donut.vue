<template>
     <client-only>
        <VueApexCharts
                                type="donut"
                                width="440"
                                :options="options"
                                 :series="series"
                              ></VueApexCharts>
     </client-only>
</template>
<script>
 export default{
    props:['summary'],
    components:{
        VueApexCharts: () => import('vue-apexcharts')
    },
    data(){
        return{
        }
    },
   computed:{
    options(){
      var labels =[];
      if(this.summary && this.summary.length>0){
        this.summary.forEach(element => {
               labels.push(element.name) 
        });
      }
      var options = {
        labels: labels
      }
      return options;
    },
    series(){
      var series= []
    if(this.summary && this.summary.length>0){
        this.summary.forEach(element => {
               series.push(element.total) 
        });
      }

    return series
    }
   }
 }
</script>