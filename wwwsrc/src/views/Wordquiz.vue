<template>
  <div class="home">
    <div class="card m-2 boxborder rounded">
      <div class="row justify-content-center">
        <div class="col-5">
          <h4 class="p-2" id="smallerfont"><b>Controls</b></h4>
          <section class="mb-2">
            <p style="font-size: 0.8rem" class="mb-0">
              <b>
                Review mode (recycles incorrect answers until all answered
                correctly)</b
              >
            </p>
            <div>
              <div class="row ml-3 justify-content-center">
                <input
                  type="radio"
                  v-model="reviewMode"
                  :value="true"
                  style="margin-top: 0.185rem"
                />
                <p style="font-size: 0.8rem" class="ml-1 mb-0">on</p>
                <br />
              </div>
              <div class="row ml-3 justify-content-center">
                <input
                  type="radio"
                  v-model="reviewMode"
                  :value="false"
                  style="margin-top: 0.185rem"
                />
                <p style="font-size: 0.8rem" class="ml-1 mb-0">off</p>
                <br />
              </div>
            </div>
          </section>
          <section class="mb-2">
            <p style="font-size: 0.8rem" class="mb-0">
              <b> hint (shows definition and iamge)</b>
            </p>
            <div>
              <div class="row ml-3 justify-content-center">
                <input
                  type="radio"
                  v-model="showStudy"
                  :value="true"
                  style="margin-top: 0.185rem"
                />
                <p style="font-size: 0.8rem" class="ml-1 mb-0">on</p>
                <br />
              </div>
              <div class="row ml-3 justify-content-center">
                <input
                  type="radio"
                  v-model="showStudy"
                  :value="false"
                  style="margin-top: 0.185rem"
                />
                <p style="font-size: 0.8rem" class="ml-1 mb-0">off</p>
                <br />
              </div>
            </div>
          </section>
        </div>
        <div class="col-3">
          <button
            @click="reset()"
            type="button"
            style="max-height: 2rem; width: 20vw"
            class="row btn border rounded btn-danger ml-3 m-1 p-2"
          >
            Reset
          </button>
        </div>
        <div class="col-3">
          <div class="row">Correct: 0</div>
          <div class="row">Incorrect: 0</div>
          <div class="row">Percent: 100</div>
        </div>
      </div>

      <div>
        <button
          @click="resetWords()"
          type="button"
          style="max-height: 2rem; width: 20vw"
          class="row btn border rounded btn-dark ml-3 m-1 p-2"
        >
          Check
        </button>
        <button
          @click="resetWords()"
          type="button"
          style="max-height: 2rem; width: 20vw"
          class="row btn border rounded btn-dark ml-3 m-1 p-2"
        >
          Next
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "wordquiz",
  mounted() {},
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
};
</script>
