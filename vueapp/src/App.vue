<template>
    <div class="position-relative page-wrapper">
        <div class="position-relative">
            <div class="admin-panel">
                <AdminPanel></AdminPanel>
            </div>
            <Navigation></Navigation>
            
        </div>
        <main id="main-content" class="d-flex">
            <!-- Основной контент -->
            <div class="flex-grow-1">
                <router-view />
            </div>
            <!-- Правая колонка -->
            <RightSidebar>
                <template v-slot:default>
                    <!-- Здесь можно передать контент через слот -->
                </template>
            </RightSidebar>
        </main>
        <!--<Footer></Footer>-->
    </div>
</template>
<script lang="ts">
    import { defineComponent } from "vue";
    import Navigation from "./components/NavigationComponent.vue";
    import AdminPanel from "./components/AdminPanelComponent.vue";
    import Footer from "./components/Footer.vue";
    import RightSidebar from '@/components/RightSidebar.vue';

    export default defineComponent({
        components: {
            Navigation,
            AdminPanel,
            Footer,
            RightSidebar
        },
        
    });
</script>

<style>
    .page-wrapper {
        display: flex;
        flex-direction: column;
        min-height: 100vh;
    }

    #main-content {
        display: flex;
        flex-grow: 1;
    }
</style>
