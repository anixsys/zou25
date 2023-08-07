export const state =()=>({
    records:[],
    record:{}
})

export const mutations={
    setRecords(state,payload){
        state.records = payload
    },
    setRecord(state,payload){
        state.record = payload
    }
}

export const actions={
    async getData({commit}){
        await this.$axios.get('Applicant').then((res)=>{
            commit('setRecords',res.data)
          })
    },  
    async getProfile({commit},payload){
        await this.$axios.get('Applicant/'+payload).then((res)=>{
            commit('setRecord',res.data)
          })
    }, 
    async addItem({commit},payload){
        await this.$axios.post('Applicant',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            var form = {needle:payload.identification}
            await this.dispatch('applicant/Search',form)
        }).catch(error=>{
            console.log(error)
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Applicant',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            var form = {needle:payload.identification}
            await this.dispatch('applicant/Search',form)
        }).catch(error=>{
            console.log(error)
        })
    },
    async Search({commit},payload){
        await this.$axios.post('Applicant/Search',payload).then(async (res)=>{
            commit('setRecords',res.data)
        }).catch(error=>{
            console.log(error)
        })
    }
}