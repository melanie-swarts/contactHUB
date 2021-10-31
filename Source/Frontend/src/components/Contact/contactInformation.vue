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
              :rules="contactNumberRules"
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
              :rules="contactNumberRules"
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
              :rules="contactNumberRules"
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
              :rules="emailRules"
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
      contactNumberRules: Rules.contactNumberRules
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
    }
  }
}
</script>
