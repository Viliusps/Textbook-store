<script setup>
import { store } from "../../store.ts";
import router from "../../router.ts";
</script>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      username: "",
      password: "",
      remember: false,
      user: null,
      isLogin: false,
      rolle: 1,
      show: false
    };
  },
  methods: {

    async handleSubmit() {

      const data = {
        /*
        id: 0,
        vardas: "",
        pavarde: "",
        miestas: "",
        adresas: "",
        el_pastas: "",
        pasto_kodas: 0,
        slapyvardis: this.username,
        slaptazodis: this.password,
        vartotojo_ivertinimas: 0*/
      };

      const responce = await axios.get('https://localhost:7293/api/Vartotojas');
      const admins = await axios.get('https://localhost:7293/api/Administratorius');
      const kurjeriai = await axios.get('https://localhost:7293/api/Kurjeris');
      //console.log(responce.data)
      
      responce.data.forEach((user, index) => {
        if(user.slapyvardis === this.username && user.slaptazodis === this.password){
              this.user = user
              this.isLogin = true

              admins.data.forEach((admin, index) => {
                if(admin.vartotojo_id === this.user.id){
                  this.rolle = 2
                }
              });

              kurjeriai.data.forEach((kurjeris, index) => {

                if(kurjeris.fk_vartotojas === this.user.id){
                  this.rolle = 3
                }
              });
            }
        });
        if(this.isLogin === true){
          store.setUser(this.rolle, this.user.slapyvardis, this.user.id, this.user.vardas, this.user.pavarde, this.user.miestas, this.user.adresas, this.user.pasto_kodas, this.user.slaptazodis, this.user.vartotojo_ivertinimas);
          this.username = localStorage.setItem('username', this.user.slapyvardis);
          this.usertype = localStorage.setItem('usertype', this.rolle);
          this.id = localStorage.setItem('id', this.user.id);
          this.name = localStorage.setItem('name', this.user.vardas);
          this.surname = localStorage.setItem('surname', this.user.pavarde);
          this.city = localStorage.setItem('city', this.user.miestas);
          this.addres = localStorage.setItem('addres', this.user.adresas);
          this.post_code = localStorage.setItem('post_code', this.user.pasto_kodas);
          this.password = localStorage.setItem('password', this.user.slaptazodis);
          this.score = localStorage.setItem('score', this.user.vartotojo_ivertinimas);
          this.$router.push("/");
        }else{
          this.show = true
        }
        
    }
  }
};
</script>

<template>
  <div class="panel">
    <h1>Prisijungimas</h1>
    <form @submit.prevent="handleSubmit">
      <div class="frame">
        <div class="inline">
          <label for="username">Vartotojo vardas:</label>
          <input class="entry" type="text" name="username" v-model="username" required />
        </div>
        <div class="inline">
          <label for="password">Slaptažodis:</label>
          <input class="entry" type="password" name="password" v-model="password" required />
        </div>
        <div class="inline">
          <input type="checkbox" name="remember" />
          <label for="remember">Prisiminti?</label>
        </div>
        <div v-if="show" class="inline">
          <p >*Vartotojo vardas arba slaptažodis neteisingi</p>
        </div>
      </div>
      <button type="submit">Prisijungti</button>
    </form>
    <router-link class="link" to="registration">
      Neturite paskyros? Registruokitės!
    </router-link>
  </div>
</template>

<style scoped>
h1 {
  color: var(--color-heading);
}

button {
  width: fit-content;
  font-size: 1.5rem;
  margin: 0.5rem auto;
}

.link {
  font-size: 1rem;
  width: fit-content;
  padding: 0 5rem;
  margin: auto;
}

.panel {
  display: flex;
  flex-direction: column;
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
