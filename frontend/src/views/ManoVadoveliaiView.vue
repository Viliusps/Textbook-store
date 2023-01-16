<script setup>
import Modal from "../components/common/Modal.vue";
import router from "../router.ts";
</script>
<script>
import Axios from "axios";
import { store } from "@/store";

export default {
  data() {
    return {
      modal_state: false,
      modal_state2: false,
      tempUserVadov: [],
      userVadov: [],
      editUserVadov: null,
      editVadov: null,
      vadov: null,
      pardavejasId: null,
      oneVadov: null,
      allVadov: null,
      info: [],
      pop: [],
      popOne: null,
      form: {
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
    console.log(localStorage.getItem('usertype'));
    if(parseInt(localStorage.getItem('usertype')) !== 1 && parseInt(localStorage.getItem('usertype')) !== 2)
    {
      router.router.push('/');
    }

    if(parseInt(store.userinfo.usertype)===2) {
      await Axios.get("https://localhost:7293/api/VartotojoVadoveliai").then(
          (resp) => (this.userVadov = resp.data)
      );
    } else {
      const pardavejai = await Axios.get("https://localhost:7293/api/Pardavejas");
      for(let i = 0; i<pardavejai.data.length; i++) {
        if(parseInt(store.userinfo.id)===pardavejai.data[i].fk_vartotojas) {
          this.pardavejasId= pardavejai.data[i].id;
          break;
        }
      }
      await Axios.get("https://localhost:7293/api/VartotojoVadoveliai").then(
          (resp) => (this.tempUserVadov = resp.data)
      );
      this.tempUserVadov.forEach((item)=>{
        if(item.fk_pardavejas===this.pardavejasId)
          this.userVadov.push(item);
      });
    }

    Axios.get("https://localhost:7293/api/Vadovelis").then(
        (resp) => (this.allVadov = resp.data)
    );



  },
  methods: {
    async changeData() {
      const resp = await Axios.put("https://localhost:7293/api/VartotojoVadoveliai", {
        id: this.editUserVadov.id,
        kaina: this.editUserVadov.kaina,
        bukle: this.editUserVadov.bukle,
        fk_pardavejas: this.editUserVadov.fk_pardavejas,
        fk_vadovelis: this.editUserVadov.fk_vadovelis,
        fk_uzsakymas: this.editUserVadov.fk_uzsakymas,
      }).catch((error) => {
        console.log(error);
      });

      for(let i=0; i<this.userVadov.length; i++) {
        if(this.userVadov[i].id===resp.data[resp.data.length-1].id) {
          this.userVadov[i].kaina=resp.data[resp.data.length-1].kaina;
          this.userVadov[i].bukle=resp.data[resp.data.length-1].bukle;
          this.userVadov[i].fk_pardavejas=resp.data[resp.data.length-1].fk_pardavejas;
          this.userVadov[i].fk_vadovelis=resp.data[resp.data.length-1].fk_vadovelis;
          this.userVadov[i].fk_uzsakymas=resp.data[resp.data.length-1].fk_uzsakymas;
        }
      }

      const resp2 = await Axios.put("https://localhost:7293/api/Vadovelis", {
        id: this.oneVadov.id,
        pavadinimas: this.oneVadov.pavadinimas,
        puslapiu_skaicius: this.oneVadov.puslapiu_skaicius,
        isbn: this.oneVadov.isbn,
        fk_populiarumas: this.oneVadov.fk_populiarumas,
        aprasymas: this.oneVadov.aprasymas,
        leidejas: this.oneVadov.leidejas,
        metai: this.oneVadov.metai,
        kalba: this.oneVadov.kalba
      }).catch((error) => {
        console.log(error);
      });

      for(let i=0; i<this.allVadov.length; i++) {
        if(this.allVadov[i].id===resp2.data[resp2.data.length-1].id) {
          this.allVadov[i].pavadinimas=resp2.data[resp2.data.length-1].pavadinimas;
          this.allVadov[i].puslapiu_skaicius=resp2.data[resp2.data.length-1].puslapiu_skaicius;
          this.allVadov[i].isbn=resp2.data[resp2.data.length-1].isbn;
          this.allVadov[i].fk_populiarumas=resp2.data[resp2.data.length-1].fk_populiarumas;
          this.allVadov[i].aprasymas=resp2.data[resp2.data.length-1].aprasymas;
          this.allVadov[i].leidejas=resp2.data[resp2.data.length-1].leidejas;
          this.allVadov[i].metai=resp2.data[resp2.data.length-1].metai;
          this.allVadov[i].kalba=resp2.data[resp2.data.length-1].kalba;
        }
      }

    },

    deleteData(id) {
      Axios.delete("https://localhost:7293/api/VartotojoVadoveliai/" + id).then(
          (resp) => (this.info = resp.data)
      );
      for(let i=0; i<this.userVadov.length; i++) {
        if(this.userVadov[i].id==id) {
          this.userVadov.splice(i,1);
          break;
        }
      }
    },

    async saveData() {
      await Axios.get("https://localhost:7293/api/Populiarumas").then(
          (resp) => (this.pop=resp.data)
      );

      const resp1 = await Axios.post("https://localhost:7293/api/Vadovelis", {
        pavadinimas: this.form.pavadinimas,
        puslapiu_skaicius: this.form.pslSkaicius,
        isbn: this.form.isbn,
        aprasymas: this.form.aprasymas,
        leidejas: this.form.leidejas,
        metai: this.form.metai,
        kalba: this.form.kalba,
        fk_populiarumas: 1
      }).catch((error) => {
        console.log(error);
      });

      const pardavejai = await Axios.get("https://localhost:7293/api/Pardavejas");
      for(let i = 0; i<pardavejai.data.length; i++) {
        if(parseInt(store.userinfo.id)===pardavejai.data[i].fk_vartotojas) {
          this.pardavejasId= pardavejai.data[i].id;
          break;
        }
      }
      const resp2 = await Axios.post("https://localhost:7293/api/VartotojoVadoveliai", {
        kaina: this.form.kaina,
        bukle: this.form.bukle,
        fk_pardavejas: this.pardavejasId,
        fk_vadovelis: resp1.data[resp1.data.length-1].id,
        fk_uzsakymas: 0
      }).catch((error) => {
        console.log(error);
      });
    }
  },
};
</script>
<template>
  <template v-if="store.userinfo.usertype===1">
  <h1>Mano parduodamų vadovėlių sąrašas</h1>
  <button @click="router.router.push('/naujas-vadovelis')">
    Pridėti naują
  </button>
  </template>
  <h1 v-else>Visi parduodami vadovėliai</h1>
  <table class="styled-table" v-if="this.userVadov.length!=0">
    <thead>
      <tr>
        <th>Pavadinimas</th>
        <th>Bukle</th>
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
      <td>{{vadovelis.kaina}}€</td>
      <td>{{visiVadoveliai.isbn}}</td>
      <td>
        <button @click="(modal_state = true), (this.editUserVadov = { ...vadovelis }), (this.oneVadov = { ...visiVadoveliai })">
          Peržiūrėti
        </button>
        <Modal :state="modal_state" @close="modal_state = false">
          <h1>Pavadinimas: {{oneVadov.pavadinimas}}</h1>
          <h2>Kaina: {{editUserVadov.kaina}}€</h2>
          <h2>Būklė: {{editUserVadov.bukle}}</h2>
          <h2>ISBN: {{oneVadov.isbn}}</h2>
          <h4>Leidėjas: {{oneVadov.leidejas}}</h4>
          <h4>Puslapių skaičius: {{oneVadov.puslapiu_skaicius}}</h4>
          <h4>Metai: {{oneVadov.metai}}</h4>
          <h4>Kalba: {{oneVadov.kalba}}</h4>
          <h4>Aprašymas: {{oneVadov.aprasymas}}</h4>
          <button @click="modal_state = false">Uždaryti</button>
        </Modal>
        <button @click="(modal_state2 = true), (this.editUserVadov = { ...vadovelis }), (this.oneVadov = { ...visiVadoveliai })">
          Keisti
        </button>
        <Modal :state="modal_state2" @close="modal_state2 = false">
          <h1>Atlikite norimus pakeitimus</h1>
          <form>
            <p>Pavadinimas:</p>
            <input type="text" v-model="oneVadov.pavadinimas" required/> <br/>
            <p>Kaina:</p>
            <input type="number" v-model="editUserVadov.kaina" required/> <br/>
            <p>Būklė:</p>
            <select required v-model="editUserVadov.bukle">
              <option>Nauja</option>
              <option>Naudota</option>
            </select>
            <p>ISBN:</p>
            <input type="text" v-model="oneVadov.isbn" required/> <br/>
            <p>Leidėjas:</p>
            <input type="text" v-model="oneVadov.leidejas" required/> <br/>
            <p>Puslapių skaičius:</p>
            <input type="number" v-model="oneVadov.puslapiu_skaicius" required/> <br/>
            <p>Metai:</p>
            <input type="number"  v-model="oneVadov.metai" required/> <br/>
            <p>Kalba:</p>
            <input type="text" v-model="oneVadov.kalba" required/> <br/>
            <p>Aprašymas:</p>
            <input type="text" v-model="oneVadov.aprasymas" required/> <br/>
          </form>
          <br /><button
            type="button"
            @click="changeData(), (modal_state2 = false)"
        >
          Saugoti
        </button>
          <button @click="modal_state2 = false">Uždaryti</button>
        </Modal>
        <button @click="deleteData(vadovelis.id)">Šalinti</button>
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