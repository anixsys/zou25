export const state =()=>({
    records:[],
    selected:[]
})

export const mutations={
    setRecords(state,payload){
        state.records = payload
    },
    setSelected(state,payload){
        state.selected = payload
    }
}

export const actions={
    async getData({commit},payload){
        await this.$axios.get('AdmissionProgramme/'+payload).then((res)=>{
            commit('setRecords',res.data)
          })
    },
    async getSelected({commit},payload){
        await this.$axios.get('AdmissionProgramme/selected/'+payload).then((res)=>{
            commit('setSelected',res.data)
          })
    },  
    async addItem({commit},payload){
        await this.$axios.post('AdmissionProgramme',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissionprogrammes/getData',payload.AdmissionTemplateId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('AdmissionProgramme',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissionprogrammes/getData',payload.AdmissionTemplateId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('AdmissionProgramme/'+payload.id).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('admissionprogrammes/getData',payload.AdmissiontemplateId)
        }).catch(error=>{
            console.log(error)
        })
    }
}