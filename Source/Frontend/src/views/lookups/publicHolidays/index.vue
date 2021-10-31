<template>
  <div>
    <div class="box-info">
      <v-layout class="button-layout" align-end justify-end>
        <router-link :to="{ name: 'NewPublicHoliday' }">
          <v-btn

            class="ma-2"
            dark
            color="#3C565B"
            tile
          >Add New Public Holiday</v-btn>
        </router-link>
      </v-layout>
      {{ publicHolidays.publicHolidays[0] }}
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
            :items="publicHolidays.publicHolidays"
            :search="search"
            item-key="PublicHolidayId"
            class="elevation-1"
          >
            <template v-slot:body="{ items }">
              <tbody>
                <tr v-for="item in items" :key="item.PublicHolidayId" @click="rowSelected(item.PublicHolidayId)">
                  <td>{{ item.name }}</td>
                  <td>{{ item.date }}</td>
                  <td>{{ item.fixed }}</td>
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

function getPublicHolidays(routeTo, next) {
  store
    .dispatch('publicHolidays/fetchPublicHolidays')
    .then(() => {
      next()
    })
}

export default {
  name: 'PublicHolidays',
  data() {
    return {
      search: '',
      headers: [
        { text: 'Public Holiday Name', align: 'left', value: 'Name' },
        { text: 'Public Holiday Date', align: 'left', value: 'Date' },
        { text: 'Fixed', align: 'left', value: 'Fixed' }
      ]
    }
  },
  beforeRouteEnter(routeTo, routeFrom, next) {
    getPublicHolidays(routeTo, next)
  },
  computed: {
    ...mapState(['publicHolidays'])
  },
  methods: {
    rowSelected(publicHolidayId) {
    //     this.$router.push({ name: 'PublicHoliday', params: { id: publicHolidayId }})
    }
  }
}
</script>
