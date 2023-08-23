<template>
    <div class="container-fluid">
        <a class="navbar-brand" href="#">
            <img src="../assets/images/logo2.png" alt="" width="40" height="30" class="d-inline-block align-middle">
            <span class="">aparshukov</span>
        </a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse row" id="navbarNavAltMarkup">
            <div class="navbar-nav col-md-11">
                <router-link class="nav-link active" to="/">{{ $t('nav-menu.main') }}</router-link>
                <router-link class="nav-link" to="/">{{ $t('nav-menu.servers') }}</router-link>
                <a class="nav-link" href="https://github.com/LeOn0408">{{ $t('nav-menu.projects') }}</a>
                <router-link class="nav-link" to="/">{{ $t('nav-menu.about') }}</router-link>
            </div>

            <!--Hide authorization while everything is in development-->
            <div class="navbar-nav col-md-1" v-if="false">
                <button type="button"
                        class="btn btn-outline-light"
                        data-bs-toggle="modal"
                        data-bs-target="#modalWindow"
                        @onclick="GetLogin">
                    {{ $t('nav-menu.login') }}
                </button>
                <Login></Login>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent,defineAsyncComponent } from 'vue';
    const Login = defineAsyncComponent(() =>
        import('./modal/LoginModalComponent.vue')
    )
    export default defineComponent({
        components: {
            Login
        },
        data() {
            return {
                
            }
        },
        methods: {

        },
    });
</script>

<style>
</style>