import Home from "./views/Homepage_KK.vue";
// account control
import Login from "./views/LoginView.vue";
import Registration from "./views/RegistrationView.vue";
import Vartotojas from "./views/VartotojoView.vue";
import Kvitai from "./views/KvitaiView.vue";
// deliveries
import ManoSiuntiniai from "./views/ManoSiuntiniaiView.vue";
import SiuntiniaiCtl from "./views/SiuntiniaiCtlView.vue";
import Transportavimas from "./views/TransportavimasView.vue";
import SiuntinysCtl from "./views/SiuntinysCtlView.vue";
// books
import Vadoveliai from "./views/VadoveliaiView.vue";
import Vadovelis from "./views/VadovelisView.vue";
import Mokejimas from "./views/MokejimasView.vue";
import ManoVadoveliai from "./views/ManoVadoveliaiView.vue";
import NaujasVadovelis from "./views/NaujasVadovelisView.vue";
import VadovelioKoregavimas from "./views/VadoveliuKoregavimasView.vue";
// admin
import Vartotojai from "./views/ViewUsersData.vue";
import Statistikaview from "./views/StatistikaView.vue";
import Statistikagen from "./views/StatistikaGen.vue";
import Administravimas from "./views/AdministravimasView.vue";
// selling
import Pardavimas from "./views/PardavejoView.vue";
import Zinutes from "./views/ZinutesView.vue";
import Vertinimai from "./views/VertinimaiView.vue";
import Grazinimas from "./views/GrazinimasView.vue";
// other
import KlientuInformavimas from "./views/KlientuInformavimasView.vue";
import NotFound from "./views/PageNotFound.vue";

import { createRouter, createWebHistory } from "vue-router";
import PopuliariausiVadoveliaiView from "@/views/PopuliariausiVadoveliaiView.vue";

const routes = [
  { path: "/", name: "homepage", component: PopuliariausiVadoveliaiView },
  // account control
  {
    path: "/login",
    name: "login",
    component: Login,
  },
  {
    path: "/registration",
    name: "registration",
    component: Registration,
  },
  {
    path: "/vartotojas",
    name: "user page",
    component: Vartotojas,
  },
  {
    path: "/kvitai",
    name: "payment history",
    component: Kvitai,
  },
  // deliveries
  {
    path: "/mano-siuntiniai",
    name: "my deliveries",
    component: ManoSiuntiniai,
  },
  {
    path: "/siuntiniu-valdymas",
    name: "delivery control",
    component: SiuntiniaiCtl,
  },
  {
    path: "/siuntiniu-valdymas/:delivery_id",
    name: "specific delivery ctl",
    component: SiuntinysCtl,
  },
  // books
  {
    path: "/vadoveliai",
    name: "books",
    component: Vadoveliai,
  },
  {
    path: "/vadoveliai/:book_id",
    name: "book view",
    component: Vadovelis,
  },
  {
    path: "/mokejimas",
    name: "payment",
    component: Mokejimas,
  },
  {
    path: "/mano-vadoveliai",
    name: "my books",
    component: ManoVadoveliai,
  },
  {
    path: "/naujas-vadovelis",
    name: "new book",
    component: NaujasVadovelis,
  },
  {
    path: "/vadoveliai/:book_id/koregavimas",
    name: "book edit",
    component: VadovelioKoregavimas,
  },
  // admin
  {
    path: "/administravimas",
    name: "Administravimas",
    component: Administravimas,
  },
  {
    path: "/userview",
    name: "User view",
    component: Vartotojai,
  },
  {
    path: "/statistikagen",
    name: "statisticsgen",
    component: Statistikagen,
  },
  {
    path: "/statistikaview",
    name: "statisticsview",
    component: Statistikaview,
  },
  // selling
  {
    path: "/pardavimas",
    name: "seller window",
    component: Pardavimas,
  },
  {
    path: "/zinutes",
    name: "messages",
    component: Zinutes,
  },
  {
    path: "/vertinimai",
    name: "ratings",
    component: Vertinimai,
  },
  {
    path: "/grazinimas/:order_id",
    name: "return",
    component: Grazinimas,
  },
  // other
  {
    path: "/klientu-informavimas",
    name: "customer informing",
    component: KlientuInformavimas,
  },
  {
    path: "/:pathMatch(.*)*",
    name: "error404 page",
    component: NotFound,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

export default { router: router };
