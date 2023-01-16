<script setup>
import router from "../../router.ts";
import { store } from "../../store.ts";
</script>
<script>
export default {
  data() {
    return {
      store: store,
      userid: "0",
    };
  },
  methods: {
    loginaction() {
      router.router.push("/");
      if (this.userid === "0") {
        store.setUser(0, "");
      } else if (this.userid === "1") {
        store.setUser(1, "Vartotojas");
      } else if (this.userid === "2") {
        store.setUser(2, "Administratorius");
      } else if (this.userid === "3") {
        store.setUser(3, "Kurjeris");
      }
    },
  },
};
</script>

<template>
  <p>laikinas rolės pasirinkimas</p>
  <input type="radio" name="r0" value="0" v-model="userid" />
  <label for="r0">Svečias</label>
  <br />
  <input type="radio" name="r1" value="1" v-model="userid" />
  <label for="r1">Vartotojas</label>
  <br />
  <input type="radio" name="r2" value="2" v-model="userid" />
  <label for="r2">Administratorius</label>
  <br />
  <input type="radio" name="r3" value="3" v-model="userid" />
  <label for="r3">Kurjeris</label>
  <br />
  <button @click="loginaction()">"prisijungi"</button>
</template>
