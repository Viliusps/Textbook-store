<script>
import Axios from "axios";
import { store } from "@/store";
import router from "../router.ts";
export default {
  data() {
    return {
      pop: [],
      popOne: null,
      form: {
        pavadinimas: '',
        kaina: '',
        bukle: 'Nauja',
        isbn: '',
        leidejas: '',
        pslSkaicius: '',
        metai: '',
        kalba: '',
        aprasymas: ''
      }
    };
  },
  methods: {
    async saveData() {
      const response = await Axios.get("https://localhost:7293/api/Populiarumas").then(
          (resp) => (this.pop=resp.data)
      );
      let count=1;
      let flag=false;
      let id=0;
      console.log(response[0]);
      for (let i=0; i<response.length; i++) {
        if(response[i].isbn===this.form.isbn) {
          id=response[i].id;
          count=response[i].pop_skaicius+1;
          flag=true;
          break;
        }
      }
      if(!flag) {
        const response = await Axios.post("https://localhost:7293/api/Populiarumas", {
          pop_skaicius: 1,
          isbn: this.form.isbn
        }).catch((error) => {
          console.log(error);
        });
        id=response.data[response.data.length-1].id;
      } else {
        await Axios.put("https://localhost:7293/api/Populiarumas", {
          id: id,
          pop_skaicius: count,
          isbn: this.form.isbn
        }).catch((error) => {
          console.log(error);
        });
      }


      const resp1 = await Axios.post("https://localhost:7293/api/Vadovelis", {
        pavadinimas: this.form.pavadinimas,
        puslapiu_skaicius: this.form.pslSkaicius,
        isbn: this.form.isbn,
        aprasymas: this.form.aprasymas,
        leidejas: this.form.leidejas,
        metai: this.form.metai,
        kalba: this.form.kalba,
        fk_populiarumas: id
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

      this.$router.push("/mano-vadoveliai");
    }
  },
  mounted() {
    if(parseInt(localStorage.getItem('usertype')) !== 1)
    {
      router.router.push('/');
    }
  }
};
</script>

<template>
  <h1>Naujo vadovėlio pridėjimo forma</h1>
  <h2>Įveskite duomenis</h2>
  <form>
    <p>Pavadinimas:</p>
    <input v-model="form.pavadinimas" type="text" required/> <br/>
    <p>Kaina:</p>
    <input v-model="form.kaina" type="number" required/> <br/>
    <p>Būklė:</p>
    <select v-model="form.bukle" required>
      <option>Nauja</option>
      <option>Naudota</option>
    </select>
    <p>ISBN:</p>
    <input v-model="form.isbn" type="text" required/> <br/>
    <p>Leidėjas:</p>
    <input v-model="form.leidejas" type="text" required/> <br/>
    <p>Puslapių skaičius:</p>
    <input v-model="form.pslSkaicius" type="number" required/> <br/>
    <p>Metai:</p>
    <input v-model="form.metai" type="number" required/> <br/>
    <p>Kalba:</p>
    <input v-model="form.kalba" type="text" required/> <br/>
    <p>Aprašymas:</p>
    <input v-model="form.aprasymas" type="text" required/> <br/> <br/>
    <button type="button" @click="saveData()">Saugoti</button>
  </form>
</template>
