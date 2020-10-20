<template>
  <div class="home">
    <div id="larger" class="header row justify-content-center">
      <span><b>VOCAB</b></span
      ><img
        class="picborder rounded mb-1 mt-3"
        src="../assets/link.png"
        alt
        style="max-width: 1.5rem; max-height: 1.5rem"
      /><b>U</b
      ><img
        class="picborder rounded mb-1 mt-3"
        src="../assets/link.png"
        alt
        style="max-width: 1.5rem; max-height: 1.5rem"
      /><span><b>LINK</b></span>
    </div>
    <div class="row justify-content-center">
      <h5 class="col-8 col-md-12">
        Welcome to Vocabulink, a language-learning app that helps you learn
        vocabulary words in the context of sentences.
      </h5>
    </div>
    <div class="row justify-content-center text-left mx-4">
      <a class="ml-3" href="#" @click="login"
        >Skip help and start adding vocabulary (requires login)</a
      >
    </div>
    <div class="row justify-content-center mb-5">
      <div class="col-12 mb-3">
        <h1><u>Help contents</u></h1>
      </div>
      <div class="col-12 text-left ml-3">
        <h2><a href="#create">1. The Create page</a></h2>
      </div>
      <div class="col-12 text-left ml-3">
        <h2><a href="#manage">2. The Manage page</a></h2>
      </div>
      <div class="col-12 text-left ml-3">
        <h2><a href="#review">3. The Review page</a></h2>
      </div>
    </div>
    <div class="row justify-content-center mb-5">
      <div id="create" class="col-12 mb-3">
        <h2>1. The Create page</h2>
      </div>
      <div>
        <img
          class="col-8 col-md-12 mb-5"
          src="../assets/addvocab.png"
          style="max-width: 75rem"
        />
      </div>
      <div>
        <img
          class="col-8 col-md-12"
          src="../assets/createlinks.png"
          style="max-width: 75rem"
        />
      </div>
    </div>
    <div class="row justify-content-center mb-5">
      <div id="manage" class="col-12 mb-3">
        <h2>2. The Manage page</h2>
      </div>
      <div>
        <img
          class="col-8 col-md-12 mb-5"
          src="../assets/edititems.png"
          style="max-width: 75rem"
        />
      </div>
      <div>
        <img
          class="col-8 col-md-12 mb-5"
          src="../assets/severlink.png"
          style="max-width: 75rem"
        />
      </div>
    </div>
    <div class="row justify-content-center mb-5">
      <div id="review" class="col-12 mb-3">
        <h2>3. The Review page</h2>
      </div>
      <div>
        <img
          class="col-8 col-md-12 mb-5"
          src="../assets/wordreview.png"
          style="max-width: 75rem"
        />
      </div>
      <div>
        <img
          class="col-8 col-md-12"
          src="../assets/sentencereview.png"
          style="max-width: 75rem"
        />
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "home",
  data() {
    return {};
  },
  computed: {},
  methods: {
    async login() {
      if (this.$auth.user == null) {
        await this.$auth.loginWithPopup();
        this.$store.dispatch("setBearer", this.$auth.bearer);
        this.$store.dispatch("getProfile");
        console.log("this.$auth.user: ");
        console.log(this.$auth.user);
        this.$router.push({ name: "create", path: "/create" });
      }
    },
  },
  components: {},
};
</script>


<style scoped>
</style>
