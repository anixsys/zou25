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
        await this.$axios.get('WorkExperience').then((res)=>{
            commit('setRecords',res.data)
          })
    },
    async addRecord({commit},payload){
        await this.$axios.post('WorkExperience',payload).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('workexperience/getData')
          })
    },
    async deleteRecord({commit},payload){
        await this.$axios.delete('WorkExperience/'+payload).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('workexperience/getData')
          })
    }
}