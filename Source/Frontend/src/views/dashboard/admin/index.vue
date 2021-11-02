<template>
  <div class="dashboard-editor-container">
    <div class="dashboard-heading">Hi {{ user.systemUser.firstName }}, welcome to your contactHUB.</div>
    <v-container fluid>
      <v-row style="height: 320px;">
               <v-col md="6" sm="12">
<v-card
    max-width="800"
    class="mx-auto"
  >
    <v-app-bar
      dark
      color="#5E7D7E"
    >

      <v-toolbar-title>Recent Contacts</v-toolbar-title>

      <v-spacer></v-spacer>

               <v-tooltip right>
          <template v-slot:activator="{ on }">
            <v-btn
              icon
              v-on="on"
              @click="viewContacts()"
            >
              <v-icon>mdi-card-account-phone</v-icon>
            </v-btn>
          </template>
          <span>View all contacts</span>
        </v-tooltip>
    </v-app-bar>

    <v-container>
      <v-row dense>
        <v-col
          v-for="(contact, i) in contacts.contacts.slice(0, 3)"
          :key="i"
          cols="12"
        >
          <v-card
          >
            <div class="d-flex flex-no-wrap justify-space-between">
              <div>
            <v-card-title>
              {{contact.firstName}} {{contact.lastName}} 
            </v-card-title>
            <v-card-subtitle>{{contact.emailAddress}} 
              <br/>
              {{contact.primaryContactNumber}}
            </v-card-subtitle>

                <v-card-actions>
                  <v-btn outlined class="ml-2" @click="$router.push({name: 'ContactInfo', params: { id: contact.id },})">View</v-btn>
                </v-card-actions>
              </div>

              <v-avatar
                size="140"
                tile
              >
                <img src="@/assets/images/user.png">
              </v-avatar>
            </div>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-card>

        </v-col>
        <v-col md="6" sm="12">
<v-card
    max-width="800"
    class="mx-auto"
  >
    <v-app-bar
      dark
      color="#5E7D7E"
    >

      <v-toolbar-title>Upcoming Events</v-toolbar-title>

      <v-spacer></v-spacer>

         <v-tooltip left>
          <template v-slot:activator="{ on }">
            <v-btn
              icon
              v-on="on"
            >
              <v-icon>mdi-calendar-range</v-icon>
            </v-btn>
          </template>
          <span>View my calendar</span>
        </v-tooltip>
    </v-app-bar>

    <v-container>
      <v-row dense>
       List latest upcoming events here.
      </v-row>
    </v-container>
  </v-card>

        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>

import { mapState } from 'vuex'
import moment from 'moment'
import store from '@/store/store'

export default {
  name: 'DashboardAdmin',
  data() {
    return {
      showAddDialog: false,
      typeName: ''
    }
  },
    computed: {
    ...mapState(['user', 'contacts'])
  },
  created() {
    if (store.getters.userProfile === false) {
      this.$router.push({ name: 'CreateAccount' })
    }

    if (store.getters.systemUser.length === 0) {
      this.getSystemUser()
    }
    this.$store.dispatch('contacts/fetchContacts')
  },
  methods: {
    getSystemUser() {
      return this.$store.dispatch('fetchSystemUser')
    },
    formatDate(date) {
      return moment(date).format('d')
    },
    viewContacts(){
      this.$router.push({ name: 'Contacts' })
    }
  }
}
</script>

<style rel="stylesheet/scss" lang="scss" scoped>
.dashboard-editor-container {
  padding: 25px;
  background-color: rgb(240, 242, 245);
  .dashboard-heading{
    text-align: center;
    color: #999;
    font-size: 40px;
    margin-top: 10px;
    padding-bottom: 35px;
  }
}
</style>
