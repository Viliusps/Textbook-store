<template>
  <div class="search">
    <button>Filtras</button>
    <button>Rikiavimas</button>
    <p>Paieška:</p>
    <input class="searchbar" v-model="text" />
  </div>
</template>

<style scoped>
.search {
  padding: 1rem;
  display: flex;
  justify-content: flex-end;
  width: 100%;
  position: sticky;
  top: 4.5rem;
  z-index: 3;

  box-shadow: 0 0.5rem 4px var(--color-background),
    0 -0.5rem 4px var(--color-background);

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
  color: var(--color-text);
  border-color: var(--color-border);
  border-width: 1px;
  border-radius: 8px;
  border-style: solid;
}

button {
  font-size: 1.2rem;
  margin: 0 0.3rem;
  color: var(--color-text);
}

p {
  flex-grow: 1;
  text-align: right;
  margin: 0 0.5rem;
}
</style>
