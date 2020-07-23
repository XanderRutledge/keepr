<template>
  <div class="vault container-fluid bg-info">
       <div id="keeps" class="card-columns p-2" style="column-gap: 2rem;">
<vaultKeep v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id" :vaultKeep="vaultKeep"/>
       </div>
  </div>
</template>

<script>
import VaultKeep from "@/components/VaultKeepComponent.vue";
export default {
  name:"Vault",
    data(){
    return {
      newVault: {},
    }
  },
  async mounted() {
    await this.$store.dispatch("getKeepsforVault",this.$route.params.vaultId)
  },
  computed: {

      vaultKeeps(){
          return this.$store.state.vaultKeeps
      }

  },
  methods:{
  },
  components:{
    VaultKeep
    
  }
};
</script>

<style></style>
