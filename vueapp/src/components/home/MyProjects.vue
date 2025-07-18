<template>
    <div class="d-flex justify-content-center align-items-center flex-column text-center p-4 shadow-sm bg-white rounded-4 border" style="min-height: 300px;">
        <svg xmlns="http://www.w3.org/2000/svg" width="64" height="64" fill="currentColor" class="bi bi-kanban mb-3 text-primary" viewBox="0 0 16 16">
            <path d="M2.5 3A1.5 1.5 0 0 0 1 4.5v7A1.5 1.5 0 0 0 2.5 13h11a1.5 1.5 0 0 0 1.5-1.5v-7A1.5 1.5 0 0 0 13.5 3h-11zM2 4.5A.5.5 0 0 1 2.5 4h11a.5.5 0 0 1 .5.5V6H2V4.5zM2 7h6v4H2V7zm7 0h5v4H9V7z" />
        </svg>
        <h5 class="fw-bold mb-2">Проекты в разработке</h5>
        <p class="text-muted mb-0">Скоро здесь появятся мои активные и завершённые проекты: от игр до сервисов и утилит.</p>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({})
</script>

<style scoped>
    @media (max-width: 768px) {
        div {
            padding: 2rem 1rem;
        }
    }
</style>
