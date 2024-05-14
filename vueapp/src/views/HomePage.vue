<template>
    
</template>

<script lang="ts">
    import { defineComponent, defineAsyncComponent } from 'vue';
    const News = defineAsyncComponent(() =>
        import('@/views/news/NewsPublic.vue')
    )

    export default defineComponent({
        components: {
            News
        },
    })
    
</script>

<style>

</style>