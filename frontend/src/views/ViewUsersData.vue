<script setup>
import UserData from "../components/admin/UserDataComp.vue";
</script>

<template>
  <UserData />
</template>

<style scoped>
button {
  margin: 0.5rem;
  font-size: 1rem;
}
header {
  margin: 0;
  font-size: 1.5rem;
  line-height: 1.5;
}

h1 {
  color: var(--color-heading);
  flex-grow: 1;
  text-align: center;
}
table,
th,
td {
  border: 1px solid black;
  border-collapse: collapse;
}
.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    margin-top: 2rem;
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}
</style>
