<template>
  <div>
    <div class="header-container">
      <div class="header-text">Calendar Event Type Update</div>
    </div>
    <div class="box-info" @submit.prevent="createCalendarEventType">
      <calendar-event-type-information ref="calendarEventTypeForm" :calendar-event-type="calendarEventType"/>
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
          @click="updateCalendarEventType()">Update</v-btn>
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
      calendarEventType: this.selectedCalendarEventType,
      valid: true
    }
  },
  computed: {
    ...mapState(['calendarEventTypes', 'snackbar'])
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
