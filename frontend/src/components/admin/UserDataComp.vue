<script setup>
import router from "../../router.ts";
import Modal from "../common/Modal.vue";
import Datepicker from '@vuepic/vue-datepicker';
</script>
<script>
import Axios from "axios";

export default {
  data() {
    return {
      info: [],
      amdinInfo: [],
      courierInfo: [],
      modal_state: false,
      modal_route: false,
      personn: null,
      pazymdat: "",
      maxmendarbval: "",
      mendarbval: "",
      selected: "",
      role: "",
      realRole: "",
      visible: false,
      apskritis: "",
      courierID: "",
      adminID: "",
      showtable: false
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
    Axios.get("https://localhost:7293/api/Administratorius").then(
      (resp) => (this.adminInfo = resp.data)
    );
    Axios.get("https://localhost:7293/api/Kurjeris").then(
      (resp) => (this.courierInfo = resp.data)
    );
  },
  methods: {
    async deleteData(role) {
      console.log(role);
      if(role == "Administratorius")
      {
        document.getElementById("warning").innerHTML  = "Negalite pašalinti administratoriaus paskyros!";
      }
      else{
        console.log("asd");
      console.log(this.personn.id);
      const resp = await Axios.put("https://localhost:7293/api/Vartotojas", {
        id: this.personn.id,
        vardas: "DELETED",
        pavarde: "DELETED",
        miestas: "DELETED",
        adresas: "DELETED",
        el_pastas: "DELETED",
        pasto_kodas: this.personn.pasto_kodas,
        slapyvardis: "DELETED",
        slaptazodis: this.personn.slaptazodis,
        vartotojo_ivertinimas: this.personn.vartotojo_ivertinimas,
      }).catch((error) => {
        console.log(error);
      });
      window.location.reload();
      }
      
      
    },
    formatDate(date) {
      const options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' }
      return new Date(date).toLocaleDateString('lt', options)
    },
    getRole(person){
      this.maxmendarbval = "";
      this.mendarbval = "";
      this.pazymdat = "";
      this.apskritis = "";
      for (var i of this.adminInfo)
      {
        
        if(person.id == i.vartotojo_id){
          this.visible = false;
          this.realRole = "Administratorius";
          this.adminID = i.id;
          return "Administratorius";
        }
          
      }
      for (var i of this.courierInfo)
      {
        if(person.id == i.fk_vartotojas){
          this.realRole = "Kurjeris";
          this.maxmendarbval = i.maksimalios_menesio_darbo_valandos;
          this.mendarbval = i.menesio_darbo_valandos;
          this.pazymdat = i.vairuotojo_pazymejimo_galiojimo_data;
          this.apskritis = i.aptarnaujama_apskritis;
          this.visible = true;
          this.courierID = i.id;
          return "Kurjeris";
        }
          
      }
    },
    filter(data){
      let arr=[];
      for(var i of data)
      {
        if(i.vardas != "DELETED")
        {
          arr.push(i);
        }
      }
      return arr;
    },
    CheckIfShow(){
      var temp = 0;
      for(var i of this.info){
        if(i.vardas != "DELETED") return true;
      }
      return false;
    },
    async changeData() {
      console.log(this.personn.vardas);
      const resp = await Axios.put("https://localhost:7293/api/Vartotojas", {
        id: this.personn.id,
        vardas: this.personn.vardas,
        pavarde: this.personn.pavarde,
        miestas: this.personn.miestas,
        adresas: this.personn.adresas,
        el_pastas: this.personn.el_pastas,
        pasto_kodas: this.personn.pasto_kodas,
        slapyvardis: this.personn.slapyvardis,
        slaptazodis: this.personn.slaptazodis,
        vartotojo_ivertinimas: this.personn.vartotojo_ivertinimas,
      }).catch((error) => {
        console.log(error);
      });
      console.log(resp);
      if(this.realRole != this.role && this.role == "Kurjeris")
      {
        if(this.realRole == "Administratorius")
        {
          Axios.delete("https://localhost:7293/api/Administratorius/"+this.adminID)
        }
        const resp = Axios.post("https://localhost:7293/api/Kurjeris", {
          maksimalios_menesio_darbo_valandos: this.maxmendarbval,
          menesio_darbo_valandos: this.mendarbval,
          vairuotojo_pazymejimo_galiojimo_data: this.pazymdat,
          aptarnaujama_apskritis: this.apskritis,
          fk_vartotojas: this.personn.id
        }).catch((error) => {
          console.log(error);
        });
        console.log(resp);
      }
      if(this.realRole != this.role && this.role == "Administratorius")
      {
        if(this.realRole == "Kurjeris")
        {
          console.log(this.courierID);
          const resp = await Axios.put("https://localhost:7293/api/Kurjeris", {
          id: this.courierID,
          vairuotojo_pazymejimo_galiojimo_data: "",
          menesio_darbo_valandos: -1,
          maksimalios_menesio_darbo_valandos: -1,
          aptarnaujama_apskritis: "Vilniaus apskritis",
          fk_vartotojas: this.personn.id
        }).catch((error) => {
          console.log(error);
        });
        }
        var currentDate = new Date();
        console.log(this.adminID);
        const resp = await Axios.post("https://localhost:7293/api/Administratorius", {
          administratorius_nuo: currentDate,
          vartotojo_id: this.personn.id,
        }).catch((error) => {
          console.log(error);
        });
        console.log(resp);
      }
      window.location.reload();
    }
  },
};
</script>

<template>
  <header>
    <div>
      <h1>Vartotojų informacija</h1>
      <label id="warning" class="warning"></label>
    </div>
    
  </header>

  <table v-if="CheckIfShow()" class="styled-table">
    <thead>
      <tr>
        <th>ID</th>
        <th>Vardas</th>
        <th>Pavardė</th>
        <th>Miestas</th>
        <th>Adresas</th>
        <th>El. Paštas</th>
        <th>Pašto kodas</th>
        <th>Slapyvardis</th>
        <th>Slaptažodis</th>
        <th>Vartotojo įvertinimas</th>
        <th>Veiksmai</th>
      </tr>
    </thead>
    <tbody>
    <tr v-for="person in filter(info)" :key="person.id">
      <td>{{ person.id }}</td>
      <td>{{ person.vardas }}</td>
      <td>{{ person.pavarde }}</td>
      <td>{{ person.miestas }}</td>
      <td>{{ person.adresas }}</td>
      <td>{{ person.el_pastas }}</td>
      <td>{{ person.pasto_kodas }}</td>
      <td>{{ person.slapyvardis }}</td>
      <td>*********</td>
      <td>{{ person.vartotojo_ivertinimas }}</td>
      <td>
        <button @click="(modal_state = true), (this.personn = { ...person }, this.role = getRole(person), temprole = getRole(person))">
          Keisti
        </button>
        <Modal :state="modal_state" @close="modal_state = false">
          <h1>Atlikite norimus pakeitimus</h1>
          <label id="warning2" class="warning"></label>
          <form>
            <div class="userinfo">
            <h3>Vartotojo duomenys: </h3>
            <br />
            <p>Vardas:</p>
            <input type="text" v-model="personn.vardas" required /> <br />
            <p>Pavardė:</p>
            <input type="text" v-model="personn.pavarde" required /> <br />
            <p>Miestas:</p>
            <input type="text" v-model="personn.miestas" required/> <br />
            <p>Adresas:</p>
            <input type="text" v-model="personn.adresas" required /> <br />
            <p>El. paštas:</p>
            <input type="email" v-model="personn.el_pastas" required/> <br />
            <p>Pašto kodas:</p>
            <input type="number" v-model="personn.pasto_kodas" required /> <br />
            <p>Slapyvardis:</p>
            <input type="text" v-model="personn.slapyvardis" required/> <br />
            <p>Rolė:</p>
            <select v-model="this.role" required>
              <option>Administratorius</option>
              <option>Kurjeris</option>
            </select>
          </div>
            <div v-if="this.role=='Kurjeris'" class="courierinfo">
            <h3>Papildomi kurjerio duomenys: </h3>
            <br />
            <p>Vairuotojo pažymėjimo galiojimo data: </p>
            <Datepicker v-model="this.pazymdat" day /> <br />
            <p>Mėnesio darbo valandos: </p>
            <input type="number" v-model="this.mendarbval" required /> <br />
            <p>Maksimalios mėnesio darbo valandos: </p>
            <input type="number" v-model="this.maxmendarbval" required /> <br />
            <p>Aptarnaujama apskritis: </p>
            <select v-model="this.apskritis" required>
              <option>Alytaus apskritis</option>
              <option>Kauno apskritis</option>
              <option>Klaipėdos apskritis</option>
              <option>Marijampolės apskritis</option>
              <option>Panevėžio apskritis</option>
              <option>Šiaulių apskritis</option>
              <option>Tauragės apskritis</option>
              <option>Telšių apskritis</option>
              <option>Utenos apskritis</option>
              <option>Vilniaus apskritis</option>
            </select>
            </div>
          </form>
          <br /><button
            type="submit"
            @click="changeData(), (modal_state = false)"
          >
            Saugoti
          </button>
          <button @click="modal_state = false">Atšaukti</button>
        </Modal>
        <button @click="(this.personn = { ...person }), deleteData(getRole(this.personn))">Šalinti</button>
      </td>
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
.userinfo{
  padding-right: 5px;
  border-right: solid 2px black;
  float:left;
}
.courierinfo{
  padding-left: 5px;
  float:right;
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
