<template>
    <aside class="right-sidebar">
        <!--TODO:Добавить статусы серверов-->
        <!-- Слот для пользовательского контента -->
        <slot>
            <!-- Контент по умолчанию -->
            <div>
                <!--<h5>Популярные статьи</h5>
                <ul>
                    <li><a href="#">Статья 1</a></li>
                    <li><a href="#">Статья 2</a></li>
                    <li><a href="#">Статья 3</a></li>
                </ul>-->
            </div>
        </slot>
    </aside>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    export default defineComponent({});
</script>

<style>
    .right-sidebar {
        width: 300px;
        padding: 15px;
        background-color: #f8f9fa;
        border-left: 1px solid #dee2e6;
    }
</style>
