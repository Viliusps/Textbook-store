<script setup>
import router from "../../router.ts";
import { store } from "../../store.ts";
</script>
<script>
export default {
  props: ["link", "text", "roles"],
  data() {
    return store;
  },
  computed: {
    visible() {
      if(this.roles!==undefined) console.log(this.roles.includes(store.userinfo.usertype));
      if (
        this.roles === undefined ||
        this.roles.includes(parseInt(store.userinfo.usertype))
      ) {
        return true;
      }
      return false;
    }
  }
};
</script>

<template>
  <button v-if="visible" @click="router.router.push(link)" class="item">
    <div class="text">
      {{ text }}
    </div>
    <div class="slot">
      <slot></slot>
    </div>
  </button>
</template>

<style scoped>
.item {
  width: fit-content;
  margin: 0.5rem;
  display: flex;
  height: fit-content;
}

.text {
  font-size: 1.25rem;
  font-weight: 350;
  flex: 1;
  margin: 0 0.5rem;

  color: var(--color-heading);
}

.slot {
  position: absolute;
  display: flex;
  place-items: center;
  place-content: center;

  color: var(--color-text);
}
</style>
