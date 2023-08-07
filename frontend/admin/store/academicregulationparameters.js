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
        await this.$axios.get('Academicregulationparameter/'+payload).then((res)=>{
            commit('setRecords',res.data)
          })
    },  
    async addItem({commit},payload){
        await this.$axios.post('Academicregulationparameter',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('academicregulationparameters/getData',payload.AcademicRegulationId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Academicregulationparameter',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('academicregulationparameters/getData',payload.AcademicRegulationId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Academicregulationparameter/'+payload.Id).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('academicregulationparameters/getData',payload.AcademicRegulationId)
        }).catch(error=>{
            console.log(error) 
          })
    }
}