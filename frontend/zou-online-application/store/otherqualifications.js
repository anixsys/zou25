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
        await this.$axios.get('Otherqualification').then((res)=>{
            commit('setRecords',res.data)
          })
    },
    async addRecord({commit},payload){
        await this.$axios.post('Otherqualification',payload).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('otherqualifications/getData')
          })
    },
    async deleteRecord({commit},payload){
        await this.$axios.delete('Otherqualification/'+payload).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('otherqualifications/getData')
          })
    }
}