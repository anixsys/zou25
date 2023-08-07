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
        await this.$axios.get('AdmissionTemplate').then((res)=>{
            commit('setRecords',res.data)
          })
    },
    async getDataByType({commit},payload){
        await this.$axios.get('AdmissionTemplate/'+payload).then((res)=>{
            commit('setRecords',res.data)
          })
    }

}