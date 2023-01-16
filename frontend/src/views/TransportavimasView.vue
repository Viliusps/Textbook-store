<script setup>
import Delivery from "../components/deliveries/Delivery.vue";
</script>

<template>
  <h1>Pagrindinis puslapis</h1>
  <h3>Dabar pristatoma:</h3>
  <Delivery
    state="pristatoma"
    title="Camera Lucida"
    img="https://d.gr-assets.com/books/1312018081l/497164.jpg"
  />
  <button>Pristatyta</button>
  <h3>Žemėlapis:</h3>
  <img src="https://www.weather-forecast.com/locationmaps/Kaunas.8.gif" />
</template>

<style scoped>
h1,
h3 {
  color: var(--color-heading);
}

h1 {
  font-size: 2.5rem;
}

h3 {
  font-size: 1.5rem;
}

button {
  font-size: 1.5rem;
  margin-bottom: 2rem;
}

img {
  border-radius: 8px;
  margin-bottom: 1rem;
}
</style>
