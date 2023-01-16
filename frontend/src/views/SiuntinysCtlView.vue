<script setup>
import router from "../router.ts";
import Modal from "../components/common/Modal.vue";
</script>
<script>
export default {
  data() {
    return { modal_state: false, modal_route: false };
  },
};
</script>

<template>
  <h1>Siuntinio valdymas</h1>
  Čia rodoma detali siuntinio informacija ir keliautinas maršrutas
  <button>Atšaukti siuntą</button>
  <button @click="modal_state = !modal_state">Keisti būseną</button>
  <Modal :state="modal_state" @close="modal_state = !modal_state">
    Būsenos keitimas
  </Modal>
  <button @click="modal_route = !modal_route">Keisti maršrutą</button>
  <Modal :state="modal_route" @close="modal_route = !modal_route">
    Maršruto keitimas
  </Modal>
  <button @click="router.router.push('/klientu-informavimas')">
    Siųsti pranešimą klientui
  </button>
</template>

<style scoped>
button {
  margin: 0.5rem;
  font-size: 1rem;
}
</style>
