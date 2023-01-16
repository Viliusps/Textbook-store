<script setup>
import Star from "../icons/RatingStar.vue";
</script>
<script>
import { store } from "../../store.ts";
export default {
  data() {
    return {
      store: store,
      img: "https://thispersondoesnotexist.com/image?3",
      username: "Pirkėjas",
      title: "Puiku :)",
      comment: "Puiki būklė ir gera kaina :))))",
      rating: 5,
    };
  },
  computed: {
    is_not_admin() {
      return parseInt(this.store.userinfo.usertype) !== 2;
    },
  },
};
</script>

<template>
  <div class="comment">
    <div class="top">
      <div class="account">
        <img :src="img" />
        <div class="username">
          {{ username }}
        </div>
      </div>
      <button v-if="is_not_admin">Raportuoti</button>
      <button v-else>Trinti komentarą</button>
    </div>
    <div class="title">
      <h2>{{ title }}</h2>
      <div class="stars">
        <Star class="yellowStar" v-for="i in rating" :key="i" />
        <Star class="greyStar" v-for="i in 5 - rating" :key="i" />
      </div>
    </div>
    <div class="text">
      {{ comment }}
    </div>
  </div>
</template>

<style scoped>
.comment {
  display: flex;
  flex-direction: column;
  background: var(--color-background-mute);
  border-color: var(--color-border);
  border-radius: 8px;
  border-style: solid;
  border-width: 1px;
  padding: 1rem;
  width: 80%;
}

.text {
  display: flex;
  flex-direction: column;
  background: var(--color-background);
  border-color: var(--color-border);
  border-radius: 8px;
  border-style: solid;
  border-width: 1px;
  padding: 1rem;
}

img {
  width: 3rem;
  height: 3rem;
  border-radius: 100%;
  border: solid 2px;
}

h2 {
  color: var(--color-heading);
}

.username {
  font-size: 1.25rem;
  font-weight: 350;
  flex: 1;
  margin: auto 0.5rem;
  width: fit-content;
  pointer-events: none;

  color: var(--color-heading);
}

.account {
  display: flex;
  flex-direction: row;
  transition: 0.4s;
  margin: 0.2rem;
  padding: 0.2rem;
  border-radius: 8px;
}

@media (hover: hover) {
  .account:hover {
    background: var(--color-background-mute);
  }
}

.account:active {
  transition: 0s;
  background: var(--color-background-active);
}

button {
  margin: auto 0;
  height: fit-content;
  padding: 0.5rem;
}

.top {
  display: flex;
  justify-content: space-between;
}

.title {
  display: flex;
  justify-content: space-around;
}

.stars {
  margin: auto 0;
}

.yellowStar {
  color: gold;
}
.grayStar {
  color: gray;
}
</style>
