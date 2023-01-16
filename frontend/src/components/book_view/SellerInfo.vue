<script setup>
import Star from "../icons/RatingStar.vue";
</script>
<script>
import Axios from "axios";
import {store} from "@/store";

export default {
  data() {
    return {
      vartotojas: [],
      img: "https://thispersondoesnotexist.com/image?2",
      username: "Pardavėjas",
      rating: 0,
    };
  },
  async mounted() {
    await Axios.get("https://localhost:7293/api/Vartotojas").then(
        (resp) => (this.vartotojas = resp.data)
    );

    let temp=0;
    for(var i of this.vartotojas) {
      if(i.id === parseInt(localStorage.getItem("id"))) {
        for(var j of i.vartotojo_ivertinimas) {
          temp+=parseInt(j);
        }
        temp=temp/i.vartotojo_ivertinimas.length;
        break;
      }
    }
    this.rating=Math.round(temp);
  },
};
</script>

<template>
  <div class="seller">
    <div class="account">
      <img :src="img" />
      <div class="text">
        {{ username }}
      </div>
    </div>
    <div class="stars">
      <Star class="yellowStar" v-for="i in rating" :key="i" />
      <Star class="greyStar" v-for="i in 5 - rating" :key="i" />
    </div>
  </div>
</template>

<style scoped>
.seller {
  display: flex;
}
img {
  width: 3rem;
  height: 3rem;
  border-radius: 100%;
  border: solid 2px;
}

.text {
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

  .login-button:hover {
    background: var(--color-background-mute);
  }
}

.account:active {
  transition: 0s;
  background: var(--color-background-active);
}

.stars {
  margin: auto;
}

.yellowStar {
  color: gold;
}
.grayStar {
  color: gray;
}
</style>
