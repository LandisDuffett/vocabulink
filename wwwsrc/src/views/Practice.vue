<template>
  <div class="study">
    <div>
      <div class="row justify-content-center">
        <h3 class="ml-4">View words by sentence</h3>
      </div>
      <div class="row justify-content-center">
        <h5 class="ml-4">"{{ sentences[sentenceindex].text }}"</h5>
      </div>
      <div class="row justify-content-center">
        <div
          v-for="worditem in worditems"
          :worditem="worditem"
          :key="worditem.sentenceWordId"
          :value="worditem.id"
        >
          <div class="card m-2 border rounded" style="width: 30vw">
            <span class="ml-3 mt-2"
              ><span class="mr-2"><b>word:</b></span
              >{{ worditem.name }}</span
            ><br />
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
    </div>
    <div class="row justify-content-center">
      <button
        @click="nextSentence()"
        type="button"
        style="max-height: 2rem; width: 20vw"
        class="row btn border rounded btn-danger ml-3 m-1 p-2"
      >
        Next
      </button>
      <button
        @click="nextSentence()"
        type="button"
        style="max-height: 2rem; width: 20vw"
        class="row btn border rounded btn-dark ml-3 m-1 p-2"
      >
        Reset
      </button>
    </div>
    <hr class="divider" />
    <div>
      <h3>View sentences by word</h3>
    </div>
  </div>
</template>

<script>
export default {
  name: "practice",
  mounted() {
    this.$store.dispatch("getWords");
    this.$store.dispatch("getSentences");
    this.$store.dispatch("getSentencewords");
  },
  data() {
    return {};
  },
  watch: {
    sentenceindex: function () {
      this.returnWords();
    },
    selectWord: function () {
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
    words() {
      return this.$store.state.words;
    },
    sentenceitems() {
      return this.$store.state.wordsents;
    },
    worditems() {
      return this.$store.state.sentwords;
    },
    sentencewords() {
      return this.$store.state.sentencewords;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    returnWords() {
      this.$store.dispatch(
        "getWordsBySentence",
        this.sentences[this.sentenceindex].id
      );
    },
    returnSentences() {
      this.$store.dispatch("getSentencesByWord", this.selectWord);
    },
    nextSentence() {
      this.$store.dispatch("advance");
    },
    reset() {
      this.$store.dispatch("reset");
    },
  },
};
</script>