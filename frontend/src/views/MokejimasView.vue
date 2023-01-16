<script setup>
import { store } from "../store.ts";
import { storeVad } from "../storeVad.ts";
import router from "../router.ts";
import Modal from "../components/common/Modal.vue";
</script>
<script>
import axios from "axios";

export default {
  data() {
    return {
      storeVad,
      store,
      modal_state: false,

      
      id_current: 0,
      id_buyer: 0,
      id_order: 0,

      vardas: "",
      pavarde: "",
      miestas: "",
      adresas: "",
      pasto_kodas: 0,
      metodas: "",
    };
  },
  mounted() {
    /*Axios.get("https://localhost:7293/api/VartotojoVadoveliai").then(
        (resp) => (this.userVadov = resp.data)
    );

    Axios.get("https://localhost:7293/api/Vadovelis").then(
        (resp) => (this.allVadov = resp.data)
    );*/
  },
  methods:{
    async buyBook(){
      //console.log(store.userinfo); https://localhost:7293/api/Pirkejas
      if(store.userinfo.usertype === 0){
        const response1 = await axios.post('https://localhost:7293/api/Vartotojas', {
          vardas: this.vardas,
          pavarde: this.pavarde,
          miestas: this.miestas,
          adresas: this.adresas,
          el_pastas: "",
          pasto_kodas: this.pasto_kodas,
          slapyvardis: "",
          slaptazodis: "",
          vartotojo_ivertinimas: 0
        });
        //console.log(response1);
        const responce = await axios.get('https://localhost:7293/api/Vartotojas');
        responce.data.forEach(user => {

          if (user.adresas === this.vardas && user.pasto_kodas === this.pasto_kodas) {
          this.id_current = user.id;
          }
        });
        //console.log(this.id_current);
      }else{
        this.id_current = store.userinfo.id;
      }
      const buyerRes = await axios.post('https://localhost:7293/api/Pirkejas', {
          mokejimo_metodas: this.metodas,
          fk_vartotojas: this.id_current
      });
      //console.log(buyerRes);

      const buyerGetRes = await axios.get('https://localhost:7293/api/Pirkejas');
      buyerGetRes.data.forEach(buyer => {
        if (buyer.fk_vartotojas === this.id_current) {
        this.id_buyer = buyer.id;
        }
      });
      //console.log(this.id_buyer);

      const orderRes = await axios.post('https://localhost:7293/api/Uzsakymas', {
          data: new Date(),
          fk_pirkejas: this.id_buyer
      });
      //console.log(orderRes);

      const orderGetRes = await axios.get('https://localhost:7293/api/Uzsakymas');
      orderGetRes.data.forEach(order => {
        if (order.fk_pirkejas === this.id_buyer) {
        this.id_order = order.id;
        }
      });
      //console.log(this.id_order);

      const rezRes = await axios.post('https://localhost:7293/api/Rezervacija', {
          pradzia: new Date(),
          pabaiga: new Date(),
          fk_pirkejas: this.id_buyer,
          fk_pardavejas: this.storeVad.vadinfo.id_par,
      });
      //console.log(rezRes);
      //console.log(storeVad.vadinfo.id_user)
      //console.log(storeVad.vadinfo.id_all)
      const rezVad = await axios.put('https://localhost:7293/api/VartotojoVadoveliai', {
        id: storeVad.vadinfo.id_user,
        kaina: storeVad.vadinfo.price,
        bukle: storeVad.vadinfo.state,
        fk_pardavejas: storeVad.vadinfo.id_par,
        fk_vadovelis: storeVad.vadinfo.id_all,
        fk_uzsakymas: this.id_order
      });
      //console.log(rezRes);
      this.modal_state = true;
    },
  }
};
</script>


<template>
  <h1>Mokėjimas</h1>
  <div class="panel">

    <h2>Knyga: {{ storeVad.vadinfo.name }}</h2>
    <h2>Kaina: {{ storeVad.vadinfo.price }}€</h2>
    <h2>Būklė: {{ storeVad.vadinfo.state }}</h2>
    <h2>ISBN: {{ storeVad.vadinfo.isbn }}</h2>
    <h4>Leidėjas: {{ storeVad.vadinfo.publisher }}</h4>
    <h4>Puslapių skaičius: {{ storeVad.vadinfo.pages }}</h4>
    <h4>Metai: {{ storeVad.vadinfo.year }}</h4>
    <h4>Kalba: {{ storeVad.vadinfo.language }}</h4>
    <h4>Aprašymas: {{ storeVad.vadinfo.description }}</h4>
  </div>
  <form @submit.prevent="buyBook">
  <div class="panel">
      <h1>Pirkimo duomenys</h1>
      <div class="frame">
        <div class="inline">
          <label for="vardas">Vardas:</label>
          <input
            class="entry"
            type="text" 
            name="vardas"
            v-model="vardas"
            required
          />
        </div>

        <div class="inline">
          <label for="pavarde">Pavardė:</label>
          <input
            class="entry"
            type="text"
            name="pavarde"
            v-model="pavarde"
            required
          />
        </div>

        <div class="inline">
          <label for="miestas">Miestas:</label>
          <input
            class="entry"
            type="text"
            name="miestas"
            v-model="miestas"
            required
          />
        </div>

        <div class="inline">
          <label for="adresas">Adresas:</label>
          <input
            class="entry"
            type="text"
            name="adresas"
            v-model="adresas"
            required
          />
        </div>

        <div class="inline">
          <label for="pasto_kodas">Pašto kodas:</label>
          <input
            class="entry"
            type="number"
            name="pasto_kodas"
            v-model="pasto_kodas"
            required
          />
        </div>

        <div class="inline">
          <label for="metodas">Mokėjimo metodas:</label>
          <input
            class="entry"
            type="text"
            name="metodas"
            v-model="metodas"
            required
          />
        </div>
      </div>

      <button type="submit">Užsakyti</button>
    </div>
    </form>
    <Modal :state="modal_state" @close="modal_state = false">
              <h1>Sėkmingai užsakyta!!</h1>
              <button @click="$router.push('/')">Gryžti į meniu</button>
    </Modal>
</template>


<style scoped>
.inline {
  display: flex;
  flex-direction: row;
  font-size: 1.5rem;
  margin: 0.5rem 0;
}

.frame {
  padding: 1rem;
  display: flex;
  flex-direction: column;
  margin: auto;
  width: 80%;
  height: fit-content;

  background-color: var(--color-background-soft);

  border-color: var(--color-border);
  border-width: 1px;
  border-radius: 7px;
  border-style: solid;
}

.entry {
  display: flex;
  background: var(--color-background);
  font-size: 1.5rem;
  color: var(--color-text);
  border-color: var(--color-border);
  border-width: 1px;
  border-radius: 8px;
  border-style: solid;
  flex-grow: 1;
  margin-left: 0.5rem;
}
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