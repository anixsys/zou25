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
        await this.$axios.get('Province').then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },  
    async addItem({commit},payload){
        await this.$axios.post('Province',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('provinces/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Province',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('provinces/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Province/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('provinces/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    }
}