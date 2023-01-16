<script setup>
import Seller from "../components/book_view/SellerInfo.vue";
</script>
<script>
import { store } from "../store.ts";
export default {
  data() {
    return { store: store };
  },
};
</script>

<template>
  <h1>Vartotojo apžvalga</h1>
  <div class="overview">
    <Seller />
    Pateikiama vartotojo apžvalga
  </div>
  <div v-if="parseInt(store.userinfo.usertype) === 1" class="kvitai">
    <router-link to="/kvitai">
      Nuoroda pirkimų istorijai ir kvitams peržiūrėti
    </router-link>
  </div>
</template>
