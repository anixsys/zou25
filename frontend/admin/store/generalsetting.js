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
    async getRecords({commit}){
        await this.$axios.get('Globalsettingtemplate').then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
    async getRecord({commit},payload){
        await this.$axios.get('Globalsettingtemplate/'+payload).then((res)=>{
            commit('setRecord',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
    async addItem({commit},payload){
        await this.$axios.post('Globalsettingtemplate',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalsetting/getRecords')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Globalsettingtemplate',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalsetting/getRecords')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Globalsettingtemplate/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalsetting/getRecord')
        }).catch(error=>{
            console.log(error)
           
        })
    }
}