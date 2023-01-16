<script setup>
import Message from "../components/book_view/SingleMessage.vue";
import Modal from "../components/common/Modal.vue";

import { store } from "../store.ts";
import { storeMessage } from "../storeMessage.ts";
import router from "../router.ts";
import axios from "axios";
</script>

<script>
export default {
  data() {
    return { 
      responce: "",
      modal: false
     };
  },
};
</script>

<template>
  <h1>Gautų žinučių peržiūra</h1>
  <Message />
  <!--

  <button @click="modal = !modal">Atsakyti</button>
  <Modal :state="modal" @close="modal = !modal">
    <form>
      <input class="entry" type="text" name="responce" v-model="responce" required />
      Atsakymo rašymas<button>Siųsti</button>
    </form>
  </Modal>
  -->
</template>
