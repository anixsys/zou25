export const state =()=>({
    records:[],
    record:{}
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
    async getData({commit},payload){
        await this.$axios.get('Application/'+payload).then((res)=>{
            commit('setRecords',res.data)
          })
    },
    async addItem({commit},payload){
        await this.$axios.post('Application',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicant/getProfile',payload.ApplicantId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Application',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicant/getProfile',payload.ApplicantId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async SubmitForApproval({commit},payload){
        await this.$axios.get('Application/Submitforreview/'+payload.id).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicant/getProfile',payload.applicantId)
        }).catch(error=>{
            console.log(error)
        })
    },
    async getRecord({commit},payload){
        await this.$axios.get('Application/record/'+payload).then((res)=>{
            commit('setRecord',res.data)
          })
    },
    async rejectall({commit},payload){
        await this.$axios.post('Application/rejectall',payload).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            if(status =="error"){
                this.$swal.show("error",res.data.message,status)
            }else{
                this.$toaster.show(res.data.message,status)
            }
            await this.dispatch('applicants/getRecord',payload.uuid)
           
          })
    },
    async makedecision({commit},payload){
        await this.$axios.post('Application',payload).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            if(status =="error"){
                this.$swal.show("error",res.data.message,status)
            }else{
                this.$toaster.show(res.data.message,status)
            }
           
            await this.dispatch('applicants/getRecord',payload.uuid)
           
          })
    }
}