<template>
  <div>
    <div class="header-container">
      <div class="header-text">Selected Contact Info</div>
    </div>
    <div class="box-info">
            <div class="box-form">
        <v-form ref="form" v-model="valid" lazy-validation>
            <el-row>
                      <div class="text-center">
                        <v-avatar
                          class="profile"
                          size="150"
                        >
                          <!-- <img v-if="user.UserProfileImage" :src="(`data:image/jpeg;base64,${user.UserProfileImage}`)"> -->
                          <img src="@/assets/images/user.png">
                        </v-avatar>
                      </div>
                    <el-row>
          <el-col :span="11">
            <v-text-field
              v-model="contacts.selectedContact.firstName"
              :rules="nameRules"
              label="Fist Name"
            />
          </el-col>
          <el-col :span="1">
            <br>
          </el-col>
          <el-col :span="12">
            <v-text-field
              v-model="contacts.selectedContact.lastName"
              :rules="nameRules"
              label="Last Name"
            />
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="11">
            <v-text-field
              v-model="contacts.selectedContact.primaryContactNumber"
              :rules="contactNumberRules"
              :counter="10"
              :maxlength="10"
              type="number"
              oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
              label="Primary Contact Number"
            />
          </el-col>
          <el-col :span="1">
            <br>
          </el-col>
          <el-col :span="12">
            <v-text-field
              v-model="contacts.selectedContact.mobileNumber"
              type="number"
              :counter="10"
              :maxlength="10"
              oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
              label="Mobile Number"
            />
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="11">
            <v-text-field
              v-model="contacts.selectedContact.workNumber"
              type="number"
              :counter="10"
              :maxlength="10"
              oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
              label="Work Number"
            />
          </el-col>
          <el-col :span="1">
            <br>
          </el-col>
          <el-col :span="12">
            <v-text-field
              v-model="contacts.selectedContact.homeNumber"
              type="number"
              :counter="10"
              :maxlength="10"
              oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
              label="Home Number"
            />
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="11">
            <v-text-field
              v-model="contacts.selectedContact.emailAddress"
              label="E-mail"
            />
          </el-col>
          <el-col :span="1">
            <br>
          </el-col>
          <el-col :span="12">
            <v-text-field
              v-model="contacts.selectedContact.website"
              label="Website"
            />
          </el-col>
        </el-row>

        <v-text-field v-model="contacts.selectedContact.address" label="Address"/>

      <v-dialog
        ref="dialog"
        v-model="modal"
        :return-value.sync="contacts.selectedContact.Birthdy"
        persistent
        width="290px"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-text-field
          color="#5E7D7E"
            v-model="contacts.selectedContact.Birthdy"
            label="Birthday"
            prepend-icon="mdi-calendar"
            readonly
            v-bind="attrs"
            v-on="on"
          ></v-text-field>
        </template>
        <v-date-picker
          v-model="contacts.selectedContact.Birthdy"          
          year-icon="mdi-calendar-blank"
          prev-icon="mdi-skip-previous"
          next-icon="mdi-skip-next"
          scrollable
        >
          <v-spacer></v-spacer>
          <v-btn
            text
            color="#5E7D7E"
            @click="modal = false"
          >
            Cancel
          </v-btn>
          <v-btn
            text
            color="#5E7D7E"
            @click="$refs.dialog.save(contacts.selectedContact.Birthdy)"
          >
            OK
          </v-btn>
        </v-date-picker>
      </v-dialog>
            </el-row>

      </v-form>
      </div>
      <v-layout class="button-layout" align-center justify-center>
        <!-- <v-btn
          x-large
          tile
          color="#3C565B"
          width="300px"
          dark
          type="submit"
          class="submit-button"
          @click="updateContact(contacts.selectedContact)">Update</v-btn> -->
        <v-btn x-large tile color="#999" width="300px" dark style="margin-left:15px;" @click="$router.go(-1)">Back</v-btn>
      </v-layout>
      <br>
    </div>
  </div>
</template>
<script>
import NProgress from 'nprogress'
import { mapState } from 'vuex'
import Rules from '@/store/modules/rules.js'

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
      contact: this.selectedContact,
      valid: true,
      name: '',
      nameRules: Rules.nameRules,
      email: '',
      emailRules: Rules.emailRules,
      contactNumberRules: Rules.contactNumberRules,
      date: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10),
      menu: false,
      modal: false
    }
  },
  computed: {
    ...mapState(['systemUser', 'contacts', 'snackbar'])
  },
  methods: {
    createFreshContactObject() {
      return {
        SystemUserId: this.$store.getters.systemUser.id,
        FirstName: '',
        LastName: '',
        PrimaryContactNumber: '',
        MobileNumber: '',
        WorkNumber: '',
        HomeNumber: '',
        emailAddress: '',
        Website: '',
        Address: '',
        Birthdy: (new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10),
        CreatedAt: Date.now(),
        LastViewed: Datenow()
      }
    },
    updateContact(data) {
        this.$store
          .dispatch('contacts/updateContact', data)
          .then(() => {
            this.$store.dispatch('snackbar/setSnack', this.successMessage(true, data.contact.firstName + ' was successfully updated.', 'success'))
            this.$router.push({
              name: 'Contacts'
            })
            this.contact = this.createFreshContactObject()
          })
          .catch(() => {
            NProgress.done()
          })
    },
    setBirthday() {
      this.contact.Birthdy = this.date
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
