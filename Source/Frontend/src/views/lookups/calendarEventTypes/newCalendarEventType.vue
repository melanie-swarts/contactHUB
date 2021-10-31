<template>
  <div>
    <div class="header-container">
      <div class="header-text">New Calendar Event Type</div>
    </div>
    <div class="box-info" @submit.prevent="createCalendarEventType">
      <calendar-event-type-information ref="calendarEventTypeForm" :calendar-event-type="newCalendarEventTypeInfo" :new-calendar-event-type="true" @newCalendarEventTypeInfo:change="updateCalendarEventType"/>

      <v-layout class="button-layout" align-center justify-center>
        <v-btn
          :disabled="!valid"
          x-large
          tile
          color="#3C565B"
          width="300px"
          dark
          type="submit"
          class="submit-button"
          @click="createCalendarEventType()">Create</v-btn>
        <v-btn x-large tile color="#999" width="300px" dark style="margin-left:15px;" @click="$router.go(-1)">Cancel</v-btn>
      </v-layout>

      <br>
    </div>
  </div>
</template>
<script>
import NProgress from 'nprogress'
import { mapState } from 'vuex'

import CalendarEventTypeInformation from '@/components/CalendarEventType/calendarEventTypeInformation.vue'
export default {
  components: { CalendarEventTypeInformation },
  data() {
    return {
      newCalendarEventTypeInfo: this.createFreshCalendarEventTypObject(),
      valid: true
    }
  },
  computed: {
    ...mapState(['calendarEventTypes', 'snackbar'])
  },
  methods: {
    createCalendarEventType() {
      console.log(this.newCalendarEventTypeInfo)
      if (this.$refs.calendarEventTypeForm.$refs.form.validate()) {
        if (!this.calendarEventTypeExists(this.newCalendarEventTypeInfo)) {
          this.$store.dispatch('calendarEventTypes/createCalendarEventType', this.newCalendarEventTypeInfo)
            .then(() => {
              this.$store.dispatch('snackbar/setSnack', this.successMessage(true, this.newCalendarEventTypeInfo.EventTypeName + ' was successfully created.', 'success'))
              this.$router.push({
                name: 'Lookups'
              })
              this.newCalendarEventTypeInfo = this.createFreshCalendarEventTypObject()
            })
            .catch(() => {
              NProgress.done()
            })
        } else {
          this.$store.dispatch('snackbar/setSnack', this.successMessage(true, 'Calendar Event Type ' + this.newCalendarEventTypeInfo.EventTypeName + ' already exists.', 'error'))
        }
      }
    },
    createFreshCalendarEventTypObject() {
      return {
        EventTypeName: ''
      }
    },
    updateCalendarEventType(value) {
      this.newCalendarEventTypeInfo = value
    },
    calendarEventTypeExists(newCalendarEventTypeInfo) {
      if (this.$store.state.calendarEventTypes.calendarEventTypes.filter(x => x.Name.toUpperCase() === newCalendarEventTypeInfo.EventTypeName.toUpperCase()).length > 1) {
        return true
      }
      return false
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
