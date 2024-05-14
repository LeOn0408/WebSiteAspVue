<template>
    <div class="position-relative page-wrapper">
        <div class="position-relative">
            <div class="admin-panel">
                <AdminPanel></AdminPanel>
            </div>
            <Navigation></Navigation>
            
        </div>
        <main id="main-content">
            <router-view />
            <aside>
                <!--<Servers></Servers>-->
            </aside>
        </main>
        <Footer></Footer>
    </div>
</template>
<script lang="ts">
    import { defineComponent } from "vue";
    import Navigation from "./components/NavigationComponent.vue";
    import AdminPanel from "./components/AdminPanelComponent.vue";
    import Footer from "./components/Footer.vue";

    export default defineComponent({
        components: {
            Navigation,
            AdminPanel,
            Footer
        },
        
    });
</script>

<style>
    #app {
        font-family: 'Yanone Kaffeesatz', sans-serif;
        margin: 0;
        /*background: url(./assets/images/background.png);*/
        font-size: larger;
        /*color: #000000bf;*/
        height:100%
    }
    .page-wrapper {
        display: flex;
        flex-direction: column;
        height: 100vh;
    }

    #main-content {
        flex-grow: 1;
        overflow: auto;
    }
    #footer {
        background-color: #303030;
        color: white;
    }
    #language-select {
        background-color: #303030;
        color: #f1f1f1;
    }
</style>
