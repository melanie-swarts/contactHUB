<template>
  <div>
    <div class="header-container" style="padding-bottom: 20px;">
      <div class="header-text">Lookups</div>
    </div>
    <v-card>
      <v-tabs
        v-model="tab"
        grow
        height="80"
        slider-color="#3C565B"
        slider-size="2"
        @change="tabChanged(tab)"
      >
        <v-tab>
          <div class="wrapper" >
            <div class="info-0">Calendar</div>
          </div>
        </v-tab>
        <v-tab>
          <div class="wrapper" >
            <div class="info-0">To-Do Types</div>
          </div>
        </v-tab>
      </v-tabs>

      <v-tabs-items v-model="tab">
        <!-- Calendar -->
        <v-tab-item>
          <v-card flat style="padding:15px">
            <v-expansion-panels v-model="panel" class="mb-6" accordion focusable>
              <v-expansion-panel>
                <v-expansion-panel-header expand-icon="mdi-menu-down">Calendar Event Types</v-expansion-panel-header>
                <v-expansion-panel-content>
                  <calendar-event-types />
                </v-expansion-panel-content>
              </v-expansion-panel>
            </v-expansion-panels>
          </v-card>
        </v-tab-item>

      </v-tabs-items>
    </v-card>
  </div>
</template>

<script>
import { mapState } from 'vuex'

import moment from 'moment'
import CalendarEventTypes from './calendarEventTypes/index'

export default {
  components: {
    CalendarEventTypes
  },
  data() {
    return {
      search: '',
      tab: this.$store.state.lookupTab,
      formattedDate: null,
      panel: 0
    }
  },
  computed: {
    ...mapState(['calendarEventTypes'])
  },
  created() {
    this.$store.dispatch('calendarEventTypes/fetchCalendarEventTypes')
  },
  methods: {
    formatDate(date) {
      return moment(date, 'YYYY-MM-DD').format('DD MMMM YYYY')
    },
    tabChanged(e) {
      this.$store.state.lookupTab = e
    }
  }
}
</script>

<style rel="stylesheet/scss" lang="scss">
.primary{
    background-color: #3C565B !important;
}

.basil {
  background-color: #FFFBE6 !important;
}
.basil--text {
  color: #356859 !important;
}
.wrapper{
    height:auto;
}

.info-1{
  font-size: 12px;
  font-weight: 400;
  color: gray;
  float:left;
  clear: left;
  padding-left: 10px;
}

.info-0{
    font-size: 12px;
    font-weight: 400;
    color: gray;
    float:left;
    clear: left;
    padding-left: 10px;
    padding-bottom: 5px;
}

.info-container {
  background-color: rgb(240, 242, 245);

  .info-dashboard-text{
    text-align: center;
    color: #999;
    font-size: 45px;
    margin-top: 15px;
    padding-bottom: 10px;
  }
}

</style>
