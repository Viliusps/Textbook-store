<script setup>
import router from "../../router.ts";
import Modal from "../common/Modal.vue";
import moment from 'moment';
</script>
<script>
import Axios from "axios";

export default {
  data() {
    return {
      info: [],
      Orders:[],
      VartVad:[],
      modal_state: false,
      modal_route: false,
      stat: null,
      selected: "",
    };
  },
  mounted() {
    if(parseInt(localStorage.getItem('usertype')) !== 2)
    {
      router.router.push('/');
    }
    Axios.get("https://localhost:7293/api/Statistika").then(
      (resp) => (this.info = resp.data)
    );
    Axios.get("https://localhost:7293/api/Uzsakymas").then(
      (resp) => (this.Orders = resp.data)
    );
    Axios.get("https://localhost:7293/api/VartotojoVadoveliai").then(
      (resp) => (this.VartVad = resp.data)
    );
  },
  methods: {
    DeleteStat(id){
        console.log(id);
        Axios.delete("https://localhost:7293/api/Statistika/"+id).then(
      (resp) => (this.info = resp.data)
    );
    },
    formatDate(date) {
      const options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' }
      let temp2 = moment.utc(date).local().format();
      let temp = new Date(temp2).toLocaleDateString('lt', options);
      return temp;
    },
    getOrderCount(id, nuo, iki)
    {
      var temp = 0;
      for(var i of this.Orders)
      {
        console.log(nuo);
        console.log(iki);
        console.log(i.data);
        if(i.data > nuo && i.data < iki)
        {
          temp++;
        }
      }
      return temp;

    },
    getBookCount(nuo, iki){
      var temp = 0;
      for(var i of this.Orders)
      {
        console.log(nuo);
        console.log(iki);
        console.log(i.data);
        if(i.data > nuo && i.data < iki)
        {
          for(var j of this.VartVad)
          {
            if(j.fk_uzsakymas == i.id)
            {
              temp++;
            }
          }
        }
      }
      return temp;
    }
  },
};
</script>

<template>
  <header>
    <div>
      <h1>Statistika</h1>
      <button @click="router.router.push('/statistikagen')">Generuoti naują</button>
      <label id="warning" class="warning"></label>
    </div>
    
  </header>

  <table v-if="this.info.length > 0" class="styled-table">
    <thead>
        <tr>
        <th>ID</th>
        <th>Sudaryta</th>
        <th>Veiksmai</th>
        </tr>
    </thead>
    <tbody>
        <tr v-for="stat in info" :key="stat.id">
        <td>{{ stat.id }}</td>
        <td> {{ formatDate(stat.sudaryta) }} </td>
        <td><button  @click="(modal_state = true), (this.statt = { ...stat })">Peržiūrėti</button>
        <Modal :state="modal_state" @close="modal_state = false">
            <h1>Statistikos rezultatai</h1>
            <h2>Pasirinktas laikotarpis: {{formatDate(this.statt.data_nuo)}} - {{formatDate(this.statt.data_iki)}}</h2>
            <p>Jūsų nurodytu laikotarpiu buvo: </p>
            <p> Atlikta {{getOrderCount(this.statt.id, this.statt.data_nuo, this.statt.data_iki)}} užsakymų.</p>
            <p>Parduota {{getBookCount(this.statt.data_nuo, this.statt.data_iki)}} vadovėlių.</p>
            <br />
            <button @click="modal_state = false">Baigti peržiūrą</button>
            </Modal>
            <button  @click="DeleteStat(stat.id)">Trinti</button></td>
        </tr>
    </tbody>
  </table>
  <h1 v-else>Sąrašas tuščias!</h1>
</template>

<style scoped>
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
div{
  text-align: center;
}
.warning{
  color: red;
  text-align: center;
}
button {
  margin: 0.5rem;
  font-size: 1rem;
}
header {
  margin: 0;
  font-size: 1.5rem;
  line-height: 1.5;
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
</style>
