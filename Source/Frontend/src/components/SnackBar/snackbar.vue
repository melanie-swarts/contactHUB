
<template>
  <v-snackbar
    v-model="snackbar.show"
    :color="snackbar.color"
    :timeout="timeout"
    top
    right
  >
    {{ snackbar.message }}
    <v-btn
      color="white"
      text
      @click.native="snackbar.show = false"
    >
      Close
    </v-btn>
  </v-snackbar>
</template>

<script>
import { mapState } from 'vuex'

export default {
  data: () => ({
    timeout: 4000
  }),
  computed: {
    ...mapState(['snackbar'])
  }

}
</script>

<style>
</style>
