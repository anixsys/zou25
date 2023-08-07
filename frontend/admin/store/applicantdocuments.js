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
        await this.$axios.get('ApplicantDocument/'+payload).then((res)=>{
            commit('setRecords',res.data)
          })
    },
    
    async deleteRecord({commit},payload){
        await this.$axios.delete('ApplicantDocument/'+payload.id).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicant/getProfile',payload.applicantId)
          })
    },
    async verify({commit},payload){
        await this.$axios.get('ApplicantDocument/verified/'+payload.id).then(async(res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('applicant/getProfile',payload.applicantId)
          }).catch((error)=>{
            console.log(error)
          })
    }
}