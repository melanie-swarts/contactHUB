<template>
  <div>
    <div>
      <v-card>
        <v-app-bar class="confirmation elevation-0">
          <v-icon large class="dialogYN">mdi-alert-circle-outline</v-icon>
          <v-card-title class="headline dialogYN">{{ heading }}</v-card-title>
        </v-app-bar>
        <v-spacer />
        <v-card-text class="text-subtitle-1">{{ message }}</v-card-text>
        <v-card-text class="text-subtitle-1">{{ message2 }}</v-card-text>
        <v-card-actions class="grey lighten-3">
          <v-spacer/>
          <v-btn text-color="primary" text @click="$emit('close-confirm-dialog')">NO</v-btn>
          <v-btn color="primary" text @click="$emit('continue-process', menuId)">YES</v-btn>
        </v-card-actions>
      </v-card>
    </div>

  </div>

</template>

<script>
export default {
  props: {
    heading: {
      type: String,
      default: 'Heading'
    },
    message: {
      type: String,
      default: 'Message'
    },
    message2: {
      type: String,
      default: 'Message 2'
    },
    menuId: {
      type: Number,
      default: 0,
      required: true
    }
  },
  data() {
    return {
      dialog: false,
      confirm: false
    }
  }
}
</script>

<style scoped>
  .dialogYN {
    background-color: transparent;
    color: white;
  }
</style>
