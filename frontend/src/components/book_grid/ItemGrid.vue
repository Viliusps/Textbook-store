<script setup>
import Search from "./ItemSearch.vue";
</script>

<template>
  <Search />
  <div class="panel">
    <slot></slot>
  </div>
</template>

<style scoped>
h1 {
  color: var(--color-kk-heading);
}

.panel {
  padding: 1rem;
  display: grid;
  grid-template-columns: repeat(2, 1fr);

  border-color: var(--color-border);
  border-width: 1px;
  border-style: solid;
}

@media (min-width: 1024px) {
  .panel {
    grid-template-columns: repeat(4, 1fr);
  }
}
</style>
