<template>
  <div>
    <div class="header-container">
      <div class="header-text">Calendar Event Type Update</div>
    </div>
    <div class="box-info" @submit.prevent="createCalendarEventType">

      <v-container v-if="enabled !== undefined && enabled !== 'True'">
        <v-row>
          <v-col>
            <v-alert
              color="blue lighten-3"
              type="info"
            >
              This Calendar Event Type has been disabled and cannot be re-enabled.
            </v-alert>
          </v-col>
        </v-row>
      </v-container>

      <calendar-event-type-information ref="calendarEventTypeForm" :calendar-event-type="calendarEventType"/>
      <v-divider/>
      <lookupHistory
        :history="history" />

      <v-container fluid>
        <v-row v-if="enabled === undefined || enabled === 'True'" justify="center">
          <v-col md="4" sm="12" class="text-center">
            <v-btn
              :disabled="!valid"
              x-large
              tile
              color="#3C565B"
              width="200px"
              dark
              type="submit"
              class="submit-button"
              @click="confirmUpdateCalendarEventType($event)">Update
            </v-btn>

          </v-col>
          <v-col md="4" sm="12" class="text-center">
            <v-btn x-large tile color="#999" width="200px" dark @click="$router.go(-1)">Cancel</v-btn>
          </v-col>
        </v-row>

        <v-row v-else justify="center">
          <v-col md="12" class="text-center">
            <v-btn x-large tile color="#999" width="200px" dark @click="$router.go(-1)">Close</v-btn>
          </v-col>
        </v-row>
      </v-container>

      <v-dialog v-model="confirmDialog" persistent max-width="480">
        <ConfirmDialog
          ref="confirmDialogForm"
          :heading="confirmHeading"
          :message="confirmMessage"
          :message2="confirmMessage2"
          :menu-id="confirmMenuId"
          @close-confirm-dialog="closeConfirmDialog"
          @continue-process="updateCalendarEventType(event)"
        />
      </v-dialog>

      <br>

      <br>
    </div>
  </div>
</template>
<script>
import NProgress from 'nprogress'
import { mapState } from 'vuex'

import CalendarEventTypeInformation from '@/components/CalendarEventType/calendarEventTypeInformation.vue'
import LookupHistory from '@/components/History/lookupHistory.vue'
import ConfirmDialog from '@/components/Dialogs/confirmDialog.vue'

export default {
  components: { CalendarEventTypeInformation, LookupHistory, ConfirmDialog },
  props: {
    selectedCalendarEventType: {
      type: Object,
      default: () => null
    },
    updateDialog: {
      type: Boolean,
      default: false
    }
  },
  data() {
    return {
      dialog: false,
      show: false,
      confirmDialog: false,
      confirmHeading: '',
      confirmMessage: '',
      confirmMessage2: '',
      confirmMenuId: 0,
      calendarEventType: this.selectedCalendarEventType,
      valid: true,
      history: [],
      enabled: 'True'
    }
  },
  computed: {
    ...mapState(['calendarEventTypes', 'snackbar'])
  },
  created() {
    this.getHistory()
    this.enabled = this.calendarEventType.Enabled
  },
  methods: {
    createFreshCalendarEventTypObject() {
      return {
        Name: '',
        Description: ''
      }
    },
    updateCalendarEventType(value) {
      if (this.$refs.calendarEventTypeForm.$refs.form.validate()) {
        if (!this.calendarEventTypeExists(this.calendarEventType)) {
          this.$store
            .dispatch('calendarEventTypes/updateCalendarEventType', this.calendarEventType)
            .then(() => {
              this.$store.dispatch('snackbar/setSnack', this.successMessage(true, this.calendarEventType.Name + ' was successfully updated.', 'success'))
              this.$router.push({
                name: 'Lookups'
              })
              this.calendarEventType = this.createFreshCalendarEventTypObject()
            })
            .catch(() => {
              NProgress.done()
            })
        } else {
          this.$store.dispatch('snackbar/setSnack', this.successMessage(true, 'Caledar Event Type' + this.calendarEventType.Name + ' already exists.', 'error'))
        }
      }
    },
    calendarEventTypeExists(calendarEventType) {
      if (this.$store.state.calendarEventTypes.calendarEventTypes.filter(x => x.Name.toUpperCase() === calendarEventType.Name.toUpperCase()).length > 1) {
        return true
      }
      return false
    },
    getHistory() {
      this.$store.dispatch('lookupHistory/getHistoryById', { id: this.selectedCalendarEventType._id, entity: 'Calendar Event Type' })
        .then(response => {
          this.history = response
        })
        .catch(err => {
          console.log('Get history error: ', err)
        })
    },
    confirmUpdateCalendarEventType(e) {
      if (this.calendarEventType.Enabled === 'False') {
        this.confirmHeading = 'Confirm Disable'
        this.confirmMessage = 'Are you sure you want to disable this Calendar Event Type?'
        this.confirmMessage2 = ''
        this.confirmMessage2 = 'NOTE: setting this Calendar Event Type to false is irreversible!'
        this.confirmDialog = true
        this.confirmMenuId = 1
        this.show = true
        this.confirmDialog = true
      } else {
        this.updateCalendarEventType()
      }
    },
    closeConfirmDialog() {
      this.confirmDialog = false
    },

    successMessage(show, message, color) {
      return {
        show: show,
        message: message,
        color: color
      }
    }
  }
}
</script>
