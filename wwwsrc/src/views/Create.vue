<template>
  <div class="home">
    <h4 class="ml-2 mt-3">Sentence:</h4>
    <div class="row ml-5 mt-4">
      <form>
        <label for="sentence" class="mr-2">Load a sentence:</label>
        <select
          v-model="selectSentence"
          class="rounded"
          id="sentence"
          style="width: 82vw"
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
    <div class="row ml-5">
      <form>
        <label for="sentence">Or add new sentence:</label>
        <input
          type="text"
          id="sentence"
          name="sentence"
          v-model="newSentence.text"
          class="my-3 mx-2 rounded"
          style="width: 80vw"
        /><br />
      </form>
    </div>
    <h4 class="ml-2 mt-3">Word:</h4>
    <div class="row ml-5 mt-4">
      <form>
        <label for="word" class="mr-2"
          >Load a word to link to this sentence:</label
        >
        <select
          v-model="selectWord"
          class="rounded"
          id="sentence"
          style="width: 73vw"
        >
          <option
            v-for="word in words"
            :word="word"
            :key="word.id"
            :value="word.id"
          >
            {{ sentence.text }}
          </option>
        </select>
      </form>
    </div>
    <div class="row ml-5">
      <form @submit.prevent="addWord()">
        <label for="wordname">Or add new word to link to sentence:</label>
        <input
          type="text"
          id="wordname"
          name="wordname"
          v-model="newWord.text"
          class="my-3 mx-2 rounded"
          style="width: 73vw"
        /><br />
        <label for="worddef">definition:</label>
        <input
          type="text"
          id="worddef"
          name="worddef"
          v-model="newWord.definition"
          class="my-3 mx-2 rounded"
          style="width: 86vw"
        /><br />
        <label for="wordimage">image URL:</label>
        <input
          type="text"
          id="wordimage"
          name="wordimage"
          v-model="newWord.image"
          class="my-3 mx-2 rounded"
          style="width: 85vw"
        /><br />
        <div class="col">
          <div class="row mb-3 ml-1">
            <input
              type="submit"
              value="ADD WORD (click to link a word to sentence showing above; you may add more than one word)"
              class="btn border btn-danger rounded"
              style="max-height: 2rem; width: 90vw"
            />
          </div>
        </div>
      </form>
      <div class="row ml-3">
        <button
          @click="addLink()"
          type="button"
          style="max-height: 2rem; width: 90vw"
          class="row btn btn-xs border rounded btn-dark m-1 p-2"
        >
          CREATE CONNECTION (click to confirm a link between sentence showing
          above and all words added)
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "create",
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
    addWord() {},
    addLink() {},
  },
};
</script>
