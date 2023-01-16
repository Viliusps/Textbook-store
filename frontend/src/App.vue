<script setup lang="ts">
import Headerbar from "./components/header/Header_KK.vue";
import HeaderItem from "./components/header/HeaderItem.vue";

// 0 svečias
// 1 Vartotojas
// 2 Administratorius
// 3 Kurjeris
</script>

<template>
  <Headerbar>
    <HeaderItem link="/" text="Pradžia" />
    <HeaderItem link="/vadoveliai" text="Vadovėliai" />
    <HeaderItem link="/mano-siuntiniai" text="Siuntos" />
    <HeaderItem
      :roles="[2, 3]"
      link="/siuntiniu-valdymas"
      text="Siuntų valdymas"
    />
    <HeaderItem :roles="[1]" link="/pardavimas" text="Pardavimas" />
    <HeaderItem :roles="[2]" link="/administravimas" text="Administravimas" />
    <HeaderItem
      :roles="[1]"
      link="/mano-vadoveliai"
      text="Mano vadovėliai"
    />
    <HeaderItem
        :roles="[2]"
        link="/mano-vadoveliai"
        text="Visi parduodami vadovėliai"
    />
  </Headerbar>
  <div id="main">
    <router-view></router-view>
  </div>
</template>

<style>
#main {
  display: flex;
  flex-direction: column;
  max-width: 1280px;
  margin: 0 auto;
  padding: 2rem;
  place-items: center;
}

@media (min-width: 1024px) {
  #main {
    padding: 0 2rem;
  }
}
</style>
