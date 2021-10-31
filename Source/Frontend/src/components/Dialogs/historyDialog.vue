<template>
  <div>
    <div>
      <v-card>
        <v-card-title class="headline dialogYN">{{ heading }}</v-card-title>
        <v-spacer />
        <v-data-table
          :headers="headers"
          :items="history"
          :items-per-page="5"
          class="elevation-1"
        />
        <v-spacer />
        <v-card-text class="text-subtitle-1">{{ message }}</v-card-text>
        <v-card-actions>
          <v-spacer/>
          <v-btn text-color="primary" text @click="$emit('close-confirm-dialog')">CLOSE</v-btn>
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
    history: {
      type: Array,
      required: false,
      default: null
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
      required: false
    }
  },
  data() {
    return {
      headers: [
        {
          text: 'Timestamp',
          align: 'start',
          value: 'doc.TimeStamp'
        },
        { text: 'Action', value: 'doc.action' },
        { text: 'Field', value: 'doc.Field' },
        { text: 'Old Value', value: 'doc.OldValue' },
        { text: 'New Value', value: 'doc.NewValue' },
        { text: 'Changed By', value: 'doc.ChangedBy' }
      ],
      dialog: false,
      confirm: false
    }
  }
}
</script>

<style scoped>
  .dialogYN {
    background-color: cornflowerblue;
    color: white;
  }
</style>
