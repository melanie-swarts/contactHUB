<template>
  <div>
    <div>
      <v-card>
        <v-app-bar class="secondary elevation-0">
          <v-icon large class="dialogYN">mdi-alert-question-outline</v-icon>
          <v-card-title class="headline dialogYN">{{ heading }}</v-card-title>
        </v-app-bar>
        <v-spacer />
        <v-card-text class="text-subtitle-1">{{ message }}</v-card-text>
        <v-card-text v-if="message2.length > 0" class="text-subtitle-1">{{ message2 }}</v-card-text>
        <v-card-text v-if="errorMessage.length > 0"><v-alert dense type="error" outlined>{{ errorMessage }}</v-alert></v-card-text>
        <v-card-text>
          <v-select
            v-model="model"
            :label="label"
            :items="items"
            @change="$emit('select-change', model)"
          />
        </v-card-text>

        <v-card-actions class="grey lighten-2">
          <v-spacer/>
          <v-btn text-color="primary" text @click="$emit('close-select-dialog')">cancel</v-btn>
          <v-btn color="primary" text @click="$emit('continue-process', model)">ok</v-btn>
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
    items: {
      type: Array,
      default: () => { [] }
    },
    label: {
      type: String,
      default: ''
    },
    vModel: {
      type: String,
      default: ''
    },
    errorMessage: {
      type: String,
      default: ''
    }
  },
  data() {
    return {
      dialog: false,
      confirm: false,
      model: this.vModel
    }
  },
  methods: {
    selectChange() {
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
