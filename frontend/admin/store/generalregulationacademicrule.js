
export const actions={
   
    async addItem({commit},payload){
        await this.$axios.post('Generalregulationacademicrule',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalregulations/getRecord',payload.generalregulationId)
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Generalregulationacademicrule',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalregulations/getRecord',payload.generalregulationId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Generalregulationacademicrule/'+payload.id).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('generalregulations/getRecord',payload.generalregulationId)
        }).catch(error=>{
            console.log(error)
        })
    }
}