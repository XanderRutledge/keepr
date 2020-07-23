<template>

    <div class = "keep rounded-lg">
        <div class=" card rounded-lg bg-light" style="max-width: 30rem;">
            <img :src="keep.img" class="card-img-top p-2 bg-primary" alt="..." />
        
        <div class ="card-body bg-primary text-center text-white">
            <h3>{{keep.name}}</h3>
            <p>{{keep.description}}</p>
            <h5>{{keep.views}} <i class="far fa-eye"></i> | {{keep.keeps}} <i class="fas fa-chess-rook"></i> </h5>
            <div>
                <h5>Add to Vault:</h5>
                    <button v-for="vault in vaults" :key="vault.id" :vault="vault" @click="addVK(keep.id,vault.id)">
                     {{vault.name}}</button>
                
            </div>
        </div></div>
    </div>
</template>

<script>
export default {
    name: "keep",
    props:["keep"],
    data(){
        return {
            newVK:{}
        };
},
mounted(){},
computed:{
     vaults(){
      return this.$store.state.vaults;
    }
},
methods:{
 addVK(keepId,vaultId){
this.newVK.keepId=keepId
this.newVK.vaultId=vaultId
this.$store.dispatch("addVK",this.newVK);
      $("#myModal").modal("hide");
      this.newVK={}
    }
},
components:{}
    };
</script>