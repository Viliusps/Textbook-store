<script setup>
import Comment from "../components/book_view/SingleComment.vue";
import Seller from "../components/book_view/SellerInfo.vue";
</script>

<template>
  <h1>Vertinimų peržiūra</h1>
  <div class="overview">
    <Seller />
    Pateikiama išsami informacija apie reitingus, kaip tikslus vidurkis.
  </div>
  <div class="new">
    <h2>Nauji vertinimai</h2>
    <Comment />
    <Comment />
    <Comment />
  </div>
  <div class="old">
    <Comment />
    <Comment />
    <Comment />
    <Comment />
    <Comment />
  </div>
</template>

<style scoped>
.new,
.old {
  margin-top: 2rem;
  display: flex;
  flex-direction: column;
  width: 600px;
  align-items: center;
}

.new {
  border: solid 1px var(--color-border);
  border-radius: 8px;
}

.new *,
.old * {
  margin: 1rem;
}
</style>
