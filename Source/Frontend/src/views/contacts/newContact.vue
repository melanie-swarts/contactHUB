<template>
  <div>
    <div class="header-container">
      <div class="header-text">New Contact Info</div>
    </div>
    <div class="box-info" @submit.prevent="createContact">
      <ContactInformation ref="contactInformationForm" :contact="contact" @contact:change="updateContact"/>
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
          @click="createContact()">Create</v-btn>
        <v-btn
          x-large
          tile
          color="#999"
          width="300px"
          dark
          style="margin-left:15px;"
          @click="$router.go(-1)">Cancel</v-btn>
      </v-layout>
      <br>
    </div>
  </div>
</template>
<script>
import NProgress from 'nprogress'
import { mapState } from 'vuex'

import ContactInformation from '@/components/Contact/contactInformation.vue'
export default {
  components: { ContactInformation },
  data() {
    return {
      contact: this.createFreshContactObject(),
      valid: true
    }
  },
  computed: {
    ...mapState(['contacts', 'snackbar'])
  },
  methods: {
    createContact() {
      if (this.$refs.contactInformationForm.$refs.form.validate()) {
        if (!this.$store.state.contacts.contacts.find(c => c.emailAddress.toUpperCase() === this.contact.emailAddress.toUpperCase())) {
          this.$store.dispatch('contacts/createContact', this.contact)
            .then(() => {
              this.$store.dispatch('snackbar/setSnack', this.successMessage(true, this.contact.FirstName + ' was successfully created.', 'success'))
              this.$router.push({
                name: 'Contacts'
              })
              this.contact = this.createFreshContactObject()
            })
            .catch(() => {
              NProgress.done()
            })
        } else {
          this.$store.dispatch('snackbar/setSnack', this.successMessage(true, 'A contact with this email address  ' + this.contact.emailAddress + ' already exists.', 'error'))
        }
      }
    },
    createFreshContactObject() {
      return {
        FirstName: '',
        LastName: '',
        PrimaryContactNumber: '',
        MobileNumber: '',
        WorkNumber: '',
        HomeNumber: '',
        emailAddress: '',
        Website: '',
        Address: ''
      }
    },
    updateContact(value) {
      this.contact = value
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

<style>
.primary {
  background-color: #3C565B !important;
}
</style>
