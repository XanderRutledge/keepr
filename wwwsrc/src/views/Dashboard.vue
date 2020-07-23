<template>
  <div class="dashboard container-fluid bg-info">
    <div class="row text-center text-white">
      <div class="col">
        <h1>Your Keeps</h1>
      </div>
    </div>

<div class="row">
      <div class="col-12 justify-content-center list-container md-px-5">
      <div id="keeps" class="card-columns p-2" style="column-gap: 2rem;">
        <userKeep v-for="userKeep in userKeeps" :key="userKeep.id" :userKeep="userKeep" />
      </div>
      </div>
  </div>


<div class="row text-center">
  <div class="col">
  <button
          type="button"
          class="btn btn-primary btn-lg shadow my-1"
          data-toggle="modal"
          data-target="#myModal"
          v-if="$auth.isAuthenticated"
        >
          <h2>New Vault</h2>
        </button>
    
      <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header bg-primary">
              <h4 class="modal-title text-white">New Vault</h4>
              <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body shadow-sm container text-secondary">
              <!-- NOTE add submit method here -->
              <form @submit.prevent="addVault">
                <div class="row justify-content-center">
                  <div class="col text-center">
                    <h5 class="text-dark">Name:</h5>
                    <input type="text" placeholder="Title" required v-model="newVault.name" />
                  </div>
                </div>
                <div class="row justify-content-center mt-3">
                  <div class="col text-center">
                    <h5 class="text-dark">Description:</h5>
                    <textarea
                      class="m-3"
                      rows="3"
                      type="text"
                      placeholder="whats this?"
                      required
                      v-model="newVault.description"
                      style="width:90%;"
                    />
                  </div>
                </div>
               
                <div class="row mt-3 align-items-end">
                  
                  <div class="col text-center">
                    <button type="submit" class="btn btn-info btn-lg">Create Vault</button>
                  </div>
                </div>
              </form>
            </div>
            <div class="modal-footer bg-primary shadow-sm">
              <button type="button" class="btn btn-light" data-dismiss="modal">Cancel</button>
            </div>
          </div>
          </div>
          </div>
      </div>
      </div>



<vault v-for="vault in vaults" :key="vault.id" :vault="vault"/>

  </div>
</template>

<script>
import UserKeep from "@/components/UserKeepsComponent.vue";
import Vault from "@/components/VaultComponent.vue"
export default {
  name:"Dashboard",
    data(){
    return {
      newVault: {},
    }
  },
  async mounted() {
    await this.$store.dispatch("getKeepsByUser"),
    await this.$store.dispatch("getVaults")
  },
  computed: {

    userKeeps(){
      return this.$store.state.userKeeps;
    },
    vaults(){
      return this.$store.state.vaults;
    }

  },
  methods:{
  addVault(){
      if(this.newVault.isPrivate == "false"){
        this.newVault.isPrivate=false;
      }
      else {this.newVault.isPrivate = true}
      this.$store.dispatch("addVault",{...this.newVault})
      this.newVault={};
      $("#myModal").modal("hide");
    }
  },
  components:{
    UserKeep,
    Vault
  }
};
</script>

<style></style>
