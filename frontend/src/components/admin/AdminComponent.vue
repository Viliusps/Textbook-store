<script setup>
import router from "../../router.ts";
</script>
<script>
import Axios from "axios";

export default {
  data() {
    return {
      info: [],
      date: ""
    };
  },
  mounted() {
    if(parseInt(localStorage.getItem('usertype')) !== 2)
    {
      router.router.push('/');
    }
    }
};
</script>

<template>
</template>
<style scoped>
div{
  text-align: center;
  width:100%;
}
.warning{
  color: red;
}
 </style>
