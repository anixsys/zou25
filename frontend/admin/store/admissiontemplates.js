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
        await this.$axios.get('AdmissionTemplate').then((res)=>{
            commit('setRecords',res.data)
          })
    },  
    async addItem({commit},payload){
        await this.$axios.post('AdmissionTemplate',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissiontemplates/getData')
        }).catch(error=>{
            console.log(error)
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('AdmissionTemplate',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissiontemplates/getData')
        }).catch(error=>{
            console.log(error)
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('AdmissionTemplate/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissiontemplates/getData')
        }).catch(error=>{
            console.log(error)
        })
    }
}