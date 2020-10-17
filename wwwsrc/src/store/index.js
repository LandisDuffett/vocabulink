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
    sentencewords: []
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
      api.post('sentenceword', data)
        .then(server => {
          dispatch('getSentencewords')
        })
    },
  }
});
