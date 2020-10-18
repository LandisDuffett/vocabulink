<template>
  <div class="manage">
    <!--create locus lists begin-->
    <div>
      <h2 class="ml-4">Sentences</h2>
      <div>
        <form>
          <label for="activestudy" class="ml-4"
            >Select a sentence to edit or delete:</label
          >
          <select v-model="edSentence" id="editSentence" class="ml-2">
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
    </div>
    <div>
      <form @submit.prevent="editSentence()">
        <input
          type="text"
          class="ml-4 m-1 rounded"
          id="editsentence"
          name="editsentence"
          v-model.lazy="edSentence.text"
          style="width: 80vw"
        />
        <div class="row ml-3">
          <input
            type="submit"
            value="submit edit"
            class="mx-2 mt-2 btn border btn-danger rounded"
            style="max-height: 2rem"
          />
          <button
            @click="deleteSentence()"
            type="button"
            class="row btn btn-xs border rounded btn-dark mt-2 ml-3"
            style="max-height: 2rem"
          >
            delete sentence
          </button>
        </div>
      </form>
    </div>
    <div>
      <h2 class="ml-4 mt-5">Words</h2>
      <div>
        <form>
          <label for="editword" class="ml-4"
            >Select a word to edit or delete:</label
          >
          <select v-model="edWord" id="editWord" class="ml-2">
            <option
              v-for="word in words"
              :word="word"
              :key="word.id"
              :value="word"
            >
              {{ word.name }}
            </option>
          </select>
        </form>
      </div>
    </div>
    <div>
      <form @submit.prevent="editWord()">
        <div class="row ml-4">
          <label for="editwordname" class="mt-1">word:</label>
          <input
            type="text"
            class="ml-4 m-1 rounded boxborder rounded"
            id="editwordname"
            name="editwordname"
            v-model.lazy="edWord.name"
            style="width: 62vw"
          />
        </div>
        <br />
        <div class="row ml-4">
          <label for="editwordname" class="mt-1">definition:</label>
          <input
            type="text"
            class="ml-4 m-1 rounded boxborder rounded"
            id="editwordname"
            name="editwordname"
            v-model.lazy="edWord.definition"
            style="width: 60vw"
          />
        </div>
        <br />
        <div class="row ml-4">
          <label for="editwordname" class="mt-1">image URL:</label>
          <input
            type="text"
            class="ml-4 m-1 rounded boxborder rounded"
            id="editwordname"
            name="editwordname"
            v-model.lazy="edWord.img"
            style="width: 59vw"
          />
        </div>
        <br />
        <div class="row ml-3">
          <input
            type="submit"
            value="submit edit"
            class="mx-2 btn border btn-danger rounded"
            style="max-height: 2rem"
          />
          <button
            @click="deleteWord()"
            type="button"
            class="row btn btn-xs border rounded btn-dark ml-3"
            style="max-height: 2rem"
          >
            delete word
          </button>
        </div>
      </form>
    </div>
    <div class="ml-4 mt-5">
      <h2>Links</h2>
      <p class="mb-4">Sever any link between sentence and word:</p>
      <form>
        <label for="sentence" class="mr-2"
          >select sentence to sever links to words:</label
        >
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
      <div>
        <div
          v-for="worditem in worditems"
          :worditem="worditem"
          :key="worditem.id"
          :value="worditem.id"
        >
          <div class="card m-2" style="width: 30vw">
            <span class="ml-3">{{ worditem.name }}</span>
            <button
              @click="severLink(worditem.id)"
              type="button"
              style="max-height: 2rem; width: 20vw"
              class="row btn border rounded btn-dark ml-3 m-1 p-2"
            >
              <div class="mb-2">Sever Link</div>
            </button>
          </div>
        </div>
      </div>
    </div>

    <div class="row ml-4 mt-4">
      <form>
        <label for="word" class="mr-2"
          >select by word to sever links to sentence:</label
        >
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
      <div>
        <div
          v-for="sentenceitem in sentenceitems"
          :sentenceitem="sentenceitem"
          :key="sentenceitem.id"
          :value="sentenceitem.id"
        >
          <div class="card m-2" style="width: 30vw">
            <span class="ml-3">{{ sentenceitem.text }}</span>
            <button
              @click="deleteLink(sentenceitem.id)"
              type="button"
              style="max-height: 2rem; width: 20vw"
              class="row btn border rounded btn-dark ml-3 m-1 p-2"
            >
              <div class="mb-2">Sever Link</div>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "manage",
  mounted() {
    this.$store.dispatch("getWords");
    this.$store.dispatch("getSentences");
    this.$store.dispatch("getSentencewords");
  },
  data() {
    return {
      updateSentence: {
        text: "",
      },
      updateWord: {
        name: "",
        definition: "",
        img: "",
      },
      edSentence: {},
      edWord: {},
      selectSentence: 0,
      selectWord: 0,
    };
  },
  watch: {
    selectSentence: function () {
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
    editWord() {
      this.$store.dispatch("editWord", this.updateWord);
      this.edWord = {};
    },
    editSentence() {
      this.$store.dispatch("editSentence", this.edSentence);
      this.edSentence = {};
    },
    async severLink(id) {
      let sw = this.sentencewords.find(
        (s) => s.sentenceId == this.selectSentence && s.wordId == id
      );
      let num = sw.id;
      await this.$store.dispatch("deleteSentenceword", num);
      this.returnWords();
    },
    async deleteLink(id) {
      let sw = this.sentencewords.find(
        (s) => s.sentenceId == id && s.wordId == this.selectWord
      );
      let num = sw.id;
      await this.$store.dispatch("deleteSentenceword", num);
      this.returnSentences();
    },
    returnWords() {
      this.$store.dispatch("getWordsBySentence", this.selectSentence);
    },
    returnSentences() {
      this.$store.dispatch("getSentencesByWord", this.selectWord);
    },
  },
};
</script>