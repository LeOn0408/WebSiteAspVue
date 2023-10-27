<template>
    <div class="position-relative page-wrapper">
        <div class="position-relative">
            <div class="admin-panel">
                <AdminPanel></AdminPanel>
            </div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <Navigation></Navigation>
            </nav>
        </div>
        <main id="main-content">
            <router-view />
            <aside>
                <!--<Servers></Servers>-->
            </aside>
        </main>
        <footer class="fixed-bottom bg-light">
            <div class="container-fluid py-3" id="footer">
                <div class="row">
                    <div class="col-md-11 text-center">
                        © 2023. aparshukov.ru
                    </div>
                    <div class="col-md-1">
                        <select class="form-select" id="language-select" @change="onChangeLang" v-model="preferredLocale">
                            <option value="ru">Русский</option>
                            <option value="en">English</option>
                        </select>
                    </div>
                </div>
            </div>
        </footer>
    </div>
</template>
<script lang="ts">
    import { defineComponent } from "vue";
    import { mapState } from 'vuex';
    import Navigation from "./components/NavigationComponent.vue";
    import AdminPanel from "./components/AdminPanelComponent.vue";

    export default defineComponent({
        components: {
            Navigation,
            AdminPanel
        },
        computed: mapState([
            'preferredLocale'
        ]),
        methods: {
            onChangeLang(value: any) {
                localStorage.setItem('userLocale', value?.target?.value); 
                location.reload();
            }
        },
    });
</script>

<style>
    #app {
        font-family: 'Yanone Kaffeesatz', sans-serif;
        margin: 0;
        background: url(./assets/images/background.png);
        font-size: larger;
        color: #000000bf;
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
