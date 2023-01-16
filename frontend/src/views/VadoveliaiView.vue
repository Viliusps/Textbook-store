<script setup>
import { store } from "@/store";
import { storeVad } from "../storeVad.ts";
import router from "../router.ts";
import Modal from "../components/common/Modal.vue";
</script>
<script>
import Axios from "axios";

export default {
  data() {
    return {
      storeVad,
      modal_state: false,
      modal_route: false,
      userVadov: [],
      allVadov: [],
      oneVadov: null,
      oneVadov2: null,
      vadov: null,
      form: [],
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
      },

      id_all: 0,
      id_user: 0,

      id_pop: 0,
      id_par: 0,
      id_uz: 0,

      name: "",
      price: 0,
      state: "",
      isbn: "",
      publisher: "",
      pages: 0,
      year: 0,
      language: "",
      description: "",
      vartotojas: "",
      pardavejas: "",
      ivertinimas: [],
      pasirinkimas: ""
    };
  },
  mounted() {
    Axios.get("https://localhost:7293/api/VartotojoVadoveliai").then(
        (resp) => (this.userVadov = resp.data)
    );

    Axios.get("https://localhost:7293/api/Vadovelis").then(
        (resp) => (this.allVadov = resp.data)
    );
    Axios.get("https://localhost:7293/api/Pardavejas").then(
        (resp) => (this.pardavejas = resp.data)
    );
    Axios.get("https://localhost:7293/api/Vartotojas").then(
        (resp) => (this.vartotojas = resp.data)
    );
  },
  methods:{
    payment(Vadov, Vadov2){
      this.storeVad.setVad(Vadov2.id, Vadov.id, Vadov2.fk_populiarumas, Vadov.fk_pardavejas, Vadov.fk_uzsakymas,
      Vadov2.pavadinimas, Vadov.kaina, Vadov.bukle, Vadov2.isbn, Vadov2.leidejas, Vadov2.puslapiu_skaicius, Vadov2.metai, Vadov2.kalba, Vadov2.aprasymas);
      //console.log(this.storeVad.vadinfo);
      this.id_all = localStorage.setItem('id_all', Vadov2.id);
      this.id_user = localStorage.setItem('id_user', Vadov.id);
      this.id_pop = localStorage.setItem('id_pop', Vadov2.fk_populiarumas);
      this.id_par = localStorage.setItem('id_par', Vadov.fk_pardavejas);
      this.id_uz = localStorage.setItem('id_uz', Vadov.fk_uzsakymas);

      this.name = localStorage.setItem('name', Vadov2.pavadinimas);
      this.price = localStorage.setItem('price', Vadov.kaina);
      this.state = localStorage.setItem('state', Vadov.bukle);
      this.isbn = localStorage.setItem('isbn', Vadov2.isbn);
      this.publisher = localStorage.setItem('publisher', Vadov2.leidejas);
      this.pages = localStorage.setItem('pages', Vadov2.puslapiu_skaicius);
      this.year = localStorage.setItem('year', Vadov2.metai);
      this.language = localStorage.setItem('language', Vadov2.kalba);
      this.description = localStorage.setItem('description', Vadov2.aprasymas);
      
      router.router.push('/mokejimas');
    },
    rate(id, vadovelioId)
    {
      var tempid = -1;
        for(var i of this.pardavejas)
        {
          if(i.id === id)
          {
            tempid = i.fk_vartotojas;
          }
        }
        var tempuser = "";
        for(var i of this.vartotojas)
        {
          if(i.id === tempid)
          {
            tempuser = i;
          }
        }
        if(this.ivertinimas[vadovelioId]!==undefined) {
          tempuser.vartotojo_ivertinimas = tempuser.vartotojo_ivertinimas + this.ivertinimas[vadovelioId];
          const resp = Axios.put("https://localhost:7293/api/Vartotojas", {
            id: tempuser.id,
            vardas: tempuser.vardas,
            pavarde: tempuser.pavarde,
            miestas: tempuser.miestas,
            adresas: tempuser.adresas,
            el_pastas: tempuser.el_pastas,
            pasto_kodas: tempuser.pasto_kodas,
            slapyvardis: tempuser.slapyvardis,
            slaptazodis: tempuser.slaptazodis,
            vartotojo_ivertinimas: tempuser.vartotojo_ivertinimas,
          }).catch((error) => {
            console.log(error);
          });
        }
    }
  }
};
</script>

<template>
  <header>
    <h1>Vadovėliai</h1>
  </header>
  <table class="styled-table" v-if="this.userVadov.length!=0">
    <thead>
      <tr>
          <th>Pavadinimas</th>
          <th>Būkle</th>
          <th>Kaina</th>
          <th>ISBN</th>
          <th>Veiksmai</th>
      </tr>
    </thead>
    <tbody>
    <tr v-for="vadovelis in userVadov" :key="vadovelis.id">
      <template v-for="visiVadoveliai in allVadov" :key="visiVadoveliai.id">
        <template v-if="vadovelis.fk_vadovelis===visiVadoveliai.id">
          <td>{{visiVadoveliai.pavadinimas}}</td>
          <td>{{vadovelis.bukle}}</td>
          <td>{{vadovelis.kaina}}</td>
          <td>{{visiVadoveliai.isbn}}</td>
          <td>
            <button @click="(modal_state = true), (this.oneVadov = { ...vadovelis }), (this.oneVadov2 = { ...visiVadoveliai })">
              Peržiūrėti
            </button>
            <Modal :state="modal_state" @close="modal_state = false">
              <h1>Pavadinimas: {{oneVadov2.pavadinimas}}</h1>
              <h2>Kaina: {{oneVadov.kaina}}€</h2>
              <h2>Būklė: {{oneVadov.bukle}}</h2>
              <h2>ISBN: {{oneVadov2.isbn}}</h2>
              <h4>Leidėjas: {{oneVadov2.leidejas}}</h4>
              <h4>Puslapių skaičius: {{oneVadov2.puslapiu_skaicius}}</h4>
              <h4>Metai: {{oneVadov2.metai}}</h4>
              <h4>Kalba: {{oneVadov2.kalba}}</h4>
              <h4>Aprašymas: {{oneVadov2.aprasymas}}</h4>
              <button @click="modal_state = false">Uždaryti</button>
              <template v-if="store.userinfo.usertype===1 || store.userinfo.usertype===0">
              <button @click="payment(oneVadov, oneVadov2)">Pirkti</button>
              </template>
            </Modal>
            <template v-if="store.userinfo.usertype===1 || store.userinfo.usertype===0">
            <button @click="payment(vadovelis, visiVadoveliai)">Pirkti</button>
            </template>
            <label>Pardavėjo įvertinimas: </label>
            <v-select v-model="this.pasirinkimas" :options="['5','4']" />
            <select :key="vadovelis.id" v-model="this.ivertinimas[vadovelis.id]" id="ivertinimas">
              <option>5</option>
              <option>4</option>
              <option>3</option>
              <option>2</option>
              <option>1</option>
            </select>
            <button @click="rate(vadovelis.fk_pardavejas, vadovelis.id)">Įvertinti</button>
          </td>
        </template>
      </template>
    </tr>
    </tbody>
  </table>
  <h2 v-else>Sąrašas tuščias!</h2>
</template>

<style scoped>
header {
  display: flex;
  justify-content: space-evenly;
  width: 100%;
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
