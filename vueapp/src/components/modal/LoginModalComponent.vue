<template>
    <Modal :title="getTitle">
        <template v-slot:modal-body>
            <div class="row g-3">
                <div class="col-md-6">
                    <label for="username" class="form-label">
                        {{ $t('login.username') }}
                    </label>
                    <input v-model="username" type="text" class="form-control" id="username" required>
                </div>
                <div class="col-md-6">
                    <label for="username" class="form-label">
                        {{ $t('login.password') }}
                    </label>
                    <input v-model="password" type="password" class="form-control" id="password" required>
                </div>
                <!--TODO:Add validation. Can be implemented from bootstrap 5-->
                <div class="invalid-feedback"></div>
            </div>
        </template>
        <template v-slot:footer>
            <button @click="login">{{ $t('login.submit') }} </button>
        </template>
    </Modal>
</template>

<script lang="ts">
    import { defineComponent, defineAsyncComponent } from 'vue';
    import { mapActions } from 'vuex'

    const Modal = defineAsyncComponent(() =>
        import('./ModalComponent.vue')
    )
    export default defineComponent({
        components: {
            Modal
        },
        data() {
            return {
                isVisible: false,
                lang: this.$t,
                username: "",
                password: "",
                error:""
            }
        },
        computed: {
            getTitle():string {
                return this.lang('nav-menu.login');
            }
        },
        methods: {
            ...mapActions('auth',{
                auth: 'login'
            }),
            login(){
                if (!this.username.trim() || !this.password.trim()) {
                    this.error = this.lang('login.emptyFields');
                    return;
                    
                }
                this.auth({ username: this.username, password: this.password })
                    .then(() => {
                        const redirect = this.$route.query.redirect as string | undefined;
                        this.isVisible = false;
                        if (redirect) {
                            this.$router.push(decodeURIComponent(redirect));
                        }
                        //else {
                        //    this.$emit('close');
                        //}
                    })
                    .catch((err) => {
                        if (err.response && err.response.status === 401) {
                            const redirect = this.$route.query.redirect as string | undefined;

                            if (!redirect) {
                                this.$router.push('/');
                            }
                        } else {
                            this.error = this.lang('login.failed');
                        }
                    });
            }
        },
    });
</script>

<style>
</style>