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
    async getData({commit},payload){
        await this.$axios.get('Application').then((res)=>{
            commit('setRecords',res.data)
          })
    },
    async getRecord({commit},payload){
        await this.$axios.get('Application/'+payload).then((res)=>{
            commit('setRecord',res.data)
          })
    },
    async getApplication({commit},payload){
        await this.$axios.get('Application/'+payload).then((res)=>{
            commit('setRecord',res.data)
          })
    },
    async addItem({commit},payload){
        await this.$axios.post('Application',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applications/getData')
            if(res.data.status){
                this.$router.push("/payment/"+res.data.uuid);
            }
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async confirm({commit},payload){
        await this.$axios.get('Application/confirm/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applications/getData')
            if(res.data.status){
                this.$router.push("/dashboard");
            }
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Application/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applications/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    }
}