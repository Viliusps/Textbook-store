<script setup>
import LoginItem from "./LoginItem.vue";
</script>

<template>
  <div class="panel">
    <h1>Knygų Kirminai</h1>
    <div class="links">
      <slot></slot>
    </div>
    <LoginItem />
  </div>
</template>

<style scoped>
h1 {
  color: var(--color-kk-heading);
}

.panel {
  padding: 0 1rem;
  display: flex;
  align-items: center;
  height: fit-content;
  width: 100%;
  position: sticky;
  top: 0;
  z-index: 10;

  background-color: var(--color-background-soft);
  box-shadow: 0 0.5rem 4px var(--color-background);

  border-color: var(--color-border);
  border-width: 0 1px 0 0;
  border-style: solid;
}

.links {
  margin-left: 2rem;
  display: flex;
  flex-direction: row;
  flex-grow: 1;
}
</style>
