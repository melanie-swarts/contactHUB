import CalendarService from '@/services/calendarService.js'

export const namespaced = true

export const state = {
  calendarEventTypes: [],
  selectedEventType: {}
}

export const mutations = {
  ADD_EVENT_TYPE(state, newEventType) {
    state.calendarEventTypes.push(newEventType)
  },
  SET_CALENDAR_EVENT_TYPES(state, eventTypes) {
    state.calendarEventTypes = eventTypes
  },
  SET_SELECTED_EVENT_TYPE(state, selectedEventType) {
    state.selectedEventType = selectedEventType
  }
}

export const actions = {
  fetchCalendarEventTypes({ commit, dispatch }) {
    return CalendarService.getCalendarEventType().then(response => {
      commit('SET_CALENDAR_EVENT_TYPES', response.data)
    })
  },
  fetchEventType({ commit, getters, state }, id) {
    if (id === state.selectedEventType.id) {
      return state.selectedEventType
    }
    var selectedEventType = getters.getEventTypeById(id)

    if (selectedEventType) {
      commit('SET_SELECTED_EVENT_TYPE', selectedEventType)
      return selectedEventType
    } else {
      return CalendarService.getCalendarEventTypeById(id).then(response => {
        commit('SET_SELECTED_EVENT_TYPE', response.data)
        return response.data
      })
    }
  },
  updateCalendarEventType({ commit, dispatch }, data) {
    return CalendarService.updateCalendarEventType(
      data.Id,
      data
    ).catch(error => {
      console.log('error')
      throw error
    })
  },
  createCalendarEventType({ commit, dispatch }, data) {
    CalendarService.createCalendarEventType(data)
      .then(response => {
        commit('ADD_EVENT_TYPE', data)
        commit('SET_SELECTED_EVENT_TYPE', data)
      })
      .catch(error => {
        console.log('error')
        throw error
      })
  }
}
export const getters = {
  getEventTypeById: state => id => {
    return state.calendarEventTypes.find(selectedEventType => selectedEventType.id === id)
  }
}

