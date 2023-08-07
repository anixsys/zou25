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
        await this.$axios.get('Academicregulation/'+payload).then((res)=>{
            commit('setRecords',res.data)
          })
    },  
    async addItem({commit},payload){
        await this.$axios.post('Academicregulation',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('programmes/getProgramme',payload.ProgrammeId)
        }).catch(error=>{
            console.log(error)
         })
    },
    async Changestatus({commit},payload){
        await this.$axios.post('Academicregulation/ChangeStatus',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('programmes/getProgramme',payload.programmeId)
        }).catch(error=>{
            console.log(error)
         })
    },
    async SetAsDefault({commit},payload){
        await this.$axios.get('Academicregulation/setdefault/'+payload.id).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('programmes/getProgramme',payload.programmeId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async duplicateItem({commit},payload){
        await this.$axios.post('Academicregulation/Duplicate',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('academicregulations/getData',payload.programmeId)
        }).catch(error=>{
            console.log(error)           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Academicregulation',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('academicregulations/getData',payload.programmeId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Academicregulation/'+payload.id).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('academicregulations/getData',payload.programmeId)
        }).catch(error=>{
            console.log(error)
        })
    }
}