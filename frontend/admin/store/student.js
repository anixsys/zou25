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
    async getData({commit}){
        await this.$axios.get('Student').then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
    async Search({commit},payload){
        await this.$axios.post('Student/Search',payload).then(async (res)=>{
            commit('setRecords',res.data)  
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async getRecord({commit},payload){
        await this.$axios.get('Student/Profile/'+payload).then((res)=>{
            commit('setRecord',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
   
}