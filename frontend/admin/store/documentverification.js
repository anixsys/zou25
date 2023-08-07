export const state =()=>({
    record:{}
})

export const mutations={
    setRecord(state,payload){
        state.record = payload
    }
}

export const actions={
    async getData({commit}){
        await this.$axios.get('DocumentVerification').then((res)=>{
            commit('setRecords',res.data)
          })
    },  
    async Search({commit},payload){
        await this.$axios.post('DocumentVerification',payload).then(async (res)=>{
            commit('setRecord',res.data)
        }).catch(error=>{
              console.log(error.response)
            this.$toaster.show("An Error has occurred trying to save record")
        })
    },
    async Verify({commit},payload){
        await this.$axios.get('DocumentVerification/verify/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
        }).catch(error=>{
            console.log(error)
        })
    }
}