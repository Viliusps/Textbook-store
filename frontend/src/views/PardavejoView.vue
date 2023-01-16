<script setup>
import { store } from "../store.ts";
import { storeMessage } from "../storeMessage.ts";
import router from "../router.ts";
import axios from "axios";
</script>

<script>
export default {
  data() {
    return {
      store,
      storeMessage,
      info: [],
    };
  },

  async mounted() {
    const responce = await axios.get('https://localhost:7293/api/Pranesimas');
    responce.data.forEach((message, index) => {
      if (message.fk_vartotojas === parseInt(this.store.userinfo.id)) {
        this.info.push(message);
      }
    });
    console.log(this.info);
  },
  methods:{
    openMessage(index){
      this.storeMessage.setMessage(this.info[index].id, this.info[index].pranesimo_turinys, this.info[index].tipas, this.info[index].fk_vartotojas);
      //console.log(this.storeMessage.currentmessage.id);
      router.router.push('/zinutes');
    }
  }
};
</script>

<template>
  <h1>Pardavimas</h1>
  <div class="cls">
    <div>
      <button>
        {{ info.length }} nauji pranešimai
      </button>
        <div v-for="(message, index) in info" :key="message.id" @click="openMessage(index)" class="msg">
          Pranešimas {{ index+1 }}
        </div>
    </div>
    <div>
      <button @click="router.router.push('/vertinimai')">
        3 nauji įvertinimai
      </button>
      <div @click="router.router.push('/vertinimai')" class="rt">
        Įvertinimas 1
      </div>
      <div @click="router.router.push('/vertinimai')" class="rt">
        Įvertinimas 2
      </div>
      <div @click="router.router.push('/vertinimai')" class="rt">
        Įvertinimas 3
      </div>
    </div>
  </div>
</template>

<style scoped>
.cls {
  display: flex;
  flex-direction: row;
  margin: 1rem;
}

button {
  font-size: 1rem;
  margin: 0.5rem;
}

.msg,
.rt {
  padding: 0.5rem;
  margin: 0.5rem;
  font-size: 1rem;
  background: var(--color-background-soft);
  border: solid 1px var(--color-border);
  border-radius: 8px;
}
</style>
