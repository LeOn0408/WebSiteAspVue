<template>
    <div class="container">
        <div class="row">
            <div class="col-1">
                <button type="button"
                        class="btn btn-secondary"
                        data-bs-toggle="modal"
                        data-bs-target="#modalWindow">
                    {{ $t('nav-menu.login') }}
                </button>
            </div>
        </div>
        <Login></Login>
    </div>
</template>

<script lang="ts">
    import { defineComponent, defineAsyncComponent } from 'vue';
    const Login = defineAsyncComponent(() =>
        import('@/components/modal/LoginModalComponent.vue')
    )

    export default defineComponent({
        components: {
            Login
        },
        directives: {
        },
        filters: {
        },
        props: {
        },
        data() {
            return {
            }
        },
        computed: {
        },
        
        methods: {
            
        },
    });
</script>

<style>
</style>