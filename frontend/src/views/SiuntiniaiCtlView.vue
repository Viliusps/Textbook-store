<script setup>
import AdminDelivery from "../components/deliveries/AdminDelivery.vue";
import Search from "../components/deliveries/DeliverySearch.vue";
</script>

<template>
  <header>
    <h1>Siuntiniai</h1>
  </header>
  <Search />
  <AdminDelivery
    img="https://balka-book.com/files/2017/06_07/08_27/u_files_store_3_344867.jpg"
    title="Introduction to Algorithms"
    state="Pristatoma"
    esttime="2022-11-08"
    user="Pardavėjas 1"
  >
    Numatoma pristatymo data:
  </AdminDelivery>
  <AdminDelivery
    img="https://balka-book.com/files/2017/06_07/08_27/u_files_store_3_344867.jpg"
    title="Introduction to Algorithms"
    state="Pristatoma"
    esttime="2022-11-08"
    user="Pardavėjas 4"
  >
    Numatoma pristatymo data:
  </AdminDelivery>
  <AdminDelivery
    img="https://balka-book.com/files/2017/06_07/08_27/u_files_store_3_344867.jpg"
    title="Introduction to Algorithms"
    state="Pristatyta"
    esttime="2022-11-08"
    user="Pardavėjas 2"
  >
    Pristatymo data:
  </AdminDelivery>
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

.grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
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
