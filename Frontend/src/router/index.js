import Vue from "vue";
import Router from "vue-router";
import Dashboard from "@/components/Dashboard";
import Profile from "@/components/Profile";
import Tables from "@/components/Tables";
import Maps from "@/components/Maps";
import BadGateway from "@/components/BadGateway";
import Finca from "@/components/Finca";
import Lote from "@/components/Lote";
import Usuario from "@/components/Usuario";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/dashboard",
      name: "Dashboard",
      component: Dashboard,
      props: { page: 1 },
      alias: "/"
    },
    {
      path: "/actividades",
      name: "Actividades",
      props: { page: 2 },
      component: Profile
    },
    {
      path: "/reportes",
      name: "Reportes",
      props: { page: 3 },
      component: Tables
    },
    {
      path: "/configuracion",
      name: "Configuración",
      props: { page: 4 },
      component: Maps
    },
    {
      path: "finca",
      name: "Finca",
      component: Finca,
    },
    {
      path: "lote",
      name: "Lote",
      component: Lote,
    },
    {
      path: "usuario",
      name: "Usuario",
      component: Usuario,
    },
    {
      path: "/404",
      name: "BadGateway",
      props: { page: 5 },
      component: BadGateway
    },
    {
      path: "*",
      props: { page: 5 },
      redirect: "/404"
    }
  ]
});
