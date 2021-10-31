<template>
  <v-app>
    <v-content>
      <div id="app">
        <router-view/>
        <Snackbar/>
      </div>
    </v-content>
  </v-app>
</template>

<script>
import Snackbar from '@/components/Snackbar/snackbar.vue'
export default {
  name: 'App',
  components: {
    Snackbar
  }
}
</script>
