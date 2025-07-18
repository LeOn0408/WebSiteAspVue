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

<script>
import { mapActions } from 'vuex';

export default {
  methods: {
    ...mapActions('auth', ['logout']),
    logout() {
      this.$store.dispatch('auth/logout').then(() => {
        this.$router.push('/login');
      });
    }
  }
}
</script>