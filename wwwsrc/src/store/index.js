import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";
// import { KeepStore } from './KeepStore'

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
    publicKeeps: []
  },
  mutations: {
    setPublicKeeps(state, keeps){
      state.publicKeeps = keeps;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getAllKeeps({commit, dispatch}){
      try {
          let res = await api.get("keeps");
          commit("setPublicKeeps",res.data);
      } catch (error) {
          console.error(error);
      }
  },
    async addKeep({commit,dispatch}, newKeep){
      try {
        let res = await api.post("keeps",newKeep);
        dispatch("getAllKeeps");
        return res.data;
      } catch (error) {
        console.error(error);
      }
    }

  },
  modules: {
    // KeepStore,
  }
});
