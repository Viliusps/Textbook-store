<template>
  <div class="information">
    <router-link to="/login">Prisijunkite</router-link>
    norėdami pamatyti savo siuntinio statusą. Arba įveskite savo siuntinio kodą
    apačioje.
  </div>
  <div class="search">
    <p>Siuntos kodo paieška:</p>
    <input class="searchbar" v-model="text" />
  </div>
</template>

<style scoped>
.search {
  padding: 1rem;
  display: flex;
  justify-content: flex-end;
  width: fit-content;
  font-size: 1.2rem;
  border-color: var(--color-border);
  background: var(--color-background-soft);
  border-width: 1px;
  border-style: solid;
  border-radius: 8px;
}

.searchbar {
  background: var(--color-background);
  font-size: 1.2rem;
  padding: 0 1rem;
  margin-left: 0.5rem;
  color: var(--color-text);
  border-color: var(--color-border);
  border-width: 1px;
  border-radius: 8px;
  border-style: solid;
}

.information {
  font-size: 1.5rem;
  width: 80%;
  text-align: center;
  margin-bottom: 2rem;
}
</style>
