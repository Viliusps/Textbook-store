<script setup>
import HeaderItem from "../components/header/HeaderItem.vue";
import AdminComponent from "../components/admin/AdminComponent.vue";
</script>

<template>
  <body>
    <AdminComponent/>
    <div class="admin">
      <HeaderItem class="adminbutton" link="/userview" text="Vartotojai" />
      <HeaderItem
        class="adminbutton"
        link="/statistikagen"
        text="Statistikos generavimas"
      />
      <HeaderItem
        class="adminbutton"
        link="/statistikaview"
        text="Statistikos peržiūra"
      />
    </div>

    <div id="main">
      <router-view></router-view>
    </div>
  </body>
</template>

<style scoped>
.admin {
  width: 640px; /* Can be in percentage also. */
  height: 50%;
  margin: 0 auto;
  padding: 10px;
  position: relative;
  top: 50%;
  -ms-transform: translateY(-50%);
  transform: translateY(-50%);
}
.adminbutton {
  width: 100%;
}
</style>
