<script setup>
import Icon404 from "../components/icons/Icon_404.vue";
import Login from "../components/login/LoginComp.vue";
import TmpLogin from "../components/login/TempRoleChoice.vue";
</script>

<template>
  <div class="grid">
    <header>
      <Icon404 />
      <TmpLogin />
    </header>
    <main>
      <Login />
    </main>
  </div>
</template>

<style scoped>
.grid {
  display: grid;
  grid-template-columns: 1fr 3fr;
}

header {
  height: 400px;
  color: var(--color-header);
}

.link {
  font-size: 1.5rem;
}

main {
  display: flex;
  flex-direction: column;

  font-size: 2rem;
  text-align: center;
  color: var(--color-header);
}

@media (min-width: 1024px) {
  main {
    margin: 20% 0;
  }
  header {
    margin: 20% 0;
  }
}
</style>
