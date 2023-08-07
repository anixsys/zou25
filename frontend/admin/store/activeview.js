export const state =()=>({
    record:""
})

export const mutations={
    setRecord(state,payload){
        state.record = payload
    }
}

export const actions={
    async SetView({commit},payload){
            commit('setRecord',payload) 
   
    }
}