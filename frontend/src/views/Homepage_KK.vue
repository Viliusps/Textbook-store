<script setup lang="ts">
import { store } from "../store.ts";
import Populiariausi from "./PopuliariausiVadoveliaiView.vue";
import Admin from "./AdminPagrindinisView.vue";
import Transportavimas from "./TransportavimasView.vue";
</script>
<script lang="ts">
export default {
  data() {
    return store;
  },
};
</script>

<template>
  <Admin v-if="parseInt(store.userinfo.usertype) === 2" />
  <Transportavimas v-else-if="parseInt(store.userinfo.usertype) === 3" />
  <Populiariausi v-else />
</template>
