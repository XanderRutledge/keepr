<template>
<div class="vault row" >
    <div class="col justify-content-center text-center">
            
        <router-link :to="{ name: 'vault', params: { vaultId: vault.id } }"><h3 class="text-white">{{vault.name}} - {{vault.description}}</h3></router-link>  <button type="button" @click="deleteVault(vault.id)" class="btn btn-danger">Delete</button>
            
        </div>
    </div>
</template>

<script>
export default {
    name: "vault",
    props:["vault"],
    data(){
        return {};
},
async mounted(){
},
// computed(){},
methods:{
deleteVault(id){
this.$store.dispatch("deleteVault", id)
}
},
components:{}
    };
</script>