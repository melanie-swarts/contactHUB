<template>
  <div >
    <v-container class="ma-5">

      <v-row justify="center">
        <v-expansion-panels accordion flat>
          <v-expansion-panel v-if="history.length > 0" ref="exPanel" @change="panelChanged()">
            <v-expansion-panel-header disable-icon-rotate>

              <span class="text-center subtitle-1 primary--text">
                <v-btn v-if="!showHistory" dark text medium color="blue lighten-4" >
                  <v-icon left>
                    mdi-history
                  </v-icon>
                  View History ({{ history.length }})
                </v-btn>
                <v-btn v-if="showHistory" dark text medium color="grey lighten-1" >
                  <v-icon left>
                    mdi-history
                  </v-icon>
                  Hide History
                </v-btn>
              </span>
              <template v-slot:actions>
                <v-icon color="error">
                  mdi-blank
                </v-icon>
              </template>
            </v-expansion-panel-header>
            <v-expansion-panel-content>
              <v-data-table
                :headers="headers"
                :items="history"
                :items-per-page="5"
                :sort-by="sortBy"
                :sort-desc="sortDesc"
                class="elevation-1"
              />
            </v-expansion-panel-content>
          </v-expansion-panel>
        </v-expansion-panels>
      </v-row>
    </v-container>
  </div>
</template>

<script>

export default {
  name: 'LookupHistory',
  props: {
    history: {
      type: Array,
      default: null,
      required: true
    }
  },
  data() {
    return {
      search: '',
      headers: [
        {
          text: 'Timestamp',
          align: 'start',
          value: 'doc.TimeStamp'
        },
        { text: 'Action', value: 'doc.Action' },
        { text: 'Field', value: 'doc.Field' },
        { text: 'Old Value', value: 'doc.OldValue' },
        { text: 'New Value', value: 'doc.NewValue' },
        { text: 'Changed By', value: 'doc.ChangedBy' }
      ],
      sortBy: 'doc.TimeStamp',
      sortDesc: true,
      showHistory: false
    }
  },
  methods: {
    panelChanged() {
      this.showHistory = !this.showHistory
    }
  }
}
</script>
