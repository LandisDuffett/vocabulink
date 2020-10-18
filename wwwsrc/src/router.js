import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Create from "./views/Create.vue";
import Manage from "./views/Manage.vue";
import Practice from "./views/Practice.vue";
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/create",
      name: "create",
      component: Create,
      beforeEnter: authGuard
    },
    {
      path: "/manage",
      name: "manage",
      component: Manage,
      beforeEnter: authGuard
    },
    {
      path: "/practice",
      name: "practice",
      component: Practice,
      beforeEnter: authGuard
    }
  ]
});
