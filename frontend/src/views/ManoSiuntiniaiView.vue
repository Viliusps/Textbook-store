<script setup>
import { store } from "../store.ts";
import Delivery from "../components/deliveries/Delivery.vue";
import GuestDelivery from "../components/deliveries/GuestDelivery.vue";
</script>
<script>
export default {
  data() {
    return store;
  },
};
</script>

<template>
  <header>
    <h1>Mano siuntiniai</h1>
  </header>
  <div class="deliveries" v-if="parseInt(store.userinfo.usertype) !== 0">
    <Delivery
      img="https://balka-book.com/files/2017/06_07/08_27/u_files_store_3_344867.jpg"
      title="Introduction to Algorythms"
      state="Pristatoma"
      esttime="2022-11-08"
      :button="true"
    >
      Numatoma pristatymo data:
    </Delivery>
    <Delivery
      img="https://balka-book.com/files/2017/06_07/08_27/u_files_store_3_344867.jpg"
      title="Introduction to Algorythms"
      state="Pristatyta"
      esttime="2022-11-03"
    >
      Pristatymo data:
    </Delivery>
    <Delivery
      img="https://balka-book.com/files/2017/06_07/08_27/u_files_store_3_344867.jpg"
      title="Introduction to Algorythms"
      state="Pristatyta"
      esttime="2022-11-03"
    >
      Pristatymo data:
    </Delivery>
  </div>
  <GuestDelivery v-else />
</template>

<style scoped>
h1 {
  color: var(--color-heading);
  text-align: center;
}

header {
  margin: 0;
  width: 100%;
  height: fit-content;
  font-size: 1.5rem;
  line-height: 1.5;
}

.deliveries {
  display: flex;
  flex-direction: column;
  width: 100%;
}

.link {
  font-size: 1.5rem;
}

main {
  display: flex;
  flex-direction: column;
  margin: 0;

  font-size: 2rem;
  text-align: center;
  color: var(--color-header);
}

@media (min-width: 1024px) {
  main {
    margin: 40% 0;
  }
}
</style>
