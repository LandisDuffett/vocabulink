<template>
  <div class="home">
    <div class="row justify-content-center">
      <div class="card m-2 rounded" style="width: 80vw">
        <div class="row justify-content-center">
          <div class="col-2">
            <div class="row"><b>Correct: 0</b></div>
            <div class="row"><b>Incorrect: 0</b></div>
            <div class="row"><b>Percent: 100</b></div>
          </div>
          <div class="col-3 mr-5">
            <div class="row justify-content-center">
              <h4 class="p-2 ml-5" id="smallerfont"><b>Dashboard</b></h4>
            </div>
            <button
              @click="reset()"
              type="button"
              style="max-height: 2rem; width: 20vw"
              class="row btn border rounded btn-danger ml-3 mt-3 m-1 p-2"
            >
              Reset
            </button>
          </div>
          <div class="col-4 ml-5 mb-2 mt-2">
            <p style="font-size: 0.8rem" class="ml-3 mb-0">
              <b>
                review mode (recycles incorrect answers until all answered
                correctly)</b
              >
            </p>
            <div>
              <div class="row ml-5">
                <input
                  type="radio"
                  v-model="reviewMode"
                  :value="true"
                  style="margin-top: 0.185rem"
                />
                <p style="font-size: 0.8rem" class="ml-1 mr-3 mb-0">on</p>
                <br />
                <input
                  type="radio"
                  v-model="reviewMode"
                  :value="false"
                  style="margin-top: 0.185rem"
                />
                <p style="font-size: 0.8rem" class="ml-1 mb-0">off</p>
                <br />
              </div>
              <div class="row ml-3 justify-content-center"></div>
            </div>
            <p style="font-size: 0.8rem" class="ml-3 mb-0">
              <b>hint (shows definition and iamge)</b>
            </p>
            <div>
              <div class="row ml-5">
                <input
                  type="radio"
                  v-model="hint"
                  :value="true"
                  style="margin-top: 0.185rem"
                />
                <p style="font-size: 0.8rem" class="ml-1 mr-3 mb-0">on</p>
                <br />
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
          </div>
        </div>
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
