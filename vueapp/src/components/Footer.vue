﻿<template>
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
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { mapState } from 'vuex';


    export default defineComponent({
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
    @media (max-width: 575px) {
        footer.fixed-bottom {
            position: static; /* Убираем фиксированное позиционирование для маленьких экранов */
        }
    }
</style>