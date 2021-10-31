<template>
  <div>

    <v-card>

      <v-card-title class="accent">{{ conflicts1.length }} Conflicts found</v-card-title>
      <v-list>
        <v-list-item v-for="(conflict, i) in conflicts1" :key="i" two-line>
          <v-list-item-content>
            <v-list-item-title>{{ conflict.StartDate }}</v-list-item-title>
            <v-list-item-subtitle>{{ conflict.Description }}</v-list-item-subtitle>
          </v-list-item-content>
          <v-list-item-action>
            <v-btn icon @click="openConflict(conflict)">
              <v-icon color="grey lighten-1">mdi-open-in-new</v-icon>
            </v-btn>
          </v-list-item-action>

        </v-list-item>
      </v-list>
      <v-card-actions class="grey lighten-2">
        <v-spacer/>
        <v-btn
          color="primary"
          text
          right
          @click="$emit('close-conflict-dialog')"
        >
          close
        </v-btn>
      </v-card-actions>
    </v-card>
  </div>

</template>

<script>
export default {
  props: {
    conflicts1: {
      type: Array,
      default: () => { [] }
    }
  },
  data: function() {
    return {
      conflicts: this.conflicts1
    }
  },
  methods: {
    openConflict(conflict) {
      this.$emit('view-conflict', conflict)
    }
  }

}
</script>

<style scoped>

</style>
