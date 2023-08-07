export const actions={
    async addItem({commit},payload){
        await this.$axios.post('UserRole',payload).then(async (res)=>{
            var status = "success"
            if(!res.data.status){
                status ="error"
            }
            this.$toaster.show(res.data.message,status)
            await this.dispatch('users/getUser',payload.userId)
        }).catch(error=>{
                 console.log(error)
        })
    }
}