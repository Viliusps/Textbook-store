<script setup>
import router from "../../router.ts";
</script>
<script>
export default {
  props: ["link", "title", "price", "bukle", "isbn"],
};
</script>

<template>
  <button @click="router.router.push(link)" class="item">
    <p class="title">{{ title }}</p>
    <p class="price">{{ price }}€</p>
    <p class="price">{{ bukle }}</p>
    <p class="price">{{ isbn }}</p>
  </button>
</template>

<style scoped>
.item {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin: 0.5rem 0.2rem;
  width: 14rem;
  height: fit-content;

  background: var(--color-background-soft);
}

@media (hover: hover) {
  .item:hover img {
    filter: brightness(125%);
    transform: scale(1.1);
  }
}

.item:active {
  background: var(--color-background-active);
}

.image {
  overflow: hidden;
  border-width: 1px;
  border-color: var(--color-border);
  margin-top: 0.5rem;
}

.price {
  width: 100%;
  padding: 0.2rem;
  text-align: right;
  font-size: 1rem;

  color: var(--color-text);
}

img {
  width: 11rem;
  margin: auto;
  transition: 0.4s;
}

.title {
  font-size: 1.5rem;
  font-weight: 350;
  flex: 1;

  color: var(--color-heading);
}
</style>
