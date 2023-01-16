<script setup>
import ItemGrid from "../components/book_grid/ItemGrid.vue";
import Item from "../components/book_grid/BookItem.vue";
import router from "../router.ts";
import Modal from "../components/common/Modal.vue";
</script>

<script>
import Axios from "axios";
import {store} from "../store.ts";
export default {
  data() {
    return {
      modal_state: false,
      modal_route: false,
      userVadov: [],
      pop: [],
      allVadov: [],
      oneVadov: null,
      oneVadov2: null,
      vadov: null,
      form: [],
      info: [],
      form1: {
        pavadinimas: '',
        kaina: '',
        bukle: '',
        isbn: '',
        leidejas: '',
        pslSkaicius: '',
        metai: '',
        kalba: '',
        aprasymas: ''
      }
    };
  },
  async mounted() {
    await Axios.get("https://localhost:7293/api/VartotojoVadoveliai").then(
        (resp) => (this.userVadov = resp.data)
    );

    await Axios.get("https://localhost:7293/api/Vadovelis").then(
        (resp) => (this.allVadov = resp.data)
    );

    await Axios.get("https://localhost:7293/api/Populiarumas").then(
        (resp) => (this.pop=resp.data)
    );
    this.pop.sort((a,b)=> (a.pop_skaicius<b.pop_skaicius)?1:-1);

    let count=0;
    for(let i=0; i<this.pop.length; i++) {
      for(let j=0;j<this.allVadov.length; j++) {
        if(this.pop[i].isbn===this.allVadov[j].isbn && count<3) {
          this.info.push(this.allVadov[j]);
          count++;
          break;
        }
      }
    }
  },
};
</script>

<template>
  <header>
    <h1>Populiariausi vadovėliai</h1>
  </header>
  <table class="styled-table" v-if="this.userVadov.length!=0">
    <thead>
    <tr>
      <th>Pavadinimas</th>
      <th>Leidėjas</th>
      <th>Metai</th>
      <th>ISBN</th>
      <th>Veiksmai</th>
    </tr>
    </thead>
    <tbody>
    <tr v-for="vadovelis in this.info" :key="vadovelis.id">
      <td>{{vadovelis.pavadinimas}}</td>
      <td>{{vadovelis.leidejas}}</td>
      <td>{{vadovelis.metai}}</td>
      <td>{{vadovelis.isbn}}</td>
      <td>
        <button @click="(modal_state = true), (this.oneVadov = { ...vadovelis })">
          Peržiūrėti
        </button>
        <Modal :state="modal_state" @close="modal_state = false">
          <h1>Pavadinimas: {{oneVadov.pavadinimas}}</h1>
          <h2>ISBN: {{oneVadov.isbn}}</h2>
          <h4>Leidėjas: {{oneVadov.leidejas}}</h4>
          <h4>Puslapių skaičius: {{oneVadov.puslapiu_skaicius}}</h4>
          <h4>Metai: {{oneVadov.metai}}</h4>
          <h4>Kalba: {{oneVadov.kalba}}</h4>
          <h4>Aprašymas: {{oneVadov.aprasymas}}</h4>
          <button @click="modal_state = false">Uždaryti</button>
        </Modal>
      </td>
    </tr>
    </tbody>
  </table>
  <h2 v-else>Sąrašas tuščias!</h2>
</template>

<style scoped>
header {
  margin: 0;
  font-size: 1.5rem;
  line-height: 1.5;
}
button {
  height: fit-content;
  width: fit-content;
  color: var(--color-heading);
  font-size: 1rem;
  line-height: 1.5;
  margin: auto 2rem;
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

.styled-table {
  border-collapse: collapse;
  margin: 25px 0;
  font-size: 0.9em;
  font-family: sans-serif;
  min-width: 400px;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
}

.styled-table thead tr {
  background-color: #009879;
  color: #ffffff;
  text-align: left;
}

.styled-table th,
.styled-table td {
  padding: 12px 15px;
}

.styled-table tbody tr {
  border-bottom: 1px solid #dddddd;
}

.styled-table tbody tr:nth-of-type(even) {
  #background-color: #f3f3f3;
}

.styled-table tbody tr:last-of-type {
  border-bottom: 2px solid #009879;
}
</style>
