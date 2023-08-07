export const state =()=>({
    record:{}
})

export const mutations={
    setRecord(state,payload){
        state.record = payload
    },
}

export const actions={
    async getData({commit},payload){
        await this.$axios.get('Payment/'+payload).then((res)=>{
            commit('setRecord',res.data)
          
          })
    },
    async InitiatePayment({commit},payload){
        await this.$axios.post('Payment',payload).then((res)=>{
            if(res.data.status){
                this.$toaster.show(res.data.message,"success")
                window.location.href=res.data.url
            }else{
                this.$toaster.show(res.data.message,"error")
            }
          })
    },
    
    async CheckPayment({commit},payload){
        await this.$axios.get('Payment/payment/check/'+payload).then((res)=>{
            commit('setRecord',res.data)
            if(res.data.status){
                this.$toaster.show("Application Successfully Settled","success")
                this.$router.push("/selectprogrammes/"+payload);
               
            }else{
                this.$toaster.show("Application Fee unsettled","error")
                this.$router.push("/dashboard");
            }
          })
    }
}