

export default {
    state: {
        user: {},
    },
    mutations: {
        
    },
    actions: {
        async getUser(context: any, id:number) {
            const result = await context.rootState.axios.get(`/api/user?id=${id}`).catch((err:any) => {
                throw err;
            });
           
            return result;
        },
        async isAdmin(context: any, id: number) {
            const result = await context.rootState.axios.get(`/api/user/isadmin`).catch((err: any) => {
                throw err;
            });
            return result.data;
        }
    }
};
