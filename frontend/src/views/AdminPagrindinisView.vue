<script setup>
import router from "../router.ts";
import Modal from "../components/common/Modal.vue";
import Comment from "../components/book_view/SingleComment.vue";
</script>
<script>
export default {
  data() {
    return { modal_msg: false };
  },
};
</script>

<template>
  <h1>Pagrindinis puslapis</h1>
  <div class="main">
    <h3>5 nauji pranešti komentarai</h3>
    <Comment @click="modal_msg = !modal_msg" class="msg" />
    <Comment @click="modal_msg = !modal_msg" class="msg" />
    <Comment @click="modal_msg = !modal_msg" class="msg" />
    <Comment @click="modal_msg = !modal_msg" class="msg" />
    <Comment @click="modal_msg = !modal_msg" class="msg" />
  </div>
  <Modal :state="modal_msg" @close="modal_msg = !modal_msg">
    Išsami informacija apie komentarą ir pasirinkimai nuobaudoms komentatoriui
    arba pranešėjui.
  </Modal>
</template>

<style scoped>
h1,
h3 {
  color: var(--color-heading);
}

.main {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 800px;
}

.main * {
  margin: 1rem;
}
</style>
