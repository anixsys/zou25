export const actions={
    async addItem({commit},payload){
        await this.$axios.post('Prerequisite',payload).then(async (res)=>{
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
    async deleteItem({commit},payload){
        await this.$axios.delete('Prerequisite/'+payload.id).then(async (res)=>{
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