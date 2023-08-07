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
        await this.$axios.get('Programme').then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },  
    async getProgrammesByUser({commit}){
        await this.$axios.get('Programme/GetProgrammesByUser').then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },  
    async getProgramme({commit},payload){
        await this.$axios.get('Programme/'+payload).then((res)=>{
            commit('setRecord',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },
    async getProgrammesByType({commit},payload){
        await this.$axios.get('Programme/ByType/'+payload).then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
    async addItem({commit},payload){
        await this.$axios.post('Programme',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('programmes/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Programme',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('programmes/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Programme/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('programmes/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    }
}