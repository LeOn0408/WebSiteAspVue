<template>
    <!-- Modal -->
    <div class="modal fade" id="modalWindow" tabindex="-1" aria-labelledby="modalWindow" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalWindow">{{title}}</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <slot name="modal-body"></slot>
                </div>
                <div class="modal-footer">
                    <slot name="footer"></slot>
                </div>
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
            title:String
        },
        data() {
            return {
            }
        },
        methods: {
        },
    });
</script>

<style>
</style>