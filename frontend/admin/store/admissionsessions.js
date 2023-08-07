export const state =()=>({
    records:[]
})

export const mutations={
    setRecords(state,payload){
        state.records = payload
    }
}

export const actions={
    async getData({commit}){
        await this.$axios.get('AdmissionSession').then((res)=>{
            commit('setRecords',res.data)
          })
    },  
    async getAllPublish({commit}){
        await this.$axios.get('AdmissionSession/Published').then((res)=>{
            commit('setRecords',res.data)
          })
    },
    async addItem({commit},payload){
        await this.$axios.post('AdmissionSession',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissionsessions/getData')
        }).catch(error=>{
            console.log(error)
        })
    },
    async changeStatus({commit},payload){
        await this.$axios.post('AdmissionSession/ChangeStatus',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissionsessions/getData')
        }).catch(error=>{
            console.log(error)
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('AdmissionSession',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissionsessions/getData')
        }).catch(error=>{
            console.log(error)
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('AdmissionSession/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissionsessions/getData')
        }).catch(error=>{
            console.log(error)
        })
    }
}