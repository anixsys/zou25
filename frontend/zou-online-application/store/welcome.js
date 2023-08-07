export const state =()=>({
    record:{}
})

export const mutations={
    setRecord(state,payload){
        state.record = payload
    }
}

export const actions={
    async getData({commit}){
        await this.$axios.get('Welcome').then((res)=>{
            commit('setRecord',res.data)
          })
    },
    async getData({commit}){
        await this.$axios.get('Welcome').then((res)=>{
            commit('setRecord',res.data)
          })
    }
}