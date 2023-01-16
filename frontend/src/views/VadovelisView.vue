<script setup>
import BookInfo from "../components/book_view/BookInfo.vue";
import SellerInfo from "../components/book_view/SellerInfo.vue";
import Comments from "../components/book_view/CommentSection.vue";
</script>

<template>
  <BookInfo
    img="https://balka-book.com/files/2017/06_07/08_27/u_files_store_3_344867.jpg"
    title="Introduction to Algorithms"
  />
  <SellerInfo />
  <Comments />
</template>

<style scoped>
.grid {
  display: grid;
  grid-template-columns: 1fr 3fr;
}

header {
  height: 400px;
  color: var(--color-header);
}

.link {
  font-size: 1.5rem;
}

main {
  display: flex;
  flex-direction: column;

  font-size: 2rem;
  text-align: center;
  color: var(--color-header);
}

@media (min-width: 1024px) {
  main {
    margin: 20% 0;
  }
  header {
    margin: 20% 0;
  }
}
</style>
