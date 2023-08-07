export const state =()=>({
    records:{}
})

export const mutations={
    setRecords(state,payload){
        state.records = payload
    }
}

export const actions={
    async getData({commit},payload){
        await this.$axios.get('Dashboard/'+payload).then((res)=>{
            commit('setRecords',res.data)
          })
    }
}