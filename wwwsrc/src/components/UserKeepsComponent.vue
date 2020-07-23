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
               <form @submit.prevent="addVK(userKeep.id)">
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <button class="btn btn-info" type="sumbit">Vault</button>
                </div>
                <select v-model="newVK.vaultId" class="custom-select">
                  <option selected>Choose...</option>
                    <option v-for="vault in vaults" :key="vault.id" :vault="vault">
                     {{vault.name}}</option>
                     </select>
                
                </div></form>
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
 addVK(vaultId){
        
  console.log(vaultId); 

      this.newVk={};
      $("#myModal").modal("hide");
    }
},
components:{}
    };
</script>