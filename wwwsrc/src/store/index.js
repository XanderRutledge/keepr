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
    publicKeeps: [],
    userKeeps:[],
    vaults:[],
    vaultKeeps:[]
  },
  mutations: {
    setPublicKeeps(state, keeps){
      state.publicKeeps = keeps;
    },
    setUserKeeps(state,keeps){
      state.userKeeps = keeps;
    },
    setVaults(state, vaults){
      state.vaults = vaults;
    },
    addVaultKeeps(state, vaultKeeps ){
      state.vaultKeeps = vaultKeeps
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

async getKeepsByUser({commit,dispatch}){
  try {
    let res = await api.get("keeps/user")
    commit("setUserKeeps",res.data)
  } catch (error) {
    console.error(error)
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
    },

    async deleteKeep({commit,dispatch}, id){
      try {
        let res = await api.delete("keeps/" + id)
        dispatch("getKeepsByUser")
      } catch (error) {
        console.error(error);
      }
    },

    async getVaults({commit,dispatch}){
      try {
        let res = await api.get("vaults/user");
        commit("setVaults",res.data)
      } catch (error) {
        console.error(error);
      }
  },

  async addVault({commit,dispatch}, newVault){
    try {
      let res = await api.post("vaults",newVault);
      dispatch("getVaults");
      return res.data;
    } catch (error) {
      console.error(error);
    }
  },

  async deleteVault({commit,dispatch}, id){
    try {
      let res = await api.delete("vaults/" + id)
      dispatch("getVaults")
    } catch (error) {
      console.error(error);
    }
  },

  async addVK({commit,dispatch}, newVaultKeep){
    try {
      let res = await api.post("vaultkeeps", newVaultKeep)

    } catch (error) {
      console.error(error);
    }
  },

  async getKeepsforVault({commit,dispatch}, vaultId){
    try {
      let res = await api.get("vaults/" + vaultId + "/keeps")
        commit("addVaultKeeps",res.data)
      
    } catch (error) {
      console.error(error);
    }
  },
  async deleteVK({commit,dispatch}, VKid){
    try {
      let res = await api.delete("vaultkeeps/"+ VKid)
    } catch (error) {
      console.error(error);
    }
  }

  },
  modules: {
    // KeepStore,
  }
});
