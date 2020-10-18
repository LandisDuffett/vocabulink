<template>
  <div class="study">
    <div>
      <div class="row justify-content-center">
        <h3 class="ml-4">View words by sentence</h3>
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
          @click="reset()"
          type="button"
          style="max-height: 2rem; width: 20vw"
          class="row btn border rounded btn-dark ml-3 m-1 p-2"
        >
          Reset
        </button>
      </div>
      <div class="row justify-content-center mt-2">
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
    <hr class="divider" />
    <!--begin sentences byword-->
    <div>
      <div class="row justify-content-center">
        <h3 class="ml-4">View sentences by word</h3>
      </div>
      <div class="row justify-content-center">
        <button
          @click="nextWord()"
          type="button"
          style="max-height: 2rem; width: 20vw"
          class="row btn border rounded btn-danger ml-3 m-1 p-2"
        >
          Next
        </button>
        <button
          @click="resetWords()"
          type="button"
          style="max-height: 2rem; width: 20vw"
          class="row btn border rounded btn-dark ml-3 m-1 p-2"
        >
          Reset
        </button>
      </div>
      <div class="row justify-content-center">
        <div class="card m-2 border rounded" style="width: 30vw">
          <span class="ml-3 mt-2"
            ><span class="mr-2"><b>word:</b></span
            >{{ words[wordindex].name }}</span
          ><br />
          <span class="ml-3"
            ><span class="mr-2"><b>definition:</b></span
            >{{ words[wordindex].definition }}</span
          ><br />
          <span class="ml-3"
            ><img :src="words[wordindex].img" style="max-width: 8rem" /></span
          ><br />
        </div>
      </div>
      <div class="row justify-content-center">
        <div
          v-for="sentenceitem in sentenceitems"
          :sentenceitem="sentenceitem"
          :key="sentenceitem.sentenceWordId"
          :value="sentenceitem.id"
        >
          <div class="card m-2 border rounded" style="width: 30vw">
            <span class="ml-3 mt-2"
              ><span class="mr-2">"{{ sentenceitem.text }}"</span></span
            >
          </div>
        </div>
      </div>
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
    sentenceitems() {
      return this.$store.state.wordsents;
    },
    worditems() {
      return this.$store.state.sentwords;
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
      this.$store.dispatch("getSentencesByWord", this.words[this.wordindex].id);
    },
    nextSentence() {
      this.$store.dispatch("advance");
    },
    reset() {
      this.$store.dispatch("reset");
    },
    nextWord() {
      this.$store.dispatch("advanceWord");
    },
    resetWords() {
      this.$store.dispatch("resetWord");
    },
  },
};
</script>