<template>
  <div class="panel">
    <h1>Knygų Kirminai</h1>
    <div class="links">
      <slot></slot>
    </div>
  </div>
</template>

<style scoped>
h1 {
  color: var(--color-kk-heading);
}

.panel {
  padding: 1rem;
  display: flex;
  flex-direction: column;
  position: absolute;
  left: 0;
  width: 15%;
  height: 100%;

  background-color: var(--color-background-soft);

  border-color: var(--color-border);
  border-width: 0 1px 0 0;
  border-style: solid;
}

.links {
  margin-top: 1rem;
}
</style>
