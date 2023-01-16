<script>
export default {
  props: ["link", "text"],
};
</script>

<template>
  <button class="item">
    <i>
      <slot></slot>
    </i>
    <p class="text">{{ text }}</p>
  </button>
</template>

<style scoped>
.item {
  width: 100%;
  margin-top: 1rem;
  display: flex;
  height: fit-content;
}

.text {
  font-size: 1.5rem;
  font-weight: 350;
  flex: 1;
  margin-left: 0.5rem;
  text-align: left;

  color: var(--color-heading);
}

i {
  display: flex;
  place-items: center;
  place-content: center;
  width: 32px;
  height: 32px;

  color: var(--color-text);
}
</style>
