<template>
  <div>
    <div class="box-info">
      <v-layout class="button-layout" align-end justify-end>
        <router-link :to="{ name: 'NewCalendarEventType' }">
          <v-btn
            class="ma-2"
            dark
            color="#3C565B"
            tile
          >Add New Calendar Event Type</v-btn>
        </router-link>
      </v-layout>
      <div class="box-form">
        <v-card>
          <v-card-title>
            <v-spacer/>
            <v-text-field
              v-model="search"
              append-icon="search"
              label="Search"
              single-line
              hide-details
            />
          </v-card-title>
          <v-data-table
            :headers="headers"
            :items="calendarEventTypes.calendarEventTypes"
            :search="search"
            item-key="Id"
            class="elevation-0"
          >
            <template v-slot:body="{ items }">
              <tbody>
                <tr v-for="item in items" :key="item.CalendarEventTypeId" @click="rowSelected(item.Id)">
                  <td>{{ item.EventTypeName }}</td>
                  <td>{{ item.Enabled }}</td>
                </tr>
              </tbody>
            </template>
            <v-alert
              slot="no-results"
              :value="true"
              color="error"
              icon="warning"
            >Your search for "{{ search }}" found no results.</v-alert>
          </v-data-table>
        </v-card>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import store from '@/store/store'

function getCalendarEventTypes(routeTo, next) {
  store
    .dispatch('calendarEventTypes/fetchCalendarEventTypes')
    .then(() => {
      next()
    })
}

export default {
  name: 'CalenderEventTypes',
  data() {
    return {
      search: '',
      headers: [
        { text: 'Calendar Event Type', align: 'left', value: 'Name' },
        { text: 'Calendar Event Type Enabled', align: 'left', value: 'Enabled' }
      ]
    }
  },
  beforeRouteEnter(routeTo, routeFrom, next) {
    getCalendarEventTypes(routeTo, next)
  },
  computed: {
    ...mapState(['calendarEventTypes'])
  },
  methods: {
    rowSelected(calendarEventTypeId) {
        this.$router.push({ name: 'CalendarEventType', params: { id: calendarEventTypeId }})
    }
  }
}
</script>
