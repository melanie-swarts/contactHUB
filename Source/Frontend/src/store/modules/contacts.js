import ContactService from '@/services/contactService.js'
import contactService from '../../services/contactService'

export const namespaced = true

export const state = {
  contacts: [],
  selectedContact: {}
}

export const mutations = {
  ADD_CONTACT(state, newContact) {
    state.contacts.push(newContact)
  },
  SET_CONTACTS(state, contacts) {
    state.contacts = contacts
  },
  SET_CONTACT(state, contact) {
    state.selectedContact = contact
  }
}

export const actions = {
  fetchContacts({ commit }) {
    return ContactService.getContact().then(response => {
      commit('SET_CONTACTS', response.data)
    })
  },
  fetchContact({ commit }, id) {
    return ContactService.getContactById(id).then(response => {
      commit('SET_CONTACT', response.data[0])
    })
  },
  createContact({ commit}, newContact) {
    ContactService.createContact(newContact)
      .then(savedContact => {
          commit('ADD_CONTACT', savedContact)
          commit('SET_CONTACT', savedContact)
      })
      .catch(error => {
        console.log('error')
        throw error
      })
  },
  updateContact({ commit, dispatch }, updatedContact) {
    return contactService.updateContact(
      updatedContact.Id,
      updatedContact
    ).catch(error => {
      console.log('error')
      throw error
    })
  }
}
