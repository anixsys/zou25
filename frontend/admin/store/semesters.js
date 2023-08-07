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
        await this.$axios.get('Semester').then((res)=>{
            commit('setRecords',res.data)
          })
    }, 
    async getRecord({commit},payload){
        await this.$axios.get('Semester/'+payload).then((res)=>{
            commit('setRecord',res.data)
          })
    }, 
    async addItem({commit},payload){
        await this.$axios.post('Semester',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('semesters/getData')
        }).catch(error=>{
            console.log(error)
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Semester',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('semesters/getData')
        }).catch(error=>{
            console.log(error)
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Semester/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('semesters/getData')
        }).catch(error=>{
            console.log(error)
        })
    }
}