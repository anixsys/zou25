export const state =()=>({
    records:[]
})

export const mutations={
    setRecords(state,payload){
        state.records = payload
    }
}

export const actions={
    async getData({commit},payload){
        await this.$axios.get('ApplicationDocument/'+payload).then((res)=>{
            commit('setRecords',res.data)
          }) 
    },
    async addRecord({commit},payload){
        await this.$axios.post('ApplicationDocument',payload).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicationdocuments/getData',payload.applicationId)
          })
    },
    async deleteRecord({commit},payload){
        await this.$axios.delete('ApplicationDocument/'+payload.id).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicationdocuments/getData',payload.applicationId)
          })
    }
}