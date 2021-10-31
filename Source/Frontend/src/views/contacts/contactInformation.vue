<template>
  <div>
    <div class="header-container">
      <div class="header-text">Selected Contact Info</div>
    </div>
    <div class="box-info" @submit.prevent="createContact">
      <ContactInformation ref="contactInformationForm" :contact="contact" @contact:change="updateContact"/>
      <v-layout class="button-layout" align-center justify-center>
        <v-btn
          x-large
          tile
          color="#3C565B"
          width="300px"
          dark
          type="submit"
          class="submit-button"
          @click="updateContact()">Update</v-btn>
        <v-btn x-large tile color="#999" width="300px" dark style="margin-left:15px;" @click="$router.go(-1)">Cancel</v-btn>
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
  props: {
    selectedContact: {
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
      contact: this.selectedContact
    }
  },
  computed: {
    ...mapState(['contacts', 'snackbar'])
  },
  methods: {
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
      if (this.$refs.contactInformationForm.$refs.form.validate()) {
        this.$store
          .dispatch('contacts/updateContact', this.selectedContact)
          .then(() => {
            this.$store.dispatch('snackbar/setSnack', this.successMessage(true, this.selectedContact.Name + ' was successfully updated.', 'success'))
            this.$router.push({
              name: 'Contacts'
            })
            this.contact = this.createFreshContactObject()
          })
          .catch(() => {
            NProgress.done()
          })
      }
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
.submit-button{
  margin-right: 15px;
}
</style>
