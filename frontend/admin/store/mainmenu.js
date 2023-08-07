export const state =()=>({
    records:localStorage.getItem("mainmenu") ? localStorage.getItem("mainmenu") :[],
    role:localStorage.getItem("role") ? localStorage.getItem("role") :""
})

export const mutations={
    setRecords(state,payload){
        state.records = localStorage.getItem("mainmenu")
    },
    setRole(state,payload){
        state.role = localStorage.getItem("role") ? localStorage.getItem("role") :""
    }
}

export const actions={
    async getData({commit},payload){
        await this.$axios.get('Profile/'+payload.name).then((res)=>{
            localStorage.removeItem("role")
            localStorage.setItem("role",payload.view)
            localStorage.removeItem("mainmenu")
            localStorage.setItem("mainmenu",JSON.stringify(res.data))
            commit('setRecords',JSON.stringify(res.data))
            commit('setRole',payload)
          }).catch(error=>{
            console.log(error)
           
        })
    },  
    async SwitchRole({commit}){
      
            localStorage.removeItem("role")
            localStorage.removeItem("mainmenu")
            commit('setRecords',[])
            commit('setRole',"")
         
    },

   
}