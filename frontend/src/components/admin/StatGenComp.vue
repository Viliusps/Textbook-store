<script setup>
import router from "../../router.ts";
import Modal from "../common/Modal.vue";
import Datepicker from '@vuepic/vue-datepicker';
import StatistikaView from "../../views/StatistikaView.vue";
import '@vuepic/vue-datepicker/dist/main.css'
</script>
<script>
import Axios from "axios";

export default {
  data() {
    return {
      info: [],
      date: ""
    };
  },
  mounted() {
    if(parseInt(localStorage.getItem('usertype')) !== 2)
    {
      router.router.push('/');
    }
    Axios.get("https://localhost:7293/api/Vartotojas").then(
      (resp) => (this.info = resp.data)
    );
  },
  methods: {
    Generate(){
        if(this.date == "")
        {
          document.getElementById("warning").innerHTML  = "Įveskite datą!";
        }
        else
        {
          console.log(this.date[0])
        var currentDate = new Date();
        console.log(currentDate)
        const resp = Axios.post("https://localhost:7293/api/Statistika", {
          sudaryta: currentDate,
          data_nuo: this.date[0],
          data_iki: this.date[1]
        }).catch((error) => {
          console.log(error);
        });
        window.location.href = '/statistikaview';
        }
        
    }
  },
};
</script>

<template>
  <header>
    <div>
      <h1>Statistikos generavimas</h1>
      <label id="warning" class="warning"></label>
    </div>
  </header>
  <h3>Pasirinkite norimą laikotarpį statistikai generuoti</h3>
  <br>
  <label id="warning" class="warning"></label>
  <Datepicker v-model="date" range required/>
  <button @click="Generate()">Generuoti</button>
</template>
<style scoped>
div{
  text-align: center;
  width:100%;
}
.warning{
  color: red;
}
 </style>
