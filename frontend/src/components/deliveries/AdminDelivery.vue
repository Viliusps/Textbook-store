<script setup>
import router from "../../router.ts";
</script>
<script>
export default {
  props: ["state", "title", "img", "esttime", "user"],
  data() {return router;}
};
</script>

<template>
  <div class="item">
    <div class="grid">
      <div class="image">
        <img v-bind:src="img" />
      </div>
      <div class="info">
        <p class="state">Užsakovas: <b>Vartotojas</b></p>
        <p class="state">Adresas: <b>Kaunas, Savanoriu pr. 12</b></p>
        <p class="state">
          Pardavėjas: <b>{{ user }}</b>
        </p>
        <p class="state">Kaina: <b>12.50€</b></p>
        <p class="state">
          <slot></slot> <b>{{ esttime }}</b>
        </p>
        <p class="state">
          Būsena: <b>{{ state }}</b>
        </p>
      </div>
    </div>
    <div class="title">
      <p class="title">{{ title }}</p>
      <button @click="router.router.push('/siuntiniu-valdymas/1')">Valdyti siuntą</button>
    </div>
  </div>
</template>

<style scoped>
.item {
  display: flex;
  flex-grow: 1;
  flex-direction: column;
  align-items: center;
  margin: 1rem 4rem;
  padding: 1rem;
  width: 100%;
  height: fit-content;

  border-color: var(--color-border);
  border-width: 1px;
  border-radius: 8px;
  border-style: solid;

  background: var(--color-background-soft);
}

.title {
  display: flex;
  width: 100%;
  flex-direction: row;
  justify-content: space-around;
}

button {
  font-size: 1rem;
  font-weight: 350;

  color: var(--color-heading);
}

.image {
  overflow: hidden;
  border-width: 1px;
  border-color: var(--color-border);
  margin: 1rem;
}

.grid {
  display: flex;
  width: 100%;
  flex-direction: row;
}

.info {
  flex-grow: 1;
  margin: 2rem;
}

.state {
  width: 100%;
  padding: 0.2rem;
  text-align: right;
  font-size: 1rem;

  color: var(--color-heading);
}

b {
  color: var(--color-kk-heading);
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
