export const state =()=>({
    records:[]
})

export const mutations={
    setRecords(state,payload){
        state.records = payload
    }
}

export const actions={
    async addRecord({commit},payload){
        await this.$axios.post('ApplicantOtherQualification',payload).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicant/getProfile',payload.applicantId)
          })
    },
    async deleteRecord({commit},payload){
        await this.$axios.delete('ApplicantOtherQualification/'+payload.id).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicant/getProfile',payload.applicantId)
          })
    }
}