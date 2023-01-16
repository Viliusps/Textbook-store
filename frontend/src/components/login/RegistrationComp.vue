<script>
import axios from "axios";

export default {
  /*props: {
    show: Boolean
  }*/
  data() {
    return {
      vardas: "",
      pavarde: "",
      email: "",
      slapyvardis: "",
      slaptazodis: "",
      rslaptazodis: "",
      show: false,
    };
  },
  methods:{
    async handleSubmit(){
        if(this.slaptazodis === this.rslaptazodis){
          const response1 = await axios.post('https://localhost:7293/api/Vartotojas', {
          vardas: this.vardas,
          pavarde: this.pavarde,
          miestas: "",
          adresas: "",
          el_pastas: this.email,
          pasto_kodas: 0,
          slapyvardis: this.slapyvardis,
          slaptazodis: this.slaptazodis,
          vartotojo_ivertinimas: 0
          });
          console.log(response1);
          const response2 = await axios.post('https://localhost:7293/api/Pardavejas',{
          fk_vartotojas: response1.data[response1.data.length-1].id
          });
          console.log(response2);

        this.$router.push('/login');
      }else{
        this.show = true
      }
    },
  },
};
</script>

<template>
  <form @submit.prevent="handleSubmit">
    <div class="panel">
      <h1>Registracija</h1>
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
          <label for="email">El. paštas:</label>
          <input
            class="entry"
            type="text"
            name="email"
            v-model="email"
            required
          />
        </div>
        <div class="inline">
          <label for="slapyvardis">Vartotojo vardas:</label>
          <input
            class="entry"
            type="text"
            name="slapyvardis"
            v-model="slapyvardis"
            required
          />
        </div>
        <div class="inline">
          <label for="slaptazodis">Slaptažodis:</label>
          <input
            class="entry"
            type="password"
            name="slaptazodis"
            v-model="slaptazodis"
            required
          />
        </div>
        <div class="inline">
          <label for="rslaptazodis">Pakartokite:</label>
          <input
            class="entry"
            type="password"
            name="rslaptazodis"
            v-model="rslaptazodis"
            required
          />
        </div>
        <div v-if="show" class="inline">
          <p>*Pakartotas slaptažodis netinka</p>
        </div>
      </div>

      <button type="submit">Registruotis</button>
    </div>
  </form>
</template>

<style scoped>
h1 {
  color: var(--color-heading);
}

button {
  color: var(--color-text);
  font-size: 1.5rem;
}

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
</style>
