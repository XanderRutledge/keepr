<template>
    <div class = "userKeep rounded-lg text-center">
        <div class=" card rounded-lg bg-light" style="max-width: 30rem;">
            <img :src="userKeep.img" class="card-img-top p-2 bg-primary" alt="..." />
        
        <div class ="card-body bg-primary text-center text-white">
            <h3>{{userKeep.name}}</h3>
            <p>{{userKeep.description}}</p>
            <h5>{{userKeep.views}} <i class="far fa-eye"></i> | {{userKeep.keeps}} <i class="fas fa-chess-rook"></i> </h5>
            <h5>{{isPrivate(userKeep)}}</h5>
            <button type="button" @click="deleteKeep(userKeep.id)" class="btn btn-danger">Delete </button>
           <div>
                    <div type="button" v-for="vault in vaults" :key="vault.id" :vault="vault" @click="addVK(userKeep.id,vault.id)">
                     {{vault.name}}</div>
                
            </div>
          </div>
      </div>
    </div>
    
</template>

<script>
export default {
    name: "userKeep",
    props:["userKeep"],
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
isPrivate(userKeep){
    if (userKeep.isPrivate==true){
        return "Private"
    } else {return "Public"}
},
deleteKeep(id){
    if(this.userKeep.isPrivate==true){
this.$store.dispatch("deleteKeep", id)}
else{
    alert("cannot delete public keeps")
}
},
 addVK(userKeepId,vaultId){
this.newVK.keepId=userKeepId
this.newVK.vaultId=vaultId
this.$store.dispatch("addVK",this.newVK);
      $("#myModal").modal("hide");
      this.newVK={}
    }
},
components:{}
    };
</script>