<script setup>
import router from "../../router.ts";
</script>
<script>
import { store } from "../../store.ts";

const buy = () => {
  router.router.push("/mokejimas");
};

export default {
  props: ["title", "img"],
  data() {
    return {
      store: store,
      state: "Gera",
      isbn: "ISBN 9955-476-16-8",
      authors: ["Antanas Apynis", "Eugenijus Stankus", "Juozas Šinkūnas"],
      publisher: "Danieliaus leidykla",
      year: "2002",
      price: "12.50€",
    };
  },
  computed: {
    is_admin() {
      return parseInt(this.store.userinfo.usertype) === 2;
    },
  },
};
</script>

<template>
  <div class="item">
    <div class="grid">
      <div>
        <div class="title">
          <p class="title">{{ title }}</p>
        </div>
        <div class="image">
          <img v-bind:src="img" />
        </div>
      </div>
      <div class="info">
        <p class="state">
          ISBN: <b>{{ isbn }}</b>
        </p>
        <p class="state">
          Autoriai:
          <b v-for="aut in authors" :key="aut">
            {{ aut }}
            <br />
          </b>
        </p>
        <p class="state">
          Kaina: <b>{{ price }}</b>
        </p>
        <p class="state">
          Būsena: <b>{{ state }}</b>
        </p>
      </div>
    </div>
    <div class="buttons">
      <button
        @click="
          router.router.push('./' + this.$route.params.book_id + '/koregavimas')
        "
        v-if="is_admin"
      >
        Koreguoti
      </button>
      <button @click="buy">Pirkti</button>
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
  font-size: 1.2rem;
  font-weight: 350;
  margin: 0 0.5rem;

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

.buttons {
  display: flex;
  width: 100%;
  justify-content: end;
}
</style>
