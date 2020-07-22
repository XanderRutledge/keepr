<template>
<div class="vault row" >
    <div class="col">
            
            <h3>{{vault.name}} - {{vault.description}}  <button type="button" @click="deleteVault(vault.id)" class="btn btn-danger">Delete</button></h3>
            
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
mounted(){},
// computed(){},
methods:{
deleteVault(id){
this.$store.dispatch("deleteVault", id)
}
},
components:{}
    };
</script>