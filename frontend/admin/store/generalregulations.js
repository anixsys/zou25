export const state =()=>({
    records:[],
    record:null
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
        await this.$axios.get('Generalregulation').then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
    async getListByProgrammetype({commit},payload){
        await this.$axios.get('Generalregulation/retrieve/programmetype/'+payload).then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
    async getRecord({commit},payload){
        await this.$axios.get('Generalregulation/'+payload).then((res)=>{
            commit('setRecord',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },  
    async addItem({commit},payload){
        await this.$axios.post('Generalregulation',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalregulations/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async changestatus({commit},payload){
        await this.$axios.put('Generalregulation/Changestatus',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalregulations/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async duplicaterecord({commit},payload){
        await this.$axios.get('Generalregulation/duplicate/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalregulations/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Generalregulation',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalregulations/getData')
        }).catch(error=>{
            console.log(error)
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Generalregulation/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalregulations/getData')
        }).catch(error=>{
            console.log(error)
        })
    }
}