export const state =()=>({
    records:[],
    roles:[],
    record:{}
})

export const mutations={
    setRecords(state,payload){
        state.records = payload
    },
    setRoles(state,payload){
        state.roles = payload
    },
    setRecord(state,payload){
        state.record = payload
    }
}

export const actions={
    async getData({commit}){
        await this.$axios.get('User').then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
    async getRoles({commit},payload){
        await this.$axios.get('User/getUserRoles/'+payload).then((res)=>{
            commit('setRoles',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },
    async getUser({commit},payload){
        await this.$axios.get('User/'+payload).then((res)=>{
            commit('setRecord',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },   
    async resetPassword({commit},payload){
        await this.$axios.get('User/resetpassword/'+payload).then((res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
    async addItem({commit},payload){
        await this.$axios.post('User',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('users/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('User',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('users/getUser',payload.userId)
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('User/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('users/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    }
}