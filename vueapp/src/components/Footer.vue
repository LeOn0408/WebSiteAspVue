<template>
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
    #footer {
        background-color: #303030;
        color: white;
        position: static; /* Убираем фиксированное позиционирование */
        bottom: 0;
        width: 100%;
    }

    #language-select {
        background-color: #303030;
        color: #f1f1f1;
    }
    /*@media (max-width: 575px) {
        footer {
            position: static;*/ /* Для мобильных устройств */
        /*}
    }*/
</style>