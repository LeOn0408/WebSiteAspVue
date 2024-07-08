<template>
    <blog></blog>
</template>

<script lang="ts">
    import { defineComponent, defineAsyncComponent } from 'vue';
    const blog = defineAsyncComponent(() =>
        import('@/views/blog/BlogPublic.vue')
    )

    export default defineComponent({
        components: {
            blog
        },
    })
    
</script>

<style>

</style>