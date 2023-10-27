

export default {
    state: {
        user: {},
    },
    mutations: {
        
    },
    actions: {
        async getUser(context: any, id:number) {
            const result = await context.rootState.axios.get(`/api/user?id=${id}`);
            
            //const result = await axios.get(`/api/user?id=${id}`);
            return result;
        },
        async isAdmin(context: any, id: number) {
            try {
                const result = await context.rootState.axios.get(`/api/user/isadmin`);
                return result.data;
            }
            catch (error: any) {
                if (error.response && error.response.status === 403) {
                    console.error('Ошибка 403');
                } else {
                    console.error(error);
                }
                return false;
            }

        }
    }
};
