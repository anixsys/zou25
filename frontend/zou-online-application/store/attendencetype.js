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
        await this.$axios.get('Programme/'+payload.programmeId+"/"+payload.templateId).then((res)=>{
            commit('setRecords',res.data)
          })
    }
}