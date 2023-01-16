<script>
export default {
  props: { state: Boolean },
};
</script>

<template>
  <Transition name="modal">
    <div v-if="state" class="screen" @click.self="$emit('close')">
      <div class="container">
        <slot></slot>
      </div>
    </div>
  </Transition>
</template>

<style scoped>
.screen {
  display: flex;
  justify-content: center;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: 100;
  background: var(--color-background-t);
  backdrop-filter: blur(5px);
  transition: opacity 0.3s ease;
}

.container {
  padding: 1rem;
  margin: auto;
  max-width: 50%;
  height: fit-content;
  border-style: solid;
  border-color: var(--color-border);
  border-width: 1px;
  border-radius: 8px;
  background: var(--color-background-soft);
  box-shadow: 0 0 8px 8px var(--color-background);
}

.modal-enter-from {
  backdrop-filter: blur(0);
  opacity: 0;
}

.modal-leave-to {
  backdrop-filter: blur(0);
  opacity: 0;
}
</style>
