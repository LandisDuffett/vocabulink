<template>
  <div class="home">
    <h4 class="ml-2 mt-3">Sentence:</h4>
    <div class="row ml-5 mt-4">
      <form>
        <label for="sentence" class="mr-5">Load a sentence:</label>
        <select
          v-model="selectSentence"
          class="rounded"
          id="sentence"
          style="width: 60vw"
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
      <form @submit.prevent="createSentence()">
        <label for="sentence">Or add new sentence:</label>
        <input
          type="text"
          id="sentence"
          name="sentence"
          v-model="newSentence.text"
          class="my-3 mx-2 rounded"
          style="width: 60vw"
        /><br />
      </form>
    </div>
    <h4 class="ml-2 mt-3">Word:</h4>
    <div class="row ml-5 mt-4">
      <form>
        <label for="word" class="mr-3"
          >Load a word to link to this sentence:</label
        >
        <select
          v-model="selectWord"
          class="rounded"
          id="sentence"
          style="width: 40vw"
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
        <label for="sentence">Or add new word to link to sentence:</label>
        <input
          type="text"
          id="sentence"
          name="sentence"
          v-model="newSentence.text"
          class="my-3 mx-2 rounded"
          style="width: 40vw"
        />
        <input
          type="submit"
          value="add word"
          class="mx-2 btn border btn-danger rounded"
          style="max-height: 2rem"
        />
      </form>
    </div>
    <div class="row justify-content-center">
      <button
        @click="addLink()"
        type="button"
        class="row btn btn-xs border rounded btn-dark m-1 p-2"
      >
        create connection
      </button>
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
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    sentences() {
      return this.$store.state.sentences;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
};
</script>
