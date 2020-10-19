<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-danger">
    <router-link class="navbar-brand" :to="{ name: 'home' }"
      ><span><b>VOCAB</b></span
      ><img
        class="picborder rounded mb-1"
        src="../assets/link.png"
        alt
        style="max-width: 1rem"
      /><b>U</b
      ><img
        class="picborder rounded mb-1"
        src="../assets/link.png"
        alt
        style="max-width: 1rem"
      /><span><b>LINK</b></span></router-link
    >
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item" :class="{ active: $route.name == 'home' }">
          <router-link :to="{ name: 'home' }" class="nav-link"
            >Home</router-link
          >
        </li>
        <li class="nav-item" :class="{ active: $route.name == 'create' }">
          <router-link :to="{ name: 'create' }" class="nav-link"
            >Create</router-link
          >
        </li>
        <li class="nav-item" :class="{ active: $route.name == 'manage' }">
          <router-link :to="{ name: 'manage' }" class="nav-link"
            >Manage</router-link
          >
        </li>
        <li class="nav-item" :class="{ active: $route.name == 'review' }">
          <router-link :to="{ name: 'review' }" class="nav-link"
            >Review</router-link
          >
        </li>
      </ul>
      <span class="navbar-text">
        <button
          class="btn btn-success"
          @click="login"
          v-if="!$auth.isAuthenticated"
        >
          Login
        </button>
        <button class="btn btn-dark" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true,
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      this.$store.dispatch("setBearer", this.$auth.bearer);
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      this.$store.dispatch("resetBearer");
      await this.$auth.logout({ returnTo: window.location.origin });
    },
  },
};
</script>

<style></style>
