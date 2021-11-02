import CalendarService from '@/services/calendarService.js'

export const namespaced = true

export const state = {
  calendarEvents: [],
  calendarEventTypes: {}
}

export const mutations = {
  ADD_EVENT(state, newEvent) {
    state.calendarEvents.push(newEvent)
  },
  SET_CALENDAR_EVENTS(state, events) {
    state.calendarEvents = events
  },
  SET_SELECTED_EVENT(state, selectedEvent) {
    state.selectedEvent = selectedEvent
  }
}

export const actions = {
  fetchcalendarEvents({ commit, dispatch }) {
    return CalendarService.getCalendarEvents().then(response => {
      commit('SET_CALENDAR_EVENTS', response.data)
    })
  },
  fetchEvent({ commit, getters, state }, id) {
    if (id === state.selectedEvent.id) {
      return state.selectedEvent
    }
    var selectedEvent = getters.getEventById(id)

    if (selectedEvent) {
      commit('SET_SELECTED_EVENT', selectedEvent)
      return selectedEvent
    } else {
      return CalendarService.getCalendarEventById(id).then(response => {
        commit('SET_SELECTED_EVENT', response.data)
        return response.data
      })
    }
  },
  updateCalendarEvent({ commit, dispatch }, data) {
    return CalendarService.updateCalendarEvent(
      data.Id,
      data
    ).catch(error => {
      console.log('error')
      throw error
    })
  },
  createCalendarEvent({ commit, dispatch }, data) {
    CalendarService.createCalendarEvent(data)
      .then(response => {
        commit('ADD_EVENT', data)
        commit('SET_SELECTED_EVENT', data)
      })
      .catch(error => {
        console.log('error')
        throw error
      })
  }
}
export const getters = {
  getEventById: state => id => {
    return state.calendarEvents.find(selectedEvent => selectedEvent.id === id)
  }
}

