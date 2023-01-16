<script setup>
import Icon404 from "../components/icons/Icon_404.vue";
</script>

<template>
  <div class="grid">
    <header>
      <Icon404 />
    </header>
    <main>
      <h2>Jūsų ieškomo puslapio neradome :(</h2>
      <router-link class="link" to="/">
        Spauskite čia norėdami grįžti į pradžią
      </router-link>
    </main>
  </div>
</template>

<style scoped>
.grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
}

header {
  height: 500px;
  width: 500px;
  color: var(--color-header);
}

.link {
  font-size: 1.5rem;
}

main {
  display: flex;
  flex-direction: column;
  margin: 0;

  font-size: 2rem;
  text-align: center;
  color: var(--color-header);
}

@media (min-width: 1024px) {
  main {
    margin: 40% 0;
  }
  header {
    margin: 20% 0;
  }
}
</style>
