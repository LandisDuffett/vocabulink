<template>
  <div class="review">
    <h2 class="ml-4">Sentences</h2>
    <div>
      <form>
        <label for="activestudy" class="ml-4"
          >Select a sentence to review words for that sentence:</label
        >
        <select v-model="selectSentence" id="editSentence" class="ml-2">
          <option
            v-for="sentence in sentences"
            :sentence="sentence"
            :key="sentence.id"
            :value="sentence"
          >
            {{ sentence.text }}
          </option>
        </select>
      </form>
    </div>
    <div class="row justify-content-center">
      <h5 v-if="selectSentence" class="card p-2 mt-2">
        {{ selectSentence.text }}
      </h5>
      <h5 v-else></h5>
    </div>
    <div class="row justify-content-center">
      <button
        v-if="showWrds"
        @click="clearWords()"
        type="button"
        class="row btn btn-xs border rounded btn-dark mt-2 ml-3"
        style="max-height: 2rem"
      >
        hide words
      </button>
      <button
        v-else
        @click="showWords()"
        type="button"
        class="row btn btn-xs border rounded btn-dark mt-2 ml-3"
        style="max-height: 2rem"
      >
        show words
      </button>
    </div>
    <div class="row justify-content-center">
      <div v-show="showWrds" class="card justify-content-center m-5 p-4">
        <div class="row justify-content-center">
          <div
            class="m-4 p-4 card"
            v-for="worditem in worditems"
            :worditem="worditem"
            :key="worditem.sentenceWordId"
          >
            <div class="row">
              <h5 class="mr-2">word:</h5>
              <p>{{ worditem.name }}</p>
            </div>
            <div v-show="showdefinition" class="row">
              <h5 class="mr-2">definition:</h5>
              <p>{{ worditem.definition }}</p>
            </div>
            <div>
              <p v-if="worditem.img != ''" class="card border p-2 mt-2">
                <img :src="worditem.img" style="max-width: 8rem" />
              </p>
              <p v-else></p>
            </div>
          </div>
        </div>
        <div class="row justify-content-center">
          <button
            @click="showDef()"
            type="button"
            class="row btn btn-xs border rounded btn-dark mt-2 ml-3"
            style="max-height: 2rem"
            v-show="!showdefinition"
          >
            show definitions
          </button>
          <button
            @click="hideDef()"
            type="button"
            class="row btn btn-xs border rounded btn-dark mt-2 ml-3"
            style="max-height: 2rem"
            v-show="showdefinition"
          >
            hide definitions
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "review",
  mounted() {
    this.$store.dispatch("getWords");
    this.$store.dispatch("getSentences");
    this.$store.dispatch("getSentencewords");
  },
  data() {
    return {
      selectSentence: 0,
      selectWord: 0,
      showdefinition: false,
      showWrds: false,
    };
  },
  watch: {
    selectSentence: function () {
      this.clearWords();
    },
    selectWord: function () {
      this.clearSentences();
    },
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    sentences() {
      let sents = this.$store.state.sentences;
      let sorted = sents.sort((a, b) =>
        a.text.toLowerCase() > b.text.toLowerCase() ? 1 : -1
      );
      return sorted;
    },
    words() {
      let sents = this.$store.state.words;
      let sorted = sents.sort((a, b) =>
        a.name.toLowerCase() > b.name.toLowerCase() ? 1 : -1
      );
      return sorted;
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
    showWords() {
      this.showWrds = true;
      this.$store.dispatch("getWordsBySentence", this.selectSentence.id);
    },
    showDef() {
      this.showdefinition = true;
    },
    hideDef() {
      this.showdefinition = false;
    },
    clearWords() {
      this.showWrds = false;
    },
    clearSentences() {},
  },
};
</script>
