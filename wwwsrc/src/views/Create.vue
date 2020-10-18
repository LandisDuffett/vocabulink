<template>
  <div class="home">
    <div class="row ml-5">
      <div class="col">
        <div class="row justify-content-center mr-5">
          <h4>Add Vocabulary</h4>
        </div>
      </div>
      <form @submit.prevent="addSentence()">
        <label for="sentence"><h5>Add new sentence:</h5></label>
        <input
          type="text"
          id="sentence"
          name="sentence"
          onfocus="this.value=''"
          v-model="newSentence.text"
          class="my-3 mx-2 rounded"
          style="width: 80vw"
        /><br />
        <div class="col">
          <div class="row mb-5">
            <input
              type="submit"
              value="ADD SENTENCE"
              class="btn border btn-danger rounded"
              style="max-height: 2rem; width: 92vw"
            />
          </div>
        </div>
      </form>
    </div>
    <div class="row ml-5">
      <form @submit.prevent="addWord()">
        <h5>Add new word:</h5>
        <label for="wordname">word:</label>
        <input
          type="text"
          id="wordname"
          name="wordname"
          v-model="newWord.name"
          class="my-3 mx-2 rounded"
          style="width: 89vw"
        /><br />
        <label for="worddef">definition:</label>
        <input
          type="text"
          id="worddef"
          name="worddef"
          v-model="newWord.definition"
          class="my-3 mx-2 rounded"
          style="width: 87vw"
        /><br />
        <label for="wordimage">image URL:</label>
        <input
          type="text"
          id="wordimage"
          name="wordimage"
          v-model="newWord.img"
          class="my-3 mx-2 rounded"
          style="width: 86vw"
        /><br />
        <div class="col">
          <div class="row mb-3">
            <input
              type="submit"
              value="ADD WORD"
              class="btn border btn-danger rounded"
              style="max-height: 2rem; width: 92vw"
            />
          </div>
        </div>
      </form>
    </div>
    <div class="row justify-content-center mt-3">
      <h4>Create Links</h4>
    </div>
    <div class="row ml-5 mt-2">
      <h5 class="mb-4">Link any sentence with any word that appears in it:</h5>
      <form>
        <label for="sentence" class="mr-2">select a sentence:</label>
        <select
          v-model="selectSentence"
          class="rounded"
          id="sentence"
          style="width: 83vw"
        >
          <option
            v-for="sentence in sentences"
            :sentence="sentence"
            :key="sentence.id"
            :value="sentence.id"
          >
            {{ sentence.text }}
          </option>
        </select>
      </form>
    </div>
    <div class="row ml-5 mt-4">
      <form>
        <label for="word" class="mr-2">select a word:</label>
        <select
          v-model="selectWord"
          class="rounded"
          id="sentence"
          style="width: 85vw"
        >
          <option
            v-for="word in words"
            :word="word"
            :key="word.id"
            :value="word.id"
          >
            {{ word.name }}
          </option>
        </select>
      </form>
    </div>
    <div class="row ml-5">
      <button
        @click="addLink()"
        type="button"
        style="max-height: 2rem; width: 92vw"
        class="row btn btn-xs border rounded btn-dark m-1 p-2"
      >
        CREATE LINK
      </button>
    </div>
  </div>
</template>

<script>
export default {
  name: "create",
  mounted() {
    this.$store.dispatch("getWords");
    this.$store.dispatch("getSentences");
  },
  data() {
    return {
      newSentence: {
        text: "",
      },
      newWord: {
        name: "",
        definition: "",
        img: "",
      },
      selectSentence: 0,
      selectWord: 0,
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    sentences() {
      return this.$store.state.sentences;
    },
    words() {
      return this.$store.state.words;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    async addWord() {
      await this.$store.dispatch("addWord", this.newWord);
      this.newWord.name = "";
      this.newWord.definition = "";
      this.newWord.img = "";
    },
    addSentence() {
      this.$store.dispatch("addSentence", this.newSentence);
    },
    addLink() {
      this.$store.dispatch("addSentenceword", {
        wordId: this.selectWord,
        sentenceId: this.selectSentence,
      });
      this.selectSentence = 0;
      this.selectWord = 0;
    },
  },
};
</script>
