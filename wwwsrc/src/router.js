import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import Create from "./views/Create.vue";
import Manage from "./views/Manage.vue";
import Wordquiz from "./views/Wordquiz.vue";
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
      path: "/wordquiz",
      name: "wordquiz",
      component: Wordquiz,
      beforeEnter: authGuard
    }
  ]
});
