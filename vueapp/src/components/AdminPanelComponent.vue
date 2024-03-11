<template>
    <div class="container-fluid admin" v-if="name !== ''">
        Добро пожаловать, {{name}}!
    </div>
</template>
<script  lang="ts">
    import { defineComponent, defineAsyncComponent } from 'vue';
    import { mapActions, mapState } from 'vuex';
    export default defineComponent({
        data() {
            return {
                name: '',
            }
        },
        methods: {
            ...mapActions({
                user: 'getUser',
                admin: 'isAdmin'
            }),
            getUser() {

                this.user(5).then(result => {
                    console.log(result);
                    this.name=result.data.userName
                });
                this.admin().then(result => {
                    console.log(result);
                    
                });

            }
        },
        created() {
            this.getUser();
        },
    });
</script>
<style>
    .admin{
        background-color:dimgrey;
        color:white;
    }
</style>