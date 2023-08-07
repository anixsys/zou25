export const state =()=>({
    records:[],
    systemmodules:[],
    submodules:[],
    permissions:[]
})

export const mutations={
    setRecords(state,payload){
        state.records = payload
    },
    setSystemodules(state,payload){
        state.systemmodules = payload
    },
    setSubmodules(state,payload){
        state.submodules = payload
    },
    setPermissions(state,payload){
        state.permissions = payload
    }
}

export const actions={
    async getData({commit}){
        await this.$axios.get('Role').then((res)=>{
            commit('setRecords',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    }, 
    
   

    async assignFunctions({commit},payload){
        await this.$axios.post('Role/Assign',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('roles/getitems',payload.RoleId)
          }).catch(error=>{
            console.log(error)
           
        })
    },
    async addItem({commit},payload){
        await this.$axios.post('Role',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(status,res.data.message)
            this.$toaster.show(res.data.message,status)
            await this.dispatch('roles/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async updateItem({commit},payload){
        await this.$axios.put('Role',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('roles/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async removeItem({commit},payload){
        await this.$axios.delete('Role/'+payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('roles/getData')
        }).catch(error=>{
            console.log(error)
           
        })
    },

    async getSystemmodules({commit},payload){
        await this.$axios.get('Role/Systemmodule/'+payload).then((res)=>{
            commit('setSystemodules',res.data)
          }).catch(error=>{
            console.log(error)
           
        })
    },

    async AssignSystemModule({commit},payload){
        await this.$axios.post('RoleSystemModule',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('roles/getSystemmodules',payload.RoleId)
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async AssignSystemSubmodule({commit},payload){
        await this.$axios.post('RoleSubmodule',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('roles/getSystemmodules',payload.RoleId)
        }).catch(error=>{
            console.log(error)
           
        })
    },
    async AssignPermission({commit},payload){
        await this.$axios.post('RolePermission',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('roles/getSystemmodules',payload.RoleId)
        }).catch(error=>{
            console.log(error)
           
        })
    },
  


}