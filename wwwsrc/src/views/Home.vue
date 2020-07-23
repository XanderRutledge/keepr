<template>
  <div class="home container-fluid bg-info">
    <div class="row py-3 text-white">
      <div class="col text-center">
        <h1>Keepr <i class="fas fa-chess-rook"></i></h1>
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
          <h2>New Keep</h2>
        </button>
    
      <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header bg-primary">
              <h4 class="modal-title text-white">New Keep</h4>
              <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body shadow-sm container text-secondary">
              <!-- NOTE add submit method here -->
              <form @submit.prevent="addKeep">
                <div class="row justify-content-center">
                  <div class="col text-center">
                    <h5 class="text-dark">Name:</h5>
                    <input type="text" placeholder="Title" required v-model="newKeep.name" />
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
                      v-model="newKeep.description"
                      style="width:90%;"
                    />
                  </div>
                </div>
                <div class="row justify-content-center">
                  <div class="col text-center">
                    <h5 class="text-dark">Image URL:</h5>
                    <input type="text" placeholder="Image Link" v-model="newKeep.img" />
                  </div>
                </div>
                <div class="row mt-3 align-items-end">
                  <div class="col">
                    <h5 class="text-dark">public or private</h5>
                    <select v-model="newKeep.isPrivate">
                     <option disabled value="">Please select one</option>
                    <option value="true">Private</option>
                    <option value="false">Public</option>
                    </select>
                  </div>
                  <div class="col text-center">
                    <button type="submit" class="btn btn-info btn-lg">Create Keep</button>
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

    <div class="row">
      <div class="col-12 list-container md-px-5">
      <div id="keeps" class="card-columns p-2" style="column-gap: 1rem;">
        <keep v-for="keep in keeps" :key="keep.id" :keep="keep" />
      </div>
      </div>
  </div>
  </div>


</template>

<script>
import Keep from "@/components/KeepComponent.vue"
export default {
  name: "home",
  data(){
    return {
      newKeep: {}
    }
  },
  async mounted(){
    await this.$store.dispatch("getAllKeeps");
    // await this.$store.dispatch("getVaults")

  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps(){
      return this.$store.state.publicKeeps;
    }

  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    addKeep(){
      if(this.newKeep.isPrivate == "false"){
        this.newKeep.isPrivate=false;
      }
      else {this.newKeep.isPrivate = true}
      this.$store.dispatch("addKeep",{...this.newKeep})
      this.newKeep={};
      $("#myModal").modal("hide");
    }
  },
  components:{
    Keep
  }
};
</script>
