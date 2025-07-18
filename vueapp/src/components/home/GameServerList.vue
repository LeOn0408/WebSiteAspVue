<template>
    <div class="d-flex justify-content-center align-items-center flex-column text-center p-4 shadow-sm bg-white rounded-4 border" style="min-height: 300px;">
        <svg xmlns="http://www.w3.org/2000/svg" width="64" height="64" fill="currentColor" class="bi bi-tools mb-3 text-secondary" viewBox="0 0 16 16">
            <path d="M1 0a1 1 0 0 0-1 1v2h2V1h1V0H1zm3 0v1h1v2H3V1h1V0h1zM0 5h16v1H0V5zm0 3h16v1H0V8zm0 3h16v1H0v-1zm0 3h16v1H0v-1z" />
            <path d="M10.97 4.97a.75.75 0 0 0-1.06-1.06L6.75 7.06l-.72-.72a.75.75 0 0 0-1.06 1.06l1.25 1.25a.75.75 0 0 0 1.06 0l3.75-3.75z" />
        </svg>
        <h5 class="fw-bold mb-2">Серверы в разработке</h5>
        <p class="text-muted mb-0">Я активно работаю над игровыми серверами. Следите за обновлениями!</p>
    </div>
    <!--<div class="row">
        <div class="col-md-6 mb-3" v-for="server in servers" :key="server.id">
            <div class="card h-100">
                <div class="card-body">
                    <h5 class="card-title">{{ server.name }}</h5>
                    <p class="card-text text-muted">{{ server.status }}</p>
                </div>
            </div>
        </div>
    </div>-->
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
    data() {
        return {
            servers: [
                { id: 1, name: 'ARK', status: '🔴 Оффлайн' },
                { id: 2, name: 'Palworld', status: '🔴 Оффлайн' },
                { id: 3, name: '7DTD', status: '🔴 Оффлайн' }
            ]
        }
    }
})
</script>
