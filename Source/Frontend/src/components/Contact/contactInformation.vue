<template>
  <div>
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
              v-model="contact.firstName"
              :rules="nameRules"
              label="Fist Name"
              @input="updateContact"
            />
          </el-col>
          <el-col :span="1">
            <br>
          </el-col>
          <el-col :span="12">
            <v-text-field
              v-model="contact.lastName"
              :rules="nameRules"
              label="Last Name"
              @input="updateContact"
            />
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="11">
            <v-text-field
              v-model="contact.primaryContactNumber"
              :rules="contactNumberRules"
              :counter="10"
              :maxlength="10"
              type="number"
              oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
              label="Primary Contact Number"
              @input="updateContact"
            />
          </el-col>
          <el-col :span="1">
            <br>
          </el-col>
          <el-col :span="12">
            <v-text-field
              v-model="contact.mobileNumber"
              type="number"
              :counter="10"
              :maxlength="10"
              oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
              label="Mobile Number"
              @input="updateContact"
            />
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="11">
            <v-text-field
              v-model="contact.workNumber"
              type="number"
              :counter="10"
              :maxlength="10"
              oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
              label="Work Number"
              @input="updateContact"
            />
          </el-col>
          <el-col :span="1">
            <br>
          </el-col>
          <el-col :span="12">
            <v-text-field
              v-model="contact.homeNumber"
              type="number"
              :counter="10"
              :maxlength="10"
              oninput="javascript: if (this.value.length > this.maxLength) this.value = this.value.slice(0, this.maxLength);"
              label="Home Number"
              @input="updateContact"
            />
          </el-col>
        </el-row>

        <el-row>
          <el-col :span="11">
            <v-text-field
              v-model="contact.emailAddress"
              label="E-mail"
              @input="updateContact"
            />
          </el-col>
          <el-col :span="1">
            <br>
          </el-col>
          <el-col :span="12">
            <v-text-field
              v-model="contact.website"
              label="Website"
              @input="updateContact"
            />
          </el-col>
        </el-row>

        <v-text-field v-model="contact.address" label="Address" @input="updateContact"/>

      <v-dialog
        ref="dialog"
        v-model="modal"
        :return-value.sync="contact.Birthdy"
        persistent
        width="290px"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-text-field
          color="#5E7D7E"
            v-model="contact.Birthdy"
            label="Birthday"
            prepend-icon="mdi-calendar"
            readonly
            v-bind="attrs"
            v-on="on"
          ></v-text-field>
        </template>
        <v-date-picker
          v-model="contact.Birthdy"          
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
            @click="$refs.dialog.save(contact.Birthdy)"
            @input="updateContact"
          >
            OK
          </v-btn>
        </v-date-picker>
      </v-dialog>
            </el-row>

      </v-form>
    </div>
  </div>
</template>
<script>
import { mapState } from 'vuex'
import Rules from '@/store/modules/rules.js'

export default {
  inheritAttrs: false,
  props: {
    contact: {
      type: Object,
      default: null
    }
  },
  data() {
    return {
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
    ...mapState(['contacts'])
  },
  created() {
  },
  methods: {
    updateContact() {
      this.$emit('contact:change', this.contact)
    },
    setBirthday() {
      this.contact.Birthdy = this.date
    }
  }
}
</script>
