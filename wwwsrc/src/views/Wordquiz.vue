<template>
  <div class="home">
    <div class="row justify-content-center">
      <h3>Word Quiz</h3>
    </div>
    <div class="card m-2 rounded">
      <div class="row mt-2" style="justify-content: space-between">
        <div class="col-3">
          <div class="row justify-content-center">
            <span><b>Correct: 0</b></span
            ><span class="mx-5"><b>Incorrect: 0</b></span
            ><span class="mr-5"><b>Percent: 100</b></span>
          </div>
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
        <div class="col-5 mb-2 mt-2">
          <div class="row">
            <p style="font-size: 0.8rem" class="mb-0">
              <b>
                review mode (recycles incorrect answers until all answered
                correctly)</b
              >
            </p>
            <div>
              <div class="row ml-2">
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
          </div>
        </div>
      </div>
    </div>

    <div class="row justify-content-center">
      <h5>
        Write the word for each definition/image given. Show sentence if you
        need a hint.
      </h5>
    </div>
    <div class="row mt-2 ml-5">
      <button
        @click="showSentence()"
        type="button"
        style="max-height: 2rem; width: 20vw"
        class="row btn border rounded btn-dark ml-3 m-1 p-2"
        v-if="this.hint"
      >
        hide sentence
      </button>
      <button
        @click="showSentence()"
        type="button"
        style="max-height: 2rem; width: 20vw"
        class="row btn border rounded btn-danger ml-3 m-1 p-2"
        v-else
      >
        show sentence -->
      </button>
      <h5 class="ml-4" v-show="this.hint">
        "{{ sentences[sentenceindex].text }}"
      </h5>
    </div>
    <div class="row justify-content-center">
      <div
        v-for="worditem in worditems"
        :worditem="worditem"
        :key="worditem.sentenceWordId"
        :value="worditem.id"
      >
        <div class="card m-2 border rounded" style="width: 30vw">
          <span class="ml-3"
            ><span class="mr-2"><b>definition:</b></span
            >{{ worditem.definition }}</span
          ><br />
          <span class="ml-3"
            ><img :src="worditem.img" style="max-width: 8rem" /></span
          ><br />
        </div>
      </div>
    </div>
    <div class="row justify-content-center mt-4">
      <button
        @click="checkAnswer()"
        type="button"
        style="max-height: 2rem; width: 20vw"
        class="row btn border rounded btn-dark ml-3 m-1 p-2"
      >
        Check
      </button>
      <button
        @click="reset()"
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
  mounted() {
    this.$store.dispatch("getWords");
    this.$store.dispatch("getSentences");
    this.$store.dispatch(
      "getWordsBySentence",
      this.sentences[this.sentenceindex].id
    );
    this.$store.dispatch("getSentencesByWord", this.words[this.wordindex].id);
  },
  data() {
    return {
      reviewMode: false,
      hint: false,
    };
  },
  watch: {
    sentenceindex: function () {
      this.returnWords();
    },
    wordindex: function () {
      this.returnSentences();
    },
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    sentenceindex() {
      return this.$store.state.sentenceindex;
    },
    sentences() {
      return this.$store.state.sentences;
    },
    wordindex() {
      return this.$store.state.wordindex;
    },
    words() {
      return this.$store.state.words;
    },
    worditems() {
      return this.$store.state.sentwords;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    showSentence() {
      this.hint = !this.hint;
    },
    next() {
      this.hint = false;
      this.$stores.dispatch("advance");
    },
    returnWords() {
      this.$store.dispatch(
        "getWordsBySentence",
        this.sentences[this.sentenceindex].id
      );
    },
    returnSentences() {
      this.$store.dispatch("getSentencesByWord", this.words[this.wordindex].id);
    },
    checkAnswer() {},
    reset() {},
  },
};
</script>
