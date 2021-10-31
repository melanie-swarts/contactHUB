<template>
  <div>
    <div class="header-container">
      <div class="header-text">My Contacts</div>
    </div>
    <div class="box-info">
      <v-layout class="button-layout" align-end justify-end>
        <router-link :to="{ name: 'NewContact' }">
          <v-btn
            class="ma-2"
            dark
            color="#3C565B"
            tile
          >Add New Contact</v-btn>
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
            :items="contacts.contacts"
            :search="search"
            item-key="id"
            class="elevation-1"
          >
            <template v-slot:body="{ items }">
              <tbody>
                <tr v-for="item in items" :key="item.id" @click="rowSelected(item.id)">
                  <td>{{ item.firstName }} {{ item.lastName }}</td>
                  <td>{{ item.primaryContactNumber  }}</td>
                  <td>{{ item.mobileNumber }}</td>
                  <td>{{ item.emailAddress  }}</td>
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

function getContacts(routeTo, next) {
  store
    .dispatch('contacts/fetchContacts')
    .then(() => {
      next()
    })
}
export default {
  name: 'Contact',
  data() {
    return {
      search: '',
      headers: [
        { text: 'Contact Name', align: 'left', value: 'firstName, lastName ' },
        { text: 'Primary Contact Number', align: 'left', value: 'primaryContactNumber' },
        { text: 'Mobile Number', align: 'left', value: 'mobileNumber' },
        { text: 'Contact Email', align: 'left', value: 'emailAddress' }
      ]
    }
  },
  beforeRouteEnter(routeTo, routeFrom, next) {
    getContacts(routeTo, next)
  },
  beforeRouteUpdate(routeTo, routeFrom, next) {
    getContacts(routeTo, next)
  },
  computed: {
    ...mapState(['contacts'])
  },
  methods: {
    rowSelected(id) {
        this.$router.push({ name: 'ContactInfo', params: { id: id }})
    }
  }
}
</script>
