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
        await this.$axios.get('Systemsubmodule/'+payload).then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },  
    async addItem({commit},payload){
        await this.$axios.post('Systemsubmodule',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('submodules/getData',payload.SystemmoduleId)
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Systemsubmodule',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('submodules/getData',payload.SystemmoduleId)
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Systemsubmodule/'+payload.id).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('submodules/getData',payload.systemModuleId)
        }).catch(error=>{
            console.log(error)
           
        })
    }
}