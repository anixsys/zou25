export const state =()=>({
    records:[]
})

export const mutations={
    setRecords(state,payload){
        state.records = payload
    }
}

export const actions={
   
    async addItem({commit},payload){
        await this.$axios.post('ApplicationProgramme',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            if(status =="error"){
                this.$swal.show("error",res.data.message,status)
            }else{
                this.$toaster.show(res.data.message,status)
            }
            await this.dispatch('applicant/getProfile',payload.applicantId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async rejectAll({commit},payload){
        await this.$axios.get('Application/decision/rejectall/'+payload.id).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            if(status =="error"){
                this.$swal("error",res.data.message,status)
            }else{
                this.$toaster.show(res.data.message,status)
            }
            await this.dispatch('applications/getData',payload.admissionSessionId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async Accepted({commit},payload){
        await this.$axios.post('Application/decision/accepted',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            if(status =="error"){
                this.$swal("error",res.data.message,status)
            }else{
                this.$toaster.show(res.data.message,status)
            }
            await this.dispatch('applications/getData',payload.admissionSessionId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('ApplicationProgramme/'+payload.id).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            if(status =="error"){
                this.$swal("error",res.data.message,status)
            }else{
                this.$toaster.show(res.data.message,status)
            }
            await this.dispatch('applicant/getProfile',payload.applicantId)
        }).catch(error=>{
            console.log(error)
        })
    }
}