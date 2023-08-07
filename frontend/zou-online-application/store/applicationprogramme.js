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
        await this.$axios.get('ApplicationProgramme/'+payload).then((res)=>{
            commit('setRecords',res.data)
          })
    },
    async addRecord({commit},payload){
        await this.$axios.post('ApplicationProgramme',payload).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicationprogramme/getData',payload.uuid)
          })
    },
    async deleteRecord({commit},payload){
        await this.$axios.delete('ApplicationProgramme/'+payload.uuid+"/"+payload.id).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicationprogramme/getData',payload.uuid)
          })
    }
}