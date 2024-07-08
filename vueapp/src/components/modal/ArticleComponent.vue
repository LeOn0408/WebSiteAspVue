<template>
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <div class="modal-header">
                <h1 class="modal-title fs-5" id="articleModalToggleLabel">{{article.title}}</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Закрыть"></button>
            </div>
            <div class="modal-body">
                <p class="card-text" v-html="article.description"></p>
            </div>
            <div class="modal-footer">
                <!--<button class="btn btn-primary" data-bs-target="#exampleModalToggle2" data-bs-toggle="modal">Открыть второе модальное окно</button>-->
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    export default defineComponent({
        components: {
        },
        props: {
            article: Object
        },
        data() {
            return {
            }
        },
        beforeCreate() {
        },
        created() {

            console.log(this.article);
        },
        
        methods: {
        },
    });
</script>

<style>
</style>