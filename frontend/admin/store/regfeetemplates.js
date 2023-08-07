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
        await this.$axios.get('RegistrationFeeTemplate').then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },  
    async Approve({commit},payload){
        await this.$axios.get('RegistrationFeeTemplate/'+payload.uuid).then(async(res)=>{
            this.$toaster.show(res.data.message,status)
            await this.dispatch('regfeetemplates/getData')
          }).catch(error=>{
            console.log(error)
           
        })
    },
    async addItem({commit},payload){
        await this.$axios.post('RegistrationFeeTemplate',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('regfeetemplates/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('RegistrationFeeTemplate',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('regfeetemplates/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('RegistrationFeeTemplate/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('regfeetemplates/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    }
}