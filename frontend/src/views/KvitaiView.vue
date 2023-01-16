<script setup>
import Delivery from "../components/deliveries/Delivery.vue";
</script>

<template>
  <h1>Mokėjimų istorija</h1>
  <div class="payment">
    <Delivery title="Vadovėlio pavadinimas" />
    <router-link to="/grazinimas/1">Gražinti knygą</router-link>
  </div>
  <div class="payment">
    <Delivery title="Vadovėlio pavadinimas" />
    <router-link to="/grazinimas/2">Gražinti knygą</router-link>
  </div>
  <div class="payment">
    <Delivery title="Vadovėlio pavadinimas" />
    <router-link to="/grazinimas/3">Gražinti knygą</router-link>
  </div>
</template>
