<script setup>
import router from "../../router.ts";
import IconLogin from "../icons/IconLogin.vue";
</script>
<script>
import { store } from "../../store.ts";
const accountaction = () => {
  if (store.userinfo.usertype !== 0) {
    router.router.push("/vartotojas");
  } else {
    router.router.push("/login");
  }
};
const loginaction = () => {
  if (parseInt(store.userinfo.usertype) === 0) {
    router.router.push("/login");
  } else {
    localStorage.clear();
    router.router.push("/login");
    store.setUser(0, "");
  }
};
export default {
  data() {
    return store;
  },
};
</script>

<template>
  <div class="login">
    <div class="account" @click="accountaction">
      <img src="https://thispersondoesnotexist.com/image?1" />
      <div class="text">
        {{ parseInt(store.userinfo.usertype) === 0 ? "Svečias" : store.userinfo.username }}
      </div>
    </div>
    <button @click="loginaction" class="login-button">
      <IconLogin />
    </button>
  </div>
</template>

<style scoped>
.login {
  display: flex;
}

.login-button {
  display: flex;
  padding: 0.5rem 0.5rem;
  border: none;
  margin: auto 0;
  height: fit-content;

  color: var(--color-text);
}

img {
  width: 3rem;
  height: 3rem;
  border-radius: 100%;
  border: solid 2px;
}

.text {
  font-size: 1.25rem;
  font-weight: 350;
  flex: 1;
  margin: auto 0.5rem;
  width: fit-content;
  pointer-events: none;

  color: var(--color-heading);
}

.account {
  display: flex;
  flex-direction: row;
  transition: 0.4s;
  margin: 0.2rem;
  padding: 0.2rem;
  border-radius: 8px;
}

@media (hover: hover) {
  .account:hover {
    background: var(--color-background-mute);
  }

  .login-button:hover {
    background: var(--color-background-mute);
  }
}

.account:active{
  transition: 0s;
  background: var(--color-background-active);
}
</style>
