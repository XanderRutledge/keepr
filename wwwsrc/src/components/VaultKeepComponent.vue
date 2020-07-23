<template>
    <div class = "vaultKeep rounded-lg text-center">
     <!-- <h3>{{vaultKeep.name}}</h3> -->

<div class=" card rounded-lg bg-light" style="max-width: 30rem;">
            <img :src="vaultKeep.img" class="card-img-top p-2 bg-primary" alt="..." />
        
        <div class ="card-body bg-primary text-center text-white">
            <h3>{{vaultKeep.name}}</h3>
            <p>{{vaultKeep.description}}</p>
            <h5>{{vaultKeep.views}} <i class="far fa-eye"></i> | {{vaultKeep.keeps}} <i class="fas fa-chess-rook"></i> </h5>
            <h5>{{isPrivate(vaultKeep)}}</h5>
            <button type="button" @click="deleteVK(vaultKeep.id)" class="btn btn-danger">Delete </button>
           <div>
                
            </div>
          </div>
      </div>



    </div>
    
</template>

<script>
export default {
    name: "vaultKeep",
    props:["vaultKeep"],
    data(){
        return {};
},
mounted(){},
computed:{},
methods:{
isPrivate(vaultKeep){
    if (vaultKeep.isPrivate==true){
        return "Private"
    } else {return "Public"}
},
deleteVK(VKid){
this.$store.dispatch("deleteVK", VKid)}
},

components:{}
};
</script>