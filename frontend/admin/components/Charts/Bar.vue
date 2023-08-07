<template>
    <client-only>
       <VueApexCharts width="450" type="bar" :options="options" :series="series"></VueApexCharts>
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
      var categories =[];
      if(this.summary && this.summary.length>0){
        this.summary.forEach(element => {
               categories.push(element.name) 
        });
      }
      var options = {
        chart: {
          id: 'vuechart-example'
        },
        xaxis: {
          categories: categories
        }
      }
      return options;
    },
    series(){
      var series= []
    if(this.summary && this.summary.length>0){
        this.summary.forEach(element => {
               series.push({name:element.name,data:[element.total]}) 
        });
      }

    return series
    }
   }
}
</script>