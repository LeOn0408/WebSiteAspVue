<template>
    <div>
        <!--<header>
            <nav>-->
                <!-- Меню для авторизованных -->
                <!--<router-link to="/admin">Admin</router-link>
                <button @click="logout">Logout</button>
            </nav>
        </header>-->
        <main>
            <router-view />
        </main>
    </div>
</template>

<script lang="ts">
import { mapActions } from 'vuex';

export default {
  methods: {
    
  }
}
</script>