import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    sentences: [],
    words: [],
    sentencewords: [],
    wordsents: [],
    sentwords: [],
    sentenceindex: 0
  },
  mutations: {
    setSentences(state, sentences) {
      state.sentences = sentences
    },
    setWords(state, words) {
      state.words = words
    },
    setSentencewords(state, sentencewords) {
      state.sentencewords = sentencewords
    },
    setWordsents(state, wordsents) {
      state.wordsents = wordsents
    },
    setSentwords(state, sentwords) {
      state.sentwords = sentwords
    },
    setSentenceindex(state, sentenceindex) {
      state.sentenceindex = sentenceindex
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getSentences({ commit }) {
      await api.get('sentences').then(res => {
        commit('setSentences', res.data)
      })
    },
    async getWords({ commit }) {
      await api.get('words').then(res => {
        commit('setWords', res.data)
      })
    },
    async getSentencewords({ commit }) {
      await api.get('sentencewords').then(res => {
        commit('setSentencewords', res.data)
      })
    },
    addSentence({ dispatch }, data) {
      api.post('sentences', data)
        .then(server => {
          dispatch('getSentences')
        })
    },
    addWord({ dispatch }, data) {
      api.post('words', data)
        .then(server => {
          dispatch('getWords')
        })
    },
    addSentenceword({ dispatch }, data) {
      api.post('sentencewords', data)
        .then(server => {
          dispatch('getSentencewords')
        })
    },
    async getSentencesByWord({ commit }, id) {
      await api.get("words/" + id + "/sentences").then(res => {
        commit('setWordsents', res.data)
      })
    },
    async getWordsBySentence({ commit }, id) {
      await api.get("sentences/" + id + "/words").then(res => {
        commit('setSentwords', res.data)
      })
    },
    async deleteSentenceword({ dispatch }, id) {
      await api.delete("sentencewords/" + id).then(res => {
        dispatch('getSentencewords')
      })
    },
    async editSentence({ dispatch }, data) {
      await api.put("sentences/" + data.id, data).then(res => dispatch('getSentences'))
    },
    advance({ commit, state }) {
      let ind = state.sentenceindex + 1;
      commit('setSentenceindex', ind)
    },
    reset({ commit, state }) {
      let ind = 0;
      commit('setSentenceindex', ind)
    }
  }
})
